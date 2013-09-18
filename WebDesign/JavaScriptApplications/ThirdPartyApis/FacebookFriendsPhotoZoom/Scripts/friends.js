var zoomLevel = 3;

window.fbAsyncInit = function () {
    FB.init({
        appId: '475196989224660', // App ID
        channelUrl: '//http://localhost:47343/channel.html', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) {
        return;
    }
    js = d.createElement('script');
    js.id = id;
    js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

$("#show-friends").on('click', function () { 
    getFriends();
    $(this).hide();
    $('#friends-holder').on('click', 'img', function () {
        changePhotoState();
    });
});

function getFriends() {
    FB.api('/me/friends', function (response) {
        var friendsHolder = $('#friends-holder');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture?width=100&height=100';
            var friendName = response.data[i].name;
            friendsHolder.append("<img src =" + friendPictureUrl + " title=" + friendName + "/>");
        }
    });
}

var lastZoomedPhoto;

function changePhotoState() {
    var selectedImage = $(event.target);

    if (selectedImage.data("zoomed") == "true") {
        unzoomPhoto(selectedImage);
    }
    else {
        zoomPhoto(selectedImage);
    }
}

function unzoomPhoto(selectedImage) {
    selectedImage.data("zoomed", "false");
    var oldWidth = parseInt(selectedImage.css("width"));
    var oldHeight = parseInt(selectedImage.css("height"));
    selectedImage.css("width", (oldWidth / zoomLevel) + "px");
    selectedImage.css("height", (oldHeight / zoomLevel) + "px");
    selectedImage.css("position", "static");
    lastZoomedPhoto = undefined;
}

function zoomPhoto(selectedImage) {
    selectedImage.data("zoomed", "true");

    if (lastZoomedPhoto) {
        unzoomPhoto(lastZoomedPhoto);
    }

    lastZoomedPhoto = selectedImage;

    var oldWidth = parseInt(selectedImage.css("width"));
    var oldHeight = parseInt(selectedImage.css("height"));
    selectedImage.css("width", (oldWidth * zoomLevel) + "px");
    selectedImage.css("height", (oldHeight * zoomLevel) + "px");
    selectedImage.css("position", "aboslute");
}