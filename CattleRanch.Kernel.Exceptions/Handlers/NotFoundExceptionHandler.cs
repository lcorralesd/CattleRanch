using CattleRanch.Kernel.Exceptions;
using CattleRanch.Kernel.Exceptions.CustomExceptions;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class NotFoundExceptionHandler : IExceptionHandler<NotFoundException>
{
    public ValueTask<ProblemDetail> Handle(NotFoundException exception) =>
        ValueTask.FromResult(new ProblemDetail
        {
            StatusCode = StatusCode.Status404NotFound,
            Type = StatusCode.Status404NotFoundType,
            Title = "No se encontro el registro solicitado",
            Detail = exception.Message,
        });
}
