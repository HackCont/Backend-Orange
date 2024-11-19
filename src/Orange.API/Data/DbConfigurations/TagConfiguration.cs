namespace Orange.API.Data.DbConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orange.API.Models.Entities;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
	public void Configure(EntityTypeBuilder<Tag> builder)
	{
		builder.ToTable("Tags");
		builder.HasKey(t => t.Id);
		builder.Property(t => t.Id)
			.HasDefaultValueSql("uuid_generate_v4()");

		builder.Property(t => t.Name)
			.HasMaxLength(50)
			.IsRequired();
	}
}
