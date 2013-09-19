namespace PhonesStoresSystem.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StoreViewModel
    {
        public string Name { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}