function loadScript() {
	var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net",
		".net", "css", "wordpress", "xaml", "js", "http", "web",
		"asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript",
		"js", "cms", "html", "javascript", "http", "http", "CMS"];

	var tagCloud = generateTagCloud(tags, 17, 42);

	document.body.appendChild(tagCloud);
}

function generateTagCloud(tags, minFontSize, maxFontSize) {

	var tagCloud = document.createElement("div");
	tagCloud.id = 'cloud';
	tagCloud.style.margin = "15px";
	tagCloud.style.padding = "5px";
	tagCloud.style.display = "inline-block";
	tagCloud.style.width = "250px";

	var tagsWithOccurance = {};

	for (var i = 0, len = tags.length; i < len; i++) {
		var key = tags[i].toUpperCase();
		if (!tagsWithOccurance[key]) {
				tagsWithOccurance[key] = {
					count: 1,
					used: false
				};
		} 
		else {
			tagsWithOccurance[key].count++;
		}
	}

	var maxCount = Number.MIN_VALUE;
	var minCount = Number.MAX_VALUE;

	for (var j = 0, len = tags.length; j < len; j++) {
		var key = tags[j].toUpperCase();
		if (minCount > tagsWithOccurance[key].count) {
			minCount = tagsWithOccurance[key].count;
		}

		if (maxCount < tagsWithOccurance[key].count) {
			maxCount = tagsWithOccurance[key].count;
		}
	}

	var fontSizeDiffernce = maxFontSize - minFontSize;
	var occuranceDiffrence = maxCount - minCount;
	var fontSizeIncrement = parseInt(fontSizeDiffernce / occuranceDiffrence);

	for (var k = 0; k < len; k++) {
		var key = tags[k].toUpperCase();
		if (!tagsWithOccurance[key].used) {
			var fontSize;
			if (tagsWithOccurance[key].count === minCount) {
				fontSize = minFontSize;
			} else if (tagsWithOccurance[key].count === maxCount) {
				fontSize = maxFontSize;
			} else {
				fontSize = minFontSize + (tagsWithOccurance[key].count - minCount) * fontSizeIncrement;
			}

			var tagInCloud = createTag(fontSize, tags[k], tagsWithOccurance[key].count);

			tagCloud.appendChild(tagInCloud);

			tagsWithOccurance[key].used = true;
		}
	}

	return tagCloud;
}

function createTag(fontSize, text, occurrences) {
    var div = document.createElement("a");

    div.style.fontSize = fontSize + "px";
    div.style.margin = "10px"
    div.innerHTML = text;

    return div;
}