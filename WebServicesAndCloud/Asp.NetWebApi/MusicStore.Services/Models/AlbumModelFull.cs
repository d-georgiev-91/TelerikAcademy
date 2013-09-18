namespace MusicStore.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using MusicStore.Data;

    [DataContract(IsReference = true)]
    public class AlbumModelFull : AlbumModel
    {
        public Album CreateAlbum()
        {
            var album = base.CreateAlbum();
            CreateOrAddNewArtist(album);
            CreateOrAddNewSong(album);

            return album;
        }

        private void CreateOrAddNewArtist(Album album)
        {
            var musicStoreEntities = new MusicStoreEntities();

            foreach (var currentArtist in this.Artists)
            {
                Artist newArtist = musicStoreEntities.Artists.Where(a => a.Name == currentArtist.Name).FirstOrDefault();

                if (newArtist == null)
                {
                    newArtist = new Artist()
                    {
                        Name = currentArtist.Name,
                        DateOfBirth = currentArtist.DateOfBirth
                    };
                }

                album.Artists.Add(newArtist);
            }
        }

        private void CreateOrAddNewSong(Album album)
        {
            foreach (var currentSong in this.Songs)
            {
                Song newSong = new Song()
                {
                    Title = currentSong.Title,
                    Year = currentSong.Year,
                    Genre = currentSong.Genre
                };

                album.Songs.Add(newSong);
            }
        }

        public static Expression<Func<Album, AlbumModelFull>> FromAlbum
        {
            get
            {
                return a => new AlbumModelFull()
                {
                    Id = a.AlbumId,
                    Title = a.Title,
                    Year = a.Year,
                    Songs = a.Songs.AsQueryable().Select(SongModel.FromSong).AsEnumerable<SongModel>(),
                    Artists = a.Artists.AsQueryable().Select(ArtistModel.FromArtist).AsEnumerable<ArtistModel>()
                };
            }
        }

        [DataMember]
        public IEnumerable<ArtistModel> Artists { get; set; }

        [DataMember]
        public IEnumerable<SongModel> Songs { get; set; }
    }
}