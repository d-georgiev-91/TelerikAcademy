var slider = (function() {
    "use strict";
    /**
     * Object create shim
     */
    if (!Object.create) {
        Object.create = function(obj) {
            function funct() {};
            funct.prototype = obj;
            return new funct();
        }
    }

    var Slider = Object.create({
        //self: this,

        init: function(containerSelector, images) {
            var self = this;

            self._images = images;
            var container = document.querySelector(containerSelector);

            self.previewContaner = document.createElement("div");
            container.appendChild(self.previewContaner);

            self.previewContaner.classList.add("preview-contaner");
            self.currentImage = self._images[5]
            self.currentImageDom = document.createElement("img");
            self.currentImageDom.src = self.currentImage.url;
            self.currentImageDom.title = self.currentImage.title;
            self.previewContaner.appendChild(self.currentImageDom);

            self.imagesList = document.createElement("ul");
            self.imagesList.classList.add("images-list");

            for (var image in self._images) {
                var imageContaner = document.createElement("li");
                var img = document.createElement("img");
                self.imagesList.appendChild(img);
                img.src = self._images[image].thumbnailUrl;
                img.title = self._images[image].title;
            }

            container.appendChild(self.imagesList);

            self.previousButton = document.createElement("a");
            self.previousButton.classList.add("prev-btn");
            self.previousButton.addEventListener("click", onClickGoLeft, false);
            container.appendChild(self.previousButton);

            self.nextButton = document.createElement("a");
            self.nextButton.classList.add("next-btn");
            self.nextButton.addEventListener("click", onClickGoRight, false);
            container.appendChild(self.nextButton);

            function onClickGoLeft() {
                var currentImageIndex = self._images.indexOf(self.currentImage);

                if (currentImageIndex <= 0) {
                    currentImageIndex = self._images.length;
                }

                console.log(currentImageIndex);

                currentImageIndex--;
                self.currentImage = self._images[currentImageIndex];
                self.currentImageDom.title = self.currentImage.title;
                self.currentImageDom.src = self.currentImage.url;
                console.log(self.currentImageDom);
            }

            function onClickGoRight() {
                var currentImageIndex = self._images.indexOf(self.currentImage);

                console.log(self._images.length - 1);

                if (currentImageIndex >= self._images.length - 1) {
                    currentImageIndex = 0;
                }

                console.log(currentImageIndex);
                currentImageIndex++;
                self.currentImage = self._images[currentImageIndex];
                self.currentImageDom.title = self.currentImage.title;
                self.currentImageDom.src = self.currentImage.url;
                console.log(self.currentImageDom);
            }

        },

        /*onClickGoLeft: function() {
            //alert("clicked")
            var currentImageIndex = self._images.indexOf(self.currentImage);

            if (currentImageIndex < 0) {
                return;
            }

            currentImageIndex--;
            self.currentImageDom.title = self._images[currentImageIndex].title;
            self.currentImageDom.src = self._images[currentImageIndex].url;
            console.log(self.currentImageDom);
        },

        onClickGoRight: function(self) {
            var self = self;
        }*/
    });

    var Image = Object.create({
        init: function(title, url, thumbnailUrl) {
            var self = this;
            self.title = title;
            self.url = url;
            self.thumbnailUrl = thumbnailUrl;
        },
        convertToDom: function() {
            var self = this;
            var image = document.createElement("img");
            image.title = self.title;
            image.src = self.url;
        }
    });

    return {
        Slider: Slider,
        Image: Image,
    }

}());