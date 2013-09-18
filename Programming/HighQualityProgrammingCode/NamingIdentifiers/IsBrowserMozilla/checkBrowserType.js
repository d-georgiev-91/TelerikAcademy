//Taks 3
function onClickCheckIsMozilla(e, arguments) { // Дончо каза, специално на лекция по JavaScript, че правилното именуване
                                               // за event e 'e'
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;

    var isMozilla = (browser == "Mozilla");

    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}