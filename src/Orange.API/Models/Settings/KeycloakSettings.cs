namespace Orange.API.Models.Settings;

public class KeycloakSettings
{
	public required string Authority { get; set; }
	public required string Audience { get; set; }
	public required bool RequireHttpsMetadata { get; set; }
}
