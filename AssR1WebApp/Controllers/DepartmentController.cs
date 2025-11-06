using AssR1WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        //  ITIContext context = new ITIContext();
        IDepartmentReposiotry DeptRepo;
        public DepartmentController(IDepartmentReposiotry _deptRepo)
        {
            DeptRepo = _deptRepo;
        }
        [Authorize] //cookie
        public IActionResult Index()
        {
            List<Department> DeptList = DeptRepo.GetAll();
            return View("Index",DeptList);
        }

        #region NEw
        public IActionResult New()
        {
            return View("New");
        }
        //Department/SaveNew?Name=as&ManagerName=ahmed-->
        //public IActionResult SaveNew(string Name,string ManagerName)
        [HttpPost]
       
        public IActionResult SaveNew(Department deptFromReq)
        {
            //Post Only
            //if (Request.Method == "POST") { }
            if(deptFromReq.Name != null) {
                //save
                DeptRepo.Add(deptFromReq);
                DeptRepo.Save();


                return RedirectToAction("Index", "Department");
            }
            return View("New",deptFromReq);//View ="New" ,Model =Department
        }
        #endregion
        //Department/MEthod1
        [HttpGet]
        public IActionResult MEthod1()
        {
            return Content("M1Get");
        }
        [HttpPost]
        public IActionResult MEthod1(int id)
        {
            return Content("M1post ");
        }


    }
}
