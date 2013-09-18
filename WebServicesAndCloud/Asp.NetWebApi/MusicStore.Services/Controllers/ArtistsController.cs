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

    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> data;

        public ArtistsController()
        {
            this.data = new EfRepository<Artist>(new MusicStoreEntities());
        }

        public ArtistsController(IRepository<Artist> data)
        {
            this.data = data;
        }

        // GET api/artists
        public IQueryable<ArtistModelFull> Get()
        {
            var artists = this.data.All()
                              .Select(ArtistModelFull.FromArtist);
            return artists;
        }

        // GET api/artists/5
        public HttpResponseMessage Get(int id)
        {
            var artist = this.data.All().Where(a => a.ArtistId == id).Select(ArtistModelFull.FromArtist).FirstOrDefault();

            if (artist == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        // POST api/artists
        public HttpResponseMessage Post([FromBody]
                                        ArtistModel value)
        {
            var artist = value.CreateArtist();

            this.data.Add(artist);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + artist.ArtistId.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]
                        ArtistModel value)
        {
            var artist = this.data.Get(id);
            value.UpdateArtist(artist);
            this.data.Update(id, artist);
        }

        // DELETE api/artists/5
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}