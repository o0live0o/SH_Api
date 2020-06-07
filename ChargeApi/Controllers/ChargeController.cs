using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChargeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChargeController : ControllerBase
    {
        private readonly IChargeService chargeService;

        public ChargeController(IChargeService chargeService)
        {
            this.chargeService = chargeService;
        }

        [HttpPost]
        public Task<ResponseModel> SaveChargeRecord(ChargeRecord chargeRecord)
        {
            return Task.Run(async () =>
            {
                ResponseModel responseModel = new ResponseModel();
                var result = await chargeService.SaveChargeRecord(chargeRecord);
                responseModel.Code = result.Item1 ? 1 : 0;
                responseModel.Message = result.Item2;
                return responseModel;
            });
        }

        [HttpPost]
        public Task<ResponseModel> SaveChargeDetails(ChargeDetail[] chargeDetails)
        {
            return Task.Run(async () =>
            {
                ResponseModel responseModel = new ResponseModel();
                List<ChargeDetail> temps = new List<ChargeDetail>();
                foreach (var item in chargeDetails)
                {
                    if (!temps.Exists(p => p.PlateNo.Equals(item.PlateNo) && p.TestNo.Equals(item.TestNo)
                    && p.TestItem.Equals(item.TestItem)))
                    {
                        temps.Add(item);
                    }
                }

                if (temps.Count != chargeDetails.Length)
                {
                    responseModel.Code = 0;
                    responseModel.Message = "上传数据中项目重复！";
                }
                else
                {
                    var result = await chargeService.SaveChargeDetails(chargeDetails);
                    responseModel.Code = result.Item1 ? 1 : 0;
                    responseModel.Message = result.Item2;
                }
                return responseModel;
            });
        }


        [HttpGet]
        public Task<ResponseModel> CallService(string WinAddr, string PlateNo)
        {
            return Task.Run(() =>
            {
                ResponseModel responseModel = new ResponseModel();
                CallModel callEntity = null;
                try
                {
                    var obj = new
                    {
                        cmd = "Call",
                        CallerAddr = WinAddr,
                        CardNo = PlateNo
                    };
                    string requestStr = JsonConvert.SerializeObject(obj);
                    Hashtable hashtable = new Hashtable();
                    hashtable.Add("data", requestStr);
                    var content = $"data={requestStr}";
                    var retString = "";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppHelper.AppSetting.CallServiceUrl + (content == "" ? "" : "?") + content);
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.ContentType = "application/json"; ;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (Stream myResponseStream = response.GetResponseStream())
                    {
                        using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8))
                        {
                            retString = myStreamReader.ReadToEnd();
                        }
                    }

                    callEntity = JsonConvert.DeserializeObject<CallModel>(HttpUtility.HtmlDecode(retString));
                    responseModel.Code = 1;
                    responseModel.Message = "请求成功";
                }
                catch (Exception ex)
                {
                    responseModel.Code = 0;
                    responseModel.Message = ex.Message;
                }
                return responseModel;
            });
        }

    }
}
