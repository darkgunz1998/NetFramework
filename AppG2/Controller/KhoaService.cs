using AppG2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Controller
{
    public class KhoaService
    {
        public static List<Khoa> GetListKhoa()
        {
            return new AppG2Context().KhoaDbset.ToList();
        }
        public static Khoa GetKhoaByIDKhoa(string IDKhoa)
        {
            return new AppG2Context().KhoaDbset.Where(e => e.IDKhoa == IDKhoa).FirstOrDefault();
        }
    }
}
