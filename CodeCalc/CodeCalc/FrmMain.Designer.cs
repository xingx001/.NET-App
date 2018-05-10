namespace CodeCalc
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
            this.tplFather = new System.Windows.Forms.TableLayoutPanel();
            this.lvrt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tplInput = new System.Windows.Forms.TableLayoutPanel();
            this.lb = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLook = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.lbresult = new System.Windows.Forms.Label();
            this.tplFather.SuspendLayout();
            this.tplInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplFather
            // 
            this.tplFather.BackColor = System.Drawing.Color.Transparent;
            this.tplFather.ColumnCount = 1;
            this.tplFather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplFather.Controls.Add(this.lvrt, 0, 2);
            this.tplFather.Controls.Add(this.tplInput, 0, 0);
            this.tplFather.Controls.Add(this.lbresult, 0, 1);
            this.tplFather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplFather.Location = new System.Drawing.Point(0, 0);
            this.tplFather.Name = "tplFather";
            this.tplFather.RowCount = 3;
            this.tplFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tplFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tplFather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tplFather.Size = new System.Drawing.Size(742, 516);
            this.tplFather.TabIndex = 1;
            // 
            // lvrt
            // 
            this.lvrt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvrt.FullRowSelect = true;
            this.lvrt.GridLines = true;
            this.lvrt.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvrt.HideSelection = false;
            this.lvrt.Location = new System.Drawing.Point(3, 131);
            this.lvrt.Name = "lvrt";
            this.lvrt.Size = new System.Drawing.Size(736, 382);
            this.lvrt.TabIndex = 7;
            this.lvrt.UseCompatibleStateImageBehavior = false;
            this.lvrt.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件大小";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "字符数";
            this.columnHeader3.Width = 64;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "总行数";
            this.columnHeader4.Width = 57;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "空白";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "注释";
            this.columnHeader6.Width = 65;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "代码";
            // 
            // tplInput
            // 
            this.tplInput.ColumnCount = 4;
            this.tplInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tplInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tplInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tplInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tplInput.Controls.Add(this.lb, 0, 0);
            this.tplInput.Controls.Add(this.txtFileName, 1, 0);
            this.tplInput.Controls.Add(this.btnLook, 2, 0);
            this.tplInput.Controls.Add(this.btnAnalysis, 3, 0);
            this.tplInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplInput.Location = new System.Drawing.Point(3, 3);
            this.tplInput.Name = "tplInput";
            this.tplInput.RowCount = 1;
            this.tplInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplInput.Size = new System.Drawing.Size(736, 71);
            this.tplInput.TabIndex = 1;
            // 
            // lb
            // 
            this.lb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb.Location = new System.Drawing.Point(3, 22);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(75, 27);
            this.lb.TabIndex = 0;
            this.lb.Text = "工程名：";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(84, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(402, 21);
            this.txtFileName.TabIndex = 1;
            // 
            // btnLook
            // 
            this.btnLook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLook.Location = new System.Drawing.Point(492, 3);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(116, 65);
            this.btnLook.TabIndex = 2;
            this.btnLook.Text = "浏览";
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnalysis.Location = new System.Drawing.Point(614, 3);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(119, 65);
            this.btnAnalysis.TabIndex = 3;
            this.btnAnalysis.Text = "分析";
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // lbresult
            // 
            this.lbresult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbresult.Location = new System.Drawing.Point(3, 93);
            this.lbresult.Name = "lbresult";
            this.lbresult.Size = new System.Drawing.Size(109, 18);
            this.lbresult.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 516);
            this.Controls.Add(this.tplFather);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "源码计数器";
            this.tplFather.ResumeLayout(false);
            this.tplInput.ResumeLayout(false);
            this.tplInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tplFather;
        private System.Windows.Forms.ListView lvrt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TableLayoutPanel tplInput;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Label lbresult;
    }
}

