namespace PhonesStoresSystem.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class PhoneStoresContext
    {
        public ObservableCollection<StoreViewModel> stores = new ObservableCollection<StoreViewModel>();

        public PhoneStoresContext()
        {
            var technopolisStore = new StoreViewModel()
            {
                Name = "Technopolis",
                Phones = GetPhonesForTechnopolis(),
            };

            this.stores.Add(technopolisStore);

            var technomarketStore = new StoreViewModel()
            {
                Name = "TechnoMarket",
                Phones = GetPhonesForTechnomarket(),
            };

            this.stores.Add(technomarketStore);
        }

        public ObservableCollection<StoreViewModel> Stores
        {
            get
            {
                return this.stores;
            }
            set
            {
                this.stores = value;
            }
        }

        private static IEnumerable<PhoneViewModel> GetPhonesForTechnomarket()
        {
            ObservableCollection<PhoneViewModel> phones = new ObservableCollection<PhoneViewModel>();

            phones.Add(new PhoneViewModel()
            {
                Model = "Galaxy S4",
                Os = new OperatingSystemViewModel()
                {
                    Name = "Android",
                    Manufacturer = "Google",
                    Version = "Jelly Bean"
                },
                Vendor = "Samsung",
                Year = 2013
            });

            phones.Add(new PhoneViewModel()
            {
                Model = "WindowsPhone 8X",
                Os = new OperatingSystemViewModel()
                {
                    Name = "WindowsPhone",
                    Manufacturer = "Microsoft",
                    Version = "8"
                },
                Vendor = "HTC",
                Year = 2013
            });

            phones.Add(new PhoneViewModel()
            {
                Model = "iPhone 5",
                Os = new OperatingSystemViewModel()
                {
                    Name = "iOs",
                    Manufacturer = "Apple",
                    Version = "6"
                },
                Vendor = "Apple",
                Year = 2012
            });

            return phones;
        }

        private static IEnumerable<PhoneViewModel> GetPhonesForTechnopolis()
        {
            ObservableCollection<PhoneViewModel> phones = new ObservableCollection<PhoneViewModel>();

            phones.Add(new PhoneViewModel()
            {
                Model = "Nexus",
                Os = new OperatingSystemViewModel()
                {
                    Name = "Android",
                    Manufacturer = "Google",
                    Version = "Jelly Bean"
                },
                Vendor = "Samsung",
                Year = 2014,
                Features = new FeaturesViewModel()
                {
                    _3G = "Unknown",
                    Bluetooth = "Unknown",
                    DisplayResolution = 3.5,
                    DisplayType = "LED",
                    Hdd = "255GB",
                    Processor = "ARM",
                    Radio = "None",
                    Ram = "1GB",
                    ScreenProtection = "GorillaGlass",
                    Size = 42.4,
                    Weight = 100,
                    WiFi = "Fast"
                }
            });

            phones.Add(new PhoneViewModel()
            {
                Model = "Lumia 920",
                Os = new OperatingSystemViewModel()
                {
                    Name = "WindowsPhone",
                    Manufacturer = "Microsoft",
                    Version = "Jelly Bean"
                },
                Vendor = "Nokia",
                Year = 2013,
                Features = new FeaturesViewModel()
                {
                    _3G = "Unknown",
                    Bluetooth = "Unknown",
                    DisplayResolution = 3.5,
                    DisplayType = "LED",
                    Hdd = "255GB",
                    Processor = "ARM",
                    Radio = "None",
                    Ram = "1GB",
                    ScreenProtection = "GorillaGlass",
                    Size = 42.4,
                    Weight = 100,
                    WiFi = "Fast"
                }
            });

            phones.Add(new PhoneViewModel()
            {
                Model = "WindowsPhone 8X",
                Os = new OperatingSystemViewModel()
                {
                    Name = "WindowsPhone",
                    Manufacturer = "Microsoft",
                    Version = "8"
                },
                Vendor = "Nokia",
                Year = 2013,
                Features = new FeaturesViewModel()
                {
                    _3G = "Unknown",
                    Bluetooth = "Unknown",
                    DisplayResolution = 3.5,
                    DisplayType = "LED",
                    Hdd = "255GB",
                    Processor = "ARM",
                    Radio = "None",
                    Ram = "1GB",
                    ScreenProtection = "GorillaGlass",
                    Size = 42.4,
                    Weight = 100,
                    WiFi = "Fast"
                }
            });

            phones.Add(new PhoneViewModel()
            {
                Model = "Q10",
                Os = new OperatingSystemViewModel()
                {
                    Name = "BlackBerry OS",
                    Manufacturer = "BlackBerry",
                    Version = "10"
                },
                Vendor = "BlackBerry",
                Year = 2014,
                Features = new FeaturesViewModel()
                {
                    _3G = "Unknown",
                    Bluetooth = "Unknown",
                    DisplayResolution = 3.5,
                    DisplayType = "LED",
                    Hdd = "255GB",
                    Processor = "ARM",
                    Radio = "None",
                    Ram = "1GB",
                    ScreenProtection = "GorillaGlass",
                    Size = 42.4,
                    Weight = 100,
                    WiFi = "Fast"
                }
            });

            return phones;
        }

        internal void AddStore(StoreViewModel storeViewModel)
        {
            this.stores.Add(storeViewModel);
        }

        internal void AddPhoneToStore(StoreViewModel storeViewModel, PhoneViewModel phoneViewModel)
        {
            var store = this.stores.Where(s => s.Name == storeViewModel.Name).FirstOrDefault();
            ObservableCollection<PhoneViewModel> phones = new ObservableCollection<PhoneViewModel>();

            foreach (var phone in store.Phones)
            {
                phones.Add(phone);
            }

            phones.Add(phoneViewModel);

            store.Phones = phones;
        }
    }
}