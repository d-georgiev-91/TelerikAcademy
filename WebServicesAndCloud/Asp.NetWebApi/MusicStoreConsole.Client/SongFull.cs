namespace MusicStoreConsole.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SongFull : Song
    {
        public SongFull(int id, string title, int year, string genre, Album album, IEnumerable<Artist> artists) : base(id, title, year, genre)
        {
            this.Album = album;
            this.Artists = artists;
        }

        public override string ToString()
        {
            var songAsString = new StringBuilder();

            songAsString.Append(base.ToString());

            songAsString.AppendLine("\n");

            songAsString.Append("Album: ");

            if (this.Album.Id == 0)
            {
                songAsString.Append("None");
            }
            else
            {
                songAsString.AppendLine();
                
                songAsString.AppendLine("\t" + this.Album);
            }

            songAsString.Append("\nArtists: ");

            if (this.Artists == null || this.Artists.Count() == 0)
            {
                songAsString.AppendLine("None");
            }
            else
            {
                songAsString.AppendLine();
                foreach (var artist in this.Artists)
                {
                    songAsString.AppendLine("\t" + artist.ToString());
                }
            }

            return songAsString.ToString();
        }

        public Album Album { get; set; }

        public IEnumerable<Artist> Artists { get; set; }
    }
}