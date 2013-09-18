var slider = (function() {
    "use strict";

    var Class = (function() {
        function createClass(properties) {
            var funct = function() {
                if (this._superConstructor) {
                    this._super = new this._superConstructor(arguments);
                }
                this.init.apply(this, arguments);
            }
            for (var prop in properties) {
                funct.prototype[prop] = properties[prop];
            }
            if (!funct.prototype.init) {
                funct.prototype.init = function() {}
            }
            return funct;
        }

        Function.prototype.inherit = function(parent) {
            var oldPrototype = this.prototype;
            this.prototype = new parent();
            this.prototype._superConstructor = parent;
            for (var prop in oldPrototype) {
                this.prototype[prop] = oldPrototype[prop];
            }
        }

        return {
            create: createClass,
        };
    }());

    var Control = Class.create({
        init: function(sliderSelector, navigationSelector) {
            var self = this;

            self.contaner = $(sliderSelector);
            self.navigation = $(navigationSelector);

            self._items = self.contaner.find("li").hide();
            self._itemsLength = self._items.length;

            self._current = 0;
            $(self._items[self._current]).show();

            var sliderNavButton = $(".slider-nav");
            sliderNavButton.on('click', function() {
                self.setCurrent($(this).data('dir'));
            });

          //  self._autoChange = setTimeout(self.setCurrent, 5000);
        },

        setCurrent: function(direction) {
            var self = this


            $(self._items[self._current]).hide();
            self._current += (~~(direction === "next") || -1);
            self._current = (self._current < 0) ? self._itemsLength - 1 : self._current % self._itemsLength;
            $(self._items[self._current]).show();
            self._items;
        },
    });

    return {
        Control: Control,
    };
}());