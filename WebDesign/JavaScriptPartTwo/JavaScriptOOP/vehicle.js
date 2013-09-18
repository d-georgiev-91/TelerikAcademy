vehilcleNS = (function() {
	var AfterburnerState = Object.freeze({
		OFF: 0,
		ON: 1
	});

	var SpinDirection = Object.freeze({
		CLOCKWISE: 0,
		COUNTER_CLOCKWISE: 1
	});

	var AmphibiousMode = Object.freeze({
		LAND: 0,
		WATER: 1
	});

	Function.prototype.inherit = function(parent) {
		this.prototype = new parent();
		this.prototype.constructor = this;
	};

	Function.prototype.extend = function(parent) {
		for (var i = 1; i < arguments.length; i += 1) {
			var name = arguments[i];
			this.prototype[name] = parent.prototype[name];
		}
		return this;
	};

	/* Base class PropulsionUnit */
	PropulsionUnit = function() {};

	PropulsionUnit.prototype.produceAcceleration = function() {
		throw new Error("Method not implemented by inherit class.");
	};

	/* Inheritors of base class PropulsionUnit definition */
	Wheel = function(radius) {
		var self = this;
		self.radius = radius;
		PropulsionUnit.apply(self, arguments);
	};

	Wheel.inherit(PropulsionUnit);

	Wheel.prototype.produceAcceleration = function() {
		var acceleration = 2 * Math.PI * this.radius;
		return acceleration;
	};

	PropelingNozzle = function(power, afterburnerState) {
		var self = this;
		self.power = power;
		self.afterburnerState = afterburnerState;
		PropulsionUnit.apply(self, arguments);
	};

	PropelingNozzle.inherit(PropulsionUnit);

	PropelingNozzle.prototype.produceAcceleration = function() {
		var acceleration;
		if (this.afterburnerState === AfterburnerState.ON) {
			acceleration = this.power * 2;
		} else {
			acceleration = this.power;
		}
		return acceleration;
	};

	Propeller = function(finsCount, spinDirection) {
		var self = this;
		self.finsCount = finsCount;
		self.spinDirection = spinDirection;
		PropulsionUnit.apply(self, arguments);
	};

	Propeller.inherit(PropulsionUnit);

	Propeller.prototype.produceAcceleration = function() {
		var acceleration = 0;
		if (this.spinDirection === SpinDirection.CLOCKWISE) {
			acceleration = this.finsCount;
		} else {
			acceleration = -this.finsCount;
		}
		return acceleration;
	};

	/* Base class Vehicle */
	Vehicle = function(speed, propulsionUnits) {
		if (speed < 0) {
			throw new Error("Invalid speed! Speed cannot be negative!");
		} else {

			var self = this;
			self.speed = speed;
			self.propulsionUnits = propulsionUnits;
		}
	};
	for (var i = 0; i < Things.length; i++) {
		Things[i]
	};
	Vehicle.prototype.accelerate = function() {
		var acceleration = 0;
		if (this.propulsionUnits instanceof Array) {
			for (var propulsionUnit in this.propulsionUnits) {
				acceleration += this.propulsionUnits[propulsionUnit].produceAcceleration();
			}
		} else {
			acceleration = this.propulsionUnits.produceAcceleration();
		}
		this.speed = acceleration;
		/*Only for the demo*/
		console.log("Now I have speed => " + this.speed);
	};

	/* Inheritors of base class Vehicle definition */
	LandVehicle = function(speed, wheels) {
		if (wheels.length != 4) {
			throw new Error("Land vehicle should have four propulsion units!");
		}

		for (var wheel in wheels) {
			if (!(wheels[wheel] instanceof Wheel)) {
				throw new Error("Land vehicle's propulsion units should be wheels!");
			}
		}

		Vehicle.apply(this, arguments);
	};

	LandVehicle.inherit(Vehicle);

	AirVehicle = function(speed, propelingNozzle) {
		if (propelingNozzle.length instanceof Array) {
			throw new Error("Air vehicle should have one propulsion unit!");
		}
		if (!(propelingNozzle instanceof PropelingNozzle)) {
			throw new Error("Air vehicle's propulsion unit should be propeling nozzle!");
		}
		Vehicle.apply(this, arguments);
	};

	AirVehicle.inherit(Vehicle);

	AirVehicle.prototype.switchAfterBurnersState = function() {
		if (this.propulsionUnits.afterburnerState === AfterburnerState.OFF) {
			this.propulsionUnits.afterburnerState = AfterburnerState.ON;
		} else {
			this.propulsionUnits.afterburnerState = AfterburnerState.OFF;
		}
	};

	WaterVehicle = function(speed, propellers) {
		for (var propller in propellers) {
			if (!(propellers[propller] instanceof Propeller)) {
				throw new Error("Water vehicle's propulsion unit should be propellers!");
			}
		}
		Vehicle.apply(this, arguments);
	};

	WaterVehicle.inherit(Vehicle);

	WaterVehicle.prototype.changePropellerSpinDirection = function() {
		for (var propller in propellers) {
			if ((this.propulsionUnits[propller].spinDirection === SpinDirection.CLOCKWISE)) {
				this.propulsionUnits[propller].spinDirection = SpinDirection.ANTI_CLOCKWISE;
			} else {
				this.propulsionUnits[propller].spinDirection = SpinDirection.CLOCKWISE;
			}
		}
	};

	AmphibiousVehicle = function(speed, wheels, propellers, amphibiousMode) {
		propulsionUnits = [];

		for (var Wheel in wheels) {
			propulsionUnits.push(wheels[Wheel]);
		}

		for (var propller in propellers) {
			propulsionUnits.push(propellers[propller]);
		}

		Vehicle.call(this, speed, propulsionUnit);
		this.amphibiousMode = amphibiousMode;
	};

	AmphibiousVehicle.inherit(Vehicle);
	AmphibiousVehicle.extend(WaterVehicle, "changePropellerSpinDirection");

	AmphibiousVehicle.prototype.accelerate = function() {
		var propulsionUnit;
		if (this.amphibiousMode === AmphibiousMode.LAND) {
			for (propulsionUnit in propulsionUnits) {
				if (this.propulsionUnits[propulsionUnit] instanceof Wheel) {
					this.speed += this.propulsionUnits[propulsionUnit].produceAcceleration();
				}
			}
		} else {
			for (propulsionUnit in propulsionUnits) {
				if (this.propulsionUnits[propulsionUnit] instanceof Propeller) {
					this.speed += this.propulsionUnits[propulsionUnit].produceAcceleration();
				}
			}
		}
	};

	AmphibiousVehicle.prototype.switchMode = function() {
		if (this.amphibiousMode === AmphibiousMode.LAND) {
			this.amphibiousMode = AmphibiousMode.WATER;
		} else {
			this.amphibiousMode = AmphibiousMode.LAND;
		}
	};

	return {
		AfterburnerState : AfterburnerState,
		SpinDirection: SpinDirection,
		AmphibiousMode: AmphibiousMode,
		/*PropulsionUnit: PropulsionUnit,*/
		Wheel: Wheel,
		PropelingNozzle: PropelingNozzle,
		Propeller: Propeller,
		/*Vehicle: Vehicle,*/
		LandVehicle: LandVehicle,
		AirVehicle: AirVehicle,
		WaterVehicle: WaterVehicle,
		AmphibiousVehicle: AmphibiousVehicle
	};
}());