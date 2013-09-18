function createDivs() {
    var countOfDivs = document.getElementById("count-of-divs").value;
    if (!isPositiveInteger(countOfDivs)) {
        alert("Count must be positive integer!");
        return;
    }

    clearDivsWithRandomStyles();

    for (var i = 1; i <= countOfDivs; i++) {
        document.getElementById("div-factory").appendChild(getDivWithRandomStyles());
    }

    return false;
}

function isPositiveInteger(value) {
    var isInt = (parseInt(value) == parseFloat(value));
    var isNumber = !isNaN(value);
    var isPositive = value > 0;

    return isInt && isNumber && isPositive;
}

function clearDivsWithRandomStyles() {
    var divFactory = document.getElementById("div-factory");
    while (divFactory.hasChildNodes()) {
        divFactory.removeChild(divFactory.firstChild);
    }
}

function getDivWithRandomStyles() {
    var divElement = document.createElement("div");

    divElement.style.width = getRandomArbitary(20, 100) + "px";
    divElement.style.height = getRandomArbitary(20, 100) + "px";

    divElement.style.background = getRandomColor();
    divElement.style.backgroundColor = getRandomColor();

    divElement.style.position = getRandomPosition();
    divElement.style.left = getRandomArbitary(0, 90) + '%';
    divElement.style.top = getRandomArbitary(0, 90) + '%';

    divElement.style.borderRadius = getRandomBorderRadius() + '%';
    divElement.style.borderColor = getRandomColor();
    divElement.style.borderWidth = getRandomArbitary(1, 20) + "px";
    divElement.style.borderStyle = "solid";

    divElement.style.textAlign = "center";

    divElement.appendChild(getStrongElementWithTexttDiv());

    return divElement;

}

function getRandomColor() {
    /**
     * [hex Random hexadecimal number less than FFFFF]
     * @type {[string]}
     */
    var hex = ((1 << 24) * Math.random() | 0).toString(16);
    var color = "#" + hex;
    return color;
}

function getRandomPosition() {
    var positions = {
        1: "static",
        2: "absolute",
        3: "fixed",
        4: "relative",
        5: "inherit"
    };

    var randomPostion = positions[(Math.floor(Math.random() * 5) + 1)];
    return randomPostion;
}

function getRandomArbitary(min, max) {
    return Math.random() * (max - min) + min;
}

function getRandomBorderRadius() {
    var randomBorderRadius = getRandomArbitary(1, 100);
    return randomBorderRadius;
}

function getStrongElementWithTexttDiv() {
    var strongElement = document.createElement("strong");
    strongElement.textContent = "div";
    return strongElement;
}