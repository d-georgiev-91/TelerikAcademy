/// <reference group="Dedicated Worker" />
function calculatePrimes(fromNumber, toNumber, count) {
    var sieve = [],
        primes = [];

    var startNumber;

    if (fromNumber != 2) {
        startNumber = parseInt(fromNumber);
        fromNumber = 2;
    }
    else {
        startNumber = fromNumber;
    }

    toNumber = parseInt(toNumber);

    for (var i = fromNumber; i <= toNumber; i++) {
        if (!sieve[i]) {
            if (count && primes.length == count) {
                break;
            }

            if (i >= startNumber) {
                primes.push(i);
            }
            for (var j = i << 1; j <= toNumber; j += i) {
                sieve[j] = true;
            }
        }
    }

    return primes;
}

onmessage = function (event) {
    var fromNumber = event.data.fromNumber || 2;
    var toNumber = event.data.toNumber;
    var count = event.data.count;

    var primes = calculatePrimes(fromNumber, toNumber, count);

    postMessage(primes);
}