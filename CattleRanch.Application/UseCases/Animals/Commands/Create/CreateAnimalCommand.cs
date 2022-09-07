using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Commands.Create;
public record CreateAnimalCommand(
    string Code,
    string? EarTag,
    string? Name,
    string? Colour,
    string? Brand,
    string Sex,
    string Origin,
    Guid BreedId,
    Guid FarmId,
    string? Category,
    DateTime DOB,
    decimal BirthWeight,
    DateTime ArrivalDate,
    decimal IncomeWeight,
    string? ImagePath,
    string? Remark
) : IRequest;
