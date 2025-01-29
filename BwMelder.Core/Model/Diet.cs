namespace BwMelder.Core.Model;

/// <summary>
/// Dietary choices and restrictions.
/// </summary>
record Diet
{
    /// <summary>
    /// Choice of diet from basic options offered by the event.
    /// </summary>
    public DietaryOptions Choice { get; set; } = DietaryOptions.Omnivore;

    /// <summary>
    /// Details on specific dietary restrictions like allergies.
    /// </summary>
    public string? Restrictions { get; set; } = null;
}
