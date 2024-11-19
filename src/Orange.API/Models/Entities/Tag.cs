namespace Orange.API.Models.Entities;

using System.Text.Json.Serialization;

public class Tag
{
	public Guid Id { get; set; }
	public required string Name { get; set; }

	[JsonIgnore]
	public ICollection<Project> Projects { get; set; } = new List<Project>();
}
