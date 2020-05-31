using ChargeApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IConstantService
    {
        //获取字典类型集合
        Task<IEnumerable<ConstantType>> GetConstantTypes();

        //获取字典类型
        Task<ConstantType> GetConstantType(int id);

        Task<ConstantType> AddConstantType(ConstantType constantType);

        //获取常量定义集合
        Task<IEnumerable<ConstantDefine>> GetConstantDefines();

        //获取常量定义
        Task<ConstantDefine> GetConstantDefine(int id);

        Task<ConstantDefine> AddConstantDefine(ConstantDefine constantDefine);

    }
}
