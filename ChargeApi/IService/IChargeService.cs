using ChargeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IChargeService
    {
        Task<bool> SaveChargeRecord(ChargeRecord chargeRecord);

        Task<bool> SaveChargeDetails(ChargeDetail[] chargeDetail);
    }
}
