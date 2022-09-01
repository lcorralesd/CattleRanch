using MediatR;

namespace CattleRanch.Application.UseCases.Farms.Queries.GetAll;
public record GetAllFarmsQuery : IRequest<IReadOnlyList<GetAllFarmsDTO>>;
