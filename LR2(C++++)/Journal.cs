using LR2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_C_____
{
    public class Journal
    {
        private List<JournalEntry> journalEntries = new List<JournalEntry>();

        public void StudentsChangesHandler(object sender, StudentsChangedEventArgs<string> sCA)
        {
            journalEntries.Add(new JournalEntry(sCA.NameCollection, sCA.Action, sCA.NameProperty, sCA.Key));
        }

        public override string ToString()
        {
            if( journalEntries.Count != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in journalEntries)
                {
                    builder.AppendLine(item.ToString());
                }
                return builder.ToString();
            }
            return "0";
        }

    }
}
