using CattleRanch.IoC;
using CattleRanch.Kernel.Exceptions;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Web.API.Endpoints.Animals;
using CattleRanch.Web.API.Endpoints.Breeds;
using CattleRanch.Web.API.Endpoints.Configurations.SeedData;
using CattleRanch.Web.API.Endpoints.Farms;
using Microsoft.AspNetCore.Http.Features;

namespace CattleRanch.Web.API;

public static class WebApplicationHelper
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Hatogan", Version = "1.0.0" });
        });
        builder.Services.AddIoCServices(builder.Configuration);

        builder.Services.AddCors(options => options.AddDefaultPolicy(config => config.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("X-Pagination")));
        builder.Services.Configure<FormOptions>(opt =>
        {
            opt.MemoryBufferThreshold = int.MaxValue;
        });

        builder.Services.AddRazorPages();

        return builder.Build();
    }

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        //Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(o => o.EnabledConfiguration());
            //app.UseWebAssemblyDebugging();
        }

        app.UseHttpsRedirection();

        app.UseExceptionHandler(builder => builder.UseWebExceptionHandlerMiddleware(app.Environment, app.Services.GetService<IWebExceptionHandler>()!));

        app.UseCors();

        app.UseRouting();

        // Animals
        app.UseGetAllAnimalsEndpoint();
        app.UseGetAnimalByIdEndpoint();
        app.UseCreateAnimalEndpoint();
        app.UseUpdateAnimalEndpoint();

        // Breeds
        app.UseGetAllBreedsEndpoint();

        // Farms
        app.UseGetAllFarmsEndpoint();

        // Seed Data
        app.UseSeedDataEndpoint();

        return app;
    }
}
