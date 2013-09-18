using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSimulation
{
    public class Class : ICommentable
    {
        private List<Teacher> teachers;
        private int teachersCount;
        private List<Student> students;
        private int studentsCount;
        private CommentS classComments;
        private string classId;

        public Class(string classId, int teachersCount = 0, int studentsCount = 0)
        {
            this.ClassId = classId;
            this.teachersCount = teachersCount;
            this.studentsCount = studentsCount;
            this.ClassComments = new CommentS();
            this.teachers = new List<Teacher>(teachersCount);
            this.students = new List<Student>(studentsCount);
        }

        public string ClassId
        {
            get
            {
                return this.classId;
            }
            set
            {
                this.classId = value;
            }
        }

        public int StudentsCount
        {
            get
            {
                return this.studentsCount;
            }
            set
            {
                this.studentsCount = value;
            }
        }

        public int TeachersCount
        {
            get
            {
                return this.teachersCount;
            }
            set
            {
                this.teachersCount = value;
            }
        }

        public CommentS ClassComments
        {
            get
            {
                return this.classComments;
            }
            set
            {
                this.classComments = value;
            }
        }

        public List<Student> Students
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

        public List<Teacher> Teachers
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

        public CommentS CommentS
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void AddComment(string comment)
        {
            this.ClassComments.AddComment(comment);
        }

        public void AddStudent(Student student)
        {
            this.StudentsCount++;
            this.Students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.TeachersCount++;
            this.Teachers.Add(teacher);
        }

        public override string ToString()
        {
            StringBuilder classToString = new StringBuilder();

            classToString.AppendLine("=========================");

            classToString.AppendLine(this.ClassId.ToString());

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

            classToString.AppendLine("comments");
            if (this.ClassComments.HasComments())
            {
                classToString.AppendLine(ClassComments.ToString());
            }
            classToString.AppendLine("=========================");
            return classToString.ToString();
        }
    }
}