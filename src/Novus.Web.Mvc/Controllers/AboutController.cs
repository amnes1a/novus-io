using Abp.AspNetCore.Mvc.Authorization;
using Novus.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Novus.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : NovusControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}