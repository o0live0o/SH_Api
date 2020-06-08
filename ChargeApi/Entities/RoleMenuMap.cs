using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class RoleMenuMap
    {
        public int ID { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }
    }
}
