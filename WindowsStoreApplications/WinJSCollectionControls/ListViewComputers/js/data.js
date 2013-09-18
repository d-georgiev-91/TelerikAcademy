(function () {
    var computersList = [/*{
            name: "Studio 1535",
            price: 2000,
            manufacturer: "Dell",
            processor: {
                modelName: "Core i5",
                frequencyGHz: 2.0
            }
        }*/];

    var observableComputersList = new WinJS.Binding.List(computersList);

    function compareGroups(leftKey, rightKey) {
        return leftKey.charCodeAt(0) - rightKey.charCodeAt(0);
    }

    function getGroupKey(dataItem) {
        if (dataItem) {
            return dataItem.manufacturer.toUpperCase();
        }
    }

    function getGroupData(dataItem) {
        return {
            manufacturer: dataItem.manufacturer.toUpperCase()
        };
    }

    groupedComputersList = observableComputersList.createGrouped(getGroupKey, getGroupData, compareGroups);

    WinJS.Namespace.define("Data", {
        groupedComputersList: groupedComputersList,
        computersList: computersList, 
        observableComputersList: observableComputersList,
    });
})();