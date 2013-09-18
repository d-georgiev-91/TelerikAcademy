using System.Text;

namespace MusicStoreConsole.Client
{
    public class Song
    {
        public Song(int id, string title, int year, string genre)
        {
            this.Id = id;
            this.Title = title;
            this.Year = year;
            this.Genre = genre;
        }

        public override string ToString()
        {
            var songAsString = new StringBuilder();

            songAsString.AppendFormat("Id: {0}, Title: {1}, Year: {2}", this.Id, this.Title, this.Year);

            if (this.Genre != null)
            {
                songAsString.AppendFormat(", Genre: {0}", this.Genre);
            }

            return songAsString.ToString();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
    }
}
