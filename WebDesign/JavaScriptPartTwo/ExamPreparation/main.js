var controls = (function() {
	function Accordion(selector) {
		var self = this;
		var items = [];
		var accItem = document.querySelector(selector);
		var itemsList = document.createElement("ul");
		//accItem.appendChild(itemsList);

		self.add = function(title) {
			var newItem = new Item(title);
			items.push(newItem);
		}

		self.render = function() {
			while (accItem.firstChild) {
				accItem.removeChild(accItem.firstChild);
			}
			var thisList = itemsList.cloneNode(true);

			var accordionFragment = document.createDocumentFragment();
			for (var i = 0; i < items.length; i++) {
				var domItem = items[i].render();
				itemsList.appendChild(domItem);
			}
			accItem.appendChild(accordionFragment);
		}
	}

	function Item(title) {
		var self = this;

		self.render = function() {
			var itemNone = document.createElement("li");
		}
	}
}());