namespace SchoolSimulation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Student : Person, ICommentable
    {
        private int uniqueClassNumber;

        public Student(string name, int uniqueClassNumber) : base(name)
        {
            this.uniqueClassNumber = uniqueClassNumber;
            this.Comments = new List<string>();
        }

        public ICollection<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public int UniqueClassNumber
        {
            get
            {
                return this.uniqueClassNumber;
            }
            set
            {
                this.uniqueClassNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder printableStudent = new StringBuilder();
            printableStudent.AppendLine("Student");
            printableStudent.AppendLine(this.Name);
            printableStudent.AppendLine("Unique class number");
            printableStudent.AppendLine(this.UniqueClassNumber.ToString());

            if (this.Comments.Count > 0)
            {
                printableStudent.AppendLine("Comments");

                foreach (var comment in this.Comments)
                {
                    printableStudent.AppendLine(comment);
                }
            }

            return printableStudent.ToString();
        }
    }
}