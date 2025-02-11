using System.Linq.Expressions;
using Model = BwMelder.Core.Model;
using Common = BwMelder.Shared.Common;

namespace BwMelder.Core;

/// <summary>
/// Helper class to map enum values from the internal core model to the public shared model.
/// </summary>
internal static class EnumMapper
{
    public static Common.Position ToCommon(Model.Position position) =>
        position switch
        {
            Model.Position.Cox => Common.Position.Cox,
            Model.Position.Rower1 => Common.Position.Rower1,
            Model.Position.Rower2 => Common.Position.Rower2,
            Model.Position.Rower3 => Common.Position.Rower3,
            Model.Position.Rower4 => Common.Position.Rower4,
            _ => throw new ArgumentOutOfRangeException(nameof(position))
        };

}