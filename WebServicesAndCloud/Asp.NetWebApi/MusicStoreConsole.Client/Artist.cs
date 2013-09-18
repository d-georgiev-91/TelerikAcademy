namespace MusicStoreConsole.Client
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Artist
    {
        public Artist(int id, string name, DateTime dateOfBirth)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            var artistAsString = new StringBuilder();
            artistAsString.AppendFormat("Id: {0}, Name: {1}, Date of birth: {2}", this.Id, this.Name, this.DateOfBirth);
            return artistAsString.ToString();
        }
    }
}