using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Novus.Roles.Dto;
using Novus.Users.Dto;

namespace Novus.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
