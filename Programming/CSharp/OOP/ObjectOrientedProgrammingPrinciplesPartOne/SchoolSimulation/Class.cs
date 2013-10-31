namespace SchoolSimulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Class : ICommentable
    {
        private ICollection<Teacher> teachers;
        private ICollection<Student> students;
        private string uniqueTextIdentifier;

        public Class(string uniqueTextIdentifier, int teachersCount = 0, int studentsCount = 0)
        {
            this.UniqueTextIdentifier = uniqueTextIdentifier;
            this.Comments = new List<string>();
            this.teachers = new List<Teacher>(teachersCount);
            this.students = new List<Student>(studentsCount);
        }

        public ICollection<string> Comments { get; set; }

        public string UniqueTextIdentifier
        {
            get
            {
                return this.uniqueTextIdentifier;
            }
            set
            {
                this.uniqueTextIdentifier = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public ICollection<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public void AddStudent(Student student)
        {
            if (this.students.Where(s => s.UniqueClassNumber == student.UniqueClassNumber).FirstOrDefault() != null)
            {
                throw new ArgumentException(string.Format("Student with class number: \"{0}\" alredy exists",
                    student.UniqueClassNumber));
            }

            this.students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            if (this.teachers.Where(t => t.Name == teacher.Name).FirstOrDefault() != null)
            {
                throw new ArgumentException(string.Format("The teacher: \"{0}\" alredy exists", teacher.Name));
            }

            this.Teachers.Add(teacher);
        }

        public override string ToString()
        {
            StringBuilder classToString = new StringBuilder();

            classToString.AppendLine("=========================");

            classToString.AppendLine(this.UniqueTextIdentifier.ToString());

            classToString.AppendLine("list of students");
            
            foreach (var student in students)
            {
                classToString.AppendLine(student.ToString());
            }

            classToString.AppendLine("list of teachers");

            foreach (var teacher in teachers)
            {
                classToString.AppendLine(teacher.ToString());
            }

            if (this.Comments.Count > 0)
            {
                classToString.AppendLine("Comments");

                foreach (var comment in this.Comments)
                {
                    classToString.AppendLine(comment);
                }
            }

            classToString.AppendLine("=========================");

            return classToString.ToString();
        }
    }
}