using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Novus.Channels.Dto;

namespace Novus.Channels
{
    public interface IChannelAppService : IAsyncCrudAppService<ChannelDto, long, PagedResultRequestDto, CreateChannelDto, ChannelDto>
    {
        Task<ListResultDto<ChannelDto>> GetAllChannels();
    }
}