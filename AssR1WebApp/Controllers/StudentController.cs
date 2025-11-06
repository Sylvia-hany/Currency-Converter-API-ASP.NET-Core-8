using AssR1WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssR1WebApp.Controllers
{
    public class StudentController : Controller
    {
        //Student/ShowAll
        public IActionResult ShowAll()
        {
            //ask moedl about data
            StudentBl studentBl = new StudentBl();
            //get
            List<Student> StudentList= studentBl.GetAll();
            //seb to view
            //return View("All");//determine view name 
            return View("All", StudentList);//View ="All" ,With Moel Type= List<student>
        }
    }
}
