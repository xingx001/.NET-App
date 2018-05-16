using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicGenerater
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                Image imag = pictureBox1.Image;
                Graphics g = Graphics.FromImage(imag);
                Font font = new System.Drawing.Font("宋体", 12, (System.Drawing.FontStyle.Bold));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, imag.Width, imag.Height), Color.Red, Color.Red, 1.2f, true);
                g.DrawString(this.txtUp.Text, font, brush, 50, 150);
                g.DrawString(this.txtMiddle.Text, font, brush, 50, 320);
                g.DrawString(this.txtDown.Text, font, brush, 50, 500);
                g.Dispose();

                pictureBox1.Image = imag;

                Clipboard.SetDataObject(pictureBox1.Image);
                MessageBox.Show("当前图片已经成功复制到剪贴板.请粘贴到QQ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Properties.Resources.slap;
        }


    }
}
