using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class Diem
    {
        [Key, Column(Order = 0)]
        
        public string IDMonHoc { get; set; }
        [Key, Column(Order = 1)]
        public string IDStudent { get; set; }
        public double  DiemMonHoc { get; set; }

       
        public MonHoc MonHoc { get; set; }

        public Student Student { get; set; }


    }
}
