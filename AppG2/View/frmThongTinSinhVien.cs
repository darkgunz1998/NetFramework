using AppG2.Controller;
using AppG2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2.View
{
    public partial class frmThongTinSinhVien : Form
    {
        #region Variables for Image Avt process
        Image Image;
        string pathDirectoryImg;
        string pathAvatarImg;
        #endregion

        #region Path File
        string pathStudentDataFile;
        string pathHistoryLearningDataFile;
        #endregion
        public frmThongTinSinhVien(string maSinhVien)
        {
            InitializeComponent();
            pathStudentDataFile = Application.StartupPath + @"\Data\student.txt";
            pathHistoryLearningDataFile = Application.StartupPath + @"\Data\historylearning.txt";
            pathDirectoryImg = Application.StartupPath + "/Img";
            pathAvatarImg = pathDirectoryImg + "/avatar.png";
            picAvatar.AllowDrop = true;
            if (File.Exists(pathAvatarImg))
            {
                FileStream fileStream = new FileStream(pathAvatarImg, FileMode.Open, FileAccess.Read);

                picAvatar.Image = Image.FromStream(fileStream);
                fileStream.Close();
            }
            loadDataGridView(maSinhVien);
          //  var student = StudentService.GetStudent(maSinhVien);
           
        }

        private void lblChonAnh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "File ảnh(*.png, *.jpg)|*.png; *.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image = Image.FromFile(openFileDialog.FileName);
                picAvatar.Image = Image;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            #region cập nhật ảnh đại diện
            bool imageSave = false;
            if (Image != null)
            {
                if (!Directory.Exists(pathDirectoryImg))
                {
                    Directory.CreateDirectory(pathDirectoryImg);
                }
                Image.Save(pathAvatarImg);
                imageSave = true;
            }
            if (imageSave)
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void picAvatar_DragDrop(object sender, DragEventArgs e)
        {
            var rs = (string[])e.Data.GetData(DataFormats.FileDrop);
            var filePath = rs.FirstOrDefault();
            Image = Image.FromFile(filePath);
            picAvatar.Image = Image;
        }

        private void picAvatar_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void mnIXoaAvt_Click(object sender, EventArgs e)
        {
            picAvatar.Image = Properties.Resources.avatar;
            File.Delete(pathAvatarImg);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThongTinSinhVien_Load(object sender, EventArgs e)
        {

        }
        private void loadDataGridView(string maSinhVien)
        {
            var student = StudentService.GetStudent(pathStudentDataFile, pathHistoryLearningDataFile, maSinhVien);
            bdsQuaTrinhHocTap.DataSource = null;
            dtgvQuaTrinhHocTap.AutoGenerateColumns = false; // bỏ tự động tạo theo tên trường
            if (student == null)
                throw new Exception("Khong ton tai sinh vien nay");
            else
            {
                txtMaSV.Text = student.IDStudent;
                txtTen.Text = student.FirstName;
                txtHo.Text = student.LastName;
                txtHo.Text = student.FirstName + " " + student.LastName;
                txtQueQuan.Text = student.POB;
                dtpNamSinh.Value = student.DOB;
                cbGender.Checked = student.Gender == Model.Gender.Male;
                if (student.ListHistoryLearning != null)
                {
                    bdsQuaTrinhHocTap.DataSource = student.ListHistoryLearning;
                    dtgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
                }

            }
            dtgvQuaTrinhHocTap.DataSource = bdsQuaTrinhHocTap;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa dữ liệu này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                // var historyLearning = (HistoryLearning)bdsQuaTrinhHocTap.Current; 2 cach
                var historyLearning = bdsQuaTrinhHocTap.Current as HistoryLearning;
                StudentService.DeleteHistoryLearning(historyLearning.IDHistoryLearning, pathHistoryLearningDataFile);

                //delete in datagridview nếu chọn nhiều cái
                    /*foreach (DataGridViewRow item in dtgvQuaTrinhHocTap.SelectedRows)
                    {
                        dtgvQuaTrinhHocTap.Rows.RemoveAt(item.Index);
                    }*/
                //delete in datagridview nếu chỉ lấy 1 cái là cái đầu tiên mình chọn xóa
                dtgvQuaTrinhHocTap.Rows.RemoveAt(dtgvQuaTrinhHocTap.SelectedRows[0].Index);
            }
            else MessageBox.Show("Bạn đã không xóa", "Thông báo");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var history = bdsQuaTrinhHocTap.Current as HistoryLearning;
            if(history != null)
            {
                var f = new frmQuaTrinhHocTapChiTiet(pathHistoryLearningDataFile, history, null);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    loadDataGridView(txtMaSV.Text);
                    //Tiến hành nạp lại dữ liệu lên lưới
                }
            }          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new frmQuaTrinhHocTapChiTiet(pathHistoryLearningDataFile, null, txtMaSV.Text);
            if( f.ShowDialog() == DialogResult.OK)
            {
                loadDataGridView(txtMaSV.Text);
                //Tiến hành nạp lại dữ liệu lên lưới
            }
        }
        
    }
}
    