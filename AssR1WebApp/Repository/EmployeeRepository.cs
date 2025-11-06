using AssR1WebApp.Models;

namespace AssR1WebApp.Repository
{
    public class EmployeeRepository : IEmployeeReposiotry
    {
        //CRUD
        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context;// new ITIContext();
        }
        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            Employee emp=GetByID(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
            return  context.Employees.ToList();
        }

        public List<Employee> GetByDeptId(int deptId)
        {
            return context.Employees.Where(e => e.DepartmentId == deptId).ToList();
        }

        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Employee empFromDb=GetByID(entity.Id);
            empFromDb.Name= entity.Name;
            empFromDb.Salary= entity.Salary;
            empFromDb.ImageURl= entity.ImageURl;
            empFromDb.Address= entity.Address;
            empFromDb.DepartmentId= entity.DepartmentId;
        }
    }
}
