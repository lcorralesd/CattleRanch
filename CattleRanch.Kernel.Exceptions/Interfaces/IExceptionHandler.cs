using CattleRanch.Kernel.Exceptions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.Interfaces;
public interface IExceptionHandler<ExceptionType> where ExceptionType : Exception
{
    ValueTask<ProblemDetail> Handle(ExceptionType exceptionType);
}
