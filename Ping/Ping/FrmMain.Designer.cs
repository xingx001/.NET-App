namespace Ping
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnFunction = new System.Windows.Forms.Button();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbhost = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.menuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Tcp";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShow,
            this.menuHide,
            this.toolStripSeparator1,
            this.menuExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 76);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(100, 22);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHost.Location = new System.Drawing.Point(72, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(190, 23);
            this.txtHost.TabIndex = 1;
            // 
            // btnFunction
            // 
            this.btnFunction.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunction.Location = new System.Drawing.Point(424, 12);
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(75, 23);
            this.btnFunction.TabIndex = 2;
            this.btnFunction.Text = "开始";
            this.btnFunction.UseVisualStyleBackColor = true;
            this.btnFunction.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // menuShow
            // 
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size(100, 22);
            this.menuShow.Text = "显示";
            this.menuShow.Click += new System.EventHandler(this.menuShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // lbhost
            // 
            this.lbhost.AutoSize = true;
            this.lbhost.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbhost.Location = new System.Drawing.Point(22, 15);
            this.lbhost.Name = "lbhost";
            this.lbhost.Size = new System.Drawing.Size(44, 17);
            this.lbhost.TabIndex = 3;
            this.lbhost.Text = "主机：";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPort.Location = new System.Drawing.Point(268, 15);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(44, 17);
            this.lbPort.TabIndex = 4;
            this.lbPort.Text = "端口：";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPort.Location = new System.Drawing.Point(318, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex = 5;
            // 
            // menuHide
            // 
            this.menuHide.Name = "menuHide";
            this.menuHide.Size = new System.Drawing.Size(100, 22);
            this.menuHide.Text = "隐藏";
            this.menuHide.Click += new System.EventHandler(this.menuHide_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 47);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbhost);
            this.Controls.Add(this.btnFunction);
            this.Controls.Add(this.txtHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnFunction;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lbhost;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ToolStripMenuItem menuHide;
    }
}

