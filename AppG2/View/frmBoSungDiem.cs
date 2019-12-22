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
    public partial class frmBoSungDiem : Form
    {
        public List<TextBox> lsTextBox = new List<TextBox>();
        public string IDStudent;
        public frmBoSungDiem(string IDStudent, string IDKhoa)
        {
            InitializeComponent();
            this.IDStudent = IDStudent;
            var lsMonHoc = MonHocService.GetListMonHocByIDKhoa(IDKhoa);
            foreach (MonHoc mon in lsMonHoc)
            {
                Label label = new Label();
                label.Text = mon.TenMonHoc;
                TextBox text = new TextBox();
                text.Text = "0";
                text.Name = mon.IDMonHoc;
                lsTextBox.Add(text);
                flpBoSungDiem.Controls.Add(label);
                flpBoSungDiem.Controls.Add(text);
            }
            var lsDiem = DiemService.GetListDiemByIDStudent(IDStudent);
            foreach (TextBox tb in lsTextBox)
            {
                foreach (Diem diem in lsDiem)
                {
                    if (tb.Name == diem.IDMonHoc)
                        tb.Text = diem.DiemMonHoc.ToString();
                }

            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in lsTextBox)
            {
                Diem diem = DiemService.GetDiemByIDStudentAndIDMonHoc(IDStudent, tb.Name);
                if (diem == null) {
                    Diem dt = new Diem{
                        IDStudent = IDStudent,
                        IDMonHoc = tb.Name,
                        DiemMonHoc = Double.Parse(tb.Text)
                    };
                    DiemService.AddOrEditDiemDB(dt);
                }
                else { 
                diem.DiemMonHoc = Double.Parse(tb.Text);
                DiemService.AddOrEditDiemDB(diem);
                }
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK;
        }
    }
}
