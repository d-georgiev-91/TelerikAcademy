using System;
using System.Linq;

namespace SomeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoGallery.ViewModels.AlbumsViewModel models = new PhotoGallery.ViewModels.AlbumsViewModel();

            var albums = models.Albums.ToList();
            foreach (var album in albums)
            {
                Console.WriteLine(album.Name);

                foreach (var image in album.Images)
                {
                    Console.WriteLine(image.ImagePath);
                }
            }
        }
    }
}
