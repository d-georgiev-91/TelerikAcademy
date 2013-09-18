WinJS.Namespace.define("Vegetables", {
    MushroomMixin: {
        grow: function (water) {

            if (typeof water !== "number") {
                throw new Error("Amount of water must be number");
            }

            if (water <= 0) {
                throw new Error("Amount of water must be positive number");
            }

            if (this.length) {
                this.length = this.length * water;
            }

            if (this.radius) {
                this.radius = this.radius * water;
            }
        }
    }
});