using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Novus.Web.Views
{
    public abstract class NovusRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected NovusRazorPage()
        {
            LocalizationSourceName = NovusConsts.LocalizationSourceName;
        }
    }
}
