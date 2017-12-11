using System.Collections.Generic;
using Novus.Roles.Dto;
using Novus.Users.Dto;

namespace Novus.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}