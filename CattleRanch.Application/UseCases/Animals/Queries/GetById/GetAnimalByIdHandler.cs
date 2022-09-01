using CattleRanch.Application.Interfaces;
using CattleRanch.Kernel.Exceptions.CustomExceptions;
using MediatR;

namespace CattleRanch.Application.UseCases.Animals.Queries.GetById;
public class GetAnimalByIdHandler : IRequestHandler<GetAnimalByIdQuery, GetAnimalByIdDTO>
{
    private readonly IApplicationDbContext _context;

    public GetAnimalByIdHandler(IApplicationDbContext context) => _context = context;

    public async Task<GetAnimalByIdDTO> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
    {
        var animal = await _context.Animals.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (animal == null)
        {
            throw new NotFoundException($"No se encontro el registro con  Id: {request.Id}");
        }
        var animalDTO = new GetAnimalByIdDTO(
            animal.Id,
            animal.Code,
            animal.EarTag,
            animal.Name,
            animal.Colour,
            animal.Brand,
            animal.Sex.ToString(),
            animal.Origin.ToString(),
            animal.Status.ToString(),
            animal.Breed.Name,
            animal.Farm.Code,
            animal.Category,
            animal.Discard,
            animal.DOB,
            animal.BirthWeight,
            animal.ArrivalDate,
            animal.IncomeWeight,
            animal.ImagePath,
            animal.Remark,
            animal.FullAge
        );

        return animalDTO;
    }
}
