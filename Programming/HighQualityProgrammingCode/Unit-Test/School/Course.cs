using System;
using System.Collections.Generic;

namespace School
{
    public class Course
    {
        private List<Student> students;

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value; 
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
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
                if (value.Count <= 30)
                {
                    this.students = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Student's count cannot be more than 30 for one course.");
                }
            }
        }

        public Course(string name) : this(name, new List<Student>())
        {
            
        }

        public Course(string name, List <Student> students)
        {
            this.Name = name;
            this.Students = students;
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Such student has been addeed already!");
            }
            if (this.Students.Count >= 30)
            {
                throw new InvalidOperationException("Course cannot have more than 30 students!");
            }
            if (student == null)
            {
                throw new InvalidOperationException("Student cannot be null!");
            }
            else
            {
                this.Students.Add(student);
            }
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
                throw new InvalidOperationException("No such student in course!");
            }
        }
    }
}