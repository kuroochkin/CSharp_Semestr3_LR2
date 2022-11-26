using LR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = LR2.Action;

namespace LR2_C_____
{
    public class JournalEntry
    {
        private string NameCollection { get; set; }
        private Action TypeEvent { get; set; }
        private string NameProperty { get; set; }
        private string KeyElement { get; set; }


        public JournalEntry(string nameCollectionx, Action typeEvent, string namePropety, string keyElement)
        {
            NameCollection = nameCollectionx;
            TypeEvent = typeEvent;
            NameProperty = namePropety;
            KeyElement = keyElement;
        }


        public override string ToString()
        {
            return String.Format("Коллекция: {0} Событие: {1} Свойство/метод: {2}  Ключ: {3}", NameCollection, TypeEvent, NameProperty, KeyElement);
        }
    }
}
