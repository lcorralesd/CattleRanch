using FluentValidation;

namespace CattleRanch.Kernel.Exceptions.Wrappers;
public abstract class ValidatorWrapper<T> : AbstractValidator<T>, Interfaces.IValidator<T>
{
    public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; } = default!;

    public async new ValueTask<bool> Validate(T instanceToValidate)
    {
        var result = await ValidateAsync(instanceToValidate);

        if (!result.IsValid)
        {
            Failures = result.Errors
                .Select(e => new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage))
                .ToList();
        }

        return result.IsValid;
    }
}
