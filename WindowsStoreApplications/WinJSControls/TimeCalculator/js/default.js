/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var DAY = 1000 * 60 * 60 * 24;
    var HOUR = 1000 * 60 * 60;

    var startDate = new Date();
    var endDate = new Date();

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            args.setPromise(WinJS.UI.processAll());

            var startDatePicker = document.getElementById("start-time");
            startDatePicker.addEventListener("change", startDateChange);

            var endDatePicker = document.getElementById("end-time");
            endDatePicker.addEventListener("change", endDateChange);

            var calculateDifferenceElement = document.getElementById("calculate-difference");
            calculateDifferenceElement.addEventListener("click", calculateDifferenceElementClicked);

            var calculateDays = document.getElementById("calculate-days");
            calculateDays.addEventListener("click", calculateDaysClicked);

            var hideOrDisplayTime = document.getElementById("hide-display-time");
            hideOrDisplayTime.addEventListener("change", hideOrDisplayTimeChandeg);

            var calculateHours = document.getElementById("calculate-hours");
            calculateHours.addEventListener("click", calculateHoursClicked);

            var calculateDaysAndHours = document.getElementById("calculate-days-and-hours");
            calculateDaysAndHours.addEventListener("click", calculateDaysAndHoursClicked);
        }
    };

    function calculateDaysClicked() {
        var result = document.getElementById("result");
        var difference = endDate - startDate;

        if (difference < 0) {
            result.innerText = "Start date must be before End date";
            return;
        }

        result.innerText = "Days: " + parseInt(difference / DAY);
    }

    function calculateHoursClicked() {
        var result = document.getElementById("result");
        var difference = endDate - startDate;

        if (difference < 0) {
            result.innerText = "Start date must be before End date";
            return;
        }

        result.innerText = "Hours: " + parseInt(difference / HOUR);
    }

    function calculateDaysAndHoursClicked() {
        var result = document.getElementById("result");
        var difference = endDate - startDate;

        if (difference < 0) {
            result.innerText = "Start date must be before End date";
            return;
        }

        var days = parseInt(difference / DAY);
        var hours = parseInt((difference / DAY - days) * 24);

        result.innerText = "Days: " + days + " Hours: " + hours;
    }

    function hideOrDisplayTimeChandeg(eventInfo) {
        var switchControl = eventInfo.target.winControl;

        if (switchControl.checked) {
            document.getElementById("from-time").style.display = "inline-block";
            document.getElementById("to-time").style.display = "inline-block";
            document.getElementById("calculate-hours").style.display = "block";
            document.getElementById("calculate-days-and-hours").style.display = "block";
        }
        else {
            document.getElementById("from-time").style.display = "none";
            document.getElementById("to-time").style.display = "none";
            document.getElementById("calculate-hours").style.display = "none";
            document.getElementById("calculate-days-and-hours").style.display = "none";
        }
    }

    function startDateChange() {
        var startDatePicker = document.getElementById("from-date").winControl;
        var startTimePicker = document.getElementById("from-time").winControl;
        var date = parseDate(new Date(startDatePicker.current), new Date(startTimePicker.current));

        startDate = date;
    }

    function endDateChange() {
        var startDatePicker = document.getElementById("to-date").winControl;
        var startTimePicker = document.getElementById("to-time").winControl;
        var date = parseDate(new Date(startDatePicker.current), new Date(startTimePicker.current));

        endDate = date;
    }

    function parseDate(date, time) {
        var resultDate = new Date();
        resultDate.setFullYear(date.getFullYear());
        resultDate.setMonth(date.getMonth());
        resultDate.setDate(date.getDate());

        resultDate.setHours(time.getHours());
        resultDate.setMinutes(time.getMinutes());

        return resultDate;
    }

    var calculateDifferenceElementClicked = function () {
        var menu = document.getElementById("menu-id").winControl;
        menu.show();
    }

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
