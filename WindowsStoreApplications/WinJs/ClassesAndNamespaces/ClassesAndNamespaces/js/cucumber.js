/// <reference path="vegetable.js" />
WinJS.Namespace.define("Vegetables", {
    Cucumber: WinJS.Class.derive(Vegetables.Vegetable, function (length, color) {
        this.length = length;
        Vegetables.Vegetable.call(this, color, true);
    }, {
        length: {
            get: function () {
                return this._length;
            },

            set: function (length) {
                if (!length) {
                    throw new Error("Color should not be empty");
                }

                if (typeof length !== "number") {
                    throw new Error("Radius should be number");
                }

                if (length <= 0) {
                    throw new Error("Radius should be positive");
                }

                this._length = length;
            }
        },

        toString: function () {
            var cucumberAsString = Vegetables.Vegetable.prototype.toString.call(this);
            cucumberAsString += "\nLength: " + this.length;

            return cucumberAsString;
        }
    })
});