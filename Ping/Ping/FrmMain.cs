using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Ping
{
    public partial class FrmMain : Form
    {
        #region private var
        /// <summary>
        /// Tick值
        /// </summary>
        private const int TICK = 50;
        /// <summary>
        /// 计数变量
        /// </summary>
        private int count = 0;
        /// <summary>
        /// 链接标识
        /// </summary>
        private bool isLink = false;
        /// <summary>
        /// 图标反转标识
        /// </summary>
        private bool isIco = false;
        #endregion

        #region constructor
        public FrmMain()
        {
            InitializeComponent();
            this.AcceptButton = this.btnFunction;
            this.Load += new EventHandler(FrmMain_Load);
            this.FormClosed += new FormClosedEventHandler(FrmMain_FormClosed);
            this.txtPort.KeyPress += new KeyPressEventHandler(txtPort_KeyPress);
            this.FormClosing += new FormClosingEventHandler(FrmMain_FormClosing);
        }
        #endregion

        #region 载入
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.txtHost.Text = Properties.Settings.Default.host;
            this.txtPort.Text = Properties.Settings.Default.port;
            this.InitText();
        }
        #endregion

        #region 窗体关闭
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon.Dispose();
        }
        #endregion

        #region 窗体将关闭
        /// <summary>
        /// 窗体将关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("请确认退出?", "提示",
                MessageBoxButtons.OKCancel))
            {
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region 设置按钮文本
        /// <summary>
        /// 设置按钮文本
        /// </summary>
        private void InitText()
        {
            this.btnFunction.Text = this.timer.Enabled ? "结束" : "开始";
            if (!this.timer.Enabled)
                this.notifyIcon.Text = "点击<开始>检测...";
        }
        #endregion

        #region 菜单-退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuExit_Click(object sender, EventArgs e)
        {
            //if (DialogResult.OK == MessageBox.Show("请确认退出?", "提示",
            //    MessageBoxButtons.OKCancel))
            //    Application.Exit();
            //this.Close();
            Application.Exit();
        }
        #endregion

        #region 菜单-显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.BringToFront();
            }
        }
        #endregion

        #region 菜单-隐藏
        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHide_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 端口文本框按键事件
        /// <summary>
        /// 端口文本框按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57)
                && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 按钮-开始/停止
        /// <summary>
        /// 开始/停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFunction_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = !this.timer.Enabled;
            this.InitText();
            Properties.Settings.Default.host = this.txtHost.Text;
            Properties.Settings.Default.port = this.txtPort.Text;
            if (this.timer.Enabled &&
                this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 定时
        /// <summary>
        /// 定时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count++;
                this.Tcp();//2.到点Ping
                this.Notify();
            }
            else if (count == TICK)
            {
                count = 0;
            }
            else
                count++;

            //if (!this.isLink)//1.非连接状态，则闪烁
            //    this.Ico();
        }
        #endregion

        #region Ping
        /// <summary>
        /// Ping
        /// </summary>
        private void P()
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new
                     System.Net.NetworkInformation.Ping();

                System.Net.NetworkInformation.PingReply pingStatus =
                    ping.Send(IPAddress.Parse(this.txtHost.Text), 1000);

                this.isLink = (pingStatus.Status ==
                    System.Net.NetworkInformation.IPStatus.Success);
            }
            catch (System.Exception ex)
            {
                this.isLink = false;
            }
        }
        #endregion

        #region TCP
        /// <summary>
        /// TCP
        /// </summary>
        private void Tcp()
        {
            Task task = new Task(() =>
            {
                try
                {
                    int port = 0;
                    bool result = int.TryParse(this.txtPort.Text, out port);
                    if (!result)
                        this.isLink = false;

                    TcpClient client = new TcpClient(this.txtHost.Text, port);
                    client.Close();
                    this.isLink = true;
                }
                catch (Exception ex)
                {
                    this.isLink = false;
                    Console.WriteLine(ex.Message);
                }
            });//新建任务
            task.Start();//启动任务
        }
        #endregion

        #region 更改通知状态
        /// <summary>
        /// 更改通知状态
        /// </summary>
        private void Notify()
        {
            this.notifyIcon.Text = this.GetNote();
            this.notifyIcon.Icon = this.isLink ? Properties.Resources.link_32px :
                Properties.Resources.broken_link_32px;
        }
        #endregion

        #region 通知信息
        /// <summary>
        /// 通知信息
        /// </summary>
        /// <returns></returns>
        private string GetNote()
        {
            return "Host: " + this.txtHost.Text
                + "\r\n" + "Port: " + this.txtPort.Text
                + "\r\n" + "State: " + (this.isLink ? "在线" : "不在线");
        }
        #endregion

        #region ShowBalloonTip
        /// <summary>
        /// ShowBalloonTip
        /// </summary>
        private void ShowTip()
        {
            if (!this.isLink)
            {
                notifyIcon.BalloonTipText = "Ping " + this.txtHost.Text + " 失败!";
                notifyIcon.ShowBalloonTip(5000);
            }

        }
        #endregion

        #region 图片反转方法
        /// <summary>
        /// 图片反转方法
        /// </summary>
        private void Ico()
        {
            this.notifyIcon.Icon = this.isIco ? Properties.Resources.broken_link_32px :
                Properties.Resources.link_32px;
            this.isIco = !this.isIco;
        }
        #endregion

    }
}
