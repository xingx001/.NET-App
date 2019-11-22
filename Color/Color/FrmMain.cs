using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color
{
    /// <summary>
    /// 屏幕取色器 ARGB 测试版
    /// </summary>
    /// <remarks>
    /// @author zhangyp
    /// @since  19-04-11
    /// </remarks>
    public partial class FrmMain : Form
    {
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("User32.DLL")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);
        [DllImport("User32.DLL")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        [DllImport("user32.dll")]//取设备场景 
        private static extern IntPtr GetDC(IntPtr hwnd);//返回设备场景句柄 
        [DllImport("gdi32.dll")]//取指定点颜色 
        private static extern int GetPixel(IntPtr hdc, Point p);


        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public const uint OCR_NORMAL = 32512;

        public const uint SPI_SETCURSORS = 87;
        public const uint SPIF_SENDWININICHANGE = 2;

        /// <summary>
        /// 取色标记
        /// </summary>
        private bool ColorFlag = false;

        private MouseHook MouseHook = new MouseHook();

        #region constructor
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region protected override function

        #region 引发窗体载入事件
        /// <summary>
        /// 引发窗体载入事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.pnlColor.MouseDown += PnlColor_MouseDown;
            this.pnlColor.MouseUp += PnlColor_MouseUp;
            this.pnlColor.MouseHover += PnlColor_MouseHover;
            this.pnlColor.MouseLeave += PnlColor_MouseLeave;

            this.BarA.ValueChanged += Bar_ValueChanged;
            this.BarB.ValueChanged += Bar_ValueChanged;
            this.BarG.ValueChanged += Bar_ValueChanged;
            this.BarR.ValueChanged += Bar_ValueChanged;

            this.MouseHook.Hook();
            this.MouseHook.MouseMove += MouseHook_MouseMoveEvent;
        }
        #endregion

        #region 引发MouseDown事件
        /// <summary>
        /// 引发MouseDown事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        #region 引发窗体关闭事件
        /// <summary>
        /// 引发窗体关闭事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            this.MouseHook.UnHook();
            base.OnClosed(e);
        } 
        #endregion

        #endregion

        #region private event function


        private void MouseHook_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (!this.ColorFlag) return;

            Point p = new Point(e.X, e.Y);//取置顶点坐标 
            IntPtr hdc = GetDC(new IntPtr(0));//取到设备场景(0就是全屏的设备场景) 
            int c = GetPixel(hdc, p);//取指定点颜色 
            this.BarR.Value = (c & 0xFF);//转换R 
            this.BarG.Value = (c & 0xFF00) / 256;//转换G 
            this.BarB.Value = (c & 0xFF0000) / 65536;//转换B 
        }

        #region Panel框MouseDown事件
        /// <summary>
        /// Panel框MouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlColor_MouseDown(object sender, MouseEventArgs e)
        {
            this.ColorFlag = true;

            Bitmap bitmap = new Bitmap(Color.Properties.Resources.dropper_32px);
            //this.Cursor = new Cursor(bitmap.GetHicon());
            SetSystemCursor(bitmap.GetHicon(), OCR_NORMAL);
            bitmap.Dispose();
        }
        #endregion

        #region Panel框MouseUp事件
        /// <summary>
        /// Panel框MouseUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlColor_MouseUp(object sender, MouseEventArgs e)
        {
            this.ColorFlag = false;
            SystemParametersInfo(SPI_SETCURSORS, 0, IntPtr.Zero, SPIF_SENDWININICHANGE);
        }
        #endregion

        #region Panel框MouseHover事件
        /// <summary>
        /// Panel框MouseHover事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlColor_MouseHover(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Color.Properties.Resources.dropper_32px);
            this.Cursor = new Cursor(bitmap.GetHicon());
            bitmap.Dispose();
        }
        #endregion

        #region Panel框MouseLeave事件
        /// <summary>
        /// Panel框MouseLeave事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlColor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region TrackBar值更改事件
        /// <summary>
        /// TrackBar值更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar bar = sender as TrackBar;
            if (bar.Name.Equals("BarA"))
            {
                this.lbValA.Text = bar.Value.ToString();
            }
            else if (bar.Name.Equals("BarR"))
            {
                this.lbValR.Text = bar.Value.ToString();
            }
            else if (bar.Name.Equals("BarG"))
            {
                this.lbValG.Text = bar.Value.ToString();
            }
            else if (bar.Name.Equals("BarB"))
            {
                this.lbValB.Text = bar.Value.ToString();
            }
        } 
        #endregion

        #region 退出事件
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

    }
}
