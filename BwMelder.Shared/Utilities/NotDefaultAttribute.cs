using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Utilities;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
sealed class NotDefaultAttribute : ValidationAttribute
{
    public const string DefaultErrorMessage = "The {0} field must not be its default value.";

    public NotDefaultAttribute() : base(DefaultErrorMessage) { }

    public override bool IsValid(object? value)
    {
        // NotDefault does not mean it is required.
        if (value is null) { return true; }

        var type = value.GetType();

        // For value types, compare to the default value.
        if (type.IsValueType)
        {
            return !value.Equals(Activator.CreateInstance(type));
        }

        // True for reference types.
        return true;
    }
}
