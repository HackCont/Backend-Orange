namespace Orange.API.Models.DTOs.User.Register;

public class RegisterDTO
{
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string AvatarUrl { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
}
