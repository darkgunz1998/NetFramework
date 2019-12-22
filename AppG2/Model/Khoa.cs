using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class Khoa
    {
        [Key]
        public string IDKhoa { get; set; }
        public string TenKhoa { get; set; }

        public virtual ICollection<Student> ListStudent { get; set; }
        public virtual ICollection<MonHoc> ListMonHoc { get; set; }

    }
}
