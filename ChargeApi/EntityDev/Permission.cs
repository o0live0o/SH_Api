using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.EntityDev
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public string ActionName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
