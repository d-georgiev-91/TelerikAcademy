/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("PrimeNumbersCalculator", {
    PrimeNumbersCalculator: WinJS.Class.define(function () {
        this._MAX_WORKERS_COUNT = 3;
        this._primeNumberWorkers = [];
        this._freePrimeNumberWorkers = [];

        for (var i = 0; i < this._MAX_WORKERS_COUNT; i++) {
            this._primeNumberWorkers[i] = new Worker("js/prime-number-worker.js");
            this._freePrimeNumberWorkers[i] = true;
        }
    }, {
        calculate: function (fromNumber, toNumber, count) {
            var currentFreeWorker = -1;

            for (var i = 0; i < this._MAX_WORKERS_COUNT; i++) {
                if (this._freePrimeNumberWorkers[i]) {
                    currentFreeWorker = i;
                    break;
                }
            }

            if (currentFreeWorker == -1) {
                return new WinJS.Promise(function (complete, error) {
                    error("Operation could not be completed at this time");
                });
            }
            else {
                var self = this;
                var primes = {};
                return new WinJS.Promise(function (complete) {
                    self._primeNumberWorkers[currentFreeWorker].onmessage = function (event) {
                        self._freePrimeNumberWorkers[currentFreeWorker] = true;
                        self._primeNumberWorkers[currentFreeWorker].onmessage = null;
                        primes = event.data;
                        complete(primes);
                    }

                    self._freePrimeNumberWorkers[currentFreeWorker] = false;
                    self._primeNumberWorkers[currentFreeWorker].postMessage({
                        fromNumber: fromNumber,
                        toNumber: toNumber,
                        count: count
                    });
                });
            }
        }
    })
});