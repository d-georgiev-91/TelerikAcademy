namespace University.Data
{
    using System.Data.Entity.ModelConfiguration;
    using University.Models;

    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.StudentId);

            this.Property(s => s.FirstName).IsUnicode(true);
            this.Property(s => s.FirstName).HasMaxLength(50);
            this.Property(s => s.FirstName).IsRequired();

            this.Property(s => s.LastName).IsUnicode(true);
            this.Property(s => s.LastName).HasMaxLength(50);
            this.Property(s => s.LastName).IsRequired();

            this.Property(s => s.Number).IsRequired();
        }
    }
}