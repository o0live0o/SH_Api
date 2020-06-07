using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Models
{
    public class CallModel
    {

            public CallModel()
            {
                State = "";
                text = "";
                QueueId = "";
                WaitCount = "";
                ClientId = "";
                CallerAddr = "";

            }

            public string State { get; set; }
            public string text { get; set; }
            public string QueueId { get; set; }
            public string WaitCount { get; set; }
            public string ClientId { get; set; }
            public string CallerAddr { get; set; }
        }
    
}
