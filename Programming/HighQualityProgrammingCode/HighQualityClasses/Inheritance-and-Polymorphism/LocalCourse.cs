using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public string Lab
        {
            get
            {
                return lab;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid lab name! Lab name should be non-empty string.");
                }
                else
                {
                    this.lab = value;
                }
            }
        }
        
        public LocalCourse(string courseName, string lab) 
            : this(courseName, null, null, lab)
        {
            this.CourseName = courseName;
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, string lab) 
            : this(courseName, teacherName, null, lab)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { ");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}