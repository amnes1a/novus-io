using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Runtime.Validation;

namespace Novus.Channels.Dto
{
    [AutoMapTo(typeof(Channel))]
    public class CreateChannelDto
    {
        [Required]
        public string ChannelName { get; set; }
        
        public int? ThingSpeakId { get; set; }
        
        public string VideoFeedUrl { get; set; }
    }
}