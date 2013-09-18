namespace University.Data
{
    using System.Data.Entity.ModelConfiguration;
    using University.Models;

        class CourseMappings : EntityTypeConfiguration<Course>
    {
        public CourseMappings()
        {
            this.HasKey(c => c.CourseId);
            this.Property(c => c.Name).IsUnicode(true);
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.Name).IsRequired();

            this.Property(c => c.Description).IsUnicode(true);
            this.Property(c => c.Description).IsMaxLength();
            this.Property(c => c.Description).IsOptional();
        }
    }
}