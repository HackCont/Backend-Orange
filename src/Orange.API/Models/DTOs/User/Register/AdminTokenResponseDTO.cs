namespace Orange.API.Models.DTOs.User.Register;

using System.Text.Json.Serialization;

public class AdminTokenResponseDTO
{
	[JsonPropertyName("access_token")]
	public string? AccessToken { get; set; }
}
