//(function() {
//'use strict';

function querySelectorAll(selector) {

}

function getSelctorsAsList(selectorString) {
    selectorList = [];
    var selector = '';
    for (var i = 0, len = selectorString.length; i < len; i++) {
        //alert(selectorString[i]);
        if (selectorString[i] == '.' || selectorString[i] == '#' || selectorString[i] == ' ') {
            alert("if case");
            selectorList.push(selector);
            selector = '';
        }

        selector += selectorString[i];
    }
    if (selector != '') {
        selectorList.push(selector);
    }
}
//})();