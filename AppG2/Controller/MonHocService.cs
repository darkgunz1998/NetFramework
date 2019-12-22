using AppG2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Controller
{
    public class MonHocService
    {
        public static List<MonHoc> GetListMonHocByIDKhoa(string IDKhoa)
        {
            return new AppG2Context().MonHocDbset.Where(e => e.IDKhoa == IDKhoa).ToList();
        }
        public static List<MonHoc> GetListMonHoc()
        {
            return new AppG2Context().MonHocDbset.ToList();
        }
    }
}
