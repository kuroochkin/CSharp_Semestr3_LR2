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
        public Test() { Subject = "Физика"; Passed = false; }
       
        public override string ToString()
        {
            string text = "(Не сдано)";
            if (Passed == true)
                text = "(Сдано)";
            return string.Format("Предмет: {0}{1}", Subject, text);
        }
    }
}
