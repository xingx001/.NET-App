namespace Covid19
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDead = new System.Windows.Forms.Button();
            this.btnHeal = new System.Windows.Forms.Button();
            this.btnSuspect = new System.Windows.Forms.Button();
            this.lbDead = new System.Windows.Forms.Label();
            this.lbHeal = new System.Windows.Forms.Label();
            this.lbSuspect = new System.Windows.Forms.Label();
            this.lbConfirm = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbAddConfirm = new System.Windows.Forms.Label();
            this.lbAddSuspect = new System.Windows.Forms.Label();
            this.lbAddHeal = new System.Windows.Forms.Label();
            this.lbAddDead = new System.Windows.Forms.Label();
            this.btnTitle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chartTotal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAdd = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnDead, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHeal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSuspect, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDead, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbHeal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSuspect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbConfirm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirm, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbAddConfirm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAddSuspect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAddHeal, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbAddDead, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDead
            // 
            this.btnDead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDead.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnDead.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDead.Location = new System.Drawing.Point(804, 87);
            this.btnDead.Name = "btnDead";
            this.btnDead.Size = new System.Drawing.Size(75, 29);
            this.btnDead.TabIndex = 7;
            this.btnDead.Text = "死亡";
            this.btnDead.UseVisualStyleBackColor = false;
            // 
            // btnHeal
            // 
            this.btnHeal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHeal.BackColor = System.Drawing.Color.LightGreen;
            this.btnHeal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHeal.Location = new System.Drawing.Point(562, 87);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(75, 29);
            this.btnHeal.TabIndex = 6;
            this.btnHeal.Text = "治愈";
            this.btnHeal.UseVisualStyleBackColor = false;
            // 
            // btnSuspect
            // 
            this.btnSuspect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuspect.BackColor = System.Drawing.Color.Gold;
            this.btnSuspect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSuspect.Location = new System.Drawing.Point(322, 87);
            this.btnSuspect.Name = "btnSuspect";
            this.btnSuspect.Size = new System.Drawing.Size(75, 29);
            this.btnSuspect.TabIndex = 5;
            this.btnSuspect.Text = "疑似";
            this.btnSuspect.UseVisualStyleBackColor = false;
            // 
            // lbDead
            // 
            this.lbDead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDead.AutoSize = true;
            this.lbDead.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDead.ForeColor = System.Drawing.Color.LightSlateGray;
            this.lbDead.Location = new System.Drawing.Point(806, 44);
            this.lbDead.Name = "lbDead";
            this.lbDead.Size = new System.Drawing.Size(71, 26);
            this.lbDead.TabIndex = 3;
            this.lbDead.Text = "label4";
            // 
            // lbHeal
            // 
            this.lbHeal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbHeal.AutoSize = true;
            this.lbHeal.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeal.ForeColor = System.Drawing.Color.LightGreen;
            this.lbHeal.Location = new System.Drawing.Point(564, 44);
            this.lbHeal.Name = "lbHeal";
            this.lbHeal.Size = new System.Drawing.Size(71, 26);
            this.lbHeal.TabIndex = 2;
            this.lbHeal.Text = "label3";
            // 
            // lbSuspect
            // 
            this.lbSuspect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSuspect.AutoSize = true;
            this.lbSuspect.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSuspect.ForeColor = System.Drawing.Color.Gold;
            this.lbSuspect.Location = new System.Drawing.Point(324, 44);
            this.lbSuspect.Name = "lbSuspect";
            this.lbSuspect.Size = new System.Drawing.Size(71, 26);
            this.lbSuspect.TabIndex = 1;
            this.lbSuspect.Text = "label2";
            // 
            // lbConfirm
            // 
            this.lbConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConfirm.AutoSize = true;
            this.lbConfirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbConfirm.ForeColor = System.Drawing.Color.LightCoral;
            this.lbConfirm.Location = new System.Drawing.Point(84, 44);
            this.lbConfirm.Name = "lbConfirm";
            this.lbConfirm.Size = new System.Drawing.Size(71, 26);
            this.lbConfirm.TabIndex = 0;
            this.lbConfirm.Text = "label1";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirm.BackColor = System.Drawing.Color.LightCoral;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(82, 87);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 29);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确诊";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // lbAddConfirm
            // 
            this.lbAddConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbAddConfirm.AutoSize = true;
            this.lbAddConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddConfirm.ForeColor = System.Drawing.Color.LightCoral;
            this.lbAddConfirm.Location = new System.Drawing.Point(94, 11);
            this.lbAddConfirm.Name = "lbAddConfirm";
            this.lbAddConfirm.Size = new System.Drawing.Size(51, 19);
            this.lbAddConfirm.TabIndex = 8;
            this.lbAddConfirm.Text = "label1";
            // 
            // lbAddSuspect
            // 
            this.lbAddSuspect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbAddSuspect.AutoSize = true;
            this.lbAddSuspect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddSuspect.ForeColor = System.Drawing.Color.Gold;
            this.lbAddSuspect.Location = new System.Drawing.Point(334, 11);
            this.lbAddSuspect.Name = "lbAddSuspect";
            this.lbAddSuspect.Size = new System.Drawing.Size(51, 19);
            this.lbAddSuspect.TabIndex = 9;
            this.lbAddSuspect.Text = "label2";
            // 
            // lbAddHeal
            // 
            this.lbAddHeal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbAddHeal.AutoSize = true;
            this.lbAddHeal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddHeal.ForeColor = System.Drawing.Color.LightGreen;
            this.lbAddHeal.Location = new System.Drawing.Point(574, 11);
            this.lbAddHeal.Name = "lbAddHeal";
            this.lbAddHeal.Size = new System.Drawing.Size(51, 19);
            this.lbAddHeal.TabIndex = 10;
            this.lbAddHeal.Text = "label3";
            // 
            // lbAddDead
            // 
            this.lbAddDead.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbAddDead.AutoSize = true;
            this.lbAddDead.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddDead.ForeColor = System.Drawing.Color.LightSlateGray;
            this.lbAddDead.Location = new System.Drawing.Point(816, 11);
            this.lbAddDead.Name = "lbAddDead";
            this.lbAddDead.Size = new System.Drawing.Size(51, 19);
            this.lbAddDead.TabIndex = 11;
            this.lbAddDead.Text = "label4";
            // 
            // btnTitle
            // 
            this.btnTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTitle.Location = new System.Drawing.Point(12, 0);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(963, 35);
            this.btnTitle.TabIndex = 1;
            this.btnTitle.Text = "新型冠状病毒肺炎-疫情实时追踪";
            this.btnTitle.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(963, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "全国累计确诊/疑似";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(963, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "每日新增确诊";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chartTotal
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTotal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTotal.Legends.Add(legend1);
            this.chartTotal.Location = new System.Drawing.Point(12, 182);
            this.chartTotal.Margin = new System.Windows.Forms.Padding(0);
            this.chartTotal.Name = "chartTotal";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTotal.Series.Add(series1);
            this.chartTotal.Size = new System.Drawing.Size(963, 250);
            this.chartTotal.TabIndex = 6;
            this.chartTotal.Text = "chart1";
            this.chartTotal.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            // 
            // chartAdd
            // 
            chartArea2.Name = "ChartArea1";
            this.chartAdd.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartAdd.Legends.Add(legend2);
            this.chartAdd.Location = new System.Drawing.Point(12, 460);
            this.chartAdd.Margin = new System.Windows.Forms.Padding(0);
            this.chartAdd.Name = "chartAdd";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartAdd.Series.Add(series2);
            this.chartAdd.Size = new System.Drawing.Size(963, 250);
            this.chartAdd.TabIndex = 7;
            this.chartAdd.Text = "chart1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 716);
            this.Controls.Add(this.chartAdd);
            this.Controls.Add(this.chartTotal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTitle);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMain";
            this.Text = "新冠病毒>病例分布";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnDead;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Button btnSuspect;
        private System.Windows.Forms.Label lbDead;
        private System.Windows.Forms.Label lbHeal;
        private System.Windows.Forms.Label lbSuspect;
        private System.Windows.Forms.Label lbConfirm;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.Label lbAddConfirm;
        private System.Windows.Forms.Label lbAddSuspect;
        private System.Windows.Forms.Label lbAddHeal;
        private System.Windows.Forms.Label lbAddDead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAdd;
    }
}

