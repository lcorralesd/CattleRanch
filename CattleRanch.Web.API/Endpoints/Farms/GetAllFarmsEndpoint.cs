using CattleRanch.Application.UseCases.Farms.Queries.GetAll;
using MediatR;

namespace CattleRanch.Web.API.Endpoints.Farms;

public static class GetAllFarmsEndpoint
{
    public static WebApplication UseGetAllFarmsEndpoint(this WebApplication app)
    {
        app.MapGet("api/farms", GetAllFarms)
            .WithTags("Farms");
        return app;
    }

    private static async Task<IResult> GetAllFarms(IMediator mediator) =>
        Results.Ok(await mediator.Send(new GetAllFarmsQuery()));
}
