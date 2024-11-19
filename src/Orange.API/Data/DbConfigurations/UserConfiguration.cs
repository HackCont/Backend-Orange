namespace Orange.API.Data.DbConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orange.API.Models.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");
		builder.HasKey(u => u.Id);

		builder.Property(u => u.FirstName)
			.HasColumnName("First_name")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(u => u.LastName)
			.HasColumnName("Last_name")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(u => u.AvatarUrl)
			.HasColumnName("Avatar_url")
			.HasMaxLength(250)
			.IsRequired();

		builder.HasMany(u => u.Projects)
			.WithOne(p => p.User)
			.HasForeignKey(p => p.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
