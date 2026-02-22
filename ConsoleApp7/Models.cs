using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConsoleApp7
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
   
        [StringLength(10)]
        public string GradeName { get; set; } = string.Empty;
        [Range(5, 40)]   
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(6, 20)]
        public int Age { get; set; }

        
        public int GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Grade? Grade { get; set; }
    }
}
