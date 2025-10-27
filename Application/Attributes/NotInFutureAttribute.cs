using System.ComponentModel.DataAnnotations;

namespace Application.Attributes;

public class NotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
            return date <= DateTime.Today;
        return true;
    }
}