namespace Client
{
    using System;
    using System.Linq;
    using Students.Data;
    using Students.Models;

    class Program
    {
        static void Main(string[] args)
        {
            var studentsEntities = new StudentsContext();
            studentsEntities.Students.Add(new Student()
            {
                Age = 5,
                FirstName = "Pesho",
                LastName = "Stamatov",
            });
            studentsEntities.SaveChanges();
        }
    }
}
