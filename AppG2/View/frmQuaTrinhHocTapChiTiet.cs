using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppG2.Controller;
using AppG2.Model;
namespace AppG2.View
{
    public partial class frmQuaTrinhHocTapChiTiet : Form
    {
        HistoryLearning history;
        string maSinhVien;
        //string pathHistoryLearningDataFile = null;
        public frmQuaTrinhHocTapChiTiet(HistoryLearning history = null, string maSinhVien = null)
        {
            InitializeComponent();
            this.history = history;
            //this.pathHistoryLearningDataFile = pathHistoryLearningDataFile;
            if (history != null)
            {
                //chinh sua
                this.Text = "Chỉnh sửa quá trình học tập";
                numTuNam.Value = history.YearFrom;
                numDenNam.Value = history.YearEnd;
                txtNoiHoc.Text = history.Address;
                
            }
            else
            {
                //them moi
                this.Text = "Thêm quá trình học tập";
                this.maSinhVien = maSinhVien;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if(history != null)
            {
                //cap nhat
                history.YearFrom = (int)numTuNam.Value;
                history.YearEnd = (int)numDenNam.Value;
                history.Address = txtNoiHoc.Text;
                StudentService.EditHistoryLearningDB(history);
            }
            else
            {
                //them moi 
                HistoryLearning hl = new HistoryLearning();
                hl.YearFrom = (int)numTuNam.Value;
                hl.YearEnd = (int)numDenNam.Value;
                hl.Address = txtNoiHoc.Text;
                hl.IDStudent = this.maSinhVien;
                StudentService.CreateHistoryLearningDB(hl);
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
            DialogResult = DialogResult.OK; // Đóng form
        }

    }
}
