using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JetBrains.Annotations;

namespace Novus.Channels.Dto
{
    [AutoMap(typeof(Channel))]
    public class ChannelDto : FullAuditedEntityDto<long>
    {
        [Required]
        public string ChannelName { get; set; }
        
        public string ChannelGuid { get; set; }
        
        public int? ThingSpeakId { get; set; }
        
        public bool Field1 { get; set; }
        
        public bool Field2 { get; set; }
        
        public bool Field3 { get; set; }
        
        public bool Field4 { get; set; }
        
        public bool Field5 { get; set; }
        
        public bool Field6 { get; set; }
        
        public bool Field7 { get; set; }
        
        public bool Field8 { get; set; }
        
        [CanBeNull]
        public string VideoFeedUrl { get; set; }
    }
}