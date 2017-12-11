using System.Threading.Tasks;
using Abp.Application.Services;
using Novus.Sessions.Dto;

namespace Novus.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
