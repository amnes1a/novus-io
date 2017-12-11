using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Novus.Channels;
using Novus.Controllers;
using Novus.Web.Models.Users;

namespace Novus.Web.Controllers
{
    public class ChannelsController : NovusControllerBase
    {
        private readonly IChannelAppService _channelAppService;

        public ChannelsController(IChannelAppService channelAppService)
        {
            _channelAppService = channelAppService;
        }
        
        public async Task<ActionResult> Index()
        {
            var channels = await _channelAppService.GetAllChannels();
            return View(channels);
        }
    }
}