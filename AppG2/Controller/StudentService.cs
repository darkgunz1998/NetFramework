﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppG2.Model;
namespace AppG2.Controller
{
    public class StudentService
    {
        /// <summary>
        /// Lấy sinh viên theo mã sinh viên từ mockdata
        /// </summary>
        /// <param name="IDStudent"></param>
        /// <returns>Lấy sinh viên theo mã sinh viên</returns>
        public static Student GetStudent(string idStudent)
        {
            Student student = new Student();
            student.IDStudent = idStudent;
            student.FirstName = "Nghia";
            student.LastName = "Duc";
            student.DOB = new DateTime(2019, 6, 9);
            student.POB = "QN";
            student.Gender = Model.Gender.Male;

            student.ListHistoryLearning = new List<HistoryLearning>();
            for(int i = 1; i <= 12; i++)
            {
                HistoryLearning historyLearning = new HistoryLearning
                {
                    IDHistoryLearning = i.ToString(),
                    YearFrom = 2006 + i,
                    YearEnd = 2007 + i,
                    Address = "THPT NTT",
                    IDStudent = idStudent
                    
                };
                student.ListHistoryLearning.Add(historyLearning);
            }
         
            return student;
        }
        /// <summary>
        /// Lấy sinh viên theo mã sinh viên từ file
        /// </summary>
        /// <param name="pathDataFile">Đường dẫn tới file chứa dữ liệu</param>
        /// <param name="idStudent">Mã sinh viên</param>
        /// <returns>Sinh viên theo mã sinh viên hoặc null nếu không tồn tại</returns>
        public static Student GetStudent(string pathDataFileStudent, string pathDataFileHistoryLearning, string idStudent)
        {
            if (File.Exists(pathDataFileStudent))
            {
                CultureInfo cultureInfo = CultureInfo.InvariantCulture; // Dùng để parse ngày tháng
                string[] listLines = File.ReadAllLines(pathDataFileStudent);
                foreach (var line in listLines)
                {
                    var rs = line.Split(new char[]{'#'});
                    Student student = new Student
                    {
                        IDStudent = rs[0],
                        LastName = rs[1],
                        FirstName = rs[2],
                        Gender = rs[3] == "Male" ? Gender.Male : (rs[3] == "FeMale" ? Gender.FeMale : Gender.Other),
                        DOB = DateTime.ParseExact(rs[4], "yyyy-MM-dd", cultureInfo),
                        POB = rs[5]
                    };
                    //History learning
                    student.ListHistoryLearning = new List<HistoryLearning>();
                    if (File.Exists(pathDataFileHistoryLearning))
                    {
                        string[] listLinesHistoryLearning = File.ReadAllLines(pathDataFileHistoryLearning);
                        foreach(var lineHistory in listLinesHistoryLearning)
                        {
                            var ls = lineHistory.Split(new char[] { '#' });
                            HistoryLearning historyLearning = new HistoryLearning();

                            historyLearning.IDHistoryLearning = ls[0];
                            historyLearning.YearFrom = int.Parse(ls[1]);
                            historyLearning.YearEnd = int.Parse(ls[2]);
                            historyLearning.Address = ls[3];
                            historyLearning.IDStudent = ls[4];
                            
                            if(student.IDStudent == historyLearning.IDStudent)
                            {
                                student.ListHistoryLearning.Add(historyLearning);
                            }
                        }
                    }
                    if (student.IDStudent == idStudent)
                        return student;
                }
            }
            return null;
        }
        public static Student GetStudentDB(string idStudent)
        {
            var db = new AppG2Context();
            return db.StudentDbset.Where(e => e.IDStudent == idStudent).FirstOrDefault();
        }
        public static List<Student> GetAllStudentDB(string key = null)
        {
            var db = new AppG2Context();

            if (key == null) key = "";
            return db.StudentDbset.Where(e=>e.FirstName.Contains(key) || e.LastName.Contains(key) || e.POB.Contains(key)).ToList();
        }
        //xóa student 
        public static void DeleteStudent(string idStudent)
        {
            var db = new AppG2Context();

            var lsDiem = db.DiemDbset.Where(e => e.IDStudent == idStudent).ToList();
            foreach(var diem in lsDiem)
            {
                db.DiemDbset.Remove(diem);
            }

            var lsHistory = db.HistoryLearningDbset.Where(e => e.IDStudent == idStudent).ToList();
            foreach (var history in lsHistory)
            {
                db.HistoryLearningDbset.Remove(history);
            }

            var student = db.StudentDbset.Where(e => e.IDStudent == idStudent).FirstOrDefault();
            if (student != null)
                db.StudentDbset.Remove(student);
            db.SaveChanges();
        }
        //thêm student
        public static void CreateStudentDB(Student student)
        {
            var db = new AppG2Context();
            var std = db.StudentDbset.Find(student.IDStudent);
            if(std == null) { 
                db.StudentDbset.Add(student);
                db.SaveChanges();
            }
        }
        //xóa student
        public static void EditStudentDB(Student student)
        {
            var db = new AppG2Context();
            var std = db.StudentDbset.Find(student.IDStudent);
           
            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.Gender = student.Gender;
            std.DOB = student.DOB;
            std.POB = student.POB;
            std.IDKhoa = student.IDKhoa;
            db.SaveChanges();
        }
        public static List<HistoryLearning> GetHistoryLearning(string idStudent)
        {
            return new AppG2Context().HistoryLearningDbset.Where(e => e.IDStudent == idStudent).OrderBy(e=>e.YearFrom).ToList();
        }
        //Xóa kiểu di chuyển sang file khác, xóa file cũ
        /*public static void DeleteHistoryLearning(string id, string pathHistoryLearningDataFile)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(pathHistoryLearningDataFile))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var ls = line.Split(new char[] { '#' });
                    if (ls[0] != id)
                        sw.WriteLine(line);
                }
            }

            File.Delete(pathHistoryLearningDataFile);
            File.Move(tempFile, pathHistoryLearningDataFile);
        }*/
        public static void DeleteHistoryLearning(string id, string pathDataFileHistoryLearning)
        {
            if (File.Exists(pathDataFileHistoryLearning))
            {
                string[] listLinesHistoryLearning = File.ReadAllLines(pathDataFileHistoryLearning); //Lấy file ra , nên dùng var cho an toàn
                File.WriteAllText(pathDataFileHistoryLearning, ""); // Làm cho file đó trống
                foreach (var lineHistory in listLinesHistoryLearning)
                {
                    var ls = lineHistory.Split(new char[] { '#' });
                    var line = "\n";
                    if (lineHistory == listLinesHistoryLearning[listLinesHistoryLearning.Length - 1])
                        line = "";
                    if (ls[0] != id)
                    {
                        File.AppendAllText(pathDataFileHistoryLearning, lineHistory + line); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì
                    }
                }
            }
        }
        public static void DeleteHistoryLearningDB(string id)
        {
            var db = new AppG2Context();
            var history = db.HistoryLearningDbset.Where(e => e.IDHistoryLearning == id).FirstOrDefault();
            if (history != null)
                db.HistoryLearningDbset.Remove(history);
            db.SaveChanges();
        }
        public static void EditHistoryLearning(HistoryLearning history, string pathHistoryLearningDataFile)
        {
            if (File.Exists(pathHistoryLearningDataFile))
            {
                string[] listLinesHistoryLearning = File.ReadAllLines(pathHistoryLearningDataFile); //Lấy file ra , nên dùng var cho an toàn
                File.WriteAllText(pathHistoryLearningDataFile, ""); // Làm cho file đó trống             
                foreach (var lineHistory in listLinesHistoryLearning)
                {
                    var ls = lineHistory.Split(new char[] { '#' });
                    var line = "\n";
                    if (lineHistory == listLinesHistoryLearning[listLinesHistoryLearning.Length - 1])
                        line = "";
                    if (ls[0] != history.IDHistoryLearning)
                    {
                        File.AppendAllText(pathHistoryLearningDataFile, lineHistory + line); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì
                    }
                    else
                    {
                        string contentHistory = history.IDHistoryLearning + "#" + history.YearFrom + "#" + history.YearEnd + "#" + history.Address + "#" + history.IDStudent;
                       
                        File.AppendAllText(pathHistoryLearningDataFile, contentHistory + line);
                    }

                }
            }
        }
        public static void EditHistoryLearningDB(HistoryLearning history)
        {
            var db = new AppG2Context();
            var ht = db.HistoryLearningDbset.Find(history.IDHistoryLearning);
            ht.Address = history.Address;
            ht.YearFrom = history.YearFrom;
            ht.YearEnd = history.YearEnd;
            db.SaveChanges();
        }
        public static void CreateHistoryLearning(HistoryLearning history, string pathHistoryLearningDataFile)
        {
            if (File.Exists(pathHistoryLearningDataFile))
            {
                string[] listLinesHistoryLearning = File.ReadAllLines(pathHistoryLearningDataFile); //Lấy file ra , nên dùng var cho an toàn

                history.IDHistoryLearning = Guid.NewGuid().ToString();
                string contentHistory = history.IDHistoryLearning + "#" + history.YearFrom + "#" + history.YearEnd + "#" + history.Address + "#" + history.IDStudent;
                File.AppendAllText(pathHistoryLearningDataFile, "\n" + contentHistory); //Append là thêm vào, chèn vào sau chuỗi có trước, thêm vào ở File nào, nội dung là gì                 
            }
        }
        public static void CreateHistoryLearningDB(HistoryLearning history)
        {
            var db = new AppG2Context();
            history.IDHistoryLearning = Guid.NewGuid().ToString();
            db.HistoryLearningDbset.Add(history);
            db.SaveChanges();
        }
    }
}
