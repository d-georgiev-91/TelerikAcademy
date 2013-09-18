(function() {
	var canvas = document.getElementById("main-canvas");
	var ctx = canvas.getContext("2d");

	const BALL_RADIUS = 15;

	var ballStartPostition = {
		x: getRandomArbitary(BALL_RADIUS, canvas.width - BALL_RADIUS),
		y: getRandomArbitary(BALL_RADIUS, canvas.height - BALL_RADIUS)
	}

	var ballStartDirection = {
		x: randoDirection(),
		y: randoDirection()
	}

	function getRandomArbitary(min, max) {
		return (Math.random() * (max - min) + min);
	}

	function randoDirection() {
		return getRandomArbitary(0, 1) < 0.5 ? -1 : 1;
	}


	var curentBallPosition = {
		x: ballStartPostition.x,
		y: ballStartPostition.y
	}

	var ballCurrentDirection = {
		x: ballStartDirection.x,
		y: ballStartDirection.y,
	}

	function render() {
		ctx.clearRect(0, 0, canvas.width, canvas.height);
		ctx.lineWidth = 2;
		ctx.beginPath();
		ctx.fillStyle = "red";
		ctx.arc(curentBallPosition.x, curentBallPosition.y, BALL_RADIUS, 0, 2 * Math.PI, false);
		ctx.stroke();
		ctx.fill();

		var topCollision = curentBallPosition.y - BALL_RADIUS <= 0;
		var rightCollision = curentBallPosition.x + BALL_RADIUS >= canvas.width;
		var bottomCollision = curentBallPosition.y + BALL_RADIUS >= canvas.height;
		var leftCollision = curentBallPosition.x - BALL_RADIUS <= 0;

		curentBallPosition.x += 2 * ballCurrentDirection.x;
		curentBallPosition.y += 2 * ballCurrentDirection.y;

		if (topCollision) {
			ballCurrentDirection.y = 1;
		}
		if (rightCollision) {
			ballCurrentDirection.x = -1;
		}
		if (bottomCollision) {
			ballCurrentDirection.y = -1;
		}
		if (leftCollision) {
			ballCurrentDirection.x = 1;
		}
	}

	window.requestAnimFrame = (function() {
		return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || function(callback) {
			window.setTimeout(callback, 1000 / 100);
		}
	})();

	(function animloop() {
		requestAnimFrame(animloop);
		render();
	})();
}());
