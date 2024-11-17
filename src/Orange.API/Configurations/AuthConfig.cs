namespace Orange.API.Configurations;

using Microsoft.IdentityModel.Tokens;

public static class AuthConfig
{
	public static IServiceCollection AddAuthenticationSetup(this IServiceCollection services)
	{
		_ = services.AddAuthentication("Bearer").AddJwtBearer(options =>
		{
			options.Authority = "";
			options.Audience = "";
			options.RequireHttpsMetadata = false;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
			};
		});

		return services;
	}
}
