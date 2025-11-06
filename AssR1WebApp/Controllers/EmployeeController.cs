using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssR1WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        //   ITIContext context = new ITIContext();
        IEmployeeReposiotry EmployeeRepository;
        IDepartmentReposiotry DepartmentRepository;
        //DIP || DI Lossy couple IOC
        public EmployeeController(IEmployeeReposiotry empREpo,IDepartmentReposiotry deptrepo)
        {
            EmployeeRepository =empREpo;
            DepartmentRepository = deptrepo;
        }

        public IActionResult Index()
        {
            List<Employee> EmpList = EmployeeRepository.GetAll();

            return View("Index",EmpList);//view "Index" , Model = type List<Employee>
        }
        //Employee/ShowCard/1
        public IActionResult ShowCard(int id)
        {
            Employee empModel=EmployeeRepository.GetByID(id);
            return PartialView("_EmpCardPartial",empModel);
        }
        
        #region Ajax With Json
        //endpoint return data ==> view disaply
        public IActionResult ShowDEpartments()
        {
            ViewData["DEptList"] = DepartmentRepository.GetAll();
            return View("ShowDEpartments");
        }
        //Employee/GetEmpByDepartment?deptId=1
        public IActionResult GetEmpByDepartment([FromQuery]int deptId)
        {
            List<Employee> empList = EmployeeRepository.GetByDeptId(deptId);
            return Json(empList);
        }

        #endregion












        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 7000)
            {
                return Json(true);
            }
            return Json(false);
        }

        #region Delete
        public IActionResult Delete(int id)
        {
            Employee EmpModel =
               EmployeeRepository.GetByID(id);
            return View("Delete", EmpModel);
        }
        #endregion


        #region NEw

        public IActionResult New()
        {
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee EmpFromReq)
        {
            //if (EmpFromReq.Name != null && EmpFromReq.Salary > 7000)
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Add(EmpFromReq);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //send exception to view Div
                    ModelState.AddModelError("xyz", ex.InnerException.Message);
                }
            }

            ViewData["DeptList"] = DepartmentRepository.GetAll() ;
            return View("New", EmpFromReq);
        }

        #endregion


        #region Edit
        public IActionResult Edit(int id)
        {
            //Collect
            Employee EmpModel=EmployeeRepository.GetByID(id);
            List<Department> DeptList = DepartmentRepository.GetAll();
            //DEclre VM
            EmployeeWithDeptListViewModel EmpVM = new();
            //Mapping
            EmpVM.Id = EmpModel.Id;
            EmpVM.Name = EmpModel.Name;
            EmpVM.ImageURl = EmpModel.ImageURl;
            EmpVM.Salary = EmpModel.Salary;
            EmpVM.Address = EmpModel.Address;
            EmpVM.DepartmentId = EmpModel.DepartmentId;

            EmpVM.DepartmentList = DeptList;
            //send VM
            return View("Edit", EmpVM);//View Model With typeEmployeeWithDeptListViewModel
        }
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFRomREq) {
            if (EmpFRomREq.Name != null) { //jsut validation server side
                //oldd obj
                Employee EmpFromDB = new Employee();//context.Employees.FirstOrDefault(e => e.Id == EmpFRomREq.Id);
                //set new value
                EmpFromDB.Id = EmpFRomREq.Id;
                EmpFromDB.Address= EmpFRomREq.Address;
                EmpFromDB.Salary= EmpFRomREq.Salary;
                EmpFromDB.Name= EmpFRomREq.Name;
                EmpFromDB.ImageURl= EmpFRomREq.ImageURl;
                EmpFromDB.DepartmentId= EmpFRomREq.DepartmentId;
                EmployeeRepository.Update(EmpFromDB);
                //save db
                EmployeeRepository.Save();
                //index
                return RedirectToAction("Index", "Employee");
            }

            EmpFRomREq.DepartmentList = DepartmentRepository.GetAll();
            return View("Edit",EmpFRomREq);
        }
        #endregion

        #region Details
        //Employee/DEtails/1
        //Employee/DEtails?id=1
        public IActionResult Details(int id,string name,int age)
        {
            string Msg = "Hi";
            int Temp = 30;
            List<string> brches= new List<string>() { "Alex","New Capital" ,"Assiut" ,"Mansoura" ,"Smart"};
            string Color = "red";

            //set Data  to ViewData To Send To View 
            ViewData["Msg"] = Msg;
            ViewData["Temp"] = Temp;
            ViewData["Brch"] = brches;
            ViewData["Clr"] = Color;
            ViewBag.Address = "Assiut";//ViewData["Address"]="Assiut"



            Employee EmpModel=
                EmployeeRepository.GetByID(id);
            if (EmpModel==null)
            {
                return NotFound();
            }
            return View("Details", EmpModel);//Model ==>Employee
        }



        public IActionResult DetailsVM(int id)
        {
            //Collected data (Source)
            string Msg = "Hi";
            int Temp = 30;
            List<string> brches = new List<string>() { "Alex", "New Capital", "Assiut", "Mansoura", "Smart" };
            string Color = "red";
            Employee EmpModel =
                EmployeeRepository.GetByID(id);
            // DEclare ViewModel (Destination)
            EmployeeNameWithTempMsgClrBranchViewModel EmpVM = new();


            // mapping from source ==>destination(VM) (automapper)
            EmpVM.EmpId = EmpModel.Id;
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.Temp = Temp;
            EmpVM.Color = Color;
            EmpVM.Branches = brches;
            EmpVM.Message = Msg;

            //return view with  Viewmodel
            return View("DetailsVM",EmpVM);
        }
        #endregion
    }
}












