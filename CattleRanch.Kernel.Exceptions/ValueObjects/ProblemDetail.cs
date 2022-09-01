using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.ValueObjects;
public record struct ProblemDetail(
    int StatusCode,
    string Type,
    string Title,
    string Detail,
    Dictionary<string, List<string>> InvalidParams);
