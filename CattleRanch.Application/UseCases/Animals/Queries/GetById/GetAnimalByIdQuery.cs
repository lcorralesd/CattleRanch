using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Queries.GetById;
public record GetAnimalByIdQuery(Guid Id) : IRequest<GetAnimalByIdDTO>;
