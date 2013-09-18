var inserter = (function() {
	
	var insertBefore = function(selector, domElement) {
		$(domElement).insertBefore($(selector));
	}

	var insertAfter = function(selector, domElement) {
		$(domElement).insertAfter($(selector));
	}

	return {
		insertBefore: insertBefore,
		insertAfter: insertAfter
	}
}());