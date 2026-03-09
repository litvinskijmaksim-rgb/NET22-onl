using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7.Controllers
{
    
    public class StudentController
    {
        private readonly AppDbContext _context;

        
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        
        public List<Student> FindByName(string name)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Name == name)
                .ToList();
        }

        
        public List<Student> FindByNameContains(string text)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Name.Contains(text))
                .ToList();
        }

       
        public List<Student> FindOlderThan(int age)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Age > age)
                .ToList();
        }

       
        public List<Student> FindYoungerThan(int age)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Age < age)
                .ToList();
        }

     
        public List<Student> FindByAgeRange(int minAge, int maxAge)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Age >= minAge && s.Age <= maxAge)
                .ToList();
        }

        /// <summary>
        /// Найти учеников по названию класса
        /// </summary>
        public List<Student> FindByGradeName(string gradeName)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Grade != null && s.Grade.GradeName == gradeName)
                .ToList();
        }

        /// <summary>
        /// Найти учеников по ID класса
        /// </summary>
        public List<Student> FindByGradeId(int gradeId)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.GradeId == gradeId)
                .ToList();
        }

        
        public Student? FindFirst(string name)
        {
            return _context.Students
                .Include(s => s.Grade)
                .FirstOrDefault(s => s.Name.Contains(name));
        }

        
        public List<Student> SortByNameAscending()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderBy(s => s.Name)
                .ToList();
        }

        
        public List<Student> SortByNameDescending()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderByDescending(s => s.Name)
                .ToList();
        }

        
        public List<Student> SortByAgeAscending()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderBy(s => s.Age)
                .ToList();
        }

        
        public List<Student> SortByAgeDescending()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderByDescending(s => s.Age)
                .ToList();
        }

        
        public List<Student> SortByGradeThenByName()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderBy(s => s.Grade!.GradeName)
                .ThenBy(s => s.Name)
                .ToList();
        }

        
        public List<Student> SortByAgeThenByName()
        {
            return _context.Students
                .Include(s => s.Grade)
                .OrderBy(s => s.Age)
                .ThenBy(s => s.Name)
                .ToList();
        }

        
        public Dictionary<string, List<Student>> GroupByGrade()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,           
                    g => g.ToList()        
                );
        }

        
        public Dictionary<string, int> CountStudentsPerGrade()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
        }

       
        public Dictionary<string, double> AverageAgePerGrade()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(s => s.Age)
                );
        }

        
        public Dictionary<string, int> MinAgePerGrade()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Min(s => s.Age)
                );
        }

        
        public Dictionary<string, int> MaxAgePerGrade()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Max(s => s.Age)
                );
        }

        
        public Dictionary<string, object> FullGradeStatistics()
        {
            return _context.Students
                .Include(s => s.Grade)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => (object)new
                    {
                        Count = g.Count(),
                        AverageAge = g.Average(s => s.Age),
                        MinAge = g.Min(s => s.Age),
                        MaxAge = g.Max(s => s.Age),
                        Students = g.Select(s => s.Name).ToList()
                    }
                );
        }

       
        public Dictionary<string, List<Student>> FindSortAndGroup(string searchText)
        {
            return _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Name.Contains(searchText))
                .OrderBy(s => s.Age)
                .GroupBy(s => s.Grade!.GradeName)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                );
        }

        
        public List<Student> FindByAgeSorted(int age, string sortOrder = "asc")
        {
            var query = _context.Students
                .Include(s => s.Grade)
                .Where(s => s.Age == age);

            if (sortOrder.ToLower() == "asc")
                return query.OrderBy(s => s.Name).ToList();
            else
                return query.OrderByDescending(s => s.Name).ToList();
        }


        public StudentStatistics GetGeneralStatistics()  
        {
            var students = _context.Students.ToList();

            return new StudentStatistics  
            {
                TotalCount = students.Count,
                AverageAge = students.Any() ? students.Average(s => s.Age) : 0,
                MinAge = students.Any() ? students.Min(s => s.Age) : 0,
                MaxAge = students.Any() ? students.Max(s => s.Age) : 0,
                AgeGroups = students.GroupBy(s => s.Age)
                                    .Select(g => new AgeGroup { Age = g.Key, Count = g.Count() })  
                                    .OrderBy(g => g.Age)
                                    .ToList()
            };
        }


        public bool StudentExists(string name)
        {
            return _context.Students.Any(s => s.Name == name);
        }

        
        public List<int> GetUniqueAges()
        {
            return _context.Students
                .Select(s => s.Age)
                .Distinct()
                .OrderBy(age => age)
                .ToList();
        }
    }
    
    public class StudentStatistics
    {
        public int TotalCount { get; set; }           
        public double AverageAge { get; set; }        
        public int MinAge { get; set; }               
        public int MaxAge { get; set; }               
        public List<AgeGroup> AgeGroups { get; set; } = new(); 
    }

    
    public class AgeGroup
    {
        public int Age { get; set; }                 
        public int Count { get; set; }                 
    }
}