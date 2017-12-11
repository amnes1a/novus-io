using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Novus.Controllers
{
    public abstract class NovusControllerBase: AbpController
    {
        protected NovusControllerBase()
        {
            LocalizationSourceName = NovusConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
