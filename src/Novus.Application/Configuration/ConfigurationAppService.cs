using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Novus.Configuration.Dto;

namespace Novus.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NovusAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
