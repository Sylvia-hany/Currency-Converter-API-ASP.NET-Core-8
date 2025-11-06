using AssR1WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssR1WebApp.Controllers
{
    public class BindController : Controller
    {
        //[Authorize]
        public IActionResult Welcome()
        {
            if(User.Identity.IsAuthenticated==true)
            {


                //User.IsInRole("Admin")
                string? name=User.Identity.Name;
                Claim addressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");
                string address = addressClaim.Value;


                Claim? idClaim= User.Claims  //come from cookie Compact  (Sign in manager)
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                string? id = idClaim.Value;
                return Content($"Welcome {name} \t {id} \t {address}");

            }
            return Content("Welcome Gust");

        }














        int count ;
        public BindController()
        {
           // IdentityUser
            count = 0;
        }
        public IActionResult Increase()
        {
            count++;
            return Content($"Count={count}");
        }




        /*
         <form method="get" action="/Bind/TestPrimitive">
            <input type=text name="name">
            <input type=number name="age">

         </form>
         
         */

        //Bind/TestPrimitive?name=sd&age=12&id=10
        //Bind/TestPrimitive/10?name=sd&age=12&color[1]=black&color[0]=red
        //Bind/TestPrimitive/10?name=sd&age=12&color=red&color=black
        public IActionResult TestPrimitive(int age ,string name,int id,string[] color)
        {
            return Content($"name={name}");
        }


        //Collection
        //Bind/TestDic?name=christen&phoneBook[Ahmed]=123&phoneBook[Mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> phoneBook ,string name)
        {
            return Content($"name={name}");

        }


        //Custom Class
        //Bind/TestObj?id=1&name=sd&ManagerName=ahmed&Employees[0].name=1000
        public IActionResult TestObj(Department dept,string name)
       // public IActionResult TestObj
       // (int Id, string Name, string? ManagerName, List<Employee> Employees)
        {
            return Content("");
        }
    }
}
