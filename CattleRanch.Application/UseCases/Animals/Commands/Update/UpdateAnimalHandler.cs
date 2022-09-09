using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Enums;
using CattleRanch.Core.Domain.Helpers;
using CattleRanch.Kernel.Exceptions.CustomExceptions;
using CattleRanch.Kernel.Exceptions.Services;
using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Commands.Update;
public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ValidationService<UpdateAnimalCommand> _validationService;

    public UpdateAnimalHandler(IApplicationDbContext context, ValidationService<UpdateAnimalCommand> validationService)
    {
        _context = context;
        _validationService = validationService;
    }

    public async Task<Unit> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        await _validationService.ExcecuteValidationsGuard(request);

        var animalToUpdate = await _context.Animals.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (animalToUpdate == null)
        {
            throw new NotFoundException($"No se encontro el registro con Id: {request.Id}");
        }
        animalToUpdate.UpdateInfo(
            request.Code,
            request.EarTag,
            request.Name,
            request.Colour,
            request.Brand,
            Utils.ParseEnum<Sex>(request.Sex),
            Utils.ParseEnum<Origin>(request.Origin),
            request.DOB,
            request.BirthWeight,
            request.ArrivalDate,
            request.IncomeWeight,
            null,
            null,
            request.ImagePath,
            request.Remark);

        animalToUpdate.SetCategory(animalToUpdate.AgeInDays, animalToUpdate.Sex);
        _context.Animals.Update(animalToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
