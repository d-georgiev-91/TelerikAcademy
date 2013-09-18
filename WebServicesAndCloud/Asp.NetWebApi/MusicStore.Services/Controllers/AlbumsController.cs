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
    
    public class AlbumsController : ApiController
    {
        private readonly IRepository<Album> data;

        public AlbumsController()
        {
            this.data = new EfRepository<Album>(new MusicStoreEntities());
        }

        public AlbumsController(IRepository<Album> data)
        {
            this.data = data;
        }

        // GET api/albums
        public IQueryable<AlbumModelFull> Get()
        {
            var albums = this.data.All()
                             .Select(AlbumModelFull.FromAlbum);
            return albums;
        }

        // GET api/albums/5
        public HttpResponseMessage Get(int id)
        {
            var album = this.data.All().Where(s => s.AlbumId == id)
                           .Select(AlbumModelFull.FromAlbum);

            if (album == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, album);
        }

        // POST api/albums
        public HttpResponseMessage Post([FromBody]
                                        AlbumModelFull value)
        {
            var album = value.CreateAlbum();

            this.data.Add(album);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + album.AlbumId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]
                        AlbumModel value)
        {
            var album = this.data.Get(id);
            value.UpdateAlbum(album);
            this.data.Update(id, album);
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}