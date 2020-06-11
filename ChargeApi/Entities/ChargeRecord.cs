using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Entities
{
    public class ChargeRecord
    {
        public int ID { get; set; }

        public string PlateNo { get; set; }

        public string TestNo { get; set; }

        public string Guider { get; set; }

        public string VehicleType { get; set; }

        public string TestItem { get; set; }

        public decimal Price { get; set; }

        public string DateOfTest { get; set; }

        public string DateOfCharge { get; set; }
        public string ChagreUser { get; set; }
    }
}
