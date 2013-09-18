using System;
using System.Collections.Generic;

namespace SchoolSimulation
{
    class SchoolSimulation
    {
        static void Main()
        {
            int i = 1;

            Teacher ivan = new Teacher("Ivan Todorov");
            ivan.AddDiscipline("Matematika", 3, 5);
            ivan.AddComment("comment");
            ivan.AddComment("comment");
            ivan.AddComment("comment");

            foreach (var disciplne in ivan.Disciplines)
            {
                disciplne.AddComment(String.Format("comment"));
                i++;
            }

            Teacher penka = new Teacher("Penka Popova");
            penka.AddDiscipline("Nemski Ezik", 3, 2);
            penka.AddComment("comment");
            penka.AddComment("comment");
            penka.AddComment("comment");

            foreach (var disciplne in penka.Disciplines)
            {
                disciplne.AddComment(String.Format("comment"));
                i++;
            }

            Teacher stefan = new Teacher("Stefan Nikolov");
            stefan.AddDiscipline("Matematika", 2, 4);
            stefan.AddComment("comment");
            stefan.AddComment("comment");
            stefan.AddComment("comment");

            foreach (var disciplne in stefan.Disciplines)
            {
                disciplne.AddComment(String.Format("comment"));
                i++;
            }

            Student ivancho = new Student("Ivan Mihailov", 4142);
            Student miro = new Student("Miroslav Petrov", 5325);
            Student mitko = new Student("Dimitar Stoqnov", 4152);
            Student mariika = new Student("Mariq Angelova", 1754);
            Student kiro = new Student("Kiro Kirev", 6655);
            Student spiridon = new Student("Spiridon Stamatov", 4373);

            Class OsmiA = new Class("8 A", 2, 3);

            OsmiA.AddTeacher(ivan);
            OsmiA.AddTeacher(penka);

            OsmiA.AddStudent(ivancho);
            OsmiA.AddStudent(miro);
            OsmiA.AddStudent(mariika);

            Class petiB = new Class("5 B", 2, 3);

            petiB.AddTeacher(stefan);

            petiB.AddStudent(spiridon);
            petiB.AddStudent(kiro);

            School school = new School(2);
            school.AddClass(OsmiA);
            school.AddClass(petiB);

            school.SchoolInfo();
        }
    }
}
