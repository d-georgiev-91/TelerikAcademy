var movingShapes = (function() {
	"use strict";

	var BROWSER_SAFE_FONTS = [
		/*Serif Fonts*/
		"Georgia, serif",
		"\"Palatino Linotype\", \"Book Antiqua\", Palatino, serif",
		"\"Times New Roman\", Times, serif",

		/*Sans-Serif Fonts*/
		"Arial, Helvetica, sans-serif",
		"\"Arial Black\", Gadget, sans-serif",
		"\"Comic Sans MS\", cursive, sans-serif",
		"Impact, Charcoal, sans-serif",
		"\"Lucida Sans Unicode\", \"Lucida Grande\", sans-serif",
		"Tahoma, Geneva, sans-serif",
		"\"Trebuchet MS\", Helvetica, sans-serif",
		"Verdana, Geneva, sans-serif",

		/*Monospace Fonts*/
		"\"Courier New\", Courier, monospace",
		"\"Lucida Console\", Monaco, monospace"
	];

	var SHAPE_WIDTH = 80;
	var SHAPE_HEIGHT = 80;

	var RADIUS_OF_CIRCLE_TRAJECTORY = 100;

	var WIDTH_OF_RECTANGULAR_TRAJECTORY = 200;
	var HEIGHT_OF_RECTANGULAR_TRAJECTORY = 100;

	var movingShapesToRender = {};

	function InvalidArumentException(message) {
		this.message = message;
		this.name = "InvalidArumentException";
	}

	function add(shapeMovementType) {
		switch (shapeMovementType) {
			case "rect":
				intializeDivMovingInRectangle();
				break;
			case "ellipse":
				intializeDivMovingInCircle();
				break;
			default:
				throw new InvalidArumentException("Error! The argument must be either 'rect' or 'ellipse'.");
		}
	}

	function intializeDivMovingInRectangle() {
		var	div = document.createElement("div");
		generateRandomStylesForDiv(div);

		div.className = "moving-in-rect";
		div.innerHTML = "rect";

		var trajectoryX = getRandomArbitary(0, window.innerWidth - WIDTH_OF_RECTANGULAR_TRAJECTORY - SHAPE_WIDTH);
		var trajectoryY = getRandomArbitary(0, window.innerHeight - HEIGHT_OF_RECTANGULAR_TRAJECTORY - SHAPE_HEIGHT);

		div.style.left = trajectoryX + "px";
		div.style.top = trajectoryY + "px";
		
		div.setAttribute("data-trajectory-coordinates", trajectoryX + ' ' + trajectoryY);

		div.setAttribute("data-moving-shape-coordintes", trajectoryX + ' ' + trajectoryY);

		div.setAttribute("data-clockwise", getRandomArbitary(0, 2) | 0);

		document.body.appendChild(div);
	}

	function intializeDivMovingInCircle() {
		var div = document.createElement("div");
		generateRandomStylesForDiv(div);

		div.className = "moving-in-ellipse";
		div.innerHTML = "ellipse";

		var trajectoryX = getRandomArbitary(RADIUS_OF_CIRCLE_TRAJECTORY, window.innerWidth - 2 * RADIUS_OF_CIRCLE_TRAJECTORY);
		var trajectoryY = getRandomArbitary(RADIUS_OF_CIRCLE_TRAJECTORY, window.innerHeight - 2 * RADIUS_OF_CIRCLE_TRAJECTORY);
		div.setAttribute("data-trajectory-coordinates", trajectoryX + ' ' + trajectoryY);

		div.setAttribute("data-degrees", 0);

		div.setAttribute("data-clockwise", getRandomArbitary(0, 2) | 0);

		document.body.appendChild(div);
	}

	function generateRandomStylesForDiv(div) {
		div.style.position = "absolute";

		div.style.backgroundColor = getRandomColor();
		div.style.border = "1px solid " + getRandomColor();

		div.style.fontSize = (SHAPE_HEIGHT / 4.5) + "px";
		div.style.fontFamily = getRandomFontFamily();
		/**
		 * To be sure that font color an background color don"t match.
		 */
		do {
			div.style.color = getRandomColor();
		} while (div.style.color == div.style.backgroundColor);
		div.style.textAlign = "center";
		div.style.lineHeight = SHAPE_HEIGHT + "px";

		div.style.width = SHAPE_WIDTH + "px";
		div.style.height = SHAPE_HEIGHT + "px";
	}

	function moveInRectangularTrajectory() {
		var divs = document.getElementsByClassName("moving-in-rect");
		for (var i = 0, len = divs.length; i < len; i++) {
			drawDivAtCordinates(divs[i]);
		}

		function drawDivAtCordinates(div) {
			var minX = div.getAttribute("data-trajectory-coordinates").split(" ")[0];
			var minY = div.getAttribute("data-trajectory-coordinates").split(" ")[1];

			var maxX = parseFloat(minX) + WIDTH_OF_RECTANGULAR_TRAJECTORY;
			var maxY = parseFloat(minY) + HEIGHT_OF_RECTANGULAR_TRAJECTORY;

			var divX = parseFloat(div.getAttribute("data-moving-shape-coordintes").split(" ")[0]);
			var divY = parseFloat(div.getAttribute("data-moving-shape-coordintes").split(" ")[1]);

			goAntiClockWise(div, divX, divY, minX, maxX, minY, maxY);

			if (div.getAttribute("data-clockwise") == 1) {
				goClockWise(div, divX, divY, minX, maxX, minY, maxY);
			}
			else {
				goAntiClockWise(div, divX, divY, minX, maxX, minY, maxY);
			}
		}

		function goClockWise(div, divX, divY, minX, maxX, minY, maxY) {
			//right
			if (divX <= maxX && divY == minY) {
				divX++;
			}
			//down
			if (divX == maxX && divY <= maxY) {
				divY++;
			}
			//left
			if (divX >= minX && divY == maxY) {
				divX--;
			}
			//up
			if (divX == minX && divY >= minY) {
				divY--;
			}

			div.style.left = divX + "px";
			div.style.top = divY + "px";
			div.setAttribute("data-moving-shape-coordintes", divX + " " + divY);
		}

		function goAntiClockWise(div, divX, divY, minX, maxX, minY, maxY) {
			//down
			if (divX == minX && divY <= maxY) {
				divY++;
			}
			//right
			if (divX <= maxX && divY == maxY) {
				divX++;
			}
			//up
			if (divX == maxX && divY >= minY) {
				divY--;
			}
			//left
			if (divX >= minX && divY == minY) {
				divX--;
			}

			div.style.left = divX + "px";
			div.style.top = divY + "px";
			div.setAttribute("data-moving-shape-coordintes", divX + " " + divY);
		}
	}

	function moveInCircularTrajectory() {
		var divs = document.getElementsByClassName("moving-in-ellipse");
		for (var i = 0, len = divs.length; i < len; i++) {
			drawDivAtDegrees(divs[i]);
		}

		function drawDivAtDegrees(div) {
			var trajectory = div.getAttribute("data-trajectory-coordinates").split(" ");
			var degrees = div.getAttribute("data-degrees");
			div.style.left = parseFloat(trajectory[0]) + Math.cos(degrees * Math.PI / 180) * RADIUS_OF_CIRCLE_TRAJECTORY + "px";
			div.style.top = parseFloat(trajectory[1]) + Math.sin(degrees * Math.PI / 180) * RADIUS_OF_CIRCLE_TRAJECTORY + "px";
			if (div.getAttribute("data-clockwise") == 1) {
				degrees++;
			} else {
				degrees--;
			}
			div.setAttribute("data-degrees", degrees);
		}
	}

	// Returns a hex value with starting with "#"
	function getRandomColor() {
		var hex = ((1 << 24) * Math.random() | 0).toString(16);
		var color = "#" + hex;
		return color;
	}

	function getRandomFontFamily() {
		var fontIndexInList = getRandomArbitary(0, BROWSER_SAFE_FONTS.length) | 0;
		var randomFont = BROWSER_SAFE_FONTS[fontIndexInList];
		return randomFont;
	}

	function getRandomArbitary(min, max) {
		return Math.random() * (max - min) + min;
	}

	window.requestAnimFrame = window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame;

	(function renderMovingShapes() {
		window.requestAnimFrame(renderMovingShapes);
		moveInRectangularTrajectory();
		moveInCircularTrajectory();
	})();

	return {
		add: add,
	};
})();