using CattleRanch.Application.Interfaces;
using CattleRanch.Core.Domain.Entities;
using CattleRanch.Core.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CattleRanch.Application.UseCases.Configurations.SeedData;

public class SeedDataHandler : IRequestHandler<SeedDataCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public SeedDataHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
    {
        var initialized = await _context.Breeds.AnyAsync(cancellationToken: cancellationToken);

        var breeds = new List<Breed>();
        var farms = new List<Farm>();
        var animals = new List<Animal>();

        if (!initialized)
        {
            breeds.Add( Breed.Create(new Guid("9eba4aca-45ce-44b3-93aa-49800256454b"), "-No Asignado-", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("05bda989-a000-4dd5-86f2-cf23ff463ebb"), "Angus", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("c237a864-cf77-472c-a338-c93088cedbe2"), "Angus Negro", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("8ecbded0-499f-4c34-bfd0-656521d12004"), "Angus Rojo", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("b5b5a787-1931-4211-a5e9-21aa87b8622e"), "Ayrshire", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("e1b86138-7062-4a6a-a356-20ab3c9a48a3"), "Bom", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("3ec70ff5-da80-4fb2-9d15-e0d3bb56787f"), "Brahman", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("7fbb71a6-9965-4017-889e-fe25b357bf5c"), "Brangus", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("42757dfc-698d-4c90-94ec-490931f5f891"), "Casanareño", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("bc62f6d7-0f76-4c2a-b921-ab9eb550287e"), "Cebu", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("342bc403-c092-4f75-ab34-8429b36d564b"), "Charolais", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("afaf1ca2-bd5d-4142-9b9f-d3879fca05a7"), "Chino Santandereano", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("bb70b0a3-f761-4512-a41a-6f05604ff993"), "Costeño con Cuernos", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("daa9ef44-3e65-4702-bbb5-a959a472a24c"), "Criollo", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("f874aaaf-897c-4d04-9941-e4775c783523"), "Guzerat", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("8057a836-ffa3-4bf8-b99c-691c3c170777"), "Gyr", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("96f096d0-8348-4d9f-8529-e2605e6fb9d4"), "Harton del valle", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("68e3dc96-7699-48d0-bc90-4167048b863e"), "Holstein", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("ee6d1c04-c1c7-4af5-abce-28a8aa6ddda8"), "Indubrasil", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("8f5e0fd4-c0ad-41d8-990d-0b4ae58039db"), "Jersey", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("b406a770-ae66-4d10-86d7-e0e5011b71bc"), "Limousin", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("1116c9da-2a1a-4232-b8b1-5ee69664d8b3"), "Lucerna", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("e002dfd5-c8e9-422b-82f9-3bd1a1a40f94"), "Nelore", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("82e3ff4e-e9e3-4e7b-b469-ba7ddec52ed4"), "Normando", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("ec21e32a-234c-435a-b35f-7fe003a844df"), "Pardo", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("165a95a4-5783-441a-af38-448969a931ed"), "Romosinuano", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("e67c2963-850b-4454-877c-419575b714d4"), "Sanmartinero", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("07bd0381-9f8a-4f55-9708-d7d0fafe26c2"), "Simmental", DateTimeOffset.Now));
            breeds.Add(Breed.Create(new Guid("c5ff9711-a78a-4beb-8647-52a426dda365"), "Velasquez", DateTimeOffset.Now));

            _context.Breeds.AddRange(breeds);

            farms.Add(Farm.Create(new Guid("e0b37a6d-0f91-4537-aae1-7f5b91f7303a"), "ARZ", "Hacienda Arizona y Villa Monica", "Santa Rosa, Paralelo 38", "3000000000", DateTimeOffset.Now));

            _context.Farms.AddRange(farms);

            animals.Add(Animal.Create(
                Guid.NewGuid(),
                "MD",
                "MD",
                "Madre Desconocida",
                "No",
                "No",
                Core.Domain.Enums.Sex.Hembra,
                Core.Domain.Enums.Origin.Criado,
                new Guid("9eba4aca-45ce-44b3-93aa-49800256454b"),
                new Guid("e0b37a6d-0f91-4537-aae1-7f5b91f7303a"),
                new DateTime(2010, 01, 01),
                35m,
                new DateTime(2010, 01, 01),
                35m,
                null,
                null,
                DateTimeOffset.Now
                ));

            animals.Add(Animal.Create(
                Guid.NewGuid(),
                "PD",
                "PD",
                "Padre Desconocido",
                "No",
                "No",
                Core.Domain.Enums.Sex.Macho,
                Core.Domain.Enums.Origin.Criado,
                new Guid("9eba4aca-45ce-44b3-93aa-49800256454b"),
                new Guid("e0b37a6d-0f91-4537-aae1-7f5b91f7303a"),
                new DateTime(2010, 01, 01),
                35m,
                new DateTime(2010, 01, 01),
                35m,
                null,
                null,
                DateTimeOffset.Now));

            animals[0].SetCategory(5000, Sex.Hembra);
            animals[0].UpdateStatus(Status.Inactivo, DateTime.Now, "Datos iniciales");
            animals[1].SetCategory(5000, Sex.Macho);
            animals[1].UpdateStatus(Status.Inactivo, DateTime.Now, "Datos iniciales");

            _context.Animals.AddRange(animals);

            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
