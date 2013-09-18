(function($) {
	//'use strict';
	$.fn.treeView = function() {
		var treeViewContainer = this;
		treeViewContainer.find('li>ul')
			.addClass('subtree-view')
				.hide()
					.prev()
						.addClass('subtree-root');

		treeViewContainer.on('click', 'a[href=#]', function(event) {
			event.preventDefault();
		});

		treeViewContainer.on('click', '.subtree-root', function() {
			$(this).next().slideToggle();
		});
	}
}(jQuery));