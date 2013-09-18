// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        var primeNumberCalculator;
        if (args.detail.kind === activation.ActivationKind.launch) {
            args.setPromise(WinJS.UI.processAll());
            var localSettings = Windows.Storage.ApplicationData.current.localSettings;
            var maxWorkersCount = localSettings.values['maxWorkersCount'];
            try {
                primeNumberCalculator = new PrimeNumbersCalculator.PrimeNumbersCalculator(maxWorkersCount);
                calculatePrimesTo(primeNumberCalculator);
                calculateFirstNPrimesTo(primeNumberCalculator);
                calculatePrimesFromTo(primeNumberCalculator);
            } catch (error) {
                showError(error);
            }
        }

        var setWorkersCountButton = document.getElementById("workers-count-btn");
        setWorkersCountButton.addEventListener("click", function () {
            var workersCountField = document.getElementById("workers-count");
            var maxWorkersCount = parseInt(workersCountField.value);
            var localSettings = Windows.Storage.ApplicationData.current.localSettings;
            localSettings.values['maxWorkersCount'] = maxWorkersCount;

            if (primeNumberCalculator) {
                try {
                    primeNumberCalculator.maxWorkersCount = maxWorkersCount;
                } catch (error) {
                    showError(error);
                }
            }
        });
    };

    function calculatePrimesTo(primeNumberCalculator) {
        var calculateButton = document.getElementById("btn-calculate-prime-numbers-to");

        var number = document.getElementById("all-to-number");

        calculateButton.addEventListener("click", function () {
            primeNumberCalculator.calculate(undefined, number.value).then(function (primes) {
                document.getElementById("calculate-prime-numbers-to-result").innerText = primes.join(", ");
            }, function (error) {
                showError(error);
            });
        }, false);
    }

    function calculateFirstNPrimesTo(primeNumberCalculator) {
        var count = document.getElementById("prime-numbers-count");
        var number = document.getElementById("first-prime-number-to");
        var calculateButton = document.getElementById("btn-calculate-first-prime-numbers-to");

        calculateButton.addEventListener("click", function () {
            primeNumberCalculator.calculate(undefined, number.value, count.value).then(function (primes) {
                document.getElementById("calculate-first-prime-numbers-to-result").innerText = primes.join(", ");
            }, function (error) {
                showError(error);
            });
        }, false);
    }

    function calculatePrimesFromTo(primeNumberCalculator) {
        var fromNumber = document.getElementById("from-number");
        var toNumber = document.getElementById("to-number");
        var calculateButton = document.getElementById("btn-calculate-prime-numbers-from-to");

        calculateButton.addEventListener("click", function () {
            primeNumberCalculator.calculate(fromNumber.value, toNumber.value).then(function (primes) {
                document.getElementById("calculate-prime-numbers-from-to-result").innerText = primes.join(", ");
            }, function (error) {
                showError(error);
            });
        }, false);
    }

    function showError(error) {
        var errorHandler = document.getElementById("error-handler");
        errorHandler.innerText = error.message ? error.message : error;
        WinJS.UI.Animation.fadeIn(errorHandler);
        setTimeout(function () {
            WinJS.UI.Animation.fadeOut(errorHandler);
        }, 5000);
    }

    app.start();
})();
