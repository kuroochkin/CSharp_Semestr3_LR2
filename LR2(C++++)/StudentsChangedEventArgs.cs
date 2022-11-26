using LR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = LR2.Action;

namespace LR2_C_____
{
    public class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string NameCollection { get; set; }
        public Action Action { get; set; }
        public string NameProperty { get; set; }
        public TKey Key { get; set; }

        public StudentsChangedEventArgs(string NameCollection, Action Action, string NameProperty, TKey Key)
        {
            this.NameCollection = NameCollection;
            this.Action = Action;
            this.NameProperty = NameProperty;
            this.Key = Key;
        }

        public string ToString()
        {
            return $"{NameCollection} {Action} {NameProperty} {Key}";
        }

    }
}
