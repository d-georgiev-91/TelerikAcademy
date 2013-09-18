namespace Salaries
{
    using System;
    using System.Collections.Generic;

    class Salaries
    {
        private static HashSet<int> EmployeesWithCalculatedSalaries = new HashSet<int>();

        static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>(employeesCount);
            ReadEmployees(employees, employeesCount);
            long salaries = CalculateEmployeesSalaries(employees);
            Console.WriteLine(salaries);
        }

        private static long CalculateEmployeesSalaries(Dictionary<int, Employee> employees)
        {
            long salaries = 0;

            foreach (var employee in employees.Keys)
            {
                CalculateSalarie(employees[employee]);
                salaries = employees[employee].Salarie;
            }

            return salaries;
        }

        private static void CalculateSalarie(Employee employee)
        {
            if (EmployeesWithCalculatedSalaries.Contains(employee.Id))
            {
                return;
            }

            EmployeesWithCalculatedSalaries.Add(employee.Id);

            if (employee.Employers.Count == 0)
            {
                employee.Salarie = 1;
                return;
            }


            foreach (var emp in employee.Employers)
            {
                CalculateSalarie(emp);
                employee.Salarie += emp.Salarie;
            }
        }

        private static void ReadEmployees(Dictionary<int, Employee> employees, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (!employees.ContainsKey(i))
                {
                    employees.Add(i, new Employee(i));
                }
                var employer = employees[i];

                string input = Console.ReadLine();

                for (int j = 0; j < count; j++)
                {
                    if (input[j] == 'Y')
                    {
                        if (!employees.ContainsKey(j))
                        {
                            employees.Add(j, new Employee(j));
                        }

                        var worker = employees[j];

                        employer.Employers.Add(worker);
                    }
                }
            }
        }
    }
}

//using System;
//using System.Collections.Generic;

//namespace Salaries
//{
//    class Program
//    {
//        static HashSet<int> vizited = new HashSet<int>();

//        static void Main()
//        {
//#if DEBUG
//            //Console.SetIn(new System.IO.StreamReader("../../input.txt"));
//#endif
//            Dictionary<int, Employee> employers = new Dictionary<int, Employee>();
//            int n = int.Parse(Console.ReadLine());
//            for (int i = 0; i < n; i++)
//            {
//                if (!employers.ContainsKey(i))
//                {
//                    employers.Add(i, new Employee(i));
//                }
//                var employer = employers[i];

//                string input = Console.ReadLine();
//                for (int j = 0; j < n; j++)
//                {
//                    if (input[j] == 'Y')
//                    {
//                        if (!employers.ContainsKey(j))
//                        {
//                            employers.Add(j, new Employee(j));
//                        }

//                        var worker = employers[j];

//                        employer.Employers.Add(worker);
//                    }
//                }
//            }

//            long sum = 0;

//            for (int i = 0; i < n; i++)
//            {
//                Solve(employers[i]);
//            }

//            foreach (var employer in employers.Values)
//            {
//                sum += employer.Salarie;
//            }

//            Console.WriteLine(sum);
//        }

//        private static void Solve(Employee employer)
//        {
//            if (vizited.Contains(employer.Id))
//            {
//                return;
//            }

//            vizited.Add(employer.Id);

//            if (employer.Employers.Count == 0)
//            {
//                employer.Salarie = 1;
//                return;
//            }

//            foreach (var e in employer.Employers)
//            {
//                Solve(e);
//                employer.Salarie += e.Salarie;
//            }
//        }
//    }
//}