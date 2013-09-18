(function () {
    var computer = {
        name: "",
        price: 0,
        processor: {
            modelName: "",
            frequencyGHz: 0
        }
    }

    var ObservableComputer = WinJS.Binding.define(computer);

    WinJS.Namespace.define("Data", {
        getComputer: function (name, price, processorName, processorGHz) {
            return new ObservableComputer({
                name: name,
                price: price,
                processor: {
                    modelName: processorName,
                    frequencyGHz: processorGHz
                }
            });
        }
    });
})();