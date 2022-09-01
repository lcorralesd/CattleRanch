using CattleRanch.Core.Domain.Helpers;
using MediatR;

namespace CattleRanch.Application.UseCases.Breeds.Queries.GetAll;
public record GetAllBreedsQuery(int? PageNumber, int? PageSize) : IRequest<PagedList<GetAllBreedsDTO>>;
