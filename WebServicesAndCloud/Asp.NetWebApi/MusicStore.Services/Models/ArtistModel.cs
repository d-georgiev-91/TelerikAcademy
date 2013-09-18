namespace MusicStore.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicStore.Data;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    Id = a.ArtistId,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Artist CreateArtist()
        {
            return new Artist
            {
                Name = this.Name,
                DateOfBirth = this.DateOfBirth,
            };
        }

        public void UpdateArtist(Artist artist)
        {
            if (this.Name != null)
            {
                artist.Name = this.Name;
            }

            if (this.DateOfBirth != null && (this.DateOfBirth!= DateTime.MinValue))
            {
                artist.DateOfBirth = this.DateOfBirth;
            }
        }
    }
}