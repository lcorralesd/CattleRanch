using Swashbuckle.AspNetCore.SwaggerUI;

namespace CattleRanch.Web.API;

public static class SwaggerExtension
{
    public static SwaggerUIOptions EnabledConfiguration(this SwaggerUIOptions options)
    {
        options.DisplayOperationId();
        options.DisplayRequestDuration();
        options.EnableFilter();
        return options;
    }
}
