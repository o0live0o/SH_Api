using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChargeApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class QueryCarController : ControllerBase
    {
        private readonly IQueryService queryService;

        public QueryCarController(IQueryService queryService)
        {
            this.queryService = queryService;
        }
        [HttpPost]
        public Task<ResponseModel> Query18J52(X18J52 x18J52)
        {
            return Task.Run(async () =>
            {
                ResponseModel responseModel = new ResponseModel();
                var result = await  queryService.Query18J52(x18J52);
                responseModel.Code = result.Item1 ? 1 : 0;
                responseModel.Data = result.Item2;
                responseModel.Message = result.Item3;
                return responseModel;
            });
        }

    }
}