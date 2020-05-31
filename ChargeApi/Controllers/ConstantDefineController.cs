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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConstantDefineController : ControllerBase
    {

        private IConstantService m_constantService = null;

        public ConstantDefineController(IConstantService constantService)
        {
            m_constantService = constantService;
        }

        [HttpGet]
        public  Task<ResponseModel> GetConstantDefines()
        {
            return Task.Run(async ()=>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetConstantDefines();
                response.Data = data;
                response.DataCount = data.Count();
                return response;
            });
        }

        [HttpGet("{id}")]
        public Task<ResponseModel> GetConstantDefine(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetConstantDefine(id);
                response.Data = data;
                response.DataCount = 1;
                return response;
            });
        }

        [HttpPut]
        public Task<ResponseModel> ModifyConstantDefine(ConstantDefine constantType)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();

                return response;
            });
        }

        [HttpPost]
        public Task<ResponseModel> AddConstantDefine(ConstantDefine constantDefine)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.AddConstantDefine(constantDefine);
                if(type.ID > 0)
                {
                    response.Code = 1;
                    response.Data = type;
                    response.DataCount = 1;
                }
                return response;
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel> DeleteConstantDefine(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                return response;
            });
        }

        [HttpGet]
        public Task<ResponseModel> GetConstantTypes()
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetConstantTypes();
                response.Data = data;
                response.DataCount = data.Count();
                return response;
            });
        }

        [HttpGet("{id}")]
        public Task<ResponseModel> GetConstantType(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetConstantType(id);
                response.Data = data;
                response.DataCount = 1;
                return response;
            });
        }

        [HttpPut]
        public Task<ResponseModel> ModifyConstantType(ConstantType constantType)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                return response;
            });
        }

        [HttpPost]
        public Task<ResponseModel> AddConstantType(ConstantType constantType)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.AddConstantType(constantType);
                if (type.ID > 0)
                {
                    response.Code = 1;
                    response.Data = type;
                    response.DataCount = 1;
                }
                return response;
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel> DeleteConstantType(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                return response;
            });
        }
    }
}