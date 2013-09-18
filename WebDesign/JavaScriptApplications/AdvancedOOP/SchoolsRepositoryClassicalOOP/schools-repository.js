var schoolsRepository = (function() {
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

    var Person = Class.create({
        init: function(firstName, lastName, age) {
            var self = this;
            self.firstName = firstName;
            self.lastName = lastName;
            self.age = age;
        },

        introduce: function() {
            var self = this;
            var fullName = self.firstName + " " + self.lastName;
            var introduceMessage = "Name: " + fullName + ", Age: " + self.age;
            return introduceMessage;
        }
    });

    var Student = Class.create({
        init: function(firstName, lastName, age, grade) {
            var self = this;
            self._super.init(firstName, lastName, age);
            self.grade = grade;
        },

        introduce: function() {
            var self = this;
            var introduceMessage = self._super.introduce() + ", Grade: " + self.grade;

            return introduceMessage;
        }
    });

    Student.inherit(Person);

    var Teacher = Class.create({
        init: function(firstName, lastName, age, specialty) {
            var self = this;
            self._super.init(firstName, lastName, age);
            self.specialty = specialty;
        },

        introduce: function() {
            var self = this;
            var introduceMessage = self._super.introduce() + ", Specialty: " + self.specialty;

            return introduceMessage;
        }
    });

    Teacher.inherit(Person);

    var Course = Class.create({
        init: function(name, capacity, students, formTeacher) {
            var self = this;
            self.name = name;
            self.capacity = capacity;

            if (students) {
                if (students.length > capacity) {
                    throw new Error("Students count is more than capacity")
                }

                self.students = students;
            } else {
                self.students = [];
            }

            self.formTeacher = formTeacher;
        },

        add: function(student) {
            var self = this;

            if (students.length > capacity) {
                throw new Error("Students count is more than capacity")
            }

            self.students.push(student);
        },

        remove: function(student) {
            var self = this;
            var studentPosition = self.students.indexOf(student);

            if (studentPosition >= 0) {
                self.students.splice(studentPosition, 1);
            }
        },

        toString: function() {
            var self = this;
            var name = "Name: " + self.name + "\n";
            var capacity = "Capcity: " + self.capacity + "\n";
            var students = "Students:\n";

            for (var i = 0, len = self.students.length; i < len; i++) {
                students += "    " + self.students[i].introduce() + "\n";
            }

            var formTeacher = "Form teacher:\n    " + self.formTeacher.introduce();
            var courseAsString = name + capacity + students + formTeacher;

            return courseAsString;
        }
    });

    var School = Class.create({
        init: function(name, town, courses, teachers) {
            var self = this;
            self.name = name;
            self.town = town;

            if (courses) {
                self.courses = courses;
            } else {
                self.courses = [];
            }

            if (courses) {
                self.teachers = teachers;
            } else {
                self.teachers = [];
            }
        },

        addClass: function(course) {
            var self = this;
            self.courses.push(course);
        },

        removeClass: function(course) {
            var self = this;
            var classIndex = self.courses.indexOf(course);
            if (classIndex >= 0) {
                self.courses.splice(classIndex, 1);
            }
        },

        addTeacher: function(teacher) {
            var self = this;
            self.teachers.push(teacher);
        },

        removeTeacher: function(teacher) {
            var self = this;
            var classIndex = self.teachers.indexOf(teacher);
            if (classIndex >= 0) {
                self.teachers.splice(classIndex, 1);
            }
        },

        toString: function() {
            var self = this;
            var name = "Name: " + self.name + "\n";
            var town = "Town: " + self.town + "\n";
            var courses = "Classes:\n";

            for (var i = 0, len = self.courses.length; i < len; i++) {
                courses += "    " + self.courses[i].toString() + "\n";
            }

            var teachers = "Teachers:\n"

            for (var i = 0, len = self.teachers.length; i < len; i++) {
                teachers += "    " + self.teachers[i].introduce() + "\n";
            }

            var courseAsString = name + town + courses + teachers;

            return courseAsString;
        }
    });

    return {
        Student: Student,
        Teacher: Teacher,
        Course: Course,
        School: School
    };
}());