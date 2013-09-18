using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class School
    {
        private List<Student> students;

        private List<Course> courses;

        private List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (value != null)
                {
                    students = value;
                }
                else
                {
                    throw new ArgumentException("Student cannot be null.");
                }
            }
        }

        private List<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public School()
        {
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            if (this.Courses.Contains(course))
            {
                throw new InvalidOperationException("Such course already exsists!");
            }
            else
            {
                this.Courses.Add(course);
            }
        }

        public void RemoveCourse(Course course)
        {
            if (this.Courses == null || this.Courses.Count == 0)
            {
                throw new InvalidOperationException("Couse list is empty!");
            }

            if (this.Courses.Contains(course))
            {
                this.Courses.Remove(course);
            }
            else
            {
                throw new InvalidOperationException("No such course in school!");
            }
        }

        public void AddStudent(Student student)
        {
            if (IsStudentNumberTaken(this.Students, student))
            {
                throw new InvalidOperationException("Such student with unique number exsists!");
            }
            else
            {
                this.Students.Add(student);
            }
        }

        private bool IsStudentNumberTaken(List<Student> students, Student studentToCheckFor)
        {
            foreach (var student in students)
            {
                if (student.UniqueNumber == studentToCheckFor.UniqueNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveStudent(Student student)
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                throw new InvalidOperationException("Students list is empty!");
            }

            if (this.Students.Contains(student))
            {
                this.Students.Remove(student);
            }
            else
            {
                throw new ArgumentException("No such student in course!");
            }
        }
    }
}