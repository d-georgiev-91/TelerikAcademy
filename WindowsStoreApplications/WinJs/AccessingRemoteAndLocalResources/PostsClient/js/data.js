/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
(function () {
    'use strict';

    var observablePosts = WinJS.Binding.List([{}]);

    WinJS.Namespace.define("Data", {
        posts: observablePosts
    });
})();