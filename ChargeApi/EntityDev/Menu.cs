using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.EntityDev
{
    public class Menu
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public int ParentId { get; set; }

        public bool IsShow { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
