/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    var app = WinJS.Application;

    app.onactivated = function (args) {
        var loadedVideosList = document.getElementById("loaded-videos");
        var player = document.getElementById("player");
        var currentPlaylist = new Windows.Media.Playlists.Playlist();
        var currentSelectedVideo = -1;
        var currentSelectedVideoUrl;
        var storagePermissions = Windows.Storage.AccessCache.StorageApplicationPermissions;

        WinJS.Utilities.id("appbar-save-playlist-btn").listen("click", function () {
            var savePicker = Windows.Storage.Pickers.FolderPicker();
            savePicker.fileTypeFilter.append("*");

            savePicker.pickSingleFolderAsync().then(function (folder) {
                if (folder) {
                    currentPlaylist.saveAsAsync(folder, "New Playlist",
                    Windows.Storage.NameCollisionOption.replaceExisting, Windows.Media.Playlists.PlaylistFormat.windowsMedia);
                }
            })
        });

        WinJS.Utilities.id("appbar-open-playlist-btn").listen("click", function () {
            var openPicker = Windows.Storage.Pickers.FileOpenPicker();

            openPicker.fileTypeFilter.append(".wpl");
            openPicker.pickSingleFileAsync().then(function (file) {
                if (file) {
                    Windows.Media.Playlists.Playlist.loadAsync(file)
                    .then(function (playlist) {
                        currentPlaylist = playlist;
                        renderCurrentPlaylist();
                    });
                }
            })
        });

        loadedVideosList.addEventListener("click", function (event) {
            var videoEntry = event.target;
            currentSelectedVideo = videoEntry.getAttribute("data-video-index");

            if (videoEntry.tagName.toLowerCase() == "strong") {
                videoEntry = videoEntry.parentElement;
            }

            player.src = videoEntry.getAttribute("data-video-url");
            currentSelectedVideoUrl = player.src;
        });

        function renderCurrentPlaylist() {
            loadedVideosList.innerHTML = "";
            for (var i = 0; i < currentPlaylist.files.length; i++) {
                var storageFile = currentPlaylist.files[i];
                var videoName = storageFile.displayName;
                var videoUrl = URL.createObjectURL(storageFile);

                var videoEntry = document.createElement("li");
                videoEntry.setAttribute("data-video-index", i);
                videoEntry.setAttribute("data-video-url", videoUrl);
                videoEntry.innerHTML = "<strong>" + videoName + "</strong>";
                loadedVideosList.appendChild(videoEntry);
            }
        }

        var addVideo = function (storageFile) {
            if (storageFile) {
                storageFile.properties.getVideoPropertiesAsync().then(function (properties) {
                    currentPlaylist.files.append(storageFile);
                    storagePermissions.futureAccessList.add(storageFile);
                    renderCurrentPlaylist();
                });
            }
        }

        WinJS.Utilities.id("appbar-remove-btn").listen("click", function () {
            if (currentSelectedVideo < 0 || currentSelectedVideo >= currentPlaylist.files.length) {
                return;
            }

            currentPlaylist.files.removeAt(currentSelectedVideo);
            currentSelectedVideo = -1;
            if (player.src == currentSelectedVideoUrl) {
                player.src = undefined;
                currentSelectedVideoUrl = undefined;
            }
            renderCurrentPlaylist();
        });

        WinJS.Utilities.id("appbar-add-videos-btn").listen("click", function () {
            var openPicker = Windows.Storage.Pickers.FileOpenPicker();

            openPicker.fileTypeFilter.replaceAll([".avi", ".mp4", ".mpeg", ".mpg", ".wmv"]);
            openPicker.pickMultipleFilesAsync().then(function (files) {
                files.forEach(addVideo);
            });
        });

        args.setPromise(WinJS.UI.processAll());
    };

    app.start();
})();