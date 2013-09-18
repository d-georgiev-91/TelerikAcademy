namespace University.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using University.Data;
    using University.Models;

    public sealed class Configuration : DbMigrationsConfiguration<UniversityContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UniversityContext context)
        {
            var csharpCourse = new Course { Name = "C#", Description = "Learn basic part of programming" };
            var sdaCourse = new Course { Name = "SDA", Description = "Structure of data and algorithms" };
            var phpCourse = new Course { Name = "PHP", Description = "Web Development With Php"};

            context.Courses.AddOrUpdate(csharpCourse, sdaCourse, phpCourse);

            var ivan = new Student { FirstName = "Ivan", LastName = "Pesho", Number = 24121525 };
            var gosho = new Student { FirstName = "Gosho", LastName = "Goshov", Number = 24343525 };
            var minka = new Student { FirstName = "Minka", LastName = "Popova", Number = 34234235 };

            context.Homeworks.AddOrUpdate(
                new Homework { Content = "Sorting Algorithms",  Course = csharpCourse, Student = minka},
                new Homework { Content = "Php Basic" , Course = phpCourse, Student = gosho},
                new Homework { Content = "Console Input Output", Course = phpCourse, Student = ivan });
        }
    }
}