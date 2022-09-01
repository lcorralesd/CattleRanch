using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Entities;
using CattleRanch.Core.Domain.Enums;
using CattleRanch.Core.Domain.Helpers;
using CattleRanch.Kernel.Exceptions.Services;
using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Commands.Create;
public class CreateAnimalHandler : IRequestHandler<CreateAnimalCommand, Unit>
{
    private readonly IApplicationDbContext _context;
    private readonly ValidationService<CreateAnimalCommand> _validationService;

    public CreateAnimalHandler(IApplicationDbContext context, ValidationService<CreateAnimalCommand> validationService)
    {
        _context = context;
        _validationService = validationService;
    }

    public async Task<Unit> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        await _validationService.ExcecuteValidationsGuard(request);

        Animal newAnimal = Animal.Create(
            Guid.NewGuid(),
            request.Code,
            request.EarTag,
            request.Name,
            request.Colour,
            request.Brand,
            Utils.ParseEnum<Sex>(request.Sex),
            Utils.ParseEnum<Origin>(request.Origin),
            request.BreedId,
            request.FarmId,
            request.DOB,
            request.BirthWeight,
            request.ArrivalDate,
            request.IncomeWeight,
            request.ImagePath,
            request.Remark,
            null); 

        _context.Animals.Add(newAnimal);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
