namespace PhonesStoresSystem.ViewModels
{
    using System;
    using System.Linq;

    public class PhoneViewModel
    {
        public string Vendor { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public OperatingSystemViewModel Os { get; set; }

        public FeaturesViewModel Features { get; set; }
    }
}
