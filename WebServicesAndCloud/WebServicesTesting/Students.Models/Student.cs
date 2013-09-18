namespace Students.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }
        
        [ForeignKey("School")]
        [Column("SchoolId")]
        public int? SchoolId { get; set; }
        
        public virtual School School { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}