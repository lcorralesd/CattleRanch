using CattleRanch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CattleRanch.Application.UseCases.Farms.Queries.GetAll;
public class GetAllFarmsHandler : IRequestHandler<GetAllFarmsQuery, IReadOnlyList<GetAllFarmsDTO>>
{
    private readonly IApplicationDbContext _context;

    public GetAllFarmsHandler(IApplicationDbContext context) => _context = context;

    public async Task<IReadOnlyList<GetAllFarmsDTO>> Handle(GetAllFarmsQuery request, CancellationToken cancellationToken)
    {
        var farms = await _context.Farms.Select(f => new GetAllFarmsDTO(
            f.Id,
            f.Code,
            f.Name,
            f.Address,
            f.Phone
        )).ToListAsync(cancellationToken: cancellationToken) as IReadOnlyList<GetAllFarmsDTO>;

        return farms;
    }
}
