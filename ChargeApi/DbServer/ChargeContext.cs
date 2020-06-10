using ChargeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.DbServer
{
    public class ChargeContext : DbContext
    {
        public ChargeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChargeRecord>()
                      .Property(p => p.Price)
                      .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<ChargeDetail>()
                      .Property(p => p.Price)
                      .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<ChargeDefine>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,4)");
        }

        public DbSet<ConstantDefine> constantDefines { get; set; }
        public DbSet<ConstantType> constantTypes { get; set; }
        public DbSet<ChargeRecord> chargeRecords { get; set; }
        public DbSet<ChargeDetail> chargeDetails { get; set; }
        public DbSet<ChargeDefine> chargeDefines { get; set; }
        public DbSet<Menus> menus { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRoleMap> userRoleMaps { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<RolePermissionMap> rolePermissionMaps { get; set; }
        public DbSet<RoleMenuMap> RoleMenuMaps { get; set; }

    }
}
