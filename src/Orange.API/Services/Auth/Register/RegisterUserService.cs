namespace Orange.API.Services.Auth.Register;

using System.Net.Http.Headers;
using FluentValidation;
using Microsoft.Extensions.Options;
using Orange.API.Models.DTOs.User.Register;
using Orange.API.Models.Settings;

public class RegisterUserService : IRegisterUserService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly IValidator<RegisterDTO> _validator;
	private readonly KeycloakSettings _keycloakSettings;

	public RegisterUserService(IHttpClientFactory httpClientFactory, IOptions<KeycloakSettings> keycloakSettings, IValidator<RegisterDTO> validator)
	{
		_httpClientFactory = httpClientFactory;
		_validator = validator;
		_keycloakSettings = keycloakSettings.Value;
	}

	public async Task<object> RegisterAsync(RegisterDTO registerDTO)
	{
		var validateResult = await _validator.ValidateAsync(registerDTO);
		if (!validateResult.IsValid)
		{
			var errors = validateResult.Errors
				.GroupBy(e => e.PropertyName)
				.ToDictionary(
					g => g.Key,
					g => g.Select(e => e.ErrorMessage).ToArray()
				);

			return errors;
		}

		var adminAccesToken = await GetAdminTokenAsync();

		var client = _httpClientFactory.CreateClient();

		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminAccesToken);

		var responseUserRegister = await client.PostAsJsonAsync(
			_keycloakSettings.Uri.Register,
			new
			{
				email = registerDTO.Email,
				firstName = registerDTO.FirstName,
				lastName = registerDTO.LastName,
				enabled = true,
				emailVerified = true,
				attributes = new
				{
					avatar_url = registerDTO.AvatarUrl,
				},
				credentials = new[]
				{
					new { type = "password", value = registerDTO.Password, temporary = false }
				}
			}
		);

		if (!responseUserRegister.IsSuccessStatusCode)
		{
			return "erro ao criar usuario";
		}

		var locationHeader = responseUserRegister.Headers.Location?.ToString();
		var userId = locationHeader?.Split('/').Last();

		return "usuario registrado com sucesso";
	}


	private async Task<string?> GetAdminTokenAsync()
	{
		var client = _httpClientFactory.CreateClient();

		var content = new FormUrlEncodedContent(
		[
			new KeyValuePair<string, string>("grant_type", "client_credentials"),
			new KeyValuePair<string, string>("client_id", _keycloakSettings.ClientId),
			new KeyValuePair<string, string>("client_secret", _keycloakSettings.ClientSecret)
		]);

		var tokenResponse = await client.PostAsync(_keycloakSettings.Uri.Login, content);

		if (!tokenResponse.IsSuccessStatusCode)
		{
			return null;
		}

		var tokenResult = await tokenResponse.Content.ReadFromJsonAsync<AdminTokenResponseDTO>();
		return tokenResult?.AccessToken;
	}
}
