namespace CattleRanch.Application.UseCases.Animals.Queries.GetAll;
public record GetAllAnimalsDTO(
    Guid Id,
    string Code,
    string? EarTag,
    string? Name,
    string? Colour,
    string? Brand,
    string Sex,
    string Origin,
    string Status,
    string Breed,
    string Farm,
    string? Category,
    bool Discard,
    DateTime DOB,
    decimal BirthWeight,
    DateTime ArrivalDate,
    decimal IncomeWeight,
    string? ImagePath,
    string? Remark,
    string? FullAge
);
