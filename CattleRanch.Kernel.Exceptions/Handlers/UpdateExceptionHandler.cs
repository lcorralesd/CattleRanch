using CattleRanch.Kernel.Exceptions.CustomExceptions;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.ValueObjects;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class UpdateExceptionHandler : IExceptionHandler<UpdateException>
{
    public ValueTask<ProblemDetail> Handle(UpdateException exception) =>
        ValueTask.FromResult(new ProblemDetail
        {
            StatusCode = StatusCode.Status400BadRequest,
            Type = StatusCode.Status400BadRequestType,
            Title = "Occurio un error en la actualización",
            Detail = exception.Message,
            InvalidParams = new Dictionary<string, List<string>>
            {
                {
                    "Entities", exception.Entries.ToList()
                }
            }
        });
}
