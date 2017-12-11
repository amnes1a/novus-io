using Abp.AspNetCore.Mvc.Authorization;
using Novus.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Novus.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : NovusControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}