namespace Students.Data
{
    using System.Data.Entity;
    using Students.Models;

    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("StudentsDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMappings());
            modelBuilder.Configurations.Add(new MarkMappings());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Mark> Marks { get; set; }
    }
}
