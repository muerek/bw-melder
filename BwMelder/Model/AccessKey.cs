namespace BwMelder.Model;

public class AccessKey
{
    public int Id { get; set; } = 0;

    public required string Key { get; init; }

    public DateTime NotBefore { get; } = DateTime.Now;

    public DateTime NotAfter { get; init; } = DateTime.Now.AddDays(30);

    public bool IsValid => NotBefore <= DateTime.Now && DateTime.Now <= NotAfter;
}
