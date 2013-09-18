/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
WinJS.Namespace.define("Controls", {
    Repeater: WinJS.Class.define(function () {
        var templatesHolder, dataList, templateUri;
        if (arguments.length < 3) {
            templatesHolder = document.createElement("div");
            document.body.appendChild(templatesHolder);
            dataList = arguments[0];
            templateUri = arguments[1];
        } else {
            templatesHolder = arguments[0];
            dataList = arguments[1];
            templateUri = arguments[2];
        }

        this._templatesHolder = templatesHolder;
        this._dataList = dataList;
        this._template = new WinJS.Binding.Template(null, { href: templateUri });
    }, {
        render: function () {
            for (var i = 0; i < this._dataList.length; i++) {
                var item = this._dataList[i];
                var currentTemplateHolder = document.createElement("div");
                this._template.render(item, currentTemplateHolder);
                this._templatesHolder.appendChild(currentTemplateHolder);
            }
        },

        addNewItem: function (item) {
            this._dataList.push(item);      
            this._template.render(item, this._templatesHolder);
        }
    })
});