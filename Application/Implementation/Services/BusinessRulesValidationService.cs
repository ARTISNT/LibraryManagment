using Application.Abstractions.Services;

namespace Application.Implementation.Services;

public class BusinessRuleValidationServiceService : IBusinessRuleValidationService
{
    public void CheckObjectForNull<T>(T obj, string message)
    {
        if (obj == null)
            throw new ArgumentNullException(message);
    }

    public void CheckForValidId(int id, string message)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(message);
    }
}