using LR2;
using LR2_C_____;
using LR3;
using System;
using System.Diagnostics;


StudentCollection<string> collection1 = new StudentCollection<string>(StudentCollection<string>.GiveKey, "Юноши");
StudentCollection<string> collection2 = new StudentCollection<string>(StudentCollection<string>.GiveKey, "Девушки");

Console.WriteLine("2-ое задание: \n");

Journal journal = new Journal();
collection1.StudentsChanged += journal.StudentsChangesHandler;
collection2.StudentsChanged += journal.StudentsChangesHandler;

Student student1 = new Student(new Person("Влад", "Курочкин", DateTime.Now), Education.Bachelor, 21);
Student student2 = new Student(new Person("Анна", "Самофеева", DateTime.Now), Education.SecondEducation, 31);
Student student3 = new Student(new Person("Софья", "Аверина", DateTime.Now), Education.Specialist, 21);

List<Student> students = new List<Student>();
students.Add(student1);
students.Add(student2);
students.Add(student3);

student1.PropertyChanged += collection1.PropertyChangeded;
student2.PropertyChanged += collection2.PropertyChangeded;
student3.PropertyChanged += collection2.PropertyChangeded;


foreach (Student item in students) // ИЗНАЧАЛЬНЫЙ СПИСОК
{
    Console.WriteLine(item.ToString());
}

collection1.AddStudents(student1); // ДОБАВЛЯЕМ В КОЛЛЕКЦИИ
collection2.AddStudents(student2, student3);


student1.DataGroup = 105;
student1.Dataeducation = Education.SecondEducation; // ИЗМЕНЯЕМ СВОЙСТВА

student2.DataGroup = 120;
student2.Dataeducation = Education.Specialist;

student3.DataGroup = 140;
student3.Dataeducation = Education.Specialist;

collection1.Remove(student1);
collection2.Remove(student3);
collection2.Remove(student3);

student1.DataGroup = 105;
student1.Dataeducation = Education.SecondEducation;

student3.DataGroup = 140;
student3.Dataeducation = Education.Specialist;

Console.WriteLine(journal.ToString());














