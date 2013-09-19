namespace PhotoGallery.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Linq;

    public class ImageViewModel
    {
        public string ImagePath { get; set; }

        public static Expression<Func<XElement, ImageViewModel>> FromXElement
        {
            get
            {
                return e =>
                    new ImageViewModel()
                    {
                        ImagePath = e.Value
                    };
            }
        }
    }
}
