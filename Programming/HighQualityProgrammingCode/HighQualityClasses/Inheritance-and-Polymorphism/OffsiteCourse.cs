using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid town! Town name should be non-empty string.");
                }
                else
                {
                    this.town = value;
                }
            }
        }
        
        public OffsiteCourse(string courseName, string town)
            : this(courseName, null, null, town)
        {
            this.CourseName = courseName;
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, string town) 
            : this(courseName, teacherName, null, town)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town) 
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { ");
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}