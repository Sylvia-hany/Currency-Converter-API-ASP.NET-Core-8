using AssR1WebApp.Filtters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
   // [HandelError]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService _Service)//inject (Ask)
        {
            service = _Service;
        }
        //Service/index
        public IActionResult Index()
        {
            ViewData["Id"] = service.Id;
            return View();
        }

        //[HandelError]
        //  [MyCustom]
        [AllowAnonymous]//poritoy
        public IActionResult M1()
        {
            //try {
            //    return View("");
            //}catch(Exception ex)
            //{
            //    return View("error");
            //}
            throw new NotImplementedException();
        }
        //[HandelError]
        public IActionResult M2()
        {
            throw new NotImplementedException();
        }
    }
}
