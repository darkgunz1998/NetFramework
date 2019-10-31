using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class Student
    {
        public string IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; } //day of birt
        public string POB { get; set; } //place of birt

        public virtual ICollection<HistoryLearning> ListHistoryLearning { get; set; }
    }
    public enum Gender
    {
        Male, FeMale, Other
    }
}
