using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSimulation
{
    public class Teacher : Person, ICommentable
    {
        private List<Discipline> disciplines;
        private CommentS teacherComments;
        private int disciplinesCount;

        public Teacher(string name)
            : base(name)
        {
            this.Disciplines = new List<Discipline>(this.DisciplinesCount);
            teacherComments = new CommentS();
        }

       
        public CommentS TeacherComments
        {
            get
            {
                return this.teacherComments;
            }
            set
            {
                this.teacherComments = value;
            }
        }

        public int DisciplinesCount
        {
            get
            {
                return this.disciplinesCount;
            }
            private set
            {
                this.disciplinesCount = value;
            }
        }

        public List<Discipline> Disciplines
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

        public void AddDiscipline(string name, int numberOfLectures, int numberOfExercises)
        {
            Discipline discipline = new Discipline(name, numberOfLectures, numberOfExercises);
            this.Disciplines.Add(discipline);
            this.DisciplinesCount++;
        }

        public void RemoveDiscipline(string nameOfDiscipline)
        {
            if (this.DisciplinesCount > 0)
            {
                for (int i = 0; i < DisciplinesCount; i++)
                {
                    if (nameOfDiscipline == Disciplines[i].Name)
                    {
                        Disciplines.Remove(Disciplines[i]);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("No more disciplines.");
            }
        }

        public void AddComment(string comment)
        {
            this.TeacherComments.AddComment(comment);
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
            if (this.TeacherComments.HasComments())
            {
                printableTeacher.AppendLine("Comments for the teacher");
                printableTeacher.AppendLine(this.teacherComments.ToString());
            }
            return printableTeacher.ToString();
        }
    }
}
