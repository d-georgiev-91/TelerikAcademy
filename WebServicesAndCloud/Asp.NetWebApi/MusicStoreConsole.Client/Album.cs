namespace MusicStoreConsole.Client
{
    using System;
    using System.Linq;
    using System.Text;

    public class Album
    {
        public Album(int id, string title, int year, string producer)
        {
            this.Id = id;
            this.Title = title;
            this.Year = year;
            this.Producer = producer;
        }

        public override string ToString()
        {
            var albumAsString = new StringBuilder();

            albumAsString.AppendFormat("Id: {0}, Title: {1}, Year: {2}", this.Id, this.Title, this.Year);
            
            if (this.Producer!=null)
            {
                albumAsString.AppendFormat(", Producer: {0}", this.Producer);    
            }

            return albumAsString.ToString();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}
