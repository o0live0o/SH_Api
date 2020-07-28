using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.EntityDev
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RodeCode { get; set; }

        public string RoleName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
