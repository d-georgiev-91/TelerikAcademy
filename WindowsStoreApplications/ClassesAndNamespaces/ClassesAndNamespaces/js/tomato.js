/// <reference path="vegetable.js" />
WinJS.Namespace.define("Vegetables", {
    Tomato: WinJS.Class.derive(Vegetables.Vegetable, function (radius, color) {
        this.radius = radius;
        Vegetables.Vegetable.call(this, color, true);
    }, {
        radius: {
            get: function () {
                return this._radius;
            },

            set: function (radius) {
                if (!radius) {
                    throw new Error("Color should not be empty");
                }

                if (typeof radius !== "number") {
                    throw new Error("Radius should be number");
                }

                if (radius <= 0) {
                    throw new Error("Radius should be positive");
                }

                this._radius = radius;
            }
        },

        toString: function () {
            var tomatoAsString = Vegetables.Vegetable.prototype.toString.call(this);

            tomatoAsString += "\nRadius: " + this.radius;

            return tomatoAsString;
        }
    })
});