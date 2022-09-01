using CattleRanch.Application.UseCases.Animals.Queries.GetById;
using MediatR;

namespace CattleRanch.Web.API.Endpoints.Animals;

public static class GetAnimalByIdEndpoint
{
    public static WebApplication UseGetAnimalByIdEndpoint(this WebApplication app)
    {
        app.MapGet("api/animals/{id}", GetAnimalById)
            .WithTags("Animals");

        return app;
    }

    private async static Task<IResult> GetAnimalById(Guid id, IMediator mediator) =>
        Results.Ok(await mediator.Send(new GetAnimalByIdQuery(id)));
}
