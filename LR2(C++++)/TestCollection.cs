using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LR2;

namespace LR3
{
    public delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    public class TestCollections<TKey, TValue>
    {
        private List<TKey> tKeyList;
        private List<string> stringList;
        private Dictionary<TKey, TValue> dictionaryTKey;
        private Dictionary<string, TValue> dictionaryString;
        private GenerateElement<TKey, TValue> generateMethod;

        public TestCollections(int count, GenerateElement<TKey, TValue> method)
        {
            tKeyList = new List<TKey>();
            stringList = new List<string>();
            dictionaryTKey = new Dictionary<TKey, TValue>();
            dictionaryString = new Dictionary<string, TValue>();
            generateMethod = method;
            for (int i = 0; i < count; i++)
            {
                tKeyList.Add(generateMethod(i).Key);
                stringList.Add(generateMethod(i).Value.ToString());
                dictionaryTKey.Add(generateMethod(i).Key, generateMethod(i).Value);
                dictionaryString.Add(generateMethod(i).Key.ToString(), generateMethod(i).Value);
            }
        }
        public static KeyValuePair<Person, Student> Generation(int Value)
        {
            Person KeyPerson = new Person("Name" + Value, "Surname", DateTime.Now);
            Student ValueStudent = new Student(KeyPerson, Education.Specialist, Value);
            return new KeyValuePair<Person, Student>(KeyPerson, ValueStudent);
        }

        public void searchTkeyList()
        {
            var first = tKeyList[0];
            var middle = tKeyList[tKeyList.Count / 2];
            var end = tKeyList[tKeyList.Count - 1];
            var nonExist = generateMethod(tKeyList.Count + 1).Key;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            tKeyList.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            tKeyList.Contains(middle);
            sw.Stop();
            Console.WriteLine("Центральный элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            tKeyList.Contains(end);
            sw.Stop();
            Console.WriteLine("Последний элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            tKeyList.Contains(nonExist);
            sw.Stop();
            Console.WriteLine("Несуществующий элемент tKeyList: {0}", sw.Elapsed);

        }

        public void searchstringList()
        {
            var first = stringList[0];
            var middle = stringList[stringList.Count / 2];
            var end = stringList[stringList.Count - 1];
            var nonExist = generateMethod(stringList.Count + 1).Key;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            stringList.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(middle);
            sw.Stop();
            Console.WriteLine("Центральный элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(end);
            sw.Stop();
            Console.WriteLine("Последний элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(nonExist.ToString());
            sw.Stop();
            Console.WriteLine("Несущетсвующий элемент stringList: {0}", sw.Elapsed);
        }

        public void searchdictionaryTKey()
        {
            TKey start = dictionaryTKey.ElementAt(0).Key;
            TKey middle = dictionaryTKey.ElementAt(dictionaryTKey.Count / 2).Key;
            TKey end = dictionaryTKey.ElementAt(dictionaryTKey.Count - 1).Key;
            TKey nonExist = generateMethod(dictionaryTKey.Count + 1).Key;


            Console.WriteLine("Поиск элемента " + start + " в коллекции _dictionary<TKey,TValue> - ");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictionaryTKey.ContainsKey(start);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryTKey.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("Время поиска центрального элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryTKey.ContainsKey(end);
            sw.Stop();
            Console.WriteLine("Время поиска последнего элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryTKey.ContainsKey(nonExist);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);
        }

        public void searchdictionaryString()
        {
            string start = dictionaryString.ElementAt(0).Key;
            string middle = dictionaryString.ElementAt(dictionaryString.Count / 2).Key;
            string end = dictionaryString.ElementAt(dictionaryString.Count - 1).Key;
            TKey nonExist = generateMethod(dictionaryString.Count + 1).Key;

            Console.WriteLine("Поиск элемента " + start + " в коллекции _dictionary<TKey,TValue> - ");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictionaryString.ContainsKey(start);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryString.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("Время поиска центрального элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryString.ContainsKey(end);
            sw.Stop();
            Console.WriteLine("Время поиска последнего элемента" + sw.Elapsed);

            sw.Restart();
            dictionaryString.ContainsKey(nonExist.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);
        }
    }
}
