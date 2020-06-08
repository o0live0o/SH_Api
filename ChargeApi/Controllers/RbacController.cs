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
    public class RbacController : ControllerBase
    {
        private readonly IRBACService rbac;


        public RbacController(IRBACService service)
        {
            this.rbac = service;
        }

        #region User
        [HttpPost]
        public Task<ResponseModel> AddUser(User user)
        {
            return Task.Run(() =>
           {
               return rbac.AddUser(user);
           });
        }
        [HttpPost]
        public Task<ResponseModel> ModifyUser(User user)
        {
            return Task.Run(() =>
            {
                return rbac.ModifyUser(user);
            });
        }
        [HttpGet]
        public Task<ResponseModel> DeleteUser(int id)
        {
            return Task.Run(() =>
            {
                return rbac.DeleteUser(id);
            });
        }
        [HttpGet]
        public Task<ResponseModel> GetUser(int id)
        {
            return Task.Run(() =>
            {
                return rbac.GetUser(id);
            });
        }
        [HttpGet]
        public Task<ResponseModel> GetUsers(string name, string sex)
        {
            return Task.Run(() =>
            {
                return rbac.GetUsers(name, sex);
            });
        }
        #endregion

        #region Role
        [HttpPost]
        public Task<ResponseModel> SaveRole(Role role)
        {
            return Task.Run(() =>
            {
                return rbac.SaveRole(role);
            });
        }
        [HttpGet]
        public Task<ResponseModel> DeleteRole(int id)
        {
            return Task.Run(() =>
            {
                return rbac.DeleteRole(id);
            });
        }

        [HttpGet]
        public Task<ResponseModel> GetRole(int id)
        {
            return Task.Run(() =>
            {
                return rbac.GetRole(id);
            });
        }

        [HttpGet]
        public Task<ResponseModel> GetRoles()
        {
            return Task.Run(() =>
            {
                return rbac.GetRoles();
            });
        }
        #endregion

        #region User-Role
        [HttpPost]
        public Task<ResponseModel> SaveUserRole(UserRoleMap[] userRoleMaps)
        {
            return Task.Run(() =>
            {
                return rbac.SaveUserRole(userRoleMaps);
            });
        }
        #endregion

        #region Permission
        [HttpGet]
        public Task<ResponseModel> GetPermissions()
        {
            return Task.Run(() =>
            {
                return rbac.GetPermissions();
            });
        }
        #endregion

        #region Role-Permission
        [HttpPost]
        public Task<ResponseModel> SaveRolePermission(RolePermissionMap[] rolePermissionMaps)
        {
            return Task.Run(() =>
            {
                return rbac.SaveRolePermission(rolePermissionMaps);
            });
        }
        [HttpGet]
        public Task<ResponseModel> GetRoleByUser(int userid)
        {
            return Task.Run(() =>
            {
                return rbac.GetRoleByUser(userid);
            });
        }
        #endregion
    }
}