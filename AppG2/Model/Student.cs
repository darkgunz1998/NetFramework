using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class Student
    {
        [Key]// IDStudent là khóa chính
        public string IDStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; } //day of birt
        public string POB { get; set; } //place of birt

        public string IDKhoa { get; set; }
        [ForeignKey("IDKhoa")]
        public Khoa Khoa { get; set; }

        public virtual ICollection<HistoryLearning> ListHistoryLearning { get; set; }

        public virtual ICollection<Diem> ListDiem { get; set; }

        public string FullName
        {
            get
            {
                var anh = "Anh";
                if (Gender == Gender.FeMale) anh = "Chị";  
                return string.Format("{0} {1} {2}", anh, FirstName , LastName);
            }
        }
    }
    public enum Gender
    {
        Male, FeMale, Other
    }
    
}
