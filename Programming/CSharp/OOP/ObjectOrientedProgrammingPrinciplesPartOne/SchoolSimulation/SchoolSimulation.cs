namespace SchoolSimulation
{
    using System;
    
    class SchoolSimulation
    {
        static void Main()
        {
            int i = 1;

            Teacher ivan = new Teacher("Ivan Todorov");
            ivan.AddDiscipline("Matematika", 3, 5);
            ivan.AddComment("comment #32424");
            ivan.AddComment("comment #53252");
            ivan.AddComment("comment #432432");

            foreach (var disciplne in ivan.Disciplines)
            {
                disciplne.AddComment(string.Format("comment"));
                i++;
            }

            Teacher penka = new Teacher("Penka Popova");
            penka.AddDiscipline("Nemski Ezik", 3, 2);
            penka.AddComment("comment #432324125");
            penka.AddComment("comment #24151");
            penka.AddComment("comment #243243");

            foreach (var disciplne in penka.Disciplines)
            {
                disciplne.AddComment(string.Format("comment #{0}", i));
                i++;
            }

            Teacher stefan = new Teacher("Stefan Nikolov");
            stefan.AddDiscipline("Matematika", 2, 4);
            stefan.AddComment("comment #343224");
            stefan.AddComment("comment #3422124");
            stefan.AddComment("comment #3422334");

            foreach (var disciplne in stefan.Disciplines)
            {
                disciplne.AddComment(string.Format("comment #{0}", i));
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
            school.Classes.Add(OsmiA);
            school.Classes.Add(petiB);

            school.SchoolInfo();
        }
    }
}