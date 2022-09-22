using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR2
{
    public class Test
    {
        public string Subject { get; set; }
        public bool Passed { get; set; }

        public Test(string subject, bool passed)
        {
            this.Subject = subject;
            this.Passed = passed;
        }
        public Test()
        {
            Subject = "Физика";
            Passed = false;
        }
        public override string ToString()
        {
            return string.Format("Предмет для зачета:  = {0}, Сдан и ли нет: = {1}", Subject, Passed);
        }
    }
}
