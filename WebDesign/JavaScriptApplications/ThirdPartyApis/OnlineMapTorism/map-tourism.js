(function() {
    "use strict";
    var map;
    var defaultZoomLevel = 9;
    var infoWindow = new google.maps.InfoWindow();
    var capitals = [{
            name: "Sofia",
            info: "<p>Sofia is the capital and largest city of Bulgaria.</p>",
            lat: 42.7,
            long: 23.333333
        },

        {
            name: "Cairo",
            info: "<p>Cairo is the capital of Egypt and the largest city in the Arab world and Africa</p>",
            lat: 30.05,
            long: 31.233333
        },

        {
            name: "Melbourne",
            info: "<p>Melbourne is the capital and most populous city in the state of Victoria, and the second most populous city in Australia.</p>",
            lat: -37.813611,
            long: 144.963056
        },

        {
            name: "Moscow",
            info: "<p>Moscow is the capital city and the most populous federal subject of Russia.</p>",
            lat: 55.75,
            long: 37.616667
        },

        {
            name: "Washington",
            info: "<p>Washington, D.C., formally the District of Columbia and commonly referred to as Washington, \"the District\", or simply D.C., is the capital of the United States. </p>",
            lat: 38.895111,
            long: -77.036667
        },

        {
            name: "Brasília",
            info: "<p>Brasília is the federal capital of Brazil and the seat of government of the Federal District.</p>",
            lat: -15.798889,
            long: -47.866667
        },

        {
            name: "London",
            info: "<p>London is the capital of England and the United Kingdom.</p>",
            lat: 51.507222,
            long: -0.1275
        },

        {
            name: "Paris",
            info: "<p>Paris is the capital and most populous city of France.</p>",
            lat: 48.8567,
            long: 2.3508
        },

        {
            name: "Tokyo",
            info: "<p>Tokyo, is one of the 47 prefectures of Japan. Tokyo is the capital of Japan, the center of the Greater Tokyo Area, and the largest metropolitan area in the world.</p>",
            lat: 35.689506,
            long: 139.6917
        },

        {
            name: "Rome",
            info: "<p>Rome in Italy. Rome is the capital of Italy and also of the homonymous province and of the region of Lazio.</p>",
            lat: 41.9,
            long: 12.5
        }
    ];

    var currentCapitalIndex = 0;

    function initialize() {
        var mapOptions = {
            zoom: defaultZoomLevel,
            center: new google.maps.LatLng(capitals[currentCapitalIndex].lat, capitals[currentCapitalIndex].long),
            mapTypeId: google.maps.MapTypeId.HYBRID
        };

        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);
        setInfoWindow();
    }

    $("#cities-list").on('click', 'a[href=#]', function(event) {
        event.preventDefault();
        var cityName = $(this).text()

        for (var i = 0, len = capitals.length; i < len; i++) {
            if (capitals[i].name == cityName) {
                currentCapitalIndex = i;
                var pos = new google.maps.LatLng(capitals[i].lat, capitals[i].long);
                map.panTo(pos);
                setInfoWindow();
                return;
            }
        }
    });

    $("#prev").on('click', function() {
        currentCapitalIndex--;

        if (currentCapitalIndex < 0) {
            currentCapitalIndex = capitals.length - 1;
        }

        var pos = new google.maps.LatLng(capitals[currentCapitalIndex].lat, capitals[currentCapitalIndex].long);
        map.panTo(pos);
        setInfoWindow();
    });

    $("#next").on('click', function() {
        currentCapitalIndex++;

        if (currentCapitalIndex >= capitals.length) {
            currentCapitalIndex = 0
        }

        var pos = new google.maps.LatLng(capitals[currentCapitalIndex].lat, capitals[currentCapitalIndex].long);
        map.panTo(pos);
        setInfoWindow();
    });

    function setInfoWindow() {
        infoWindow.setContent(capitals[currentCapitalIndex].info);
        infoWindow.setPosition(map.getCenter());
        infoWindow.open(map);
    }

    google.maps.event.addDomListener(window, 'load', initialize());
}());