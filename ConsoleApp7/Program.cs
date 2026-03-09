using ConsoleApp7;
using ConsoleApp7.Controllers;  
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
                

                
                var studentController = new StudentController(db);

                
                Console.WriteLine("Все ученики:");
                var allStudents = db.Students.Include(s => s.Grade).ToList();
                foreach (var s in allStudents)
                {
                    Console.WriteLine($"   {s.Name}, {s.Age} лет, класс: {s.Grade?.GradeName}");
                }

                

                
                Console.WriteLine("1. ПОИСК УЧЕНИКОВ:");

                var found = studentController.FindByNameContains("Петр");
                Console.WriteLine($"   Найдено учеников с 'Петр' в имени: {found.Count}");
                foreach (var s in found)
                    Console.WriteLine($"     - {s.Name}");

                var grade5A = studentController.FindByGradeName("5А");
                Console.WriteLine($"\n   Учеников в классе 5А: {grade5A.Count}");

                
                Console.WriteLine("\n2. СОРТИРОВКА:");

                var sortedByAge = studentController.SortByAgeDescending();
                Console.WriteLine("   Ученики от старших к младшим (первые 3):");
                foreach (var s in sortedByAge.Take(3))
                    Console.WriteLine($"     - {s.Name}, {s.Age} лет");

              
                Console.WriteLine("\n3. ГРУППИРОВКА ПО КЛАССАМ:");

                var countPerGrade = studentController.CountStudentsPerGrade();
                foreach (var g in countPerGrade)
                    Console.WriteLine($"   Класс {g.Key}: {g.Value} учеников");

                var avgAgePerGrade = studentController.AverageAgePerGrade();
                Console.WriteLine("\n   Средний возраст по классам:");
                foreach (var g in avgAgePerGrade)
                    Console.WriteLine($"   Класс {g.Key}: {g.Value:F1} лет");

                
                Console.WriteLine("\n4. ОБЩАЯ СТАТИСТИКА:");
                var stats = studentController.GetGeneralStatistics();
                Console.WriteLine($"   Всего учеников: {stats.TotalCount}");
                Console.WriteLine($"   Средний возраст: {stats.AverageAge:F1}");
                Console.WriteLine($"   Самый младший: {stats.MinAge}");
                Console.WriteLine($"   Самый старший: {stats.MaxAge}");

                
                Console.WriteLine("\n5. ПОИСК + СОРТИРОВКА + ГРУППИРОВКА:");
                var complex = studentController.FindSortAndGroup("а"); 
                foreach (var g in complex)
                {
                    Console.WriteLine($"   Класс {g.Key}: {g.Value.Count} учеников");
                    foreach (var s in g.Value.Take(2))
                        Console.WriteLine($"     - {s.Name}");
                }

                Console.WriteLine("\nВсе операции выполнены!");
            }
            Console.ReadKey();
        }
    }
}