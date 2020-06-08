using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class RolePermissionMap
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }
    }
}
