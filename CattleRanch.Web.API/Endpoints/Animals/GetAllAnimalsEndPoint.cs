using CattleRanch.Application.UseCases.Animals.Queries.GetAll;
using MediatR;
using System.Text.Json;

namespace CattleRanch.Web.API.Endpoints.Animals;

public static class GetAllAnimalsEndPoint
{
    public static WebApplication UseGetAllAnimalsEndpoint(this WebApplication app)
    {
        app.MapGet("api/animals", GetAllAnimals)
            .WithTags("Animals");

        return app;
    }

    private async static Task<IResult> GetAllAnimals([AsParameters] GetAllAnimalsRequestParameters parameters, IMediator mediator, HttpContext context)
    {
        var response = await mediator.Send(new GetAllAnimalsQuery(parameters.PageNumber, parameters.PageSize));
        context.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.MetaData));
        return Results.Ok(response);
    }
        
}
