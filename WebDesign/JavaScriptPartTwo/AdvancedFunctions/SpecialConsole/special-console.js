var specialConsole = (function() {
	"use strict";

	function writeLine(value, args) {
		if (arguments.length == 1) {
			console.log(value.toString());
		} else {
			console.log(stringFormat.apply(null, arguments));
		}
	}

	function writeError(value, args) {
		if (arguments.length == 1) {
			console.error(value.toString());
		} else {
			console.error(stringFormat.apply(null, arguments));
		}
	}

	function writeWarning(value, args) {
		if (arguments.length == 1) {
			console.warn(value.toString());
		} else {
			console.warn(stringFormat.apply(null, arguments));
		}
	}

	function stringFormat() {
		var result = arguments[0];
		for (var i = 0, len = arguments.length - 1; i < len; i++) {
			var placeholder = "\\{" + i + "\\}";
			var regex = new RegExp(placeholder, "g");
			result = result.replace(regex, arguments[i + 1].toString());
		}
		return result;
	}

	return {
		writeLine: writeLine,
		writeError: writeError,
		writeWarning: writeWarning
	};
})();