using CleanArchitecture.Common.ApiHelper.Controller;
using CleanArchitecture.Common.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : ApiController
    {
        public IActionResult Index()
        {
            var resp = new Response();

            resp.NotFound();

            return ApiResult(new Response());
        }
    }
}
