using ChargeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi
{
    public abstract class AppHelper
    {
        public static AppSettingModel AppSetting { get; set; }
    }
}
