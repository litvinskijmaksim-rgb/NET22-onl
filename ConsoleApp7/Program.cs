using ConsoleApp7;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SchoolConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var db = new AppDbContext())
            {
                
                
                db.Database.EnsureCreated();
                Console.WriteLine("База данных готова\n");

               
                Console.WriteLine("Список классов:");
                var grades = db.Grades.Include(g => g.Students).ToList();
                foreach (var g in grades)
                {
                    Console.WriteLine($"   {g.GradeName} (ID: {g.Id}), учеников: {g.Students.Count}");
                }

               
                Console.WriteLine("\nСписок учеников:");
                var students = db.Students.Include(s => s.Grade).ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"   {s.Name}, класс: {s.Grade?.GradeName}");
                }

                
                Console.WriteLine($"\nВсего классов: {db.Grades.Count()}");
                Console.WriteLine($"Всего учеников: {db.Students.Count()}");
            }

            
            Console.ReadKey();
        }
    }
}