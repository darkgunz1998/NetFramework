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
    public partial class frmDanhSachSinhVien : Form
    {
        public string Van = "1";
        public string VatLy = "2";
        public string CNTT = "3";
        public List<TextBox> lsTextBox = new List<TextBox>(); 
        public frmDanhSachSinhVien()
        {
            InitializeComponent();
            loadCheckedListbox();
        }
        private void loadCheckedListbox()
        {
            clbSinhVien.Items.Clear();
           
            List<Student> lsstudent = StudentService.GetAllStudentDB(null);
            clbSinhVien.DisplayMember = "FullName";
            foreach (Student std in lsstudent)
            {
                clbSinhVien.Items.Add(std);
            }
            clbSinhVien.SelectedIndex = 0;
            var lsVan = MonHocService.GetListMonHocByIDKhoa("1");
            var lsMonHoc = MonHocService.GetListMonHoc();
            foreach(MonHoc mon in lsMonHoc)
            {
                Label label = new Label();
                label.Text = mon.TenMonHoc;
                TextBox text = new TextBox();
                text.Text = "0";
                text.Name = mon.IDMonHoc;
                lsTextBox.Add(text);
                if(mon.IDKhoa == Van) { 
                    flpVan.Controls.Add(label);
                    flpVan.Controls.Add(text);
                }else if(mon.IDKhoa == VatLy)
                {
                    flpVatLy.Controls.Add(label);
                    flpVatLy.Controls.Add(text);
                }
                else if (mon.IDKhoa == CNTT)
                {
                    flpCNTT.Controls.Add(label);
                    flpCNTT.Controls.Add(text);
                }

            }
            Student stdent = clbSinhVien.Items[0] as Student;

            var lsDiem = DiemService.GetListDiemByIDStudent(stdent.IDStudent);
            foreach (TextBox tb in lsTextBox)
            {
                foreach (Diem diem in lsDiem)
                {
                    if (tb.Name == diem.IDMonHoc)
                        tb.Text = diem.DiemMonHoc.ToString();
                }

            }
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void clbSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student std = clbSinhVien.Items[clbSinhVien.SelectedIndex] as Student;
         
            txbName.Text = std.FullName;
            if (std.Gender == Gender.Male) cbGender.Checked = true;
            else cbGender.Checked = false;
            dtpDOB.Value = std.DOB;
            txbDiaChi.Text = std.POB;
            if (std.IDKhoa == Van)
                tabSinhVien.SelectedTab = tbpVan;
            else if(std.IDKhoa == VatLy)
                tabSinhVien.SelectedTab = tbpVatLy;
            else if (std.IDKhoa == CNTT)
                tabSinhVien.SelectedTab = tbpCNTT;
            var lsDiem = DiemService.GetListDiemByIDStudent(std.IDStudent);
            //foreach(Diem diem in lsDiem)
            //{
            //    foreach (TextBox tb in lsTextBox)
            //    {
            //        if (diem.IDMonHoc == tb.Name)
            //            tb.Text = diem.DiemMonHoc.ToString();

            //    }
            //}

            //set điểm về 0
            foreach (TextBox tb in lsTextBox)
            {
                tb.Text = "0";
            }
            //thêm điểm
            foreach (TextBox tb in lsTextBox)
            {
                foreach(Diem diem in lsDiem)
                {
                    if (tb.Name == diem.IDMonHoc)
                        tb.Text = diem.DiemMonHoc.ToString();
                }
                
            }

            //tinh điểm trung bình
            var dtb = 0.0;
            var tongMonHoc = 0;
            foreach (Diem diem in lsDiem)
            {
                dtb += diem.DiemMonHoc;
                tongMonHoc += 1;
            }
            lbDiemTrungBinh.Text = (dtb / tongMonHoc).ToString();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            clbSinhVien.Items.Clear();
            List<Student> lsstudent = StudentService.GetAllStudentDB(txtFind.Text);
            clbSinhVien.DisplayMember = "FullName";
            foreach (Student std in lsstudent)
            {
                clbSinhVien.Items.Add(std);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Student std = clbSinhVien.Items[clbSinhVien.SelectedIndex] as Student;
                var f = new frmDanhSachSinhVienChiTiet(std);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    loadCheckedListbox();
                    //Tiến hành nạp lại dữ liệu lên lưới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Bạn có chắc là muốn xóa sinh viên đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {

                for (int i = 0; i < clbSinhVien.Items.Count; i++)
                {
                    if (clbSinhVien.GetItemChecked(i) == true)
                    {
                        Student std = clbSinhVien.Items[i] as Student;
                        StudentService.DeleteStudent(std.IDStudent);
                        loadCheckedListbox();
                    }
                }

            }
            else MessageBox.Show("Bạn đã không xóa", "Thông báo");

           
        }

        private void bổSungSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDanhSachSinhVienChiTiet(null);
            if (f.ShowDialog() == DialogResult.OK)
            {
                loadCheckedListbox();
                //Tiến hành nạp lại dữ liệu lên lưới
            }
        }

        private void bổSungĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Student std = clbSinhVien.Items[clbSinhVien.SelectedIndex] as Student;
                var f = new frmBoSungDiem(std.IDStudent, std.IDKhoa);
                if (f.ShowDialog() == DialogResult.OK)
                {
                   
                    loadCheckedListbox();
                    //Tiến hành nạp lại dữ liệu lên lưới
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Vui lòng chọn sinh viên cần bổ sung điểm", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void xemLịchSửHọcCủaSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Student std = clbSinhVien.Items[clbSinhVien.SelectedIndex] as Student;
                var f = new frmThongTinSinhVien(std.IDStudent);
                if (f.ShowDialog() == DialogResult.OK)
                {

                    loadCheckedListbox();
                    //Tiến hành nạp lại dữ liệu lên lưới
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Xem thông tin thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
    
}
