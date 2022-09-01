using CattleRanch.Web.API;

WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .ConfigureHttpRequestPipeline()
    .Run();