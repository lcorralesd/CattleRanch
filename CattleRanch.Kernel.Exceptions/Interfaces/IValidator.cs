using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Kernel.Exceptions.Interfaces;
public interface IValidator<InstanceType>
{
    ValueTask<bool> Validate(InstanceType instanceToValidate);
    IEnumerable<KeyValuePair<string, string>> Failures { get; }
}
