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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet]
        public Task<ResponseModel> GetMenus()
        {
            return Task.Run(() => {
                return menuService.GetMenus();
            });
        }

        [HttpPost]
        public Task<ResponseModel> AddMenu(Menus menu)
        {
            return Task.Run(() => {
                return menuService.AddMenu(menu);
            });
        }

        [HttpPost]
        public Task<ResponseModel> ModifyMenu(Menus menu)
        {
            return Task.Run(() => {
                return menuService.ModifyMenu(menu);
            });
        }

        [HttpGet]
        public Task<ResponseModel> DeleteMenu(int id)
        {
            return Task.Run(() => {
                return menuService.DeleteMenu(id);
            });
        }

        [HttpGet]
        public Task<ResponseModel> GetMenu(int id)
        {
            return Task.Run(() => {
                return menuService.GetMenu(id);
            });
        }
        [HttpGet]
        public Task<ResponseModel> GetMenuByUser(int userid)
        {
            return Task.Run(() =>
            {
                return menuService.GetMenuByUser(userid);
            });
        }
        [HttpGet]
        public Task<ResponseModel> GetMenuByRole(int roleid)
        {
            return Task.Run(() =>
            {
                return menuService.GetMenuByRole(roleid);
            });
        }
    }
}