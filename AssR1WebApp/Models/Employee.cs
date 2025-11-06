using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AssR1WebApp.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
      //  [Required]
        [MinLength(3,ErrorMessage ="Name must be more than 2 char")]
        [MaxLength(25)]
        //[StringLength(25,MinimumLength =3)]
        [Unique]
        public string Name { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must be jpg or png")]
        public string ImageURl { get; set; }

        // [Range(7000,50000)]
        //Employee/CheckSalary?Salary=1000&Name=Ahemd
        [Remote("CheckSalary","Employee",ErrorMessage ="Salary Invalid",AdditionalFields ="Name")]
      //  [Remote("Route1",ErrorMessage ="Salary Invalid",AdditionalFields ="Name")]
        public int Salary { get; set; }

        public string? Address { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int? DepartmentId { get; set; }

        //[Required]
        public Department? Department { get; set; }

    }
}
