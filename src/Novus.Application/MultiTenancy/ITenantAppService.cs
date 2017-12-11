using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Novus.MultiTenancy.Dto;

namespace Novus.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
