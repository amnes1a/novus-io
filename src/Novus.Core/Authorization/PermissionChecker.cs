using Abp.Authorization;
using Novus.Authorization.Roles;
using Novus.Authorization.Users;

namespace Novus.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
