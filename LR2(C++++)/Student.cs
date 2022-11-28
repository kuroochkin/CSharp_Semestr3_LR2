using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Xml.Linq;
using LR2_C_____;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LR2
{
    public delegate TKey KeySelector<TKey>(Student st);

    public enum Action
    {
        Add,
        Remove,
        Property
    }
   
    [Serializable]
    public class Student : Person, IDateAndCopy, IComparable, INotifyPropertyChanged
    {
        private Education formeducation;
        private int NumberGroup;
        private List<Test> tests = new List<Test>();
        private List<Exam> exams = new List<Exam>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public Student()
        {
            var st = new Person();
            this.name = st.Name;
            this.surname = st.Surname;
            this.datetime = st.Datetime;
            this.formeducation = Education.Bachelor;
            this.NumberGroup = 21;
        }
        public Student(Person student, Education formeducation, int numberGroup)
        {
            this.name = student.Name;
            this.surname = student.Surname;
            this.datetime = student.Datetime;
            this.formeducation = formeducation;
            this.NumberGroup = numberGroup;
        }

        public Person Datastudent
        {
            get
            {
                Person person = new Person(this.name, this.surname, this.datetime);
                return person;
            }

            set
            {
                Person person = new Person(this.name, this.surname, this.datetime);
                person = value;
            }
        }

        public Education Dataeducation
        {
            get { return formeducation; }
            set 
            { 
                formeducation = value;
                ChangeEducationForm("Education");
            }
        }

        public int DataGroup
        {
            get { return NumberGroup; }
            set
            {
                if (value <= 100 || value > 599)
                {
                    throw new ArgumentOutOfRangeException("Ошибка! Значение группы лежит в пределах от 100 до 599.");
                }
                NumberGroup = value;
                ChangeNumberGroup("NumberGroup");
            }
        }

        public List<Exam> Dataexams
        {
            get { return exams; }
            set { exams = value; }
        }

        public List<Test> Datatests
        {
            get { return tests; }
            set { tests = value; }
        }

        public double Average
        {
            get
            {
                double sum = 0;

                foreach (Exam item in exams)
                {
                    sum += item.Grade;
                }
                return sum / exams.Count;
            }
        }

        public bool this[Education index]
        {
            get
            {
                return this.formeducation == index;
            }
        }


        public void ChangeEducationForm(string name_prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name_prop));
        }

        public void ChangeNumberGroup(string name_prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name_prop));
        }

        public void AddExams(params Exam[] exam)
        {
            foreach(Exam item in exam)
            {
                exams.Add(item);
            }
        }

        public void AddTests(Test test) => tests.Add(test);



        public override Student DeepCopy()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Student)formatter.Deserialize(stream);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Объекты не равны!");
                Console.ResetColor();
                return new Student();
            }

        }

        public bool Save(string filename)
        {
            try
            {
                var format = new BinaryFormatter();
                using (var filestream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    format.Serialize(filestream, this);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool Save(string filename, Student obj)
        {
            try
            {
                var format = new BinaryFormatter();
                using (var filestream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    format.Serialize(filestream, obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in static Save");
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
        }

        public bool Load(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var deserialize = (Student)formatter.Deserialize(fs);
                    name = deserialize.name;
                    surname = deserialize.surname;
                    datetime = deserialize.datetime;
                    formeducation = deserialize.formeducation;
                    NumberGroup = deserialize.NumberGroup;
                    tests.Clear();
                    tests.AddRange(deserialize.tests);
                    exams.Clear();
                    exams.AddRange(deserialize.exams);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Load(string filename, Student obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var deserialize = (Student)formatter.Deserialize(fs);
                    obj.name = deserialize.name;
                    obj.surname = deserialize.surname;
                    obj.datetime = deserialize.datetime;
                    obj.formeducation = deserialize.formeducation;
                    obj.NumberGroup = deserialize.NumberGroup;
                    obj.tests.Clear();
                    obj.tests.AddRange(deserialize.tests);
                    obj.exams.Clear();
                    obj.exams.AddRange(deserialize.exams);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine(
                    "Введите информацию о экзамене:\n" +
                    "Предмет-Оценка-Число экзамена-Месяц экзамена-Год экзамена"
                );
                string[] words = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                var exam = new Exam(words[0], Convert.ToInt32(words[1]), new DateTime(Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4])));
                exams.Add(exam);
                return true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                return false;
            }

        }
        public IEnumerable GetResults()
        {
            foreach (var exam in exams)
                yield return exam;
            foreach (var test in tests)
                yield return test;
        }

        public IEnumerable ExamsFilter(int grade)
        {
            foreach(var exam in exams)
            {
                Exam ex = (Exam)exam;
                if (ex.Grade > grade)
                    yield return exam;
            }
        }


        public int CompareTo(object? ExamSubject)
        {
            if (ExamSubject is null) throw new ArgumentException("Некорректное значение параметра");
            return this.CompareTo(ExamSubject);
        }

        public void SortExamsByName()
        {
            exams.Sort();
        }

        public void SortExamsByGrade()
        {
            exams.Sort(new Exam());
        }

        public void SortExamsByDate()
        {
            exams.Sort(new ExamHelper());
        }

        public void PrintExam()
        {
            foreach (Exam exam in this.Dataexams)
            {
                Console.WriteLine(exam.ToString());
            }
        }

    public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendFormat("{0}\nНомер группы: {1}\nФорма обучения: {2}\n", Datastudent, NumberGroup, formeducation);
            
            builder.Append("Экзамены:\n");
            foreach (Exam exam in exams)
                builder.AppendLine(exam.ToString());
            
            builder.Append("Зачеты:\n");
            foreach (Test test in tests)
                builder.AppendLine(test.ToString());
            return builder.ToString();
        }

        public override string ToShortString()
        {
            return string.Format("\nСтудент: {0}\nФорма обучения: {1}\nНомер группы: {2}\nСредний балл: {3}", Datastudent, formeducation, NumberGroup, Average);
        }

        
    }
}
