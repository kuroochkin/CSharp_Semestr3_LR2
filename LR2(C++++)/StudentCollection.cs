using LR2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Action = LR2.Action;

namespace LR2_C_____
{
    public delegate void StudentsChangedHandler<TKey>(object source, StudentsChangedEventArgs<TKey> args);

    public class StudentCollection<TKey> : INotifyPropertyChanged
    {
        private Dictionary<TKey, Student> students;
        private KeySelector<TKey> keySelector;

        public event StudentsChangedHandler<TKey> StudentsChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Dictionary<TKey, Student> Students { get; set; }

        public string NameCollection { get; set; }

        public StudentCollection(KeySelector<TKey> keySelector, string NameCollection)
        {
            this.students = new Dictionary<TKey, Student>();
            this.keySelector = keySelector;
            this.NameCollection = NameCollection;
        }

        public bool Remove(Student st)
        {
            if (students.ContainsValue(st))
            {
                foreach (KeyValuePair<TKey, Student> item in students)
                {
                    if (item.Value.Equals == st.Equals)
                    {
                        StudentPropertyChanged(Action.Remove, "Удаление", item.Key);
                        st.PropertyChanged -= PropertyChangeded;
                        students.Remove(item.Key);
                        break;
                    }
                }
                return true;
            }
            else return false;
        }


        public void AddDefaults()
        {
            Student student1 = new Student(new Person("Анна", "Самофеева", new DateTime(2002, 04, 06)), Education.Bachelor, 100);
            Student student2 = new Student(new Person("Софья", "Аверина", new DateTime(2002, 03, 05)), Education.Specialist, 101);


            this.students.Add(keySelector(student1), student1);
            this.students.Add(keySelector(student2), student2);         
        }

        public void AddStudents(params Student[] _students)
        {
            foreach(Student item in _students)
            {
                students.Add(keySelector(item),item);
                StudentsChanged(this, new StudentsChangedEventArgs<TKey>(NameCollection, Action.Add, "Добавление Студента", keySelector(item)));
            }
        }

        private void StudentPropertyChanged(Action action, string name, TKey key)
        {
            StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(NameCollection, action, name, key));
        }

        public void PropertyChangeded(object student, PropertyChangedEventArgs args)
        {
            StudentPropertyChanged(Action.Property, args.PropertyName, keySelector((Student)student));
        }

        public double MaxAverage
        {
            get
            {
                if (students.Count == 0) return -1;
                return students.Max(student => student.Value.Average);
            }
        }
        public IEnumerable GetList()
        {
            foreach (var item in students.Values)
                yield return item;
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupFormEducation
        {
            get { return students.GroupBy(student => student.Value.Dataeducation); }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return students.Where(student => student.Value.Dataeducation == value);
        }


        public static string GiveKey(Student st)
        {
            return st.Datastudent.Surname + " " + st.Datastudent.Name;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            
            foreach (KeyValuePair<TKey, Student> item in students)
            {
                builder.AppendLine("---------------------");
                builder.AppendFormat("{0}\nНомер группы: {1}\nФорма обучения: {2}\n", item.Value.Datastudent, item.Value.DataGroup, item.Value.Dataeducation);

                builder.Append("Экзамены:\n");
                foreach (Exam exam in item.Value.Dataexams)
                    builder.AppendLine(exam.ToString());

                builder.Append("Зачеты:\n");
                foreach (Test test in item.Value.Datatests)
                    builder.AppendLine(test.ToString());
            }
            return builder.ToString();
        }  
    }
}
