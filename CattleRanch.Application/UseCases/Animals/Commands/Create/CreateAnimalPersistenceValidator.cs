using CattleRanch.Application.Interfaces;
using CattleRanch.Kernel.Exceptions.Interfaces;

namespace CattleRanch.Application.UseCases.Animals.Commands.Create;
public class CreateAnimalPersistenceValidator : IValidator<CreateAnimalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAnimalPersistenceValidator(IApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; } = default!;

    public async ValueTask<bool> Validate(CreateAnimalCommand instanceToValidate)
    {
        var error = ValidateAnimalData(instanceToValidate)!;

        if (error != null)
        {
            Failures = new List<KeyValuePair<string, string>>() { error.Value };
        }

        return await ValueTask.FromResult(Failures == null || !Failures.Any());
    }

    private KeyValuePair<string, string>? ValidateAnimalData(CreateAnimalCommand animal)
    {
        KeyValuePair<string, string>? result = null;

        result = animal switch
        {
            CreateAnimalCommand e when _context.Animals.Any(x => x.Code == e.Code) =>
               new("Code", $"Ya existe un animal con el Código: '{e.Code}'."),

            CreateAnimalCommand e when !_context.Breeds.Any(x => x.Id == e.BreedId) =>
                new("BreedId", "Debe ingresar una Raza que exista en la fuente de datos."),

            CreateAnimalCommand e when !_context.Farms.Any(x => x.Id == e.FarmId) =>
                new("FarmId", "Debe ingresar una hacienda que exista en la fuente de datos."),

            _ => null
        };

        return result;
    }
}
