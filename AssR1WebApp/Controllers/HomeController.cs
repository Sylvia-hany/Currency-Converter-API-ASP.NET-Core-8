using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssR1WebApp.Controllers
{
    //1) name of Class End dWith Controller (Suffix)
    //2) Inherit class Controller
    public     class HomeController : Controller
    {
        /// <summary>
        /// 1) MEthod Public 
        /// 2) Cant Static 
        /// 3) cant overload (only in one case)
        /// </summary>
        //Home/Showmsg
        public ContentResult ShowMsg()
        {
            //logic
            //DEcalre
            ContentResult result=new ContentResult();
            //set
            result.Content = "Hello From my First Action";
            //return
            return result;
        }
        //Home/ShowView
        public ViewResult showView()
        {
            //loic
            //declare
            ViewResult result=new ViewResult();
            //set
            result.ViewName = "View1";
            //return
            return result;
        }

        //Home/ShowMix?id=12&no=12&name=ahme ( uery string)
        //Home/ShowMix/12?no=12&name=ahme ( uery string)
        public IActionResult ShowMix(int no,string name,int id)
        {
            
            if (no == 13)
            {
               return Content("Hello From my First Action");
                
            }
            else
            {
                return View("View1");
            }
        }
        //ViewResult View(string ViewNAme){
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = ViewNAme;
        //    //return
        //    return result;
        //}

        /*Action Returns datatype
         - Content    =>   ContentResult ==>Content
         - View       =>   ViewResult    ==> View
         - Json       =>   JsonREsult    ==>Json
         - NotFoundd  =>   NotFoundResult
         - Js
         ......
         
         */









        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
