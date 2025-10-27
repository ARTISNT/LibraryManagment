namespace Application.Abstractions.Services;

public interface IBusinessRuleValidationService
{
    public void CheckObjectForNull<T>(T obj, string message);
    public void CheckForValidId(int id, string message);
}