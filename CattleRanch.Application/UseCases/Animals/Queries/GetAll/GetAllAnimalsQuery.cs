using CattleRanch.Core.Domain.Helpers;
using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Queries.GetAll;
public record GetAllAnimalsQuery(int? PageNumber, int? PageSize) : IRequest<PagedList<GetAllAnimalsDTO>>;
