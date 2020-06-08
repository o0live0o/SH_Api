using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class Menus
    {
        public int Id { get; set; }

        [DefaultValue(0)]
        public int ParentId { get; set; }

        public string ParentName { get; set; }

        public string MenuName { get; set; }

        public string MenuPath { get; set; }

        public string OrderNo { get; set; }
    }
}
