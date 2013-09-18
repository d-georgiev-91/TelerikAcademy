var canvas = document.getElementById("main-canvas");
var ctx = canvas.getContext("2d");

function DrawBicycle() {
	ctx.strokeStyle = "38889c";
	DrawWheel(216, 652, 67);
	DrawWheel(458, 652, 67);
	DrawGear(327, 648, 15);
}

function DrawWheel(x, y, radius) {
	ctx.lineWidth = 4;
	DrawCircle(x, y, radius, "90cad7");
}

function DrawGear(x, y, radius) {
	ctx.lineWidth = 2;
	ctx.beginPath();
	ctx.moveTo(316, 637);
    ctx.lineTo(302, 623);
    ctx.stroke();
	DrawCircle(x, y, radius, "white");
}

function DrawCircle(x, y, radius, fillColor) {
	ctx.beginPath();
	ctx.fillStyle = fillColor;
	ctx.arc(x , y, radius, 0, 2 * Math.PI, false);
	ctx.stroke();
	ctx.fill();
}