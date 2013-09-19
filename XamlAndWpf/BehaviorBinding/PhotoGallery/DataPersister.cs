namespace PhotoGallery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Xml.Linq;
    using PhotoGallery.ViewModels;

    public class DataPersister
    {

        internal static IEnumerable<ViewModels.AlbumViewModel> GetAllAlbumsFromXml(string albumsDocumentPath)
        {
            var albumsRoot = XDocument.Load(albumsDocumentPath).Root;

            var albums = albumsRoot.Elements("album")
                .AsQueryable()
                .Select(AlbumViewModel.FromXElement);

            return albums;
        }
    }
}
