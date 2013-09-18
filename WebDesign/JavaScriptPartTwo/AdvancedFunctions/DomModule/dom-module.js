var domModule = (function() {

    var fragmentsBuffer = {};
    var MAX_FRAGMENT_SIZE = 100;

    function appendChild(child, parentSelector) {
        document.querySelector(parentSelector).appendChild(child);
    }

    function removeChild(parentSelector, childSelector) {
        var child = document.querySelector(childSelector);
        document.querySelector(parentSelector).removeChild(child);
    }

    function addHandler(elementSelector, eventType, eventHandler) {
        document.querySelector(elementSelector).addEventListener(eventType, eventHandler, false);
    }

    function appendToBuffer(parentSelector, frament) {
        if (!fragmentsBuffer[parentSelector]) {
            fragmentsBuffer[parentSelector] = [];
        }
        fragmentsBuffer[parentSelector].push(frament);

        if (fragmentsBuffer[parentSelector].length == MAX_FRAGMENT_SIZE) {
            for (var i = 0; i < MAX_FRAGMENT_SIZE; i++) {
                domModule.appendChild(fragmentsBuffer[parentSelector][i], parentSelector);
            }
            delete fragmentsBuffer[parentSelector];
        }
    }

    function getElementsByCssSelector(selector) {
        var elements = document.querySelectorAll(selector);
        return elements;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };
})();