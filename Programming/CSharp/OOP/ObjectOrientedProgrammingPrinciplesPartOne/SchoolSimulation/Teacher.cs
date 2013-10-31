namespace SchoolSimulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : Person, ICommentable
    {
        private IList<Discipline> disciplines;

        public Teacher(string name, int disciplinesCount = 0) : base(name)
        {
            this.Disciplines = new List<Discipline>(disciplinesCount);
            this.Comments = new List<string>();
        }

        public ICollection<string> Comments { get; set; }

        public IList<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines = value;
            }
        }

        public void AddDiscipline(string name, int numberOfLectures, int numberOfExercises)
        {
            Discipline discipline = new Discipline(name, numberOfLectures, numberOfExercises);
            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(string nameOfDiscipline)
        {
            if (this.Disciplines.Count > 0)
            {
                for (int i = 0; i < this.Disciplines.Count; i++)
                {
                    if (nameOfDiscipline == Disciplines[i].Name)
                    {
                        Disciplines.Remove(Disciplines[i]);
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format("No \"{0}\" discipline found.", nameOfDiscipline));
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("No disciplines.");
            }
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            StringBuilder printableTeacher = new StringBuilder();
            printableTeacher.AppendLine("Teacher");
            printableTeacher.AppendLine(this.Name);

            foreach (Discipline discipline in this.Disciplines)
            {
                printableTeacher.AppendLine(discipline.ToString());
            }

            if (this.Comments.Count > 0)
            {
                printableTeacher.AppendLine("Comments");

                foreach (var comment in this.Comments)
                {
                    printableTeacher.AppendLine(comment);
                }
            }

            return printableTeacher.ToString();
        }
    }
}