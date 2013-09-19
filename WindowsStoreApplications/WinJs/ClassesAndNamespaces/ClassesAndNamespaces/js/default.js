/// <reference path="vegetable.js" />
/// <reference path="tomato.js" />
/// <reference path="cucumber.js" />
/// <reference path="tomato-gmo.js" />
/// <reference path="cucumber-gmo.js" />
/// <reference path="mushroom-mixin.js" />

(function () {
    "use strict";
    WinJS.Application.onactivated = function () {
        var console = new DomLogger(document.getElementById("output"));

        console.log("Some random vegetable");
        var vegetable = new Vegetables.Vegetable("zelen", true);
        console.log(vegetable);

        console.log("A tomato");
        var domat = new Vegetables.Tomato(3.5, "green");
        console.log(domat);

        console.log("A cucumber");
        var cucumber = new Vegetables.Cucumber(421.4, "yellow");
        console.log(cucumber);

        console.log("A GMO Tomato");
        var tomatoGMO = new Vegetables.TomatoGMO(10, "red");
        console.log("Before the water");
        console.log(tomatoGMO);
        tomatoGMO.grow(15);
        console.log("After the water");
        console.log(tomatoGMO);

        console.log("A GMO Cucumber");
        var cucumberGMO = new Vegetables.CucumberGMO(1, "green");
        console.log("Before the water");
        console.log(cucumberGMO);
        cucumberGMO.grow(43);
        console.log("After the water");
        console.log(cucumberGMO);
    };

    WinJS.Application.start();
})();
