using BwMelder.Web.Utilities;

namespace BwMelder.Web;

internal static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Reads the application's configuration into suitable options classes.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    internal static WebApplicationBuilder GetBwMelderConfig(this WebApplicationBuilder builder)
    {
        // General app settings.
        builder.Services.Configure<AppSettingsOptions>(
            builder.Configuration.GetSection(AppSettingsOptions.SectionName));
        
        return builder;
    }
}