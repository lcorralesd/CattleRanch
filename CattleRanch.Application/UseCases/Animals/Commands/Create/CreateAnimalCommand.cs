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
    string Health,
    string HornStatus,
    Guid BreedId,
    Guid FarmId,
    string? Category,
    bool Discard,
    DateTime DOB,
    decimal BirthWeight,
    DateTime ArrivalDate,
    decimal IncomeWeight,
    string? ImagePath,
    string? Remark
) : IRequest;
