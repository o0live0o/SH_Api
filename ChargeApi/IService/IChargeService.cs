using ChargeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IChargeService
    {
        Task<Tuple<bool,string>> SaveChargeRecord(ChargeRecord chargeRecord);

        Task<Tuple<bool,string>> SaveChargeDetails(ChargeDetail[] chargeDetail);
    }
}
