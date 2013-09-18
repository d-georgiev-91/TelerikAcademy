using System;
using System.Text;

namespace SchoolSimulation
{
    public class Student : Person, ICommentable
    {
        private int uniqueClassNumber;
        private CommentS studentComments;

        public Student(string name, int uniqueClassNumber)
            : base(name)
        {
            this.uniqueClassNumber = uniqueClassNumber;
            studentComments = new CommentS();
        }

        public CommentS StudentComments
        {
            get
            {
                return this.studentComments;
            }
            set
            {
                this.studentComments = value;
            }
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
            this.studentComments.AddComment(comment);
        }

        public override string ToString()
        {
            StringBuilder printableStudent = new StringBuilder();
            printableStudent.AppendLine("Student");
            printableStudent.AppendLine(this.Name);
            printableStudent.AppendLine("Unique class number");
            printableStudent.AppendLine(this.UniqueClassNumber.ToString());
            if (this.StudentComments.HasComments())
            {
                printableStudent.AppendLine(StudentComments.ToString());
            }
            return printableStudent.ToString();
        }
    }
}