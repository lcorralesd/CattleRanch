using CattleRanch.Application.UseCases.Breeds.Queries.GetAll;
using MediatR;
using System.Text.Json;

namespace CattleRanch.Web.API.Endpoints.Breeds;

public static class GetAllBreedsEndpoint
{
    public static WebApplication UseGetAllBreedsEndpoint(this WebApplication app)
    {
        app.MapGet("api/breeds", GetAllBreeds)
            .WithTags("Breeds");
        return app;
    }

    private static async Task<IResult> GetAllBreeds(GetAllBreedsRequestParameters parameters, IMediator mediator, HttpContext context)
    {
        var response = await mediator.Send(new GetAllBreedsQuery(parameters.PageNumber, parameters.PageSize));
        context.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.MetaData));
        return Results.Ok(response);
    }
        
}
