using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR2
{
    public enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    public class Exam : IDateAndCopy, IComparable, IComparer<Exam>
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public Exam(string subject, int grade, DateTime datetime)
        {
            this.Subject = subject;
            this.Grade = grade;
            this.Date = datetime;
        }

        public Exam() { Subject = "Математика"; Grade = 5; Date = new DateTime(2022, 6, 20); }

        public override string ToString()
        {
            return string.Format("Предмет: {0} Оценка: {1}. Дата экзамена: {2}", Subject, Grade, Date);
        }

        public object DeepCopy()
        {
            return new Exam(this.Subject, this.Grade, this.Date);
        }

        public int CompareTo(object? subject)
        {
            if (subject is null) throw new ArgumentException("Некорректное значение параметра");
            return Subject.CompareTo(subject);
        }

        public int Compare(Exam? grade1, Exam? grade2)
        {
            if (grade1 is null || grade2 is null) throw new ArgumentException("Некорректное значение параметра");
            return grade1.Grade - grade2.Grade;
        }
    }
}
