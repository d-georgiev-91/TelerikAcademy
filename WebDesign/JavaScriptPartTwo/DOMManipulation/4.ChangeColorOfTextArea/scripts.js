document.getElementById("font-color").value = "#000000";
document.getElementById("background-color").value = "#ffffff";

function changeFontColor() {
	document.getElementById("text").style.color = document.getElementById("font-color").value;
	return false;
}

function changeBackgroundColor() {
	document.getElementById("text").style.backgroundColor = document.getElementById("background-color").value;
	return false;
}