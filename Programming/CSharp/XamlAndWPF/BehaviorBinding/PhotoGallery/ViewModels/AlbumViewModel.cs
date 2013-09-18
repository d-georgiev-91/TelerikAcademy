namespace PhotoGallery.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Xml.Linq;
    using PhotoGallery.Commands;

    public class AlbumViewModel
    {
        private ICommand nextImageCommand;

        private ICommand prevImageCommand;

        private void HandleExecuteNextImageCommand(object obj)
        {
            var imagesView = CollectionViewSource.GetDefaultView(this.Images);
            imagesView.MoveCurrentToNext();

            if (imagesView.IsCurrentAfterLast)
            {
                imagesView.MoveCurrentToFirst();
            }
        }

        private void HandleExecutePrevImageCommand(object obj)
        {
            var imagesView = CollectionViewSource.GetDefaultView(this.Images);
            imagesView.MoveCurrentToPrevious();

            if (imagesView.IsCurrentBeforeFirst)
            {
                imagesView.MoveCurrentToLast();
            }
        }

        public ICommand PrevImage
        {
            get
            {
                if (this.prevImageCommand == null)
                {
                    this.prevImageCommand = new RelayCommand(this.HandleExecutePrevImageCommand);
                }

                return this.prevImageCommand;
            }
        }

        public ICommand NextImage
        {
            get
            {
                if (this.nextImageCommand == null)
                {
                    this.nextImageCommand = new RelayCommand(this.HandleExecuteNextImageCommand);
                }

                return this.nextImageCommand;
            }
        }

        public string Name { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public static Expression<Func<XElement, AlbumViewModel>> FromXElement
        {
            get
            {
                return album => 
                new AlbumViewModel()
                {
                    Name = album.Element("name").Value,
                    Images = album.Element("images")
                                  .Elements("image-path")
                                  .AsQueryable()
                                  .Select(ImageViewModel.FromXElement)
                };
            }
        }
    }
}