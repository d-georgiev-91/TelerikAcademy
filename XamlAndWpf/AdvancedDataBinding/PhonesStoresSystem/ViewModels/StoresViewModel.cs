namespace PhonesStoresSystem.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using PhonesStoresSystem.Commands;

    public class StoresViewModel : ViewModelBase
    {
        private ObservableCollection<StoreViewModel> storesViewModels;

        private ICommand addNewStoreCommand;
        private ICommand addNewPhoneCommand;

        private PhoneStoresContext dataContext;

        private StoreViewModel newStoreViewModel;

        private PhoneViewModel newPhoneViewModel;

        private StoreViewModel newPhoneStore;

        public StoresViewModel()
        {
            this.dataContext = new PhoneStoresContext();
            this.newStoreViewModel = new StoreViewModel();
            this.newPhoneViewModel = new PhoneViewModel();
            this.newPhoneStore = new StoreViewModel();
        }

        public StoreViewModel NewPhoneStore
        {
            get
            {
                return this.newPhoneStore;
            }
            set
            {
                this.newPhoneStore = value;
                this.OnPropertyChanged("NewPhoneStore");
            }
        }

        public PhoneViewModel NewPhone
        {
            get
            {
                return this.newPhoneViewModel;
            }
            set
            {
                this.newPhoneViewModel = value;
                this.OnPropertyChanged("NewPhone");
            }
        }

        public StoreViewModel NewStore
        {
            get
            {
                return this.newStoreViewModel;
            }
            set
            {
                this.newStoreViewModel = value;
                this.OnPropertyChanged("NewStore");
            }
        }

        public ICommand AddNewStore
        {
            get
            {
                if (this.addNewStoreCommand == null)
                {
                    this.addNewStoreCommand = new RelayCommand(this.HandleAddNewStoreCommand);
                }

                return this.addNewStoreCommand;
            }
        }

        public ICommand AddNewPhone
        {
            get
            {
                if (this.addNewPhoneCommand == null)
                {
                    this.addNewPhoneCommand = new RelayCommand(this.HandleAddNewPhoneCommand);
                }

                return this.addNewPhoneCommand;
            }
        }

        private void HandleAddNewPhoneCommand(object obj)
        {
            if (this.newPhoneStore != null && this.newPhoneStore.Name != null)
            {
                this.dataContext.AddPhoneToStore(this.NewPhoneStore, this.NewPhone);
                this.Stores = dataContext.Stores;
                this.NewPhone = new PhoneViewModel();
            }
        }

        private void HandleAddNewStoreCommand(object obj)
        {
            this.dataContext.AddStore(this.NewStore);
            this.Stores = dataContext.Stores;
            this.NewStore = new StoreViewModel();
        }

        public IEnumerable<StoreViewModel> Stores
        {
            get
            {
                if (this.storesViewModels == null)
                {
                    this.Stores = dataContext.Stores;
                }

                return this.storesViewModels;
            }

            set
            {
                if (this.storesViewModels == null)
                {
                    this.storesViewModels = new ObservableCollection<StoreViewModel>();
                }

                this.storesViewModels.Clear();

                foreach (var store in value)
                {
                    this.storesViewModels.Add(store);
                }
            }
        }
    }
}