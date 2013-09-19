namespace PhotoGallery.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AlbumsViewModel
    {
        public AlbumsViewModel()
        {
            this.AlbumsDocumentPath = @"D:/Projects/TelerikAcademy/Xaml/BehaviorBinding/PhotoGallery/albums.xml"; //"..\\..\\albums.xml";
        }
        
        public string AlbumsDocumentPath { get; set; }

        public IEnumerable<AlbumViewModel> Albums
        {
            get
            {
                if (this.albums == null)
                {
                    this.albums = DataPersister.GetAllAlbumsFromXml(this.AlbumsDocumentPath);
                }

                return this.albums;
            }
        }

        private IEnumerable<AlbumViewModel> albums;
    }
}