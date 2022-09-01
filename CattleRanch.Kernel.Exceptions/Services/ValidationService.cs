using CattleRanch.Kernel.Exceptions.Interfaces;

namespace CattleRanch.Kernel.Exceptions.Services;
public class ValidationService<ValidatorType>
{
    readonly IEnumerable<IValidator<ValidatorType>> _validators;

    public ValidationService(IEnumerable<IValidator<ValidatorType>> validators) => _validators = validators;

    public async ValueTask ExcecuteValidationsGuard(ValidatorType instanceToValidate, bool stopOnFirstValidationError = true)
    {
        List<KeyValuePair<string, string>> failures = new();
        bool continueValidation = true;

        var enumerators = _validators.GetEnumerator();
        while (enumerators.MoveNext() && continueValidation)
        {
            bool isValid = await enumerators.Current.Validate(instanceToValidate);
            if (!isValid)
            {
                failures.AddRange(enumerators.Current.Failures);
                continueValidation = !stopOnFirstValidationError;
            }
        }

        if (failures.Any())
        {
            throw new CustomExceptions.ValidationException("Error de validación.", failures);
        }
    }
}

