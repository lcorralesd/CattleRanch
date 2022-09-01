using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.ValueObjects;
using System.Reflection;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class WebExceptionHandler : IWebExceptionHandler
{
    private static readonly Dictionary<Type, Type> _exceptionHandlers = new();

    public WebExceptionHandler(Assembly assembly)
    {
        Type[] types = assembly.GetTypes();
        foreach (var T in types)
        {
            var handlers = T.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));

            foreach (var handler in handlers)
            {
                var exceptionType = handler.GetGenericArguments()[0];
                _exceptionHandlers.TryAdd(exceptionType, T);
            }
        }
    }

    public async ValueTask<ProblemDetail> Handle(Exception ex, bool includeDetails)
    {
        ProblemDetail problemDetail;

        if (_exceptionHandlers.TryGetValue(ex.GetType(), out Type? handlerType))
        {
            var handler = Activator.CreateInstance(handlerType);
            problemDetail = await (ValueTask<ProblemDetail>)
                handlerType.GetMethod(nameof(IExceptionHandler<Exception>.Handle))?.Invoke(handler, new object[] { ex })!;

            if (!includeDetails)
            {
                problemDetail.Detail = "Consulte al administrador";
            }
        }
        else
        {
            string title;
            string detail;
            if (includeDetails)
            {
                title = $"Ocurrio un error {ex.Message}";
                detail = ex.ToString();
            }
            else
            {
                title = "Ha ocurrido un errror al procesar la respuesta";
                detail = "Consulte con el administrador";
            }

            problemDetail = new ProblemDetail
            {
                StatusCode = StatusCode.Status500InternalServerError,
                Type = StatusCode.Status500InternalServerErrorType,
                Title = title,
                Detail = detail
            };
        }

        return problemDetail;
    }
}
