namespace MusicStore.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicStore.Data;

    public class SongModelFull : SongModel
    {
        public static Expression<Func<Song, SongModelFull>> FromSong
        {
            get
            {
                return s => new SongModelFull()
                {
                    Id = s.SongId,
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    Album = (s.Album == null ? new AlbumModel()
                    {
                        Id = 0,
                        Producer = null,
                        Title = null,
                        Year = 1
                    }
                    : new AlbumModel()
                    {
                        Id = s.Album.AlbumId,
                        Producer = s.Album.Producer,
                        Title = s.Album.Title,
                        Year = s.Album.Year
                    }),
                    Artists = s.Artists.AsQueryable().Select(ArtistModel.FromArtist).AsEnumerable<ArtistModel>(),
                };
            }
        }

        public Song CreateSong()
        {
            var song = base.CreateSong();
            var musicStoreEntities = new MusicStoreEntities();
            CreateOrLoadNewAlbum(musicStoreEntities, song);
            CreateOrAddNewArtist(musicStoreEntities, song);

            return song;
        }
  
        private void CreateOrLoadNewAlbum(MusicStoreEntities musicStoreEntities, Song song)
        {
            Album album = musicStoreEntities.Albums.Where(a => a.Title == this.Album.Title).FirstOrDefault();
              
            if (album == null)
            {
                album = new Album()
                {
                    Title = this.Album.Title,
                    Year = this.Album.Year,
                };
            }
              
            song.Album = album;
        }
  
        private void CreateOrAddNewArtist(MusicStoreEntities musicStoreEntities, Song song)
        {
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
                  
                song.Artists.Add(newArtist);
            }
        }

        public IEnumerable<ArtistModel> Artists { get; set; }

        public AlbumModel Album { get; set; }
    }
}