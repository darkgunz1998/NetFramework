using System;
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
    }
}
