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
    public class RBACService : IRBACService
    {
        private readonly ChargeContext chargeContext;

        public RBACService(ChargeContext chargeContext)
        {
            this.chargeContext = chargeContext;
        }
        public ResponseModel DeleteRole(int id)
        {
            ResponseModel response = new ResponseModel();
            var role = chargeContext.roles.Where(p => p.Id == id).FirstOrDefault();
            if (role != null)
            {
                chargeContext.roles.Remove(role);
            }
            return response;
        }

        public ResponseModel DeleteUser(int id)
        {
            ResponseModel response = new ResponseModel();
            var user = chargeContext.users.Where(p => p.Id == id).FirstOrDefault();
            if (user != null)
            {
                chargeContext.users.Remove(user);
                chargeContext.SaveChanges();
            }
            return response;
        }

        public ResponseModel GetPermissions()
        {
            ResponseModel response = new ResponseModel();
            var permissions = chargeContext.permissions.ToList();
            response.Data = permissions;
            return response;
        }

        public ResponseModel GetRole(int id)
        {
            ResponseModel response = new ResponseModel();
            var role = chargeContext.roles.Where(p => p.Id == id).FirstOrDefault();
            if (role != null)
            {
                response.Data = role;
            }
            return response;
        }

        public ResponseModel GetRoleByUser(int userid)
        {
            ResponseModel response = new ResponseModel();
            var query = (from a in chargeContext.userRoleMaps
                         join b in chargeContext.roles on a.RoleId equals b.Id
                         where a.UserId == userid
                         select new Role
                         {
                             Id = b.Id,
                             RoleName = b.RoleName
                         }).ToList();
            response.Data = query;
            response.DataCount = query.Count();
            return response;
        }

        public ResponseModel GetRoles()
        {
            ResponseModel response = new ResponseModel();
            var roles = chargeContext.roles.ToList();
            response.Data = roles;
            response.DataCount = roles.Count();
            return response;
        }

        public ResponseModel GetUser(int id)
        {
            ResponseModel response = new ResponseModel();
            var user = chargeContext.users.Where(p => p.Id == id).FirstOrDefault();
            if (user != null)
            {
                response.Data = user;
            }
            return response;
        }

        public ResponseModel GetUsers(string name, string sex)
        {
            ResponseModel response = new ResponseModel();
            var users = chargeContext.users.ToList();
            response.Data = users;
            response.DataCount = users.Count();
            return response;
        }

        public ResponseModel SaveRole(Role role)
        {
            ResponseModel response = new ResponseModel();
            if (role.RoleName.Equals("超级管理员"))
            {
                response.Code = 0;
                response.Message = "权限非法";
            }
            else
            {
                var entity = chargeContext.roles.AsNoTracking().Where(p => p.RoleName.Equals(role.RoleName)).FirstOrDefault();
                if (entity != null)
                {
                    role.Id = entity.Id;
                    chargeContext.roles.Update(role);
                }
                else
                {
                    chargeContext.roles.Add(role);
                }
                chargeContext.SaveChanges();
                response.Data = role;
            }
            return response;
        }

        public ResponseModel SaveRolePermission(RolePermissionMap[] rolePermissionMaps)
        {
            ResponseModel response = new ResponseModel();

            if (rolePermissionMaps.Length > 0)
            {
                var maps = chargeContext.rolePermissionMaps.Where(p => p.RoleId.Equals(rolePermissionMaps[0].RoleId));
                chargeContext.rolePermissionMaps.RemoveRange(maps);
                chargeContext.rolePermissionMaps.AddRange(rolePermissionMaps);
                chargeContext.SaveChanges();
            }

            return response;
        }

        public ResponseModel ModifyUser(User user)
        {
            ResponseModel response = new ResponseModel();
            var entity = chargeContext.users.AsNoTracking().Where(p => p.Id == user.Id).FirstOrDefault();
            if (entity != null)
            {
                chargeContext.users.Update(user);
                chargeContext.SaveChanges();
                response.Data = user;
            }
            else
            {
                response.Code = 0;
                response.Message = "用户不存在";
            }
            return response;
        }

        public ResponseModel AddUser(User user)
        {
            ResponseModel response = new ResponseModel();
            if (user.UserAccount.ToLower().Equals("admin") ||
               user.UserAccount.ToLower().Equals("administrator"))
            {
                response.Code = 0;
                response.Message = "用户账户非法";
            }
            else
            {
                var entity = chargeContext.users.AsNoTracking().Where(p => p.UserAccount.Equals(user.UserAccount)).FirstOrDefault();
                if (entity != null)
                {
                    response.Code = 0;
                    response.Message = "用户账户已存在";
                }
                else
                {
                    chargeContext.users.Add(user);
                    chargeContext.SaveChanges();
                    response.Code = 1;
                    response.Data = user;
                    response.Message = "用户添加成功";
                }

            }
            return response;
        }

        public ResponseModel SaveUserRole(UserRoleMap[] userRoleMaps)
        {
            ResponseModel response = new ResponseModel();

            if (userRoleMaps.Length > 0)
            {
                var maps = chargeContext.userRoleMaps.Where(p => p.UserId.Equals(userRoleMaps[0].UserId));
                chargeContext.userRoleMaps.RemoveRange(maps);
                chargeContext.userRoleMaps.AddRange(userRoleMaps);
                chargeContext.SaveChanges();
            }
            return response;
        }

        public ResponseModel GetMenus(string account)
        {
            List<Menus> menus = new List<Menus>();
            ResponseModel response = new ResponseModel();
            menus = chargeContext.menus.ToList();
            response.Data = menus;
            return response;
            if (account.ToLower().Equals("admin") ||
                account.ToLower().Equals("administrator"))
            {
                menus = chargeContext.menus.ToList();
            }
            else
            {
                var user = chargeContext.users.Where(p => p.UserAccount.Equals(account)).FirstOrDefault();
                if (user != null)
                {
                    var userrole = chargeContext.userRoleMaps.Where(p => p.UserId.Equals(user.Id)).ToList();
                    if (userrole.Count > 0)
                    {
                        List<int> roleIds = userrole.Select(p => p.RoleId).ToList();
                        var rolerPermession = chargeContext.rolePermissionMaps.Where(p => roleIds.Contains(p.RoleId)).ToList();
                        if (rolerPermession.Count > 0)
                        {

                        }
                    }
                }
            }
            return response;
        }

        public ResponseModel SaveRoleMenu(RoleMenuMap[] roleMenuMaps)
        {
            ResponseModel response = new ResponseModel();

            if (roleMenuMaps.Length > 0)
            {
                var maps = chargeContext.RoleMenuMaps.Where(p => p.RoleId.Equals(roleMenuMaps[0].RoleId));
                chargeContext.RoleMenuMaps.RemoveRange(maps);
                chargeContext.RoleMenuMaps.AddRange(roleMenuMaps);
                chargeContext.SaveChanges();
            }
            return response;
        }

        public ResponseModel UserLogin(string account, string password)
        {
            ResponseModel response = new ResponseModel();
            if (account.ToLower().Equals("admin") || account.ToLower().Equals("administrator"))
            {
                if (password.Equals(DateTime.Now.ToString("yyyyMMddHH")))
                {
                    User user = new User()
                    {
                        Id = -999,
                        UserAccount = account,
                        UserPwd = password,
                        UserName = "超级管理员"
                    };
                    response.Code = 1;
                    response.Data = user;
                }
                else
                {
                    response.Code = 0;
                    response.Message = "密码错误!";
                }
            }
            else
            {
                var user = chargeContext.users.Where(p => p.UserAccount.Equals(account) && p.UserPwd.Equals(password)).FirstOrDefault();
                if (user == null)
                {
                    response.Message = "登录失败！用户名或密码不正确";
                    response.Code = 0;
                }
                else
                {
                    response.Message = "登录成功！";
                    response.Code = 1;
                    response.Data = user;
                }
            }
            return response;
        }
    }
}
