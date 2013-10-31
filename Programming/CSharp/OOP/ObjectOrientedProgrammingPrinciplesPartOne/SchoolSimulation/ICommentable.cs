namespace SchoolSimulation
{
    using System.Collections.Generic;

    public interface ICommentable
    {
        ICollection<string> Comments { get; set; }

        void AddComment(string comment);
    }
}