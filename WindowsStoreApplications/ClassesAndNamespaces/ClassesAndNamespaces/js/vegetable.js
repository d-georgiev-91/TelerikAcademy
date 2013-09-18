/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
WinJS.Namespace.define("Vegetables", {
    Vegetable: WinJS.Class.define(function (color, isRawEatable) {
        this.color = color;
        this.isRawEatable = isRawEatable;
    }, {
        color: {
            get: function () {
                return this._color;
            },

            set: function (color) {
                if (!color) {
                    throw new Error("Color should not be empty");
                }

                this._color = color;
            },
        },

        isRawEatable: {
            get: function () {
                return this._isRawEatable;
            },

            set: function (isRawEatable) {
                if (isRawEatable !== true && isRawEatable !== false) {
                    throw new Error('"isRawEatable should be" bool type');
                }

                this._isRawEatable = isRawEatable;
            },
        },
        
        toString: function () {
            var vegetableAsString = "Color: " + this.color + "\nCan be raw eaten: " + this.isRawEatable;

            return vegetableAsString;
        }
    })
});