(function(b) {
	var a = b.createElement("a");
	console.log(a);
	a.innerText = "Download MP3";
	a.href = "http://media.soundcloud.com/stream/" + b.querySelector("sc-button-group.sc-button-group-small").src.match(/\.com\/(.+)\_/)[1];
	a.download = b.querySelector("em").innerText + ".mp3";
	b.querySelector(".primary").appendChild(a);
	a.style.marginLeft = "10px";
	a.style.color = "red";
	a.style.fontWeight = 700
})(document);