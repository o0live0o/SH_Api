using ChargeApi.Entities;
using ChargeApi.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Service
{
    public class ChargeService : IChargeService
    {
        public Task<bool> SaveChargeDetails(ChargeDetail[] chargeDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChargeRecord(ChargeRecord chargeRecord)
        {
            throw new NotImplementedException();
        }
    }
}
