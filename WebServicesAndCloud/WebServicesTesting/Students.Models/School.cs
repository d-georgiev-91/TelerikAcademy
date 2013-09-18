namespace Students.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        [Column("SchoolId")]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("Location")]
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}