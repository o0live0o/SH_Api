using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        public int MenuId { get; set; }

        public string ActionName { get; set; }

        public string ActionCode { get; set; }

    }
}
