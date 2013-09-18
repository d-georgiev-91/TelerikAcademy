namespace MusicStoreConsole.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AlbumFull : Album
    {
        public AlbumFull(int id, string title, int year, string producer, IEnumerable<Artist> artists, IEnumerable<Song> songs)
            : base(id, title, year, producer)
        {
            this.Artists = artists;
            this.Songs = songs;
        }

        public override string ToString()
        {
            var albumAsString = new StringBuilder();

            albumAsString.Append(base.ToString());

            albumAsString.AppendLine("\n");

            albumAsString.Append("Songs: ");

            if (this.Songs == null || this.Songs.Count() == 0)
            {
                albumAsString.Append("None");
            }
            else
            {
                albumAsString.AppendLine();

                foreach (var song in this.Songs)
                {
                    albumAsString.AppendLine("\t" + song.ToString());
                }
            }

            albumAsString.Append("\nArtists: ");

            if (this.Artists == null || this.Artists.Count() == 0)
            {
                albumAsString.AppendLine("None");
            }
            else
            {
                albumAsString.AppendLine();
                foreach (var artist in this.Artists)
                {
                    albumAsString.AppendLine("\t" + artist.ToString());
                }
            }

            return albumAsString.ToString();
        }

        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}