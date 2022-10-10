using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR2
{
    public class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime datetime;

        public Person(string name, string surname, DateTime datetime)
        {
            this.name = name;
            this.surname = surname;
            this.datetime = datetime;
        }

        public Person()
        {
            this.name = "Владислав";
            this.surname = "Курочкин";
            this.datetime = new DateTime(2003, 6, 19);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }

        public int GetData
        {
            get
            {
                return Convert.ToInt32(datetime);
            }
            set
            {
                datetime = Convert.ToDateTime(value);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            Person? temp = obj as Person;
            if (temp == null)
            {
                return false;
            }
            return (this.name == temp.name) && (this.surname == temp.surname) && (this.datetime == temp.datetime);
        }
        public static bool operator == (Person a, Person b)
        {
            if (Object.ReferenceEquals(a, b))
                return false;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator != (Person a, Person b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode()^surname.GetHashCode()^datetime.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            return new Person(this.name, this.surname, this.datetime); 
        }
        DateTime IDateAndCopy.Date { get; set; }

        public override string ToString()
        {
            return string.Format("Фамилия: {0}\nИмя: {1}\nДата рождения: {2}",  Name, Surname, Datetime);
        }

        public virtual string ToShortString()
        {
            return "\n" + "Имя: " + Name + "\n" + "Фамилия: " + Surname;
        }
    }
}