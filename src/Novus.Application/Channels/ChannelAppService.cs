using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Novus.Authorization.Users;
using Novus.Channels.Dto;

namespace Novus.Channels
{
    public class ChannelAppService : AsyncCrudAppService<Channel, ChannelDto, long, PagedResultRequestDto, CreateChannelDto, ChannelDto>, IChannelAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Channel, long> _repository;
        
        public ChannelAppService(IRepository<Channel, long> repository,
                                 UserManager userManager) : base(repository)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<ListResultDto<ChannelDto>> GetAllChannels()
        {
            var currentUser = _userManager.AbpSession.UserId;
            if (currentUser == null)
                throw new Exception("No user found!");

            var channels = await _repository.GetAll().Where(us => us.CreatorUserId == currentUser).ToListAsync();
            
            return new ListResultDto<ChannelDto>(ObjectMapper.Map<List<ChannelDto>>(channels)); 
        }
        
        public override async Task<ChannelDto> Create(CreateChannelDto input)
        {
            var channel = ObjectMapper.Map<Channel>(input);
            channel.ChannelGuid = Guid.NewGuid().ToString("N");
            await _repository.InsertAsync(channel);

            return MapToEntityDto(channel);
        }
    }
}