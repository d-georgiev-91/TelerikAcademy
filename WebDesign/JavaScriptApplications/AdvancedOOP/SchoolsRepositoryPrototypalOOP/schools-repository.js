var schoolsRepository = (function() {
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

    if (!Object.prototype.extend) {
        Object.prototype.extend = function(properties) {
            function methods() {};
            methods.prototype = Object.create(this);

            for (var prop in properties) {
                methods.prototype[prop] = properties[prop];
            }

            //methods.prototype._super = this;
            return new methods();
        }
    }

    var Person = {
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

    };

    var Student = Person.extend({
        init: function(firstName, lastName, age, grade) {
            var self = this;
            Person.init.apply(self, arguments);
            self.grade = grade;
        },

        introduce: function() {
            var self = this;
            var introduceMessage = Person.introduce.apply(self) + ", Grade: " + self.grade;

            return introduceMessage;
        }
    });

    var Teacher = Person.extend({
        init: function(firstName, lastName, age, specialty) {
            var self = this;
            Person.init.apply(self, arguments);
            self.specialty = specialty;
        },

        introduce: function() {
            var self = this;
            var introduceMessage = Person.introduce.apply(self) + ", Specialty: " + self.specialty;

            return introduceMessage;
        }
    });

    var Class = {
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
    };

    var School = {
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
    }

    return {
        Student: Student,
        Teacher: Teacher,
        Class: Class,
        School: School
    }
}());