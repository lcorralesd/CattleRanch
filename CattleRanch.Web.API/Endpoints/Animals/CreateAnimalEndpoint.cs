using CattleRanch.Application.UseCases.Animals.Commands.Create;
using MediatR;

namespace CattleRanch.Web.API.Endpoints.Animals;

public static class CreateAnimalEndpoint
{
    public static WebApplication UseCreateAnimalEndpoint(this WebApplication app)
    {
        app.MapPost("api/animals", CreateAnimal)
            .WithTags("Animals");
        return app;
    }

    private async static Task<IResult> CreateAnimal(IMediator mediator, CreateAnimalCommand command) =>
        Results.Ok(await mediator.Send(command));


}
