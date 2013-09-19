namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Data;

    public class CountryViewModel
    {
        public string Name { get; set; }

        public string Language { get; set; }

        public string NationalFlagPath { get; set; }

        public IEnumerable<TownViewModel> Towns { get; set; }

        public CountryViewModel()
        {

        }

        public void PrevTown()
        {
            var townsCollectionView = this.GetDefaultView(this.Towns);
            townsCollectionView.MoveCurrentToPrevious();

            if (townsCollectionView.IsCurrentBeforeFirst)
            {
                townsCollectionView.MoveCurrentToLast();
            }
        }

        public void NextTown()
        {
            var townsCollectionView = this.GetDefaultView(this.Towns);
            townsCollectionView.MoveCurrentToNext();

            if (townsCollectionView.IsCurrentAfterLast)
            {
                townsCollectionView.MoveCurrentToFirst();
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }
    }
}