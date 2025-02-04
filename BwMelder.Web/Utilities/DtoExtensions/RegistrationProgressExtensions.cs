using BwMelder.Shared.Crews;

namespace BwMelder.Web.Utilities.DtoExtensions;

internal static class RegistrationProgressExtensions
{
    internal static bool IsComplete(this RegistrationProgressResponse registrationProgress) =>
        registrationProgress.CurrentAthleteCount == registrationProgress.TargetAthleteCount;

    internal static bool IsInProgress(this RegistrationProgressResponse registrationProgress) =>
        registrationProgress.CurrentAthleteCount > 0
        && registrationProgress.CurrentAthleteCount < registrationProgress.TargetAthleteCount;

    internal static bool IsNew(this RegistrationProgressResponse registrationProgress) =>
        registrationProgress.CurrentAthleteCount == 0;

    internal static RegistrationStatus GetStatus(this RegistrationProgressResponse registrationProgress) =>
        registrationProgress switch
        {
            _ when registrationProgress.IsNew() => RegistrationStatus.New,
            _ when registrationProgress.IsInProgress() => RegistrationStatus.InProgress,
            _ when registrationProgress.IsComplete() => RegistrationStatus.Completed,
            _ => RegistrationStatus.Unknown
        };
}