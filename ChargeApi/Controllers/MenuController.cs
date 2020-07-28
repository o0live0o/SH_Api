using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChargeApi.Entities;
using ChargeApi.IService;
using ChargeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChargeApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MenuController(IMenuService menuService, IHttpContextAccessor httpContextAccessor)
        {
            this.menuService = menuService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        public Task<string> GetToken()
        {
            var httpContext = httpContextAccessor.HttpContext;

           return Task.Run(()=> {
               var calims = new Claim[] {
                   new Claim(ClaimTypes.Name,"admin1")
               };

               var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456"));

               var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

               var token = new JwtSecurityToken(
                   signingCredentials: creds,
                    claims: calims,                 
                    expires: DateTime.Now.AddMinutes(1)
                    );

               return new JwtSecurityTokenHandler().WriteToken(token);            
            });
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