using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSimulation
{
    public class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = new List<string>();
        }

        public ICollection<string> Comments { get; set; }

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

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
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

            if (this.Comments.Count > 0)
            {
                printableDiscipline.AppendLine("Comments");
            
                foreach (var comment in this.Comments)
                {
                    printableDiscipline.AppendLine(comment);
                }
            }

            return printableDiscipline.ToString();
        }
    }
}