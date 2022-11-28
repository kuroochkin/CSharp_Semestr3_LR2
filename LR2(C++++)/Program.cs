using LR2;
using LR2_C_____;
using LR3;
using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;


Student student = new Student();
student.AddExams(new Exam());

var studentcopy = student.DeepCopy();

Console.WriteLine(student);
Console.WriteLine(studentcopy);

Console.WriteLine("Введите имя файла: ");
string filename;
do
{
    filename = Console.ReadLine();
} 
while (filename.Length < 1);
var fi = new FileInfo(filename);
if (fi.Exists)
{
    studentcopy.Load(filename);
    Console.WriteLine("Загруженный объект:");
    Console.WriteLine(studentcopy);
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Файл не найден!");
    fi.Create().Close();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Мы создали новый файл.");
    Console.ResetColor();
}

studentcopy.AddFromConsole();
studentcopy.Save(filename);
Console.WriteLine(studentcopy);

Student.Load(filename, studentcopy);
studentcopy.AddFromConsole();
Console.WriteLine("Результат:");
Student.Save(filename, studentcopy);
Console.WriteLine(studentcopy);














