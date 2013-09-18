namespace MusicStoreConsole.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    class MusicStoreClient
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:35823/") };
        
        static void Main()
        {
            ClientWithJsonHeader();
            //ClientWithXmlHeader();
        }

        private static void ClientWithXmlHeader()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            GetAllAlbums();
            GetAllSongs();
            GetAllArtists();
        }
  
        private static void ClientWithJsonHeader()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GetAllAlbums();
            GetAllSongs();
            GetAllArtists();
        }

        private static void GetAllArtists()
        {
            HttpResponseMessage response = client.GetAsync("api/artists").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistFull>>().Result;

                foreach (var artist in artists)
                {
                    Console.WriteLine(artist);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }     

        private static void GetAllSongs()
        {
            HttpResponseMessage response = client.GetAsync("api/songs").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongFull>>().Result;

                foreach (var song in songs)
                {
                    Console.WriteLine(song);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void GetAllAlbums()
        {
            HttpResponseMessage response = client.GetAsync("api/albums").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumFull>>().Result;

                foreach (var album in albums)
                {
                    Console.WriteLine(album);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}