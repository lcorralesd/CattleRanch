using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleRanch.Core.Domain.Helpers;
public class RequestParameters
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }

    public RequestParameters()
    {

    }

    //public RequestParameters(int pageNumber, int pageSize)
    //{
    //    PageNumber = pageNumber < 1 ? 1 : pageNumber;
    //    PageSize = pageSize < 10 ? 10 : pageSize;
    //}
}
