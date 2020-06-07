using ChargeApi.DbServer;
using ChargeApi.Entities;
using ChargeApi.IService;
using Microsoft.EntityFrameworkCore;
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

        public Task<Tuple<bool, ConstantDefine, string>> SaveConstantDefine(ConstantDefine constantDefine)
        {
            return Task.Run(() => {
                var msg = "";
                var succ = true;
                var entity = chargeContext.constantDefines.AsNoTracking().Where(p => p.ID.Equals(constantDefine.ID)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.constantDefines.Update(constantDefine);
                }
                else
                {
                    var entity1 = chargeContext.constantDefines.AsNoTracking().Where(p => (p.ConstantName.Equals(constantDefine.ConstantName)
                     || p.ConsatntCode.Equals(constantDefine.ConsatntCode)) && p.TypeCode.Equals(constantDefine.TypeCode)).FirstOrDefault();
                    if(entity1 == null)
                        chargeContext.constantDefines.Add(constantDefine);
                    else
                    {
                        succ = false;
                        msg = "常量名称/代号已存在";
                    }
                }
                chargeContext.SaveChanges();
                return new Tuple<bool, ConstantDefine, string>(succ, constantDefine, msg);
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

        public Task<Tuple<bool,ConstantType,string>> SaveConstantType(ConstantType constantType)
        {
            return Task.Run(() => {
                var msg = "";
                var succ = true;
                var entity = chargeContext.constantTypes.AsNoTracking().Where(p => p.ID.Equals(constantType.ID)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.constantTypes.Update(constantType);
                }
                else
                {
                    var entity1 = chargeContext.constantTypes.AsNoTracking().Where(p => p.TypeCode.Equals(constantType.TypeCode)
                    || p.TypeName.Equals(constantType.TypeName)).FirstOrDefault();
                    if (entity1 == null)
                        chargeContext.constantTypes.Add(constantType);
                    else
                    {
                        succ = false;
                        msg = "类型名称/代号已存在";
                    }
                }
                chargeContext.SaveChanges();
                return new Tuple<bool, ConstantType, string>(succ, constantType, msg);
            });
        }

        public Task<Tuple<bool, string>> DeleteConstantType(int id)
        {
            return Task.Run(()=> {
                var succ = true;
                var msg = "";

                var entity = chargeContext.constantTypes.Where(p => p.ID.Equals(id)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.constantTypes.Remove(entity);
                    chargeContext.SaveChanges();
                }
                else
                {
                    succ = false;
                    msg = "数据不存在";
                }
                return new Tuple<bool, string>(succ, msg);
            });
        }

        public Task<Tuple<bool, string>> DeleteConstantDefine(int id)
        {
            return Task.Run(() => {
                var succ = true;
                var msg = "";

                var entity = chargeContext.constantDefines.Where(p => p.ID.Equals(id)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.constantDefines.Remove(entity);
                    chargeContext.SaveChanges();
                }
                else
                {
                    succ = false;
                    msg = "数据不存在";
                }
                return new Tuple<bool, string>(succ, msg);
            });
        }

        public Task<IEnumerable<ChargeDefine>> GetChargeDefines()
        {
            return Task.Run(() => {
                return chargeContext.chargeDefines.AsEnumerable();
            });
        }

        public Task<ChargeDefine> GetChargeDefine(int id)
        {
            return Task.Run(() => {
                return chargeContext.chargeDefines.Where(p => p.ID.Equals(id)).FirstOrDefault();
            });
        }

        public Task<Tuple<bool, string>> DeleteChargeDefine(int id)
        {
            return Task.Run(() => {
                var succ = true;
                var msg = "";

                var entity = chargeContext.chargeDefines.Where(p => p.ID.Equals(id)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.chargeDefines.Remove(entity);
                    chargeContext.SaveChanges();
                }
                else
                {
                    succ = false;
                    msg = "数据不存在";
                }
                return new Tuple<bool, string>(succ, msg);
            });
        }

        public Task<Tuple<bool, ChargeDefine, string>> SaveChargeDefine(ChargeDefine chargeDefine)
        {
            return Task.Run(() => {
                var msg = "";
                var succ = true;
                var entity = chargeContext.chargeDefines.AsNoTracking().Where(p => p.ID.Equals(chargeDefine.ID)).FirstOrDefault();
                if (entity != null)
                {
                    chargeContext.chargeDefines.Update(chargeDefine);
                }
                else
                {
                    var entity1 = chargeContext.chargeDefines.AsNoTracking().Where(p => p.ItemName.Equals(chargeDefine.ItemName)
                    && p.Times.Equals(chargeDefine.Times)).FirstOrDefault();
                    if (entity1 == null)
                        chargeContext.chargeDefines.Add(chargeDefine);
                    else
                    {
                        succ = false;
                        msg = "类型名称/代号已存在";
                    }
                }
                chargeContext.SaveChanges();
                return new Tuple<bool, ChargeDefine, string>(succ, chargeDefine, msg);
            });
        }
    }
}
