using ChargeApi.DbServer;
using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.Service
{
    public class MenuService : IMenuService
    {
        private readonly ChargeContext chargeContext;
        private readonly ILogger<MenuService> logger;

        public MenuService(ChargeContext chargeContext, ILogger<MenuService> logger)
        {
            this.chargeContext = chargeContext;
            this.logger = logger;
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

        public ResponseModel GetMenuByRole(int roleid)
        {
            ResponseModel response = new ResponseModel();
            var obj = (from p in chargeContext.RoleMenuMaps
                       join q in chargeContext.menus
                       on p.MenuId equals q.Id
                       where p.RoleId == roleid
                       select new Menus
                       {
                           Id = q.Id,
                           ParentId = q.Id,
                           ParentName = q.ParentName,
                           MenuName = q.MenuName,
                           MenuPath = q.MenuPath,
                           OrderNo = q.OrderNo
                       }).ToList();
            response.Data = obj;
            response.DataCount = obj.Count();
            return response;
        }

        public ResponseModel GetMenuByUser(int userid)
        {
            ResponseModel response = new ResponseModel();
            if (userid == -999)
            {
                var menu = chargeContext.menus.ToList();
                response.Data = menu;
                response.DataCount = menu.Count;
            }
            else
            {
                var menus = (from p in chargeContext.userRoleMaps
                             join q in chargeContext.RoleMenuMaps on p.RoleId equals q.RoleId
                             join r in chargeContext.menus on q.MenuId equals r.Id
                             where userid == p.UserId
                             select new Menus
                             {
                                 Id = r.Id,
                                 ParentId = r.ParentId,
                                 ParentName = r.ParentName,
                                 MenuName = r.MenuName,
                                 MenuPath = r.MenuPath,
                                 OrderNo = r.OrderNo
                             }).Distinct().ToList();
                response.Data = menus;
                response.DataCount = menus.Count();
            }
            return response;
        }

        public ResponseModel GetMenus()
        {
            logger.LogError("111111111111");
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
