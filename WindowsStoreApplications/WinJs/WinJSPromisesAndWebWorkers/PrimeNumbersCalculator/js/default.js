/// <reference path="prime-numbers-calculator.js" />
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;

    app.onactivated = function (args) {
        var primeNumberCalculator = new PrimeNumbersCalculator.PrimeNumbersCalculator();
        calculatePrimesTo(primeNumberCalculator);
        calculateFirstNPrimesTo(primeNumberCalculator);
        calculatePrimesFromTo(primeNumberCalculator);
    };

    function calculatePrimesTo(primeNumberCalculator) {
        var calculateButton = document.getElementById("btn-calculate-prime-numbers-to");

        var number = document.getElementById("all-to-number");

        calculateButton.addEventListener("click", function () {
            primeNumberCalculator.calculate(undefined, number.value).then(function (primes) {
                document.getElementById("calculate-prime-numbers-to-result").innerText = primes.join(", ");
            }, function (error) {
                document.getElementById("error-handler").innerText = error;
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
                document.getElementById("error-handler").innerText = error;
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
                document.getElementById("error-handler").innerText = error;
            });
        }, false);
    }

    app.start();
})();
