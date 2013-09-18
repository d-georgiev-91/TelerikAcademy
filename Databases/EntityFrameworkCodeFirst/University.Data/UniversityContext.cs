namespace University.Data
{
    using System;
    using System.Data.Entity;
    using University.Data.Migrations;
    using University.Models;

    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("UniversityDB")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Course> Courses { get; set; }


        //I have tried to make the field number unique, but have problem with initializing the seed :(
        //public class DatabaseInitializer : IDatabaseInitializer<UniversityContext>
        //{
        //    public DatabaseInitializer()
        //    {
        //        Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityContext, Configuration>());
        //    }

        //    public void InitializeDatabase(UniversityContext context)
        //    {
        //        if (context.Database.Exists() && !context.Database.CompatibleWithModel(false))
        //            context.Database.Delete();

        //        if (!context.Database.Exists())
        //        {
        //            context.Database.Create();
        //            context.Database.ExecuteSqlCommand("ALTER TABLE dbo.Students ADD CONSTRAINT UK_Number_Sutdents UNIQUE (Number)");
        //        }
        //    }
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseMappings());
            modelBuilder.Configurations.Add(new HomeworkMappings());
            modelBuilder.Configurations.Add(new StudentMappings());

            modelBuilder.Entity<Student>()
                        .HasMany(c => c.Courses)
                        .WithMany(s => s.Students)
                        .Map(m =>
                        {
                            m.ToTable("StudentsInCourses");
                            m.MapLeftKey("StudentId");
                            m.MapRightKey("CourseId");
                        });
            base.OnModelCreating(modelBuilder);
        }
    }
}