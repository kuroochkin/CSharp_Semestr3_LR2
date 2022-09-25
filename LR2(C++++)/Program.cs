using LR2;
using System;
using System.Diagnostics;

Console.WriteLine("1-ое задание:"); Console.WriteLine();//отступ

Person person1 = new Person("Курочкин", "Влад", new DateTime(2003, 06, 19));
Person person2 = new Person("Курочкин", "Влад", new DateTime(2003, 06, 19));

Console.WriteLine($"Равенство ссылок: {Object.ReferenceEquals(person2, person1)}") ; // false
Console.WriteLine($"Равенство объектов: {person1 == person2}"); // true
Console.WriteLine($"HashCode1: {person1.GetHashCode()}, HashCode2: {person2.GetHashCode()}");
Console.WriteLine();

//второе задание
Student student1 = new Student(person1, Education.Bachelor, 100);
student1.AddExams(new Exam("Математика", 5, new DateTime(2022,06,20)));
student1.AddExams(new Exam("Электротехника", 3, new DateTime(2022, 06, 24)));
student1.AddTests(new Test("Физика", false));
student1.AddTests(new Test("Литература", true));


//второе задание

Console.WriteLine("3-е задание:");
Console.WriteLine(student1.Name);
Console.WriteLine();

Console.WriteLine("4-ое задание:"); Console.WriteLine();//отступ

var student2 = student1.DeepCopy();
student1.DataGroup = 200;
student1.Dataeducation = Education.Specialist;
Console.WriteLine(student2.ToString());
Console.WriteLine(student1);
Console.WriteLine();

Console.WriteLine("5-ое задание:"); Console.WriteLine();//отступ

try
{
    student1.DataGroup = 600;
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}
Console.WriteLine();//отступ

Console.WriteLine("6-ое задание:"); Console.WriteLine();//отступ

foreach (var item in student1.GetResults())
    Console.WriteLine(item.ToString());

Console.WriteLine();//отступ

Console.WriteLine("7-ое задание:"); Console.WriteLine();

foreach (var item in student1.ExamsFilter(3))
    Console.WriteLine(item.ToString());

