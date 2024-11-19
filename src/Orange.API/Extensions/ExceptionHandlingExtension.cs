namespace Orange.API.Extensions;

using Orange.API.Middlewares;

public static class ExceptionHandlingExtension
{
	public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionHandlingMiddleware>();
}
