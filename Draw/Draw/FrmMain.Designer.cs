namespace Draw
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tlpFather = new System.Windows.Forms.TableLayoutPanel();
            this.lbList = new System.Windows.Forms.Label();
            this.txtList = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.radiogroup = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lbShow = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.tlpFather.SuspendLayout();
            this.radiogroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tlpFather
            // 
            this.tlpFather.ColumnCount = 5;
            this.tlpFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.Controls.Add(this.lbList, 0, 0);
            this.tlpFather.Controls.Add(this.txtList, 1, 0);
            this.tlpFather.Controls.Add(this.btnList, 2, 0);
            this.tlpFather.Controls.Add(this.btnFont, 3, 0);
            this.tlpFather.Controls.Add(this.btnBegin, 1, 2);
            this.tlpFather.Controls.Add(this.btnStop, 3, 2);
            this.tlpFather.Controls.Add(this.radiogroup, 1, 3);
            this.tlpFather.Controls.Add(this.btnSave, 1, 4);
            this.tlpFather.Controls.Add(this.btnExcel, 3, 4);
            this.tlpFather.Controls.Add(this.lbShow, 1, 1);
            this.tlpFather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFather.Location = new System.Drawing.Point(0, 0);
            this.tlpFather.Name = "tlpFather";
            this.tlpFather.RowCount = 5;
            this.tlpFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpFather.Size = new System.Drawing.Size(1008, 730);
            this.tlpFather.TabIndex = 0;
            // 
            // lbList
            // 
            this.lbList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbList.AutoSize = true;
            this.lbList.Location = new System.Drawing.Point(157, 30);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(41, 12);
            this.lbList.TabIndex = 0;
            this.lbList.Text = "名单：";
            // 
            // txtList
            // 
            this.txtList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtList.Location = new System.Drawing.Point(204, 26);
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(195, 21);
            this.txtList.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnList.Location = new System.Drawing.Point(405, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(195, 67);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "导入名单";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnFont
            // 
            this.btnFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFont.Location = new System.Drawing.Point(606, 3);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(195, 67);
            this.btnFont.TabIndex = 3;
            this.btnFont.Text = "设置字体";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBegin.Location = new System.Drawing.Point(204, 441);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(195, 140);
            this.btnBegin.TabIndex = 4;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(606, 441);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(195, 140);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // radiogroup
            // 
            this.tlpFather.SetColumnSpan(this.radiogroup, 3);
            this.radiogroup.Controls.Add(this.radioButton10);
            this.radiogroup.Controls.Add(this.radioButton9);
            this.radiogroup.Controls.Add(this.radioButton8);
            this.radiogroup.Controls.Add(this.radioButton7);
            this.radiogroup.Controls.Add(this.radioButton6);
            this.radiogroup.Controls.Add(this.radioButton5);
            this.radiogroup.Controls.Add(this.radioButton4);
            this.radiogroup.Controls.Add(this.radioButton3);
            this.radiogroup.Controls.Add(this.radioButton2);
            this.radiogroup.Controls.Add(this.radioButton1);
            this.radiogroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radiogroup.Location = new System.Drawing.Point(204, 587);
            this.radiogroup.Name = "radiogroup";
            this.radiogroup.Size = new System.Drawing.Size(597, 67);
            this.radiogroup.TabIndex = 6;
            this.radiogroup.TabStop = false;
            this.radiogroup.Text = "评分";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(204, 660);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 67);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcel.Location = new System.Drawing.Point(606, 660);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(195, 67);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "评分表";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lbShow
            // 
            this.lbShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbShow.AutoSize = true;
            this.tlpFather.SetColumnSpan(this.lbShow, 3);
            this.lbShow.Location = new System.Drawing.Point(502, 249);
            this.lbShow.Name = "lbShow";
            this.lbShow.Size = new System.Drawing.Size(0, 12);
            this.lbShow.TabIndex = 9;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(85, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(29, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(177, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(29, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(269, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(29, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(347, 20);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(29, 16);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(443, 20);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(29, 16);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(85, 45);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(29, 16);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(177, 45);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(29, 16);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "7";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(269, 45);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(29, 16);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(347, 42);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(29, 16);
            this.radioButton9.TabIndex = 8;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "9";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(443, 42);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(35, 16);
            this.radioButton10.TabIndex = 9;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tlpFather);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽签";
            this.tlpFather.ResumeLayout(false);
            this.tlpFather.PerformLayout();
            this.radiogroup.ResumeLayout(false);
            this.radiogroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tlpFather;
        private System.Windows.Forms.Label lbList;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox radiogroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lbShow;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

