using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSimulation
{
    public class CommentS : ICommentable
    {
        private List<string> comments;

        public CommentS()
        {
            this.Comments = new List<string>();
        }

        private List<string> Comments 
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public override string ToString()
        {
            StringBuilder commentsToString = new StringBuilder();
            int linesOfComments = 1;
            foreach (var comment in comments)
            {
                commentsToString.AppendFormat("\n#{0} {1}\n", linesOfComments, comment);
                linesOfComments++;
            }
            return commentsToString.ToString();
        }

        public bool HasComments()
        {
            return this.Comments != null;
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }
    }
}
