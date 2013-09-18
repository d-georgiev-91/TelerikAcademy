"use strict";

var Student = schoolsRepository.Student;
var Teacher = schoolsRepository.Teacher;
var Class = schoolsRepository.Class;
var School = schoolsRepository.School;

var pesho = Object.create(Student);
pesho.init("Pesho", "Peshev", 15, 5);
console.log(pesho.introduce());

var ivan = Object.create(Student);
ivan.init("Ivan", "Ivanov", 14, 2);
console.log(ivan.introduce());

var stamat = Object.create(Teacher);
stamat.init("Stamat", "Stamatov", 46, "chemistry");
console.log(stamat.introduce());

var pena = Object.create(Teacher);
pena.init("Pena", "Peneva", 104, "biology");
console.log(pena.introduce());

var mincho = Object.create(Student);
mincho.init("Mincho", "Minchev", 14, 2);
console.log(mincho.introduce());

var softwareThings = Object.create(Class);
softwareThings.init("Software things", 4, [pesho, ivan], stamat);
console.log("\n" + softwareThings.toString() + "\n");

var otherCourse = Object.create(Class);
otherCourse.init("Other class", 15, [ivan, pesho, mincho], pena);
console.log("\n" + otherCourse.toString() + "\n");

var school = Object.create(School);
school.init("Telerik Academy", "Sofia", [softwareThings, otherCourse], [stamat, pena]);
console.log("\n" + school.toString() + "\n");