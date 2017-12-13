using System;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using NATS.Client;
using Newtonsoft.Json;
using Novus.Channels;
using Novus.Channels.Dto;
using Novus.Controllers;
using Novus.Web.Models.Channels;
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
        
        public async Task<ActionResult> EditChannelModal(int channelId)
        {
            var channelDto = await _channelAppService.Get(new EntityDto<long>(channelId));
            var model = new EditChannelModalViewModel
            {
                Channel = channelDto
            };
            return View("_EditChannelModal", model);
        }

        public async Task<IActionResult> ControlChannel(int id)
        {
            var channelDto = await _channelAppService.Get(new EntityDto<long>(id));
            var viewModel = new ControlChannelViewModel
            {
                Channel = channelDto
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult SendData([FromBody] DataDevice dataDevice)
        {
            Console.WriteLine($"Device name {dataDevice.DeviceName}");
            Console.WriteLine($"Value {dataDevice.Value}");
            Console.WriteLine($"Api Key {dataDevice.ApiKey}");
            
            // No es la forma apropiada obviamente, se tiene que cambiar a un servicio y autorizar.
            ConnectionFactory cf = new ConnectionFactory();
            IConnection c = cf.CreateConnection();
            
            var json = JsonConvert.SerializeObject(dataDevice);
            c.Publish(dataDevice.ApiKey, Encoding.UTF8.GetBytes(json));
            c.Close();

            return Json("true");
        }
    }
}