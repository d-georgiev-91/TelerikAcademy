/// <reference path="data.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {

            WinJS.UI.processAll().then(function () {
                args.setPromise(WinJS.UI.processAll());

                var localFolder = Windows.Storage.ApplicationData.current.localFolder;

                localFolder.getFileAsync("computers.json").then(function (file) {
                    if (file) {
                        Windows.Storage.FileIO.readTextAsync(file).then(function (text) {
                            if (text != "") {
                                Data.computersList = JSON.parse(text);
                                for (var i = 0; i < Data.computersList.length; i++) {
                                    var observableComputer = new WinJS.Binding.as(Data.computersList[i]);
                                    Data.observableComputersList.push(observableComputer);
                                }
                            }
                        });
                    }
                })
            }).done();

            var storeComputerButton = document.getElementById("store-computer");
            storeComputerButton.addEventListener("click", function () {
                var name = document.getElementById("computer-name").value;
                var price = parseFloat(document.getElementById("computer-price").value);
                var processorName = document.getElementById("processor-name").value;
                var processorFrequencyGHz = parseFloat(document.getElementById("processor-freq").value);
                var manufacturer = document.getElementById("computer-manufacturer").value;

                var computer = {
                    name: name,
                    price: price,
                    manufacturer: manufacturer,
                    processor: {
                        modelName: processorName,
                        frequencyGHz: processorFrequencyGHz
                    }
                }
                
                Data.computersList.push(computer);

                var observableComputer = WinJS.Binding.as(computer);
                Data.observableComputersList.push(observableComputer);
            });
        }
    };

    app.oncheckpoint = function (args) {
        saveData();
    };

    function saveData() {
        var computersListJSON = JSON.stringify(Data.computersList);
        var localFolder = Windows.Storage.ApplicationData.current.localFolder;
        localFolder.
        createFileAsync("computers.json",
                        Windows.Storage.CreationCollisionOption.replaceExisting).done(
                            function (file) {
                                Windows.Storage.FileIO.writeTextAsync(file, computersListJSON);
                            });
    }

    app.start();
})();