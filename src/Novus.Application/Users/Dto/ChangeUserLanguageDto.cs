using System.ComponentModel.DataAnnotations;

namespace Novus.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}