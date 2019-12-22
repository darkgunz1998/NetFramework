using AppG2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Controller
{
    public class DiemService
    {
        public static List<Diem> GetListDiemByIDStudent(string IDStudent)
        {
            var db = new AppG2Context();
            return db.DiemDbset.Where(e => e.IDStudent == IDStudent).ToList();
        }
        public static Diem GetDiemByIDStudentAndIDMonHoc(string IDStudent, string IDMonHoc)
        {
            var db = new AppG2Context();
            return db.DiemDbset.Where(e => e.IDStudent == IDStudent && e.IDMonHoc == IDMonHoc).FirstOrDefault();
        }
        public static void AddOrEditDiemDB(Diem diem)
        {
            var db = new AppG2Context();
            var std = db.DiemDbset.Where(e => e.IDMonHoc == diem.IDMonHoc && e.IDStudent == diem.IDStudent).FirstOrDefault();
            if (std != null)
            {
                std.DiemMonHoc = diem.DiemMonHoc;
            }
            else
            {
                db.DiemDbset.Add(diem);
            }

            db.SaveChanges();
        }
    }
}
