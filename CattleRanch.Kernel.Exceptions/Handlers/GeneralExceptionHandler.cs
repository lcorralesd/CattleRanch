using CattleRanch.Kernel.Exceptions.CustomExceptions;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.ValueObjects;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class GeneralExceptionHandler : IExceptionHandler<GeneralException>
{
    public ValueTask<ProblemDetail> Handle(GeneralException exception) =>
        ValueTask.FromResult(new ProblemDetail
        {
            StatusCode = StatusCode.Status500InternalServerError,
            Type = StatusCode.Status500InternalServerErrorType,
            Title = exception.Message,
            Detail = exception.Detail
        });
}
