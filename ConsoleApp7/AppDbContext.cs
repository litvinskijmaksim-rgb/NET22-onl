using Microsoft.EntityFrameworkCore;
namespace ConsoleApp7
{
    public class AppDbContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasOne(s=>s.Grade)
            .WithMany(g => g.Students)
            .HasForeignKey(s=>s.GradeId)
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>().HasData(
               new Grade { Id = 1, GradeName = "5А", Capacity = 25 },
               new Grade { Id = 2, GradeName = "5Б", Capacity = 30 },
               new Grade { Id = 3, GradeName = "6А", Capacity = 28 }
           );

            
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Иван Петров", Age = 11, GradeId = 1 },
                new Student { Id = 2, Name = "Мария Иванова", Age = 11, GradeId = 1 },
                new Student { Id = 3, Name = "Петр Сидоров", Age = 12, GradeId = 3 }
            );

        }
    }
}