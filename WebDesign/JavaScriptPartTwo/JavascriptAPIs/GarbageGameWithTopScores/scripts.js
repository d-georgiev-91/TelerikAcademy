var garbageCollectorGame = (function() {

	const CLOSED_BIN_IMG_SRC = "imgs/bin-close.png";
	const OPENED_BIN_IMG_SRC = "imgs/bin-open.png";
	var gameIsStarted = false;
	var startTime;
	var endTime;

	function popUpWelcomeScreen() {
		var welcomeScreen = document.createElement("div");
		welcomeScreen.id = "welcome-screen";
		welcomeScreen.style.margin = "100px auto";
		welcomeScreen.style.width = "300px";
		welcomeScreen.style.backgroundColor = "blue";
		welcomeScreen.style.position = "relative";
		welcomeScreen.style.zIndex = 100;
		welcomeScreen.style.textAlign = "center";
		welcomeScreen.style.color = "white";
		welcomeScreen.innerHTML = "<h1>Welcome to garbage cleaner!!!</h1><p style='font-size: 24px;'>Press start to start the game and run the timer.</p><a href='#' id='start'>Start</a>";
		document.body.appendChild(welcomeScreen);
		startButton = document.getElementById("start");
		startButton.addEventListener("click", startGame, false)
	}

	function startGame() {
		var welcomeScreen = document.getElementById("welcome-screen");
		welcomeScreen.style.display = "none";
		gameIsStarted = true;
		startTime = new Date();
	}

	var BIN_POSITION = Object.freeze({
		X: 300,
		Y: 300
	});
	var BIN_SIZE = Object.freeze({
		WIDTH: 134,
		HEIGHT: 220
	});


	const TRASH_IMG_SRC = "imgs/garbage.png";
	var TRASH_SIZE = Object.freeze({
		WIDTH: 46,
		HEIGHT: 37
	});

	function createBucket() {
		var bucket = document.createElement("img");
		bucket.id = "bucket";
		bucket.style.left = BIN_POSITION.X + "px";
		bucket.style.top = BIN_POSITION.Y + "px";
		bucket.style.position = "absolute";
		bucket.src = CLOSED_BIN_IMG_SRC;
		bucket.setAttribute("ondragenter", "openBucket(event)");
		bucket.setAttribute("ondragleave", "closeBucket(event)");
		bucket.setAttribute("ondrop", "drop(event)");
		bucket.setAttribute("ondragover", "allowDrop(event)");
		bucket.setAttribute("draggable", "false");
		document.body.appendChild(bucket);
	}

	function createGarbage(garbageId, atPosition) {
		var garbage = document.createElement("img");
		garbage.id = garbageId;
		garbage.className = "garbage";
		garbage.src = TRASH_IMG_SRC;
		garbage.style.position = "absolute";
		garbage.style.left = atPosition.x + "px";
		garbage.style.top = atPosition.y + "px";
		garbage.setAttribute("draggable", "true");
		garbage.setAttribute("ondragstart", "drag(event)");
		document.body.appendChild(garbage);
	}

	createGarbages = function(count) {
		for (var i = 1; i <= count; i++) {
			var garbageId = "garbage-" + i;
			var garbagePosition = getRandomCoordinates();
			createGarbage(garbageId, garbagePosition);
		}
	}

	function getRandomCoordinates() {
		do {
			randomX = getRandomArbitary(0, window.innerWidth - TRASH_SIZE.WIDTH);
			randomY = getRandomArbitary(0, window.innerHeight - TRASH_SIZE.HEIGHT);
		} while (BIN_POSITION.X - TRASH_SIZE.WIDTH <= randomX && randomX < BIN_POSITION.X + BIN_SIZE.WIDTH && 
			BIN_POSITION.Y - TRASH_SIZE.HEIGHT <= randomY && randomY < BIN_POSITION.Y + BIN_SIZE.HEIGHT );
		return {
			x: randomX, // da se opravi
			y: randomY//da se opravi
		}
	}

	function getRandomArbitary(min, max) {
		return Math.random() * (max - min) + min;
	}

	return {
		createBucket: createBucket,
		createGarbages: createGarbages,
		CLOSED_BIN_IMG_SRC: CLOSED_BIN_IMG_SRC,
		OPENED_BIN_IMG_SRC: OPENED_BIN_IMG_SRC,
		popUpWelcomeScreen: popUpWelcomeScreen
	}
}());