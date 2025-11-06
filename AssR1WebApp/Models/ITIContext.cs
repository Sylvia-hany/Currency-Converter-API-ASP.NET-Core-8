using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssR1WebApp.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        //Model==>Table
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //DBMS - Server Name - Auth type - Database  (BContextOptions)

        public ITIContext(DbContextOptions<ITIContext> options) : base(options)//inject
        {
        }



        //public ITIContext():base()//comp
        //{}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=R1Ass;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        // //   base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<Department>().HasData(new Department() { Id=1,Name="SD",ManagerName="Ahmed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id=2,Name="OS",ManagerName="Mohamed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id=3,Name="UI",ManagerName="KArem"});


            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=1,Name="SAyed",Salary=20000,Address="Alex",DepartmentId=1,ImageURl="m.png"});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=2,Name="Doha",Salary=20000,Address="Alex",DepartmentId=2,ImageURl="2.jpg"});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=3,Name="Eman",Salary=20000,Address="Alex",DepartmentId=3,ImageURl="2.jpg"});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=4,Name="Amer",Salary=20000,Address="Alex",DepartmentId=1,ImageURl="m.png"});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id=5,Name="Samar",Salary=20000,Address="Alex",DepartmentId=2,ImageURl="2.jpg"});
        }
    }
}
