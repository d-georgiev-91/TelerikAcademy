/// <reference path="repeater-control.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    var computersList = [];
    var repeater;

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }

            WinJS.UI.processAll().then(function () {
                //args.setPromise(WinJS.UI.processAll());

                var localFolder = Windows.Storage.ApplicationData.current.localFolder;

                localFolder.getFileAsync("computers.json").then(function (file) {
                    if (file) {

                        Windows.Storage.FileIO.readTextAsync(file).then(function (text) {
                            if (text != "") {
                                computersList = JSON.parse(text);
                                bindData();
                            }
                        }).then(function () {
                            initializeRepeater();
                        });
                    }
                }, function () {
                    initializeRepeater();
                })
            }).done();

            var storeComputerButton = document.getElementById("store-computer");
            storeComputerButton.addEventListener("click", function () {
                var name = document.getElementById("computer-name").value;
                var price = parseFloat(document.getElementById("computer-price").value);
                var processorName = document.getElementById("processor-name").value;
                var processorFrequencyGHz = parseFloat(document.getElementById("processor-freq").value);

                repeater.addNewItem(Data.getComputer(name, price, processorName, processorFrequencyGHz));
            });
        }
    };

    app.oncheckpoint = function (args) {
        saveData();
    };

    function bindData() {
        for (var i = 0; i < computersList.length; i++) {
            var computerName = computersList[i].name;
            var computerPrice = computersList[i].price;
            var processorName = computersList[i].processor.modelName;
            var processorFrequency = computersList[i].processor.frequencyGHz;
            var computerRate = computersList[i].rate;
            if (computerRate) {
                computersList[i] = Data.getComputer(computerName, computerPrice, processorName, processorFrequency, computerRate);
            } else {
                computersList[i] = Data.getComputer(computerName, computerPrice, processorName, processorFrequency);
            }
        }
    }

    function initializeRepeater() {
        var repeaterHolder = document.getElementById("repeater");
        repeater = new Controls.Repeater(repeaterHolder, computersList, "/templates/computer-template.html");
        repeater.render();
    }

    function saveData() {
        for (var i = 0; i < computersList.length; i++) {
            computersList[i] = computersList[i]._backingData;
        }

        var computersListJSON = JSON.stringify(computersList);
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
