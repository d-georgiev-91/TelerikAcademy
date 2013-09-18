namespace University.Data
{
    using System.Data.Entity.ModelConfiguration;
    using University.Models;

    public class HomeworkMappings : EntityTypeConfiguration<Homework>
    {
        public HomeworkMappings()
        {
            this.HasKey(h => h.HomeworkId);

            this.Property(h => h.Content).IsUnicode(true);
            this.Property(h => h.Content).IsMaxLength();
            this.Property(h => h.Content).IsOptional();

            this.Property(h => h.StudentId).IsOptional();
            this.Property(h => h.CourseId).IsOptional();

            this.Property(h => h.TimeSent).IsOptional();
        }
    }
}