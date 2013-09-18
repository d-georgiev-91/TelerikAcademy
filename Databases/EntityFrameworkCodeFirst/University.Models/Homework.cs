namespace University.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Homeworks")]
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}