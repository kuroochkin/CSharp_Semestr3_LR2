using LR2;
using LR2_C_____;
using LR3;
using System;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;


Student student = new Student();
student.AddExams(new Exam());

var studentcopy = student.DeepCopy(); // Создание копии

Console.WriteLine(student);
Console.WriteLine(studentcopy);

Console.WriteLine("Введите имя файла: ");
string filename;
do
{
    filename = Console.ReadLine();
} 
while (filename.Length < 1); // Ждем ввода каких-то данных
var fi = new FileInfo(filename);

if (fi.Exists) // Проверка на существование файла
{
    studentcopy.Load(filename);
    Console.WriteLine("Загруженный объект:");
    Console.WriteLine(studentcopy);
}
else
{
    Console.WriteLine("Файл не найден!");
    fi.Create().Close();
    Console.WriteLine("Мы создали новый файл.");
}

studentcopy.AddFromConsole(); // Добавляем экзамен
studentcopy.Save(filename); // Сохраняем в файл
Console.WriteLine(studentcopy); // Выводим данные студента

Student.Load(filename, studentcopy);
studentcopy.AddFromConsole();
Console.WriteLine();
Console.WriteLine("Результат:");
Student.Save(filename, studentcopy);
Console.WriteLine(studentcopy);














