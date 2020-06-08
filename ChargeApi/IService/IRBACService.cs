using ChargeApi.Entities;
using ChargeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.IService
{
    public interface IRBACService
    {
        #region User
        ResponseModel AddUser(User user);

        ResponseModel ModifyUser(User user);

        ResponseModel DeleteUser(int id);

        ResponseModel GetUser(int id);

        ResponseModel GetUsers(string name,string sex);
        #endregion

        #region Role
        ResponseModel SaveRole(Role  role);

        ResponseModel DeleteRole(int id);

        ResponseModel GetRole(int id);

        ResponseModel GetRoleByUser(int userid);

        ResponseModel GetRoles();
        #endregion

        #region User-Role
        ResponseModel SaveUserRole(UserRoleMap[] userRoleMaps);
        #endregion

        #region Permission
        ResponseModel GetPermissions();
        #endregion

        #region Role-Permission
        ResponseModel SaveRolePermission(RolePermissionMap[] rolePermissionMaps);
        #endregion

    }
}
