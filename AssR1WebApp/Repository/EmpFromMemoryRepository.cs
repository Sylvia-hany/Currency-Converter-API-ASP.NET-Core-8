using AssR1WebApp.Models;

namespace AssR1WebApp.Repository
{
    public class EmpFromMemoryRepository : IEmployeeReposiotry
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Id = 1, Name = "Esraa" });
            list.Add(new Employee() { Id = 2, Name = "Eslam" });
            return  list;
        }

        public List<Employee> GetByDeptId(int deptId)
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
