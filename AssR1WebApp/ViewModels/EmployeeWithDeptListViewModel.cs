using AssR1WebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AssR1WebApp.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURl { get; set; }
        public int Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Employee Address")]
        public string? Address { get; set; }

        public int? DepartmentId { get; set; }

        public List<Department> DepartmentList { get; set; }
    }
}
