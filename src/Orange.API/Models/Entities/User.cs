namespace Orange.API.Models.Entities;

using System.Text.Json.Serialization;

public class User
{
	public Guid Id { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string AvatarUrl { get; set; }

	[JsonIgnore]
	public ICollection<Project> Projects { get; set; } = new List<Project>();
}
