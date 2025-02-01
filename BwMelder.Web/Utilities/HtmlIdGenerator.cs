namespace BwMelder.Web.Utilities;

/// <summary>
/// Generates random and most probably unique IDs for use in HTML.
/// </summary>
public static class HtmlIdGenerator
{
    /// <summary>
    /// Gets an ID value.
    /// </summary>
    /// <returns>Random and most probably unique string.</returns>
    public static string GetId()
    {
        return Guid.NewGuid().ToString("N");
    }
}