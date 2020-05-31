using ChargeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IQueryService
    {
        Task<Tuple<bool, X18J52, string>> Query18J52(X18J52 x18J52 );
    }
}
