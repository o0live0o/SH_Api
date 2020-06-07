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

        Task<Tuple<bool,string>> DeleteConstantType(int id);

        Task<Tuple<bool, ConstantType, string>> SaveConstantType(ConstantType constantType);

        //获取常量定义集合
        Task<IEnumerable<ConstantDefine>> GetConstantDefines();

        //获取常量定义
        Task<ConstantDefine> GetConstantDefine(int id);

        Task<Tuple<bool, string>> DeleteConstantDefine(int id);

        Task<Tuple<bool, ConstantDefine, string>> SaveConstantDefine(ConstantDefine constantDefine);


        #region 收费配置
        Task<IEnumerable<ChargeDefine>> GetChargeDefines();

        Task<ChargeDefine> GetChargeDefine(int id);

        Task<Tuple<bool, string>> DeleteChargeDefine(int id);

        Task<Tuple<bool, ChargeDefine, string>> SaveChargeDefine(ChargeDefine constantDefine);
        #endregion

    }
}
