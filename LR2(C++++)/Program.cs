using LR2;
using System;
using System.Diagnostics;

Person person1 = new Person("Курочкин", "Влад", new DateTime(2003, 06, 19));
Person person2 = new Person("Курочкин", "Влад", new DateTime(2003, 06, 19));

Console.WriteLine(Object.ReferenceEquals(person2, person1)); // false
Console.WriteLine(person1 == person2); // true
Console.WriteLine($"HashCode1: {person1.GetHashCode()}, HashCode2: {person2.GetHashCode()}");

Student student1 = new Student(person1, Education.Bachelor, 100);
student1.AddExams(new Exam("Математика", 5, new DateTime(2022,06,20)));
student1.AddTests(new Test("Физика", true));

Console.WriteLine(student1.ToString());
Console.WriteLine();
Console.WriteLine(student1.Datastudent);
Console.WriteLine();

var student2 = student1.DeepCopy();
student1.DataGroup = 200;
student1.Dataeducation = Education.Specialist;
Console.WriteLine(student2);
Console.WriteLine(student1);
Console.WriteLine();

try
{
    student1.DataGroup = 600;
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.Message);
}