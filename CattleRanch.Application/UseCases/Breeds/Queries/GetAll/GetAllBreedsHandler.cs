using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CattleRanch.Application.UseCases.Breeds.Queries.GetAll;
public class GetAllBreedsHandler : IRequestHandler<GetAllBreedsQuery, PagedList<GetAllBreedsDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetAllBreedsHandler(IApplicationDbContext context) => _context = context;

    public async Task<PagedList<GetAllBreedsDTO>> Handle(GetAllBreedsQuery request, CancellationToken cancellationToken)
    {
        var breeds = await _context.Breeds
            .AsNoTracking()
            .Select(b => new GetAllBreedsDTO(
            b.Id,
            b.Name
        )).ToListAsync(cancellationToken: cancellationToken) as IReadOnlyList<GetAllBreedsDTO>;

        var resultPaginated = PagedList<GetAllBreedsDTO>.ToPagedList(breeds, request.PageNumber, request.PageSize);

        return resultPaginated;
    }
}
