namespace Countries.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Data;

    public class CountriesViewModel
    {
        public string CountriesDocumentPath { get; set; }

        public CountriesViewModel()
        {
            this.CountriesDocumentPath = "..\\..\\..\\Countries.ViewModels\\countries.xml";
        }

        private IEnumerable<CountryViewModel> countriesViewModel;
        
        public IEnumerable<CountryViewModel> Countries
        {
            get
            {
                if (this.countriesViewModel == null)
                {
                    this.countriesViewModel = DataPersister.GetContriesFromXml(this.CountriesDocumentPath);
                }

                return this.countriesViewModel;
            }
        }

        public void PrevCountry() 
        {
            var countriesCollectionView = this.GetDefaultView(this.countriesViewModel);
            countriesCollectionView.MoveCurrentToPrevious();

            if (countriesCollectionView.IsCurrentBeforeFirst)
            {
                countriesCollectionView.MoveCurrentToLast();
            }
        }

        public void NextCountry()
        {
            var countriesCollectionView = this.GetDefaultView(this.countriesViewModel);
            countriesCollectionView.MoveCurrentToNext();

            if (countriesCollectionView.IsCurrentAfterLast)
            {
                countriesCollectionView.MoveCurrentToFirst();
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }
    }
}
