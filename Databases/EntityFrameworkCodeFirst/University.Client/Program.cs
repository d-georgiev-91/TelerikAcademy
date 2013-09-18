namespace University.Client
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using University.Data;
    using University.Data.Migrations;
    using University.Models;

    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityContext, Configuration>());

            var db = new UniversityContext();

            var studentPesho = new Student 
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Number = 434224423
            };

            var course = new Course { Name = "Php programming" };
            db.Courses.Add(course);
            
            course.Students.Add(studentPesho);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.InnerException.Message);
            }
            finally
            {
                Console.WriteLine("All data added!");
                Console.ReadLine();
            }
        }
    }
}