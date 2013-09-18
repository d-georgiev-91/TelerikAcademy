namespace TelerikAcademyQueries
{
    using System;
    using System.Collections;
    using System.Linq;
    using TelerikAcademyEntities;

    public static class TelerikAcademyQueries
    {
        public static void Main()
        {
            SqlQueryWithInclude();
            //SqlQueryWithoutInclude();
            //SqlQueryToListNonOptimized();
            //SqlQueryToListOptimized();
        }

        private static void SqlQueryToListNonOptimized()
        {
            using (TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyEntities.Employees.ToList();
                var addresses = employees.Select(a => a.Address).ToList();
                var towns = addresses.Select(t => t.Town).ToList();

                foreach (var town in towns)
                {
                    if (town.Name == "Sofia")
                    {
                        Console.WriteLine("Town is Sofia");
                    }
                    else
                    {
                        Console.WriteLine("Town is not Sofia");
                    }
                }
            }
        }

        private static void SqlQueryToListOptimized()
        {
            using (TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities())
            {
                var townsNames = telerikAcademyEntities.Employees
                                                  .Select(a => a.Address)
                                                  .Select(t => t.Town.Name)
                                                  .ToList();

                foreach (var townName in townsNames)
                {
                    if (townName == "Sofia")
                    {
                        Console.WriteLine("Town is Sofia");
                    }
                    else
                    {
                        Console.WriteLine("Town is not Sofia");
                    }
                }
            }
        }

        private static void SqlQueryWithInclude()
        {
            using (TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyEntities.Employees
                                                      .Include("Address.Town")
                                                      .Include("Department");

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                    Console.WriteLine(employee.Department.Name);
                    Console.WriteLine(employee.Address.Town.Name);

                    Console.WriteLine();
                }
            }
        }

        private static void SqlQueryWithoutInclude()
        {
            using (TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyEntities.Employees;
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                    Console.WriteLine(employee.Department.Name);
                    Console.WriteLine(employee.Address.Town.Name);

                    Console.WriteLine();
                }
            }
        }
    }
}