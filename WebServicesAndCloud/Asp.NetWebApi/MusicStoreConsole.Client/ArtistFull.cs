namespace MusicStoreConsole.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ArtistFull : Artist
    {
        public ArtistFull(int id, string name, DateTime dateOfBirth, IEnumerable<Album> albums, IEnumerable<Song> songs)
            : base(id, name, dateOfBirth)
        {
            this.Albums = albums;
            this.Songs = songs;
        }

        public override string ToString()
        {
            var artistAstring = new StringBuilder();

            artistAstring.Append(base.ToString());

            artistAstring.Append("\nAlbums: ");

            if (this.Albums == null || this.Albums.Count() == 0)
            {
                artistAstring.Append("None");
            }
            else
            {
                artistAstring.AppendLine();
                foreach (var album in this.Albums)
                {
                    artistAstring.AppendLine("\t" + album.ToString());
                }
            }

            artistAstring.Append("Songs: ");

            if (this.Songs == null || this.Songs.Count() == 0)
            {
                artistAstring.Append("None");
            }
            else
            {
                artistAstring.AppendLine();

                foreach (var song in this.Songs)
                {
                    artistAstring.AppendLine("\t" + song.ToString());
                }
            }

            return artistAstring.ToString();
        }

        public IEnumerable<Album> Albums { get; set; }

        public IEnumerable<Song> Songs { get; set; }
    }
}