using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Code = 1;
            Message = "请求成功";
            DataCount = 0;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public int DataCount { get; set; }
    }
}
