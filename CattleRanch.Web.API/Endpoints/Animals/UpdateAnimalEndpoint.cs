using CattleRanch.Application.UseCases.Animals.Commands.Update;
using MediatR;

namespace CattleRanch.Web.API.Endpoints.Animals;

public static class UpdateAnimalEndpoint
{
    public static WebApplication UseUpdateAnimalEndpoint(this WebApplication app)
    {
        app.MapPut("api/animals/{id}", UpdateAnimal)
            .WithTags("Animals");

        return app;
    }

    private static async Task<IResult> UpdateAnimal(Guid id, IMediator mediator, UpdateAnimalCommand command) => id != command.Id
            ? Results.BadRequest("El Id del registro que quiere actualizar no coincide con el enviado")
            : Results.Ok(await mediator.Send(command));
}
