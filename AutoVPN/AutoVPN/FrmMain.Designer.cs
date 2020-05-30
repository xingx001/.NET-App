namespace AutoVPN
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbService = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.Dialer = new DotRas.RasDialer(this.components);
            this.lsb = new System.Windows.Forms.ListBox();
            this.cmbPhoneNumber = new System.Windows.Forms.ComboBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Location = new System.Drawing.Point(30, 25);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(47, 12);
            this.lbService.TabIndex = 9;
            this.lbService.Text = "服务器:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(42, 55);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(35, 12);
            this.lbUser.TabIndex = 10;
            this.lbUser.Text = "用户:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(42, 84);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(35, 12);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "密码:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(89, 52);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(200, 21);
            this.txtUser.TabIndex = 2;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(89, 81);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(200, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(89, 117);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(48, 16);
            this.chkAuto.TabIndex = 4;
            this.chkAuto.Text = "自动";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(89, 139);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(215, 139);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "断开";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Dialer
            // 
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            this.Dialer.Credentials = null;
            this.Dialer.EapOptions = new DotRas.RasEapOptions(false, false, false);
            this.Dialer.HangUpPollingInterval = 0;
            this.Dialer.Options = new DotRas.RasDialOptions(false, false, false, false, false, false, false, false, false, false);
            this.Dialer.StateChanged += new System.EventHandler<DotRas.StateChangedEventArgs>(this.Dialer_StateChanged);
            this.Dialer.DialCompleted += new System.EventHandler<DotRas.DialCompletedEventArgs>(this.Dialer_DialCompleted);
            // 
            // lsb
            // 
            this.lsb.FormattingEnabled = true;
            this.lsb.HorizontalScrollbar = true;
            this.lsb.ItemHeight = 12;
            this.lsb.Location = new System.Drawing.Point(306, 6);
            this.lsb.Name = "lsb";
            this.lsb.ScrollAlwaysVisible = true;
            this.lsb.Size = new System.Drawing.Size(277, 172);
            this.lsb.TabIndex = 7;
            // 
            // cmbPhoneNumber
            // 
            this.cmbPhoneNumber.FormattingEnabled = true;
            this.cmbPhoneNumber.Location = new System.Drawing.Point(89, 22);
            this.cmbPhoneNumber.Name = "cmbPhoneNumber";
            this.cmbPhoneNumber.Size = new System.Drawing.Size(201, 20);
            this.cmbPhoneNumber.TabIndex = 12;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(8, 139);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 13;
            this.btnClean.Text = "删除";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 186);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.cmbPhoneNumber);
            this.Controls.Add(this.lsb);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lbService);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoVPN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private DotRas.RasDialer Dialer;
        private System.Windows.Forms.ListBox lsb;
        private System.Windows.Forms.ComboBox cmbPhoneNumber;
        private System.Windows.Forms.Button btnClean;
    }
}

