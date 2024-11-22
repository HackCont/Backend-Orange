namespace Orange.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Orange.API.Models.DTOs.User.Register;
using Orange.API.Services.Auth.Register;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AuthController : ControllerBase
{
	private readonly IRegisterUserService _userService;

	public AuthController(IRegisterUserService userService)
	{
		_userService = userService;
	}

	[HttpPost]
	public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
	{
		var result = await _userService.RegisterAsync(registerDTO);

		return Ok(result);
	}
}
