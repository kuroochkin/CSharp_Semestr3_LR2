using LR2;
using LR2_C_____;
using System;
using System.Diagnostics;

Console.WriteLine("1-ое задание:"); Console.WriteLine();//отступ

Exam exam1 = new Exam("Электротехника", 3, new DateTime(2022, 06, 06)); // добавим объекты экзаменов
Exam exam2 = new Exam("Физика", 5, new DateTime(2022, 06, 09));
Exam exam3 = new Exam("Математика", 4, new DateTime(2022, 06, 12));
Exam exam4 = new Exam("Русский язык", 5, new DateTime(2022, 06, 15));

Student student1 = new Student(); // объект типа студент

student1.AddExams(exam1,exam2,exam3,exam4);


student1.PrintExam();

student1.SortExamsByName(); Console.WriteLine(); // Сортировка по имени

student1.PrintExam();

student1.SortExamsByGrade(); Console.WriteLine(); // Сортировка по оценке

student1.PrintExam();

student1.SortExamsByDate(); Console.WriteLine(); // Сортировка по дате

student1.PrintExam();

Console.WriteLine();

Console.WriteLine("2-ое задание:"); Console.WriteLine();//отступ

var stud = new StudentCollection<string>(StudentCollection<string>.GiveKey);

stud.AddDefaults();
stud.AddStudents(student1);

Console.WriteLine(stud.ToString());


