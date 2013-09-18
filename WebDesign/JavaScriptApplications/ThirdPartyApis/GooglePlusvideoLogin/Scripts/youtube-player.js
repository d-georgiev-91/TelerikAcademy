"use strict";

var player;
var currentVolume;

function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '390', //must be bigger than 200px
        width: '640', //must be bigger than 200px
        videoId: 'QEXFS2kV9UY',
        events: {
            'onReady': onPlayerReady,
        }
    });
}

function onPlayerReady() {
    currentVolume = player.getVolume();
    $('#volume').val(currentVolume);
    initializeShareButton();
}

function initializeShareButton() {
    var shareButton = document.createElement("g:plus");
    shareButton.setAttribute("action", "share");
    shareButton.setAttribute("href", "http://www.youtube.com/");
    shareButton.id = "share";

    document.getElementById("video-player-container").appendChild(shareButton);

    (function () {
        var po = document.createElement('script');
        po.type = 'text/javascript';
        po.async = true;
        po.src = 'https://apis.google.com/js/plusone.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(po, s);
    })();

    var shareTag = document.getElementById('share');
    shareTag.setAttribute('href', getCurrentVideoUrlClean());
    console.log(getCurrentVideoUrlClean());
}

$('#singleVideo').on('click', function () {
    var video = document.getElementById('load-video').value;
    player.cueVideoById(video, 0, "large");
});

$('single-video').on('click', function () {
    var video = document.getElementById('load-video').value;

    player.cueVideoById(video, 0, "large");
    //player.loadVideoById(video, 0, "large");
});

$('#pause').on('click', function () {
    player.pauseVideo();
});

$('#play').on('click', function () {
    player.playVideo();
});

$('#load-playlist').on('click', function () {
    var videoPlaylist = $('#playlist').val().split(',');
    player.cuePlaylist(videoPlaylist, 0, 0, "large");
});

$('#previous').on('click', function () {
    player.previousVideo();
});

$('#next').on('click', function () {
    player.nextVideo();
});

$('#mute-unmute').on('click', function () {
    if (player.isMuted()) {
        player.unMute();
        player.setVolume(currentVolume);
        $('#volume').val(currentVolume);
    }
    else {
        player.mute();
        $('#volume').val(0);
    }
});

$('#volume').on('change', function () {
    currentVolume = $(this).val();
    player.setVolume(currentVolume);
});

function getCurrentVideoUrlClean() {
    var videoUrl = player.getVideoUrl();
    var videoUrlClean = videoUrl.substring(0, videoUrl.indexOf('&'));

    return videoUrlClean;
}