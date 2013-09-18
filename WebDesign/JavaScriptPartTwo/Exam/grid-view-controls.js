var controls = (function() {
	'use strict';

	Function.prototype.inherit = function(parent) {
		this.prototype = new parent();
		this.prototype.constructor = this;
	}

	function escapeHTML(str) {
		str = str.replace(/&/g, "&amp;");
		str = str.replace(/</g, "&lt;");
		str = str.replace(/>/g, "&gt;");
		return str;
	}


	var GridView = function(gridId) {
		var self = this;
		self.gridView = document.createElement("table");
		self.gridView.style.borderCollapse = "collapse";
		self.gridView.id = gridId.substring(1);
	}

	GridView.prototype.addHeader = function(args) {

		var thead;

			if (this.gridView.querySelector("thead") == null) {
				(function() {
					thead = document.createElement("thead");
					console.log("ima");
				}());
			} else {
				(function() {
					thead = document.querySelector("thead");
					console.log("nqma");
				}());
			}

		var tr = document.createElement("tr");

		for (var i = 0, len = arguments.length; i < len; i++) {
			var th = document.createElement("th");
			th.style.padding = "5px 15px";
			th.style.background = "#C9C9C9";
			th.innerHTML = escapeHTML(arguments[i]);
			tr.appendChild(th);
		}
		console.log(thead);
		thead.appendChild(tr);
		this.gridView.appendChild(thead);
	}

	GridView.prototype.addRow = function(args) {
		var tr = document.createElement("tr");
		for (var i = 0, len = arguments.length; i < len; i++) {
			var td = document.createElement("td");
			td.style.padding = "5px 15px";
			td.innerHTML = escapeHTML(arguments[i]);
			tr.appendChild(td);
		}
		this.gridView.appendChild(tr);
	}

	GridView.prototype.render = function() {
		document.body.appendChild(this.gridView);
	}

	GridView.prototype.addNestedGridView = function() {

	};

	var getGridView = function(gridId) {
		gridId = escapeHTML(gridId);
		return new GridView(gridId);
	}

	var getNestedGridView = function() {
		document.querySelector(selectors)
		document.getElementsByTagName();
		this.appendChild("tr");
	}

	return {
		getGridView: getGridView,
		getNestedGridView: getNestedGridView
	}
}());


var MyClass = function(arguments) {
   // private:
   
   // public:
   var self = this;
}

MyClass.prototype.myMethod = function(arguments) {
    // body...
