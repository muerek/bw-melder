namespace BwMelder.Core.Model;

/// <summary>
/// Common base class for participants, representing basic information required for registration.
/// </summary>
class Participant
{
    public Guid Id { get; private set; } = Guid.Empty;

    public required Name Name { get; set; }

    public required DateTime DateOfBirth { get; set; }

    public required Address Address { get; set; }

    public required Diet Diet { get; set; }

    public required ShirtSize ShirtSize { get; set; }

    public string? Comments { get; set; }

    public bool HasPublicTransportTicket { get; set; } = false;
}
