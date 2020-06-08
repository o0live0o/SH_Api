using ChargeApi.Entities;
using ChargeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IMenuService
    {
        ResponseModel AddMenu(Menus menu);

        ResponseModel ModifyMenu(Menus menu);

        ResponseModel DeleteMenu(int id);

        ResponseModel GetMenus();

        ResponseModel GetMenu(int id);
    }
}
