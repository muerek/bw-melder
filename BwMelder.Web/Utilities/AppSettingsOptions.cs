namespace BwMelder.Web.Utilities;

/// <summary>
/// Provides strongly-typed access to general application settings.
/// </summary>
public class AppSettingsOptions
{
    private readonly string baseUri = string.Empty;

    /// <summary>
    /// Name of the config section these settings are read from.
    /// </summary>
    public const string SectionName = "AppSettings";

    /// <summary>
    /// Base URI this application is hosted at.
    /// Can be used to build absolute links to content in the app, suitable for external sharing.
    /// Guaranteed to end with a slash <c>/</c>.
    /// </summary>
    public string BaseUri
    {
        get => baseUri;
        init
        {
            if (!value.EndsWith('/')) { baseUri = value + "/"; }
            else { baseUri = value; }
        }
    }
}