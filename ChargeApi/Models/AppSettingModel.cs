using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Models
{
    public class AppSettingModel
    {
        public string WebServiceUrl { get; set; }

        public string CallServiceUrl { get; set; }

        public string Namespace { get; set; }

        public string SerialNo { get; set; }

        public string StationNo { get; set; }
    }
}
