using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Age { get; set; }
}
class AppDbContext : DbContext
{
    public DbSet<Student> Students { get;set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyFirstDB;Trusted_Connection=True;");
    }
}
class Program
{
    static void Main()
    {
        using (var db = new AppDbContext())
           {
            db.Database.EnsureCreated();
            var student = new Student
            {
                Name = "Иван",
                Age = 19
            };
            db.Students.Add(student);
            db.SaveChanges();
            var allStudents = db.Students.ToList();
            Console.WriteLine("Список студентов:");
            foreach (var s in allStudents)
            {
                Console.WriteLine($"  {s.Id}: {s.Name}, {s.Age} лет");
            }
        }
    }
}