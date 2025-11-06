using AssR1WebApp.Models;

namespace AssR1WebApp.Repository
{
    public interface IEmployeeReposiotry:IRepository<Employee>
    {
        //any method specific with Employee
        List<Employee> GetByDeptId(int deptId);
    }
}
