using CattleRanch.Kernel.Exceptions.CustomExceptions;
using CattleRanch.Kernel.Exceptions.Interfaces;
using CattleRanch.Kernel.Exceptions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.Handlers;
public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public ValueTask<ProblemDetail> Handle(ValidationException exception) =>
        ValueTask.FromResult(
            new ProblemDetail
            {
                StatusCode = StatusCode.Status400BadRequest,
                Type = StatusCode.Status400BadRequestType,
                Title = "Error en los datos de entrada",
                Detail = "Se encontraron uno o más errores de validación de datos",
                InvalidParams = exception.Failures
            });

}
