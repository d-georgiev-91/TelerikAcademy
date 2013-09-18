namespace MusicStore.Services.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicStore.Data;
    using MusicStore.Services.Models;

    public class SongsController : ApiController
    {
        private readonly IRepository<Song> data;

        public SongsController()
        {
            this.data = new EfRepository<Song>(new MusicStoreEntities());
        }

        public SongsController(IRepository<Song> data)
        {
            this.data = data;
        }

        // GET api/songs
        public IQueryable<SongModelFull> Get()
        {
            var songs = this.data.All().Select(SongModelFull.FromSong);
            return songs;
        }

        // GET api/songs/5
        public HttpResponseMessage Get(int id)
        {
            var song = this.data.All().Where(s => s.SongId == id).Select(SongModelFull.FromSong).FirstOrDefault();

            if (song == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, song);
        }

        // POST api/songs
        public HttpResponseMessage Post([FromBody]
                                        SongModel value)
        {
            var song = value.CreateSong();

            this.data.Add(song);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + song.SongId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        // PUT api/songs/5
        public void Put(int id, [FromBody]
                        SongModel value)
        {
            var song = this.data.Get(id);
            value.UpdateSong(song);
            this.data.Update(id, song);
        }

        // DELETE api/songs/5
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}