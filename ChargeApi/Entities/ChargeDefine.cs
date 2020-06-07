using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    /// <summary>
    /// 收费项目配置
    /// </summary>
    public class ChargeDefine
    {
        public int ID { get; set; }

        public string ItemName { get; set; }

        public string ItemCode { get; set; }

        public int Times { get; set; }

        public decimal Price { get; set; }
    }
}
