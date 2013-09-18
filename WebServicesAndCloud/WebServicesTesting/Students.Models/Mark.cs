using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Mark
    {
        [Column("MarkId")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Range(2d, 6d)]
        public double Value { get; set; }

        [Column("StudentId")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}