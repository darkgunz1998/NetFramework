using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class HistoryLearning
    {
        [Key] //IDHistoryLearning là khóa chính
        public string IDHistoryLearning { get; set; }
        public int YearFrom { get; set; }
        public int YearEnd { get; set; }
        public string Address { get; set; }
        
        public string IDStudent { get; set; }
        [ForeignKey("IDStudent")] //set khóa ngoại   
        //FK
        public Student Student { get; set; }

        public string Period {
            get
            {
                return string.Format("{0} -> {1}", YearFrom, YearEnd);
            }
        }
    }
}
