using CattleRanch.Application.Interfaces;
using CattleRanch.Kernel.Exceptions.Interfaces;

namespace CattleRanch.Application.UseCases.Animals.Commands.Update;
public class UpdateAnimalPersistenceValidator : IValidator<UpdateAnimalCommand>
{
    IApplicationDbContext _context;

    public UpdateAnimalPersistenceValidator(IApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; } = default!;

    public async ValueTask<bool> Validate(UpdateAnimalCommand instanceToValidate)
    {
        var error = ValidateAnimalData(instanceToValidate)!;

        if (error != null)
        {
            Failures = new List<KeyValuePair<string, string>>() { error.Value };
        }

        return await ValueTask.FromResult(Failures == null || !Failures.Any());
    }

    private KeyValuePair<string, string>? ValidateAnimalData(UpdateAnimalCommand animal)
    {
        KeyValuePair<string, string>? result = null;

        result = animal switch
        {
            UpdateAnimalCommand e when _context.Animals.Any(x => x.Code == e.Code) =>
               new("Code", $"Ya existe un animal con el Código: '{e.Code}'."),

            UpdateAnimalCommand e when !_context.Breeds.Any(x => x.Id == e.BreedId) =>
                new("BreedId", "Debe ingresar una Raza que exista en la fuente de datos."),

            UpdateAnimalCommand e when !_context.Farms.Any(x => x.Id == e.FarmId) =>
                new("FarmId", "Debe ingresar una hacienda que exista en la fuente de datos."),

            _ => null
        };

        return result;
    }
}
