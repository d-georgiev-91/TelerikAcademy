namespace MusicStore.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using MusicStore.Data;

    [DataContract(IsReference = true)]
    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel()
                {
                    Id = a.AlbumId,
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer
                };
            }
        }

        public Album CreateAlbum()
        {
            return new Album
            {
                Title = this.Title,
                Year = this.Year,
                Producer = Producer
            };
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "producer", EmitDefaultValue = false)]
        public string Producer { get; set; }

        public void UpdateAlbum(Album album)
        {
            if (album.Title != null)
            {
                album.Title = this.Title;
            }

            if (album.Year != 0)
            {
                album.Year = this.Year;
            }
        }
    }
}