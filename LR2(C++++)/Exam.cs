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
    public class Exam
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime Datetime { get; set; }

        public Exam(string subject, int grade, DateTime datetime)
        {
            this.Subject = subject;
            this.Grade = grade;
            this.Datetime = datetime;
        }

        public Exam() { Subject = "Математика"; Grade = 5; Datetime = new DateTime(2022, 6, 20); }

        public override string ToString()
        {
            return string.Format("Предмет: {0} Оценка: {1}. Дата экзамена: {2}", Subject, Grade, Datetime);
        }
    }
}
