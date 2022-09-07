using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CattleRanch.Application.UseCases.Animals.Queries.GetAll;
public class GetAllAnimalsHandler : IRequestHandler<GetAllAnimalsQuery, PagedList<GetAllAnimalsDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetAllAnimalsHandler(IApplicationDbContext context) => _context = context;

    public async Task<PagedList<GetAllAnimalsDTO>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
    {
        var animals = await _context.Animals
            .AsNoTracking()
            .Where(a => a.Status == Core.Domain.Enums.Status.Activo)
            .Select(a => new GetAllAnimalsDTO(
            a.Id,
            a.Code,
            a.EarTag,
            a.Name,
            a.Colour,
            a.Brand,
            a.Sex.ToString(),
            a.Origin.ToString(),
            a.Status.ToString(),
            a.Breed.Name,
            a.Farm.Code,
            a.Category,
            a.Discard,
            a.DOB,
            a.BirthWeight,
            a.ArrivalDate,
            a.IncomeWeight,
            a.ImagePath,
            a.Remark,
            a.FullAge
        )).ToListAsync() as IReadOnlyList<GetAllAnimalsDTO>;

        var resultPaginated = PagedList<GetAllAnimalsDTO>.ToPagedList(animals, request.PageNumber, request.PageSize);

        return resultPaginated;
    }
}
