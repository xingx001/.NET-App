using CodeCalc.Abstract;
using CodeCalc.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeCalc
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

        #region 浏览文档
        /// <summary>
        /// 浏览文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLook_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "C#工程文件|*.csproj|VB工程文件|*.vbp|VB.NET工程文件|*.vbproj";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtFileName.Text = dialog.FileName;
                }
            }
        }
        #endregion

        #region 分析工程
        /// <summary>
        /// 分析工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(this.txtFileName.Text))
            {
                MessageBox.Show("文件不存在");
                return;
            }
            ProjectDocument mDocument = ProjectDocument.Create(this.txtFileName.Text);
            if (mDocument == null)
            {
                MessageBox.Show("Analyse for " + this.txtFileName.Text + " error !");
                return;
            }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lvrt.BeginUpdate();
            this.lvrt.Items.Clear();

            mDocument.ClearResults();
            mDocument.AnalyseAllFile();

            lbresult.Text = "Result : Total " + mDocument.LastResult.Count + " files , analyse " + mDocument.LastResult.AnalysedCount + " files , spend " + mDocument.TickCount + " millisecond";
            System.Windows.Forms.ListViewItem NewItem = new ListViewItem("[Total]");
            NewItem.SubItems.Add(FileHelper.FormatFileSize(mDocument.LastResult.TotalFileSize));
            NewItem.SubItems.Add(mDocument.LastResult.TotalCharCount.ToString());
            NewItem.SubItems.Add(mDocument.LastResult.TotalLineCount.ToString());
            NewItem.SubItems.Add(mDocument.LastResult.TotalBlankCount.ToString());
            NewItem.SubItems.Add(mDocument.LastResult.TotalCommentCount.ToString());
            NewItem.SubItems.Add(mDocument.LastResult.TotalCodeCount.ToString());
            lvrt.Items.Add(NewItem);

            foreach (FileEntity item in mDocument.LastResult)
            {
                if (item.Analysed)
                {
                    NewItem = new ListViewItem(System.IO.Path.GetFileName(item.FileName));
                    if (item.Analysed)
                    {
                        NewItem.SubItems.Add(FileHelper.FormatFileSize(item.FileSize));
                        NewItem.SubItems.Add(item.CharCount.ToString());
                        NewItem.SubItems.Add(item.LineCount.ToString());
                        NewItem.SubItems.Add(item.BlankCount.ToString());
                        NewItem.SubItems.Add(item.CommentCount.ToString());
                        NewItem.SubItems.Add(item.CodeCount.ToString());
                    }
                    else
                    {
                        NewItem.SubItems.Add("未分析");
                        NewItem.BackColor = System.Drawing.Color.Red;
                    }
                    lvrt.Items.Add(NewItem);
                }
            }
            lvrt.EndUpdate();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        #endregion
    }
}
