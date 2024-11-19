namespace Orange.API.Models.Entities;

using System.Text.Json.Serialization;

public class Project
{
	public Guid Id { get; set; }
	public required string Title { get; set; }
	public required string ProjectLink { get; set; }
	public string? Description { get; set; }
	public string? ThumbnailUrl { get; set; }
	public DateTime CreatedAt { get; set; }

	public Guid UserId { get; set; }
	[JsonIgnore]
	public User? User { get; set; }

	[JsonIgnore]
	public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
