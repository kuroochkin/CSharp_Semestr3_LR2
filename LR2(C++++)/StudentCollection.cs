using LR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_C_____
{
    public class StudentCollection<TKey>
    {
        private Dictionary<TKey, Student> students;
        private KeySelector<TKey> keySelector;


        public StudentCollection(KeySelector<TKey> keySelector)
        {
            this.students = new Dictionary<TKey, Student>();
            this.keySelector = keySelector;
        }

        
        public void AddDefaults()
        {
            var stud = new StudentCollection<string>(GiveKey);
            Person person1 = new Person("Влад", "Курочкин", new DateTime(2003, 06, 19));
            Student student1 = new Student(person1, Education.Bachelor, 100);
            var student2 = new Student(new Person("Максим", "Ярочевский", new DateTime(2002, 06, 19)), Education.Bachelor, 101);
           
            this.students.Add(keySelector(student1), student1);
            this.students.Add(keySelector(student2), student2);



            foreach (var item in students)
            {
                Console.WriteLine($"key: {item.Key}\n  value:\n {item.Value}");
            }
        }

        public static string GiveKey(Student st)
        {
            return st.Datastudent.Surname + " " + st.Datastudent.Name;
        }
    }
}
