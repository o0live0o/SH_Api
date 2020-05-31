using ChargeApi.DbServer;
using ChargeApi.Entities;
using ChargeApi.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Service
{
    public class ConstantService : IConstantService
    {
        private readonly ChargeContext chargeContext;

        public ConstantService(ChargeContext chargeContext)
        {
            this.chargeContext = chargeContext;
        }

        public Task<ConstantDefine> GetConstantDefine(int id)
        {
            return Task.Run(() => {
                return chargeContext.constantDefines.Where(p=>p.ID == id).FirstOrDefault();
            });
        }

        public Task<IEnumerable<ConstantDefine>> GetConstantDefines()
        {
            return Task.Run(()=> {
               return  chargeContext.constantDefines.AsEnumerable();
            });
        }

        public Task<ConstantDefine> AddConstantDefine(ConstantDefine constantDefine)
        {
            return Task.Run(() => {
                chargeContext.constantDefines.Add(constantDefine);
                chargeContext.SaveChanges();
                return constantDefine;
            });
        }



        public Task<ConstantType> GetConstantType(int id)
        {
            return Task.Run(() => {
                return chargeContext.constantTypes.Where(p => p.ID == id).FirstOrDefault();
            });
        }

        public Task<IEnumerable<ConstantType>> GetConstantTypes()
        {
            return Task.Run(() => {
                return chargeContext.constantTypes.AsEnumerable();
            });
        }

        public Task<ConstantType> AddConstantType(ConstantType constantType)
        {
            return Task.Run(() => {
                chargeContext.constantTypes.Add(constantType);
                chargeContext.SaveChanges();
                return constantType;
            });
        }
    }
}
