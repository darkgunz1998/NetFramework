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

namespace AppG2
{
    public partial class frmThongTinSinhVien : Form
    {
        #region Variables for Image Avt process
        Image Image;
        string pathDirectoryImg;
        string pathAvatarImg;
        #endregion
        public frmThongTinSinhVien()
        {
            InitializeComponent();

            pathDirectoryImg = Application.StartupPath + "/Img";
            pathAvatarImg = pathDirectoryImg + "/avatar.png";
            if (File.Exists(pathAvatarImg))
            {
                picAvatar.Image = Image.FromFile(pathAvatarImg);
            }
        }
        
        private void lblChonAnh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh đại diện";
            openFileDialog.Filter = "File ảnh(*.png, *.jpg)|*.png; *.jpg";
            if( openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image = Image.FromFile(openFileDialog.FileName);
                picAvatar.Image = Image;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            #region cập nhật ảnh đại diện
            if(Image != null)
            {             
               if ( !Directory.Exists(pathDirectoryImg))
                {
                    Directory.CreateDirectory(pathDirectoryImg);
                }
                Image.Save(pathAvatarImg);
            }
            #endregion
        }
    }
}
