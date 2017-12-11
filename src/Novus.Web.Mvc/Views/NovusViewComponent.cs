using Abp.AspNetCore.Mvc.ViewComponents;

namespace Novus.Web.Views
{
    public abstract class NovusViewComponent : AbpViewComponent
    {
        protected NovusViewComponent()
        {
            LocalizationSourceName = NovusConsts.LocalizationSourceName;
        }
    }
}