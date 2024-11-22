namespace Orange.API.Services.Auth.Register;

using Orange.API.Models.DTOs.User.Register;

public interface IRegisterUserService
{
	public Task<object> RegisterAsync(RegisterDTO registerDTO);
}
