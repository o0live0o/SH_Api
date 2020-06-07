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
    public class ChargeService : IChargeService
    {
        private readonly ChargeContext chargeContext;

        public ChargeService(ChargeContext chargeContext)
        {
            this.chargeContext = chargeContext;
        }

        public Task<Tuple<bool, string>> SaveChargeDetails(ChargeDetail[] chargeDetails)
        {
            return Task.Run(() => {
                var succ = true;
                var msg = "保存成功";
                try
                {
                    foreach (var detail in chargeDetails)
                    {
                        var record = this.chargeContext.chargeDetails.AsNoTracking().Where(p => p.PlateNo == detail.PlateNo && p.TestNo == detail.TestNo && detail.TestItem == p.TestItem).FirstOrDefault();
                        if (record == null)
                        {
                            this.chargeContext.chargeDetails.Add(detail);
                        }
                        else
                        {
                            detail.ID = record.ID;
                            this.chargeContext.chargeDetails.Update(detail);
                        }
                    }
                    this.chargeContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    succ = false;
                    msg = ex.Message;
                }
                return new Tuple<bool, string>(succ, msg);
            });
        }

        public Task<Tuple<bool, string>> SaveChargeRecord(ChargeRecord chargeRecord)
        {
            return Task.Run(()=> {
                var succ = true;
                var msg = "保存成功"; 
                try
                {
                    var record = this.chargeContext.chargeRecords.AsNoTracking().Where(p => p.PlateNo == chargeRecord.PlateNo && p.TestNo == chargeRecord.TestNo).FirstOrDefault();
                    if (record == null)
                    {
                        this.chargeContext.chargeRecords.Add(chargeRecord);
                    }
                    else
                    {
                        chargeRecord.ID = record.ID;
                        this.chargeContext.chargeRecords.Update(chargeRecord);
                    }
                    this.chargeContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    succ = false;
                    msg = ex.Message;
                }
                return new Tuple<bool, string>(succ, msg);
            });
        }
    }
}
