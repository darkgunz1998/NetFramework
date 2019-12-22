using AppG2.Controller;
using AppG2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2.View
{
    public partial class frmDanhSachSinhVienChiTiet : Form
    {
        Student student = null;
        public frmDanhSachSinhVienChiTiet(Student student = null)
        {
            InitializeComponent();
            this.student = student;
            var lsKhoa = KhoaService.GetListKhoa();
            //foreach(var khoa in lsKhoa)
            //{
            //    ComboboxItem item = new ComboboxItem();
            //    item.Text = khoa.TenKhoa;
            //    item.Value = khoa.IDKhoa;

            //}
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "IDKhoa";
            foreach (var khoa in lsKhoa)
            {
                cbbKhoa.Items.Add(khoa);
            }
            cbbKhoa.SelectedIndex = 0;
            if (student != null)
            {
                //chinh sua
                this.Text = "Chỉnh sửa sinh viên";
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                if (student.Gender == Gender.Male)
                    cbGender.Checked = true;
                else cbGender.Checked = false;
                dtpDOB.Value = student.DOB;
                txtPOB.Text = student.POB;
                Khoa khoaEdit = KhoaService.GetKhoaByIDKhoa(student.IDKhoa);
                cbbKhoa.SelectedIndex = cbbKhoa.FindString(khoaEdit.TenKhoa);
            }
            else
            {
                //them moi
                this.Text = "Thêm sinh viên";
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (student != null)
            {
                //chinh sua
              
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                if (cbGender.Checked == true)
                    student.Gender = Gender.Male;
                else student.Gender = Gender.FeMale;
                student.DOB = dtpDOB.Value.Date;
                student.POB = txtPOB.Text;
                Khoa khoa = cbbKhoa.Items[cbbKhoa.SelectedIndex] as Khoa;
                student.IDKhoa = khoa.IDKhoa;
                StudentService.EditStudentDB(student);
            }
            else
            {
                //them moi
                Student std = new Student();
                std.IDStudent = Guid.NewGuid().ToString();
                std.FirstName = txtFirstName.Text;
                std.LastName = txtLastName.Text;
                if (cbGender.Checked == true)
                    std.Gender = Gender.Male;
                else std.Gender = Gender.FeMale;
                std.DOB = dtpDOB.Value.Date;
                std.POB = txtPOB.Text;
                Khoa khoa = cbbKhoa.Items[cbbKhoa.SelectedIndex] as Khoa;
                std.IDKhoa = khoa.IDKhoa;
                StudentService.CreateStudentDB(std);
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK; // Đóng form
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
