namespace CountriesNavigationWithoutListControls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using Countries.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = this.GetDataContext();
        }

        public void OnNextTownButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            var currentCountry = CollectionViewSource.GetDefaultView(dataContext.Countries).CurrentItem as CountryViewModel;
            currentCountry.NextTown();
        }

        public void OnPrevTownButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            var currentCountry = CollectionViewSource.GetDefaultView(dataContext.Countries).CurrentItem as CountryViewModel;
            currentCountry.PrevTown();
        }

        public void OnNextCountryButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.NextCountry();
        }

        public void OnPrevCountryButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.PrevCountry();
        }

        private CountriesViewModel GetDataContext()
        {
            var dataContext = this.DataContext;

            return dataContext as CountriesViewModel;
        }
    }
}
