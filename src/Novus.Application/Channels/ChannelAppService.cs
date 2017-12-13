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
        
        public override async Task<ChannelDto> Update(ChannelDto input)
        {
            var channel = await _repository.GetAsync(input.Id);

            //TODO: Fix AutoMapper
            channel.ChannelName = input.ChannelName;
            channel.Field1 = input.Field1;
            channel.Field2 = input.Field2;
            channel.Field3 = input.Field3;
            channel.Field4 = input.Field4;
            channel.Field5 = input.Field5;
            channel.Field6 = input.Field6;
            channel.Field7 = input.Field7;
            channel.Field8 = input.Field8;
            if(input.ThingSpeakId != null)
                channel.ThingSpeakId = (int)input.ThingSpeakId;
            channel.VideoFeedUrl = input.VideoFeedUrl;
            
            
            await _repository.UpdateAsync(channel);

            return await Get(input);
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