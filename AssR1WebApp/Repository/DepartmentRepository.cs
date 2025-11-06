using AssR1WebApp.Models;

namespace AssR1WebApp.Repository
{
    public class DepartmentRepository:IDepartmentReposiotry
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _context)
        {
            context = _context;// new ITIContext();
        }

        //CRUD
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        
        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Department entity)
        {
            context.Departments.Add(entity);
        }

        public void Update(Department entity)
        {
            //old
            Department deptFromDb=GetByID(entity.Id);
            //set
            deptFromDb.Name = entity.Name;
            deptFromDb.ManagerName = entity.ManagerName;
        }

        public void Delete(int id)
        {
            Department deptFromb=GetByID(id);
            context.Departments.Remove(deptFromb);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
