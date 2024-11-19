namespace Orange.API.Extensions;

using Microsoft.EntityFrameworkCore;
using Orange.API.Data;

public static class MigrationExtensions
{
	public static IHost UseMigrateDatabase(this IHost host)
	{
		using (var scope = host.Services.CreateScope())
		{
			var services = scope.ServiceProvider;

			try
			{
				var context = services.GetRequiredService<AppDbContext>();

				context.Database.Migrate();
			}
			catch (Exception ex)
			{

				throw new InvalidOperationException("An error occurred while migrating the database.", ex);
			}
		}
		return host;
	}
}
