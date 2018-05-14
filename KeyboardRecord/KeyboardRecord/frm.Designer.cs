namespace KeyboardRecord
{
    partial class frm
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
            this.btn = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(21, 12);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(150, 45);
            this.btn.TabIndex = 0;
            this.btn.Text = "btn";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(21, 63);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(150, 191);
            this.txt.TabIndex = 1;
            this.txt.Text = "";
            // 
            // frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 266);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.btn);
            this.MaximizeBox = false;
            this.Name = "frm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "test";
            this.Load += new System.EventHandler(this.frm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.RichTextBox txt;

    }
}

