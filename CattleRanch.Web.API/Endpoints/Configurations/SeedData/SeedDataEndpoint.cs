using CattleRanch.Application.UseCases.Configurations.SeedData;
using MediatR;

namespace CattleRanch.Web.API.Endpoints.Configurations.SeedData;

public static class SeedDataEndpoint
{
    public static WebApplication UseSeedDataEndpoint(this WebApplication app)
    {
        app.MapPost("api/configurations/seed-data", SeedData)
            .WithTags("Configurations");
        return app;
    }

    private static async Task<IResult> SeedData(IMediator mediator, SeedDataCommand command)
    {
        var response =  await mediator.Send(command);
        return Results.Ok(response);
    }
}
