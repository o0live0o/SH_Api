using ChargeApi.DbServer;
using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Service
{
    public class MenuService : IMenuService
    {
        private readonly ChargeContext chargeContext;

        public MenuService(ChargeContext chargeContext)
        {
            this.chargeContext = chargeContext;
        }
        public ResponseModel AddMenu(Menus menu)
        {
            ResponseModel response = new ResponseModel();
            chargeContext.menus.Add(menu);
            chargeContext.SaveChanges();
         
            return response;
        }

        public ResponseModel DeleteMenu(int id)
        {
            ResponseModel response = new ResponseModel();
            var menu = chargeContext.menus.Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (menu != null)
            {
                chargeContext.menus.Remove(menu);
                chargeContext.SaveChanges();
            }
            return response;
        }

        public ResponseModel GetMenu(int id)
        {
            ResponseModel response = new ResponseModel();
            var menu = chargeContext.menus.Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (menu != null)
                response.Data = menu;
            return response;
        }

        public ResponseModel GetMenus()
        {
            ResponseModel response = new ResponseModel();
            var menu = chargeContext.menus.ToList();
             response.Data = menu;
            response.DataCount = menu.Count;
            return response;
        }

        public ResponseModel ModifyMenu(Menus menu)
        {
            ResponseModel response = new ResponseModel();
            var entity = chargeContext.menus.AsNoTracking().Where(p => p.Id == menu.Id).FirstOrDefault();
            if (entity != null)
            {
                chargeContext.menus.Update(menu);
                chargeContext.SaveChanges();
                response.Data = menu;
            }
            else
            {
                response.Code = 0;
                response.Message = "菜单不存在";
            }
            return response;
        }
    }
}
