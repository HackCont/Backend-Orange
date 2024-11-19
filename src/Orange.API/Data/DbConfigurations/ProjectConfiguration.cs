namespace Orange.API.Data.DbConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orange.API.Models.Entities;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
	public void Configure(EntityTypeBuilder<Project> builder)
	{
		builder.ToTable("Projects");
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			.HasDefaultValueSql("uuid_generate_v4()");

		builder.Property(p => p.Title)
			.HasMaxLength(155)
			.IsRequired();

		builder.Property(p => p.ProjectLink)
			.HasColumnName("Project_link")
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(p => p.Description)
			.HasMaxLength(255);

		builder.Property(p => p.ThumbnailUrl)
			.HasColumnName("Thumbnail_url")
			.HasMaxLength(255);

		builder.Property(p => p.CreatedAt)
			.HasColumnName("Created_at")
			.HasDefaultValueSql("NOW()");

		builder.Property(p => p.UserId)
			.HasColumnName("User_id");

		builder.HasMany(p => p.Tags)
			.WithMany(t => t.Projects)
			.UsingEntity<Dictionary<string, object>>(
				"Project_Tag",
				j => j.HasOne<Tag>()
					.WithMany()
					.HasForeignKey("TagId"),
				j => j.HasOne<Project>()
					.WithMany()
					.HasForeignKey("ProjectId"));
	}
}
