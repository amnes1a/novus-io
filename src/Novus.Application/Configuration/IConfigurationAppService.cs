using System.Threading.Tasks;
using Novus.Configuration.Dto;

namespace Novus.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
