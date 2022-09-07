using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Commands.Update;
public record UpdateAnimalCommand(
    Guid Id,
    string Code,
    string? EarTag,
    string? Name,
    string? Colour,
    string? Brand,
    string Sex,
    string Origin,
    Guid BreedId,
    Guid FarmId,
    DateTime DOB,
    decimal BirthWeight,
    DateTime ArrivalDate,
    decimal IncomeWeight,
    string? ImagePath,
    string? Remark
) : IRequest;
