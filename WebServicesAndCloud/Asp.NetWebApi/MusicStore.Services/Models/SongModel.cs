namespace MusicStore.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicStore.Data;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel()
                {
                    Id = s.SongId,
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                };
            }
        }

        public Song CreateSong()
        {
            return new Song
            {
                Title = this.Title,
                Year = this.Year,
                Genre = this.Genre,
            };
        }

        public void UpdateSong(Song song)
        {
            if (this.Title != null)
            {
                song.Title = this.Title;
            }

            if (this.Year != 0)
            {
                song.Year = this.Year;
            }

            if (this.Genre != null)
            {
                song.Genre = this.Genre;
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
    }
}
