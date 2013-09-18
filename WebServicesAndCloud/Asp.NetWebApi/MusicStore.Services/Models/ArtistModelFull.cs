using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MusicStore.Data;

namespace MusicStore.Services.Models
{
    public class ArtistModelFull : ArtistModel
    {
        public static Expression<Func<Artist, ArtistModelFull>> FromArtist
        {
            get
            {
                return a => new ArtistModelFull()
                {
                    Id = a.ArtistId,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth,
                    Songs = a.Songs.AsQueryable().Select(SongModel.FromSong).AsEnumerable<SongModel>(),
                    Albums = a.Albums.AsQueryable().Select(AlbumModel.FromAlbum).AsEnumerable<AlbumModel>(),
                };
            }
        }

        public Artist CreateArtist()
        {
            var artist = base.CreateArtist();

            CreateOrAddNewAlbum(artist);
            AddNewSong(artist);

            foreach (var song in Songs)
            {
                artist.Songs.Add(new Song()
                {
                    Title = song.Title,
                    Genre = song.Genre,
                    Year = song.Year,
                });
            }

            return artist;
        }

        private void CreateOrAddNewAlbum(Artist artist)
        {
            var musicStoreEntities = new MusicStoreEntities();

            foreach (var currentAlbum in this.Albums)
            {
                Album newAlbum = musicStoreEntities.Albums.Where(a => a.Title == currentAlbum.Title).FirstOrDefault();

                if (newAlbum == null)
                {
                    newAlbum = new Album()
                    {
                        Title = currentAlbum.Title,
                        Year = currentAlbum.Year
                    };
                }

                artist.Albums.Add(newAlbum);
            }
        }

        private void AddNewSong(Artist artist)
        {
            foreach (var currentSong in this.Songs)
            {
                Song newSong = new Song()
                {
                    Title = currentSong.Title,
                    Year = currentSong.Year,
                    Genre = currentSong.Genre
                };

                artist.Songs.Add(newSong);
            }
        }
        
        public IEnumerable<AlbumModel> Albums { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}