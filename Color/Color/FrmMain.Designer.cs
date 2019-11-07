namespace Color
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbExit = new System.Windows.Forms.Label();
            this.lbARGB = new System.Windows.Forms.Label();
            this.txtArgb = new System.Windows.Forms.TextBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.gBColor = new System.Windows.Forms.GroupBox();
            this.BarA = new System.Windows.Forms.TrackBar();
            this.BarR = new System.Windows.Forms.TrackBar();
            this.BarG = new System.Windows.Forms.TrackBar();
            this.BarB = new System.Windows.Forms.TrackBar();
            this.lbA = new System.Windows.Forms.Label();
            this.lbR = new System.Windows.Forms.Label();
            this.lbG = new System.Windows.Forms.Label();
            this.lbB = new System.Windows.Forms.Label();
            this.lbValA = new System.Windows.Forms.Label();
            this.lbValR = new System.Windows.Forms.Label();
            this.lbValG = new System.Windows.Forms.Label();
            this.lbValB = new System.Windows.Forms.Label();
            this.gBColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarB)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(12, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(65, 12);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "屏幕取色器";
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.Location = new System.Drawing.Point(239, 9);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(29, 12);
            this.lbExit.TabIndex = 1;
            this.lbExit.Text = "退出";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // lbARGB
            // 
            this.lbARGB.AutoSize = true;
            this.lbARGB.Location = new System.Drawing.Point(32, 34);
            this.lbARGB.Name = "lbARGB";
            this.lbARGB.Size = new System.Drawing.Size(29, 12);
            this.lbARGB.TabIndex = 2;
            this.lbARGB.Text = "ARGB";
            // 
            // txtArgb
            // 
            this.txtArgb.Location = new System.Drawing.Point(67, 31);
            this.txtArgb.Name = "txtArgb";
            this.txtArgb.Size = new System.Drawing.Size(152, 21);
            this.txtArgb.TabIndex = 3;
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColor.Location = new System.Drawing.Point(25, 74);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(70, 70);
            this.pnlColor.TabIndex = 4;
            // 
            // gBColor
            // 
            this.gBColor.Controls.Add(this.lbValB);
            this.gBColor.Controls.Add(this.lbValG);
            this.gBColor.Controls.Add(this.lbValR);
            this.gBColor.Controls.Add(this.lbValA);
            this.gBColor.Controls.Add(this.lbB);
            this.gBColor.Controls.Add(this.lbG);
            this.gBColor.Controls.Add(this.lbR);
            this.gBColor.Controls.Add(this.lbA);
            this.gBColor.Controls.Add(this.BarB);
            this.gBColor.Controls.Add(this.BarG);
            this.gBColor.Controls.Add(this.BarR);
            this.gBColor.Controls.Add(this.BarA);
            this.gBColor.Location = new System.Drawing.Point(113, 58);
            this.gBColor.Name = "gBColor";
            this.gBColor.Size = new System.Drawing.Size(155, 100);
            this.gBColor.TabIndex = 5;
            this.gBColor.TabStop = false;
            this.gBColor.Text = "颜色值";
            // 
            // BarA
            // 
            this.BarA.AutoSize = false;
            this.BarA.Location = new System.Drawing.Point(23, 16);
            this.BarA.Maximum = 255;
            this.BarA.Name = "BarA";
            this.BarA.Size = new System.Drawing.Size(100, 15);
            this.BarA.TabIndex = 0;
            this.BarA.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BarR
            // 
            this.BarR.AutoSize = false;
            this.BarR.Location = new System.Drawing.Point(23, 37);
            this.BarR.Maximum = 255;
            this.BarR.Name = "BarR";
            this.BarR.Size = new System.Drawing.Size(100, 15);
            this.BarR.TabIndex = 1;
            this.BarR.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BarG
            // 
            this.BarG.AutoSize = false;
            this.BarG.Location = new System.Drawing.Point(23, 58);
            this.BarG.Maximum = 255;
            this.BarG.Name = "BarG";
            this.BarG.Size = new System.Drawing.Size(100, 15);
            this.BarG.TabIndex = 2;
            this.BarG.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BarB
            // 
            this.BarB.AutoSize = false;
            this.BarB.Location = new System.Drawing.Point(23, 79);
            this.BarB.Maximum = 255;
            this.BarB.Name = "BarB";
            this.BarB.Size = new System.Drawing.Size(100, 15);
            this.BarB.TabIndex = 3;
            this.BarB.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(6, 16);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(11, 12);
            this.lbA.TabIndex = 4;
            this.lbA.Text = "A";
            // 
            // lbR
            // 
            this.lbR.AutoSize = true;
            this.lbR.Location = new System.Drawing.Point(6, 37);
            this.lbR.Name = "lbR";
            this.lbR.Size = new System.Drawing.Size(11, 12);
            this.lbR.TabIndex = 5;
            this.lbR.Text = "R";
            // 
            // lbG
            // 
            this.lbG.AutoSize = true;
            this.lbG.Location = new System.Drawing.Point(6, 58);
            this.lbG.Name = "lbG";
            this.lbG.Size = new System.Drawing.Size(11, 12);
            this.lbG.TabIndex = 6;
            this.lbG.Text = "G";
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.lbB.Location = new System.Drawing.Point(6, 79);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(11, 12);
            this.lbB.TabIndex = 7;
            this.lbB.Text = "B";
            // 
            // lbValA
            // 
            this.lbValA.AutoSize = true;
            this.lbValA.Location = new System.Drawing.Point(129, 16);
            this.lbValA.Name = "lbValA";
            this.lbValA.Size = new System.Drawing.Size(11, 12);
            this.lbValA.TabIndex = 8;
            this.lbValA.Text = "0";
            // 
            // lbValR
            // 
            this.lbValR.AutoSize = true;
            this.lbValR.Location = new System.Drawing.Point(129, 37);
            this.lbValR.Name = "lbValR";
            this.lbValR.Size = new System.Drawing.Size(11, 12);
            this.lbValR.TabIndex = 9;
            this.lbValR.Text = "0";
            // 
            // lbValG
            // 
            this.lbValG.AutoSize = true;
            this.lbValG.Location = new System.Drawing.Point(129, 58);
            this.lbValG.Name = "lbValG";
            this.lbValG.Size = new System.Drawing.Size(11, 12);
            this.lbValG.TabIndex = 10;
            this.lbValG.Text = "0";
            // 
            // lbValB
            // 
            this.lbValB.AutoSize = true;
            this.lbValB.Location = new System.Drawing.Point(129, 79);
            this.lbValB.Name = "lbValB";
            this.lbValB.Size = new System.Drawing.Size(11, 12);
            this.lbValB.TabIndex = 11;
            this.lbValB.Text = "0";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 170);
            this.Controls.Add(this.gBColor);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.txtArgb);
            this.Controls.Add(this.lbARGB);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color";
            this.gBColor.ResumeLayout(false);
            this.gBColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.Label lbARGB;
        private System.Windows.Forms.TextBox txtArgb;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.GroupBox gBColor;
        private System.Windows.Forms.TrackBar BarA;
        private System.Windows.Forms.TrackBar BarG;
        private System.Windows.Forms.TrackBar BarR;
        private System.Windows.Forms.TrackBar BarB;
        private System.Windows.Forms.Label lbR;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbG;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.Label lbValA;
        private System.Windows.Forms.Label lbValR;
        private System.Windows.Forms.Label lbValB;
        private System.Windows.Forms.Label lbValG;
    }
}

