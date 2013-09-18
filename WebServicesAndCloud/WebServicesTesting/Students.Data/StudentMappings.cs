namespace Students.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using Students.Models;

    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasColumnName("StudentId");
            
            this.Property(s => s.FirstName).IsUnicode(true);
            this.Property(s => s.FirstName).HasMaxLength(60);
            this.Property(s => s.FirstName).IsRequired();

            this.Property(s => s.LastName).IsUnicode(true);
            this.Property(s => s.FirstName).HasMaxLength(50);
            this.Property(s => s.LastName).IsRequired();

            this.Property(s => s.Age).IsRequired();
        }
    }
}
