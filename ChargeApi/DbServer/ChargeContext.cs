using ChargeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.DbServer
{
    public class ChargeContext:DbContext
    {
        public ChargeContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<ConstantDefine> constantDefines { get; set; }
        public DbSet<ConstantType> constantTypes { get; set; }
    }
}
