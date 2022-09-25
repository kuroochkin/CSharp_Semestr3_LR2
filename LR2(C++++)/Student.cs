using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using System.Collections;

namespace LR2
{
    delegate TKey KeySelector<TKey>(Student st);
    public class Student : Person, IDateAndCopy
    {
        private Person student;
        private Education formeducation;
        private int NumberGroup;
        private List<Test> tests = new List<Test>();
        private List<Exam> exams = new List<Exam>();

        public Student(Person student, Education formeducation, int numberGroup)
        {
            this.student = student;
            this.formeducation = formeducation;
            this.NumberGroup = numberGroup;
        }
        public Student()
        {
            this.student = new Person();
            this.formeducation = Education.Bachelor;
            this.NumberGroup = 21;
        }

        public Person Datastudent
        {
            get { return student; }
            set { student = value; }
        }

        public Education Dataeducation
        {
            get { return formeducation; }
            set { formeducation = value; }
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
            }
        }

        public List<Exam> Dataexams
        {
            get { return exams; }
            set { exams = value; }
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
                if (this.formeducation == index)
                    return true;
                return false;
            }
        }

        public void AddExams(Exam exam) => exams.Add(exam);

        public void AddTests(Test test) => tests.Add(test);

        public override object DeepCopy()
        {
            var student = new Student(this.student, this.formeducation, this.NumberGroup);

            foreach (Exam item in this.exams)
            {
                student.AddExams(item);
            }
            foreach (Test item in this.tests)
            {
                student.AddTests(item);
            }
            return student;
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


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}\nНомер группы: {1}\nФорма обучения: {2}\n", base.ToString(), NumberGroup, formeducation);
            
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
            return string.Format("\nСтудент: {0}\nФорма обучения: {1}\nНомер группы: {2}\nСредний балл: {3}", student, formeducation, NumberGroup, Average);
        }
    }
}
