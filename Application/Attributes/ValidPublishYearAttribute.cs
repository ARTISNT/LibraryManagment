using System.ComponentModel.DataAnnotations;

namespace Application.Attributes;

public class ValidPublishYearAttribute : ValidationAttribute
{
    private readonly int _minYear;

    public ValidPublishYearAttribute(int minYear = 1450)
    {
        _minYear = minYear;
    }

    public override bool IsValid(object value)
    {
        if (value is int year)
        {
            int currentYear = DateTime.Now.Year;
            return year >= _minYear && year <= currentYear;
        }

        return true; 
    }
}
