using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class MonHoc
    {
        [Key]
        public string IDMonHoc { get; set; }
        public string TenMonHoc { get; set; }

        public string IDKhoa { get; set; }
        [ForeignKey("IDKhoa")]
        public Khoa Khoa { get; set; }


        public virtual ICollection<Diem> ListDiem { get; set; }
    }
}
