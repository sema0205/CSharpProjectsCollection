using Itmo.ObjectOrientedProgramming.Lab2.Order;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validator;

public interface IValidator<in T>
{
    CompatibilityConflict Validate(T computerDetail);
}