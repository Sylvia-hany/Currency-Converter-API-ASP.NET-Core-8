using System.ComponentModel.DataAnnotations;

namespace AssR1WebApp.Models
{
    
    public class UniqueAttribute:ValidationAttribute
    {
        //public string Msg { get; set; }
        //public UniqueAttribute(int id)
        //{


        //}
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            Employee EmpFRmoReq = validationContext.ObjectInstance as Employee;


            ITIContext context = validationContext.GetRequiredService<ITIContext>();// new ITIContext();
          
            Employee EmpFromDB = 
                context.Employees
                .FirstOrDefault(e => e.Name == name && e.DepartmentId==EmpFRmoReq.DepartmentId);
            if(EmpFromDB == null) {
                //sucess
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist :(");
        }
    }
}
