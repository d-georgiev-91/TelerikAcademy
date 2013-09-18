"use strict";

var Student = schoolsRepository.Student;
var Teacher = schoolsRepository.Teacher;
var SchoolClass = schoolsRepository.Course;
var School = schoolsRepository.School;

var pesho = new Student("Pesho", "Peshev", 15, 5);
console.log(pesho.introduce());

var ivan = new Student("Ivan", "Ivanov", 14, 2);
console.log(ivan.introduce());

var stamat = new Teacher("Stamat", "Stamatov", 46, "chemistry");
console.log(stamat.introduce());

var pena = new Teacher("Pena", "Peneva", 104, "biology");
console.log(pena.introduce());

var mincho = new Student("Mincho", "Minchev", 14, 2);
console.log(mincho.introduce());

var softwareThings = new SchoolClass("Software things", 4, [pesho, ivan], stamat);
console.log("\n" + softwareThings.toString() + "\n");

var otherCourse = new SchoolClass("Other Schoolclass", 15, [ivan, pesho, mincho], pena);
console.log("\n" + otherCourse.toString() + "\n");

var school = new School("Telerik Academy", "Sofia", [softwareThings, otherCourse], [stamat, pena]);
console.log("\n" + school.toString() + "\n");