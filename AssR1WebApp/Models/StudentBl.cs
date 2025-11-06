namespace AssR1WebApp.Models
{
    public class StudentBl
    {
        List<Student> Students;
        public StudentBl()
        {
            Students = new List<Student>();
            Students.Add(new Student() { Id = 1, Name = "Ahme", Address = "Alex", ImageURL = "m.png" });
            Students.Add(new Student() { Id = 2, Name = "Mohamed", Address = "Alex", ImageURL = "m.png" });
            Students.Add(new Student() { Id = 3, Name = "Sara", Address = "Alex", ImageURL = "2.jpg" });
            Students.Add(new Student() { Id = 4, Name = "Eman", Address = "Alex", ImageURL = "2.jpg" });
            Students.Add(new Student() { Id = 5, Name = "Alaa", Address = "Alex", ImageURL = "m.png" });
        }
        public List<Student> GetAll()
        {
            return Students;
        }

        public Student GetById(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

    }
}
