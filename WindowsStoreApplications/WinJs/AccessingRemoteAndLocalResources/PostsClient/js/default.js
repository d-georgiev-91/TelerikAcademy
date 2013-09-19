// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var postsApiUrl = "http://posted.apphb.com/api/posts";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var postsCountSofar = 0;

    app.onactivated = function (args) {
        WinJS.xhr({
            url: postsApiUrl,
            type: "get",
        }).then(
            function completed(response) {
                var posts = JSON.parse(response.responseText);
                Data.posts = new WinJS.Binding.List(posts);
                postsCountSofar = posts.length;
            },
            function error(response) {
                // handle error conditions.
            }).done(function () {
                WinJS.UI.processAll();
            })
        post();
        setInterval(update, 30000);
    }

    function update() {
        WinJS.xhr({
            url: postsApiUrl,
            type: "get",
        }).then(
            function completed(response) {
                if (postsCountSofar > 0) {
                    var posts = JSON.parse(response.responseText);
                    var postCount = postsCountSofar;
                    for (var i = postCount - 1; i < posts.length; i++) {
                        var post = posts[i];
                        var obsPost = new WinJS.Binding.define(post);
                        Data.posts.push(obsPost);
                        postsCountSofar++;
                    }
                }
            },
            function error(response) {
                // handle error conditions.
            }).done(function () {
                var p = document.createElement("p");
                p.innerHTML = (new Date()).getTime();
                document.getElementById("system-messages").appendChild(p);
            })
    }

    function post() {
        var postButton = document.getElementById("publish-post");
        postButton.addEventListener("click", function () {
            var author = document.getElementById("post-author").value;
            var content = document.getElementById("post-text").value;

            var post = {
                Author: author,
                Content: content
            }

            Data.posts.push(post);

            WinJS.xhr({
                type: "post",
                url: postsApiUrl,
                headers: { "Content-type": "application/json" },
                data: JSON.stringify(post)
            }).done();
        });
    }

    app.start();
})();