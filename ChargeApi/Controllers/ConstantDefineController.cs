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
        public Task<ResponseModel> GetConstantDefines()
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetConstantDefines();
                response.Data = data;
                response.DataCount = data.Count();
                return response;
            });
        }

        [HttpGet]
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


        [HttpPost]
        public Task<ResponseModel> SaveConstantDefine(ConstantDefine constantDefine)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.SaveConstantDefine(constantDefine);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item3;
                response.Data = type.Item2;
                response.DataCount = 1;
                return response;
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel> DeleteConstantDefine(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.DeleteConstantDefine(id);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item2;
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

        [HttpGet]
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

        [HttpPost]
        public Task<ResponseModel> SaveConstantType(ConstantType constantType)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.SaveConstantType(constantType);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item3;
                response.Data = type.Item2;
                response.DataCount = 1;
                return response;
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel> DeleteConstantType(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.DeleteConstantType(id);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item2;
                return response;
            });
        }

        #region 收费定义
        [HttpGet]
        public Task<ResponseModel> GetChargeDefines()
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetChargeDefines();
                response.Data = data;
                response.DataCount = data.Count();
                return response;
            });
        }

        [HttpGet]
        public Task<ResponseModel> GetChargeDefine(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var data = await m_constantService.GetChargeDefine(id);
                response.Data = data;
                response.DataCount = 1;
                return response;
            });
        }


        [HttpPost]
        public Task<ResponseModel> SaveChargeDefine(ChargeDefine constantDefine)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.SaveChargeDefine(constantDefine);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item3;
                response.Data = type.Item2;
                response.DataCount = 1;
                return response;
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel> DeleteChargeDefine(int id)
        {
            return Task.Run(async () =>
            {
                ResponseModel response = new ResponseModel();
                var type = await m_constantService.DeleteChargeDefine(id);
                response.Code = type.Item1 ? 1 : 0;
                response.Message = type.Item2;
                return response;
            });
        }
        #endregion
    }
}