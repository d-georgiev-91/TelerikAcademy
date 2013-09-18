using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class StudentTestApp
    {
        static void Main()
        {
            Student studentOneOne = new Student("Ivan", "Petrov", "Todorov", "Sofia 1000", "08851252", "dasad@mail.com", 2, 123456790, Specialty.ComputerScience, University.SofiaUniversity, Faculty.MathematicalFaculty);
            Student studentOneTwo = new Student("Ivan", "Petrov", "Todorov", "Sofia 1000", "08851252", "dasad@mail.com", 2, 123456790, Specialty.ComputerScience, University.SofiaUniversity, Faculty.MathematicalFaculty);
            Student studentTwo = new Student("Ivan", "Petrov", "Stoqnov", "Sofia 1000", "08851252", "dasad@mail.com", 2, 543456790, Specialty.Phiology, University.SofiaUniversity, Faculty.PhilogyFaculty);
            Student studentThree = new Student("Ivan", "Petrov", "Todorov", "Sofia 1000", "08851252", "dasad@mail.com", 2, 525256790, Specialty.Law, University.SofiaUniversity, Faculty.LawFaculty);
            Student studentFour = null;

            Console.WriteLine("studentOneOne ==  studentOneTwo {0}", (studentOneOne == studentOneTwo));
            Console.WriteLine("studentOneOne !=  studentOneTwo {0}", (studentOneOne != studentOneTwo));
            Console.WriteLine("studentTwo == StudentThree {0}", (studentTwo == studentThree));
            Console.WriteLine("studentTwo != StudentThree {0}", (studentTwo != studentThree));
            Console.WriteLine("studentTwo == null {0}", (studentTwo == null));
            Console.WriteLine("studentFour == null {0}", (studentFour == null));

            Student copyOfStudentTwo = studentTwo.Clone();
            Console.WriteLine(studentTwo);
            Console.WriteLine(copyOfStudentTwo);
            studentTwo.FirstName = "pesho";
            Console.WriteLine(studentTwo);
            Console.WriteLine(copyOfStudentTwo);

            studentOneOne.CompareTo(studentTwo);
            studentOneOne.CompareTo(studentThree);
        }
    }
}
