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
            picAvatar.AllowDrop = true;
            if (File.Exists(pathAvatarImg))
            {
                FileStream fileStream = new FileStream(pathAvatarImg, FileMode.Open, FileAccess.Read);

                picAvatar.Image = Image.FromStream(fileStream);
                fileStream.Close();
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
            bool imageSave = false;
            if(Image != null)
            {             
               if ( !Directory.Exists(pathDirectoryImg))
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
    }
}
    