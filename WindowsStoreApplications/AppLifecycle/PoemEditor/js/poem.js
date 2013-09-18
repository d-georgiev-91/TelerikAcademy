/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
WinJS.Namespace.define("Literature", {
    Poem: WinJS.Class.define(function (verseLength, rhymeOption) {
        this.lines = new Array();
        this._rhymeOption = rhymeOption;
    }, {
        lines: {
            get: function () {
                return this._lines;
            },
            set: function (lines) {
                lines = this._lines;
            }
        },

        addLine: function (line) {
            if (this.lines.length > 1) {
                this._validateLine(line);
            }

            this.lines.push(line);
        },

        _validateLine: function (line) {
            var previousLine;

            if (this._rhymeOption == Literature.LineRhymeOption.NeigbourLines) {
                previousLine = this.lines[this.lines.length - 1];
            } else {
                if (this.lines.length < 2) {
                    return;
                }

                previousLine = this.lines[this.lines.length - 2];
            }

            this._validateLines(previousLine, line);
        },

        _validateLines: function (previousLine, currentLine) {
            var previousLineEndWord = this._getEndWord(previousLine);
            var currentLineEndWord = this._getEndWord(currentLine);

            if (!this._areWordsRhymes(previousLineEndWord, currentLineEndWord)) {
                throw new Error(previousLineEndWord + " doesn't rhyme with " + currentLineEndWord);
            }
        },

        _getEndWord: function (line) {
            words = line.match(/("[^"]+"|[^"\s-][a-z]+)/g)
            var word = words[words.length - 1];

            return word;
        },

        _areWordsRhymes: function (previousLineEndWord, currentLineEndWord) {
            
        }
    }),

    LineRhymeOption: Object.freeze({
        NeigbourLines: 0,
        PassByOneLines: 1,
    })
});