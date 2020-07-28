using ChargeApi.EntityDev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChargeApi.RbacDev
{
    public interface IRbac
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        bool Login(string userName, string pwd);

        #region User
        User GetUser(int userId);

        IEnumerable<User> GetUsers();

        bool ModifyUser(User user);

        bool DeleteUser(int userId);

        bool AddUser(User  user);
        #endregion

        #region Role
        Role GetRole(int RoleId);

        IEnumerable<Role> GetRoles();

        bool ModifyRole(Role Role);

        bool DeleteRole(int RoleId);

        bool AddRole(Role Role);
        #endregion

        #region Menu
        Menu GetMenu(int MenuId);

        IEnumerable<Menu> GetMenus();

        bool ModifyMenu(Menu Menu);

        bool DeleteMenu(int MenuId);

        bool AddMenu(Menu Menu);
        #endregion

        void GetMenus(string userId);

        void GetPermission(string userId);
    }
}
