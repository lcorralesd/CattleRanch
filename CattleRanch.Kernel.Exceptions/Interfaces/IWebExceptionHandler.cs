using CattleRanch.Kernel.Exceptions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.Interfaces;
public interface IWebExceptionHandler
{
    ValueTask<ProblemDetail> Handle(Exception ex, bool includeDetails);
}
