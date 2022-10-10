using LR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_C_____
{
    public class ExamHelper : Exam, IComparer<Exam>
    {
        public int Compare(Exam? date1, Exam? date2)
        {
           if(date1 is null || date2 is null) throw new NotImplementedException();
            if (date1.Date > date2.Date)
                return 1;
            else if (date1.Date == date2.Date)
                return 0;
            else 
                return -1;
        }
    }
}
