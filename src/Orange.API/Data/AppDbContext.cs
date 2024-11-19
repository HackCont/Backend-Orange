namespace Orange.API.Data;

using Microsoft.EntityFrameworkCore;
using Orange.API.Models.Entities;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public required DbSet<User> Users { get; set; }
	public required DbSet<Project> Projects { get; set; }
	public required DbSet<Tag> Tags { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.HasPostgresExtension("uuid-ossp")
			.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}
