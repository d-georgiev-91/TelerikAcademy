var student = (function() {
    "use strict";

    var Class = (function() {
        function createClass(properties) {
            var funct = function() {
                if (this._superConstructor) {
                    this._super = new this._superConstructor(arguments);
                }
                this.init.apply(this, arguments);
            }
            for (var prop in properties) {
                funct.prototype[prop] = properties[prop];
            }
            if (!funct.prototype.init) {
                funct.prototype.init = function() {}
            }
            return funct;
        }

        Function.prototype.inherit = function(parent) {
            var oldPrototype = this.prototype;
            this.prototype = new parent();
            this.prototype._superConstructor = parent;
            for (var prop in oldPrototype) {
                this.prototype[prop] = oldPrototype[prop];
            }
        }

        return {
            create: createClass,
        };
    }());

    var Student = Class.create({
        init: function(firstName, lastName, grade) {
            var self = this;
            self.firstName = firstName;
            self.lastName = lastName;
            self.grade = grade;
        }
    });

    return {
        Student: Student,
    };
}());

var studentsRenderer = (function() {
    "use strict"

    var render = function(students, holderSelector) {
        $(holderSelector).append("<table id='students-table'></table>");
        var table = $("#students-table");
        table.append("<thead><tr><th>First name</th><th>Last name</th><th>Grade</th></tr></thead>");
        table.append("<tbody></tbody>");

        for (var i = 0, len = students.length; i < len; i++) {
            $(holderSelector + " tbody").append("<tr>" + splitStudentAsCells(students[i]) + "</tr>");
        }
    }

    var splitStudentAsCells = function(student) {
        var firstNameCell = "<td>" + student.firstName + "</td>";
        var lastNameCell = "<td>" + student.lastName + "</td>";
        var gradeCell = "<td>" + student.grade + "</td>";

        return firstNameCell + lastNameCell + gradeCell;
    }

    return {
        render: render,
    }
}());