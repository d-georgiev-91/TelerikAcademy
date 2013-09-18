using System;
using System.Text;

namespace SchoolSimulation
{
    public class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private CommentS disciplineComments;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            disciplineComments = new CommentS();
        }

        public CommentS DisciplineComments
        {
            get
            {
                return this.disciplineComments;
            }
            set
            {
                this.disciplineComments = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {

                this.numberOfExercises = value;

            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                this.numberOfLectures = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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
            this.disciplineComments.AddComment(comment);
        }

        public override string ToString()
        {
            StringBuilder printableDiscipline = new StringBuilder();
            printableDiscipline.AppendLine("\nDiscipline");
            printableDiscipline.AppendLine(this.Name);
            printableDiscipline.AppendLine("Number of lectures");
            printableDiscipline.AppendLine(this.NumberOfLectures.ToString());
            printableDiscipline.AppendLine("Number of exercises");
            printableDiscipline.AppendLine(this.NumberOfExercises.ToString());

            if (this.DisciplineComments.HasComments())
            {
                printableDiscipline.AppendLine("Comments for the disciplne");
                printableDiscipline.AppendLine(disciplineComments.ToString());    
            }
            return printableDiscipline.ToString();
        }
    }
}