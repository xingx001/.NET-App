using C1.C1Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Draw
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 名单表
        /// </summary>
        DataTable dt = new DataTable();
        /// <summary>
        /// Excel表
        /// </summary>
        private C1.C1Excel.C1XLBook c1XLBook1 = new C1XLBook();

        #region 构造
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }
        #endregion

        #region 窗体载入
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //this.timer1.Enabled = true;
            Font font = new Font("微软雅黑", 12f, FontStyle.Bold);
            this.lbList.Font = font;
            this.btnBegin.Font = font;
            this.btnStop.Font = font;
            this.btnSave.Font = font;
            this.btnExcel.Font = font;
            this.btnFont.Font = font;
            this.btnList.Font = font;
            this.lbShow.Font = new Font("微软雅黑", 14f, FontStyle.Bold);
        }
        #endregion

        #region 定时方法
        /// <summary>
        /// 定时方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            this.lbShow.Text = this.dt.Rows[rd.Next(1, this.dt.Rows.Count)][0].ToString();
        }
        #endregion

        #region 导入Excel
        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="HeadShow">首行是否是标题</param>
        /// <param name="ExcelType">Excle类型</param>
        private DataTable ImportExcel(string filePath, bool HeadShow, bool ExcelType)
        {
            C1XLBook book = new C1XLBook();
            //Excle类型
            if (ExcelType)
            {
                book.CompatibilityMode = CompatibilityMode.Excel2003;
            }
            else
            {
                book.CompatibilityMode = CompatibilityMode.Excel2007;
            }

            book.Load(filePath);
            XLSheet xlSheet = book.Sheets[0];
            DataTable dt = new DataTable();
            //首行是否是标题
            if (HeadShow)
            {
                for (int i = 0; i < xlSheet.Columns.Count; i++)
                {
                    dt.Columns.Add(xlSheet[0, i].Text);
                }

                for (int j = 1; j < xlSheet.Rows.Count; j++)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < xlSheet.Columns.Count; i++)
                    {
                        dr[i] = xlSheet[j, i].Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 0; i < xlSheet.Columns.Count; i++)
                {
                    dt.Columns.Add("");
                }
                for (int j = 0; j < xlSheet.Rows.Count; j++)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < xlSheet.Columns.Count; i++)
                    {
                        dr[i] = xlSheet[j, i].Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        #endregion

        #region 导出EXCEL
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="captain"></param>
        /// <param name="dt"></param>
        private void ExportTo(string fileName, string captain, DataTable dt)
        {
            //是否存在Excel文件
            bool isExist = System.IO.File.Exists(fileName);
            //将当前水标状态保存到临时变量中后将光标置为忙状态
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // populate sheet with some random values
            C1.C1Excel.XLSheet sheet = c1XLBook1.Sheets[0];
            //获取列名
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheet[1, i].Value = dt.Columns[i].Caption;
            }
            //获取dt内的数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheet[i + 2, j].Value = dr[j];
                }
            }
            //如果存在Excel文件,将生成的表加入该文件
            if (isExist)
            {
                // load Excel file
                C1XLBook book = new C1XLBook();
                book.Load(fileName);

                // clone and rename first sheet (sheet names must be unique)
                XLSheet clone = book.Sheets[0].Clone();
                clone.Name = Path.GetFileNameWithoutExtension(fileName);

                // add cloned sheet to main book
                c1XLBook1.Sheets.Add(clone);
            }
            string tempdir = Application.ExecutablePath.Substring(0,
                Application.ExecutablePath.LastIndexOf("\\") + 1);
            // autosize columns
            AutoSizeColumns(sheet);
            // save with default column widths
            c1XLBook1.Save(tempdir + fileName + ".xls");
            System.Diagnostics.Process.Start(tempdir + fileName + ".xls");
        }
        #endregion

        #region 自动设置列宽
        /// <summary>
        /// 自动设置列宽
        /// </summary>
        /// <param name="sheet"></param>
        private void AutoSizeColumns(XLSheet sheet)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                for (int c = 0; c < sheet.Columns.Count; c++)
                {
                    int colWidth = -1;
                    for (int r = 0; r < sheet.Rows.Count; r++)
                    {
                        object value = sheet[r, c].Value;
                        if (value != null)
                        {
                            // get value (unformatted at this point)
                            string text = value.ToString();

                            // format value if cell has a style with format set
                            C1.C1Excel.XLStyle s = sheet[r, c].Style;
                            if (s != null && s.Format.Length > 0 && value is IFormattable)
                            {
                                string fmt = XLStyle.FormatXLToDotNet(s.Format);
                                text = ((IFormattable)value).ToString(fmt, CultureInfo.CurrentCulture);
                            }

                            // get font (default or style)
                            Font font = this.c1XLBook1.DefaultFont;
                            if (s != null && s.Font != null)
                            {
                                font = s.Font;
                            }

                            // measure string (add a little tolerance)
                            Size sz = Size.Ceiling(g.MeasureString(text + "XX", font));

                            // keep widest so far
                            if (sz.Width > colWidth)
                                colWidth = sz.Width;
                        }
                    }

                    // done measuring, set column width
                    if (colWidth > -1)
                        sheet.Columns[c].Width = C1XLBook.PixelsToTwips(colWidth);
                }
            }
        }
        #endregion

        #region 导入名单
        /// <summary>
        /// 导入名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnList_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Application.StartupPath;
                dialog.Filter = "Excel文件(*.xls)|*.xls";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtList.Text = dialog.FileName;
                    this.dt = ImportExcel(dialog.FileName, false, false);
                }
            }
        }
        #endregion

        #region 设置字体
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog diag = new FontDialog();
            diag.ShowDialog();
            this.lbShow.Font = diag.Font;
        }
        #endregion

        #region 开始抽签
        /// <summary>
        /// 开始抽签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (this.dt != null && this.dt.Rows.Count > 0)
            {
                this.timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("请导入EXCEL名单！");
                this.timer1.Enabled = false;
            }
        }
        #endregion

        #region 停止抽签
        /// <summary>
        /// 停止抽签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }
        #endregion

        #region 保存评分
        /// <summary>
        /// 保存评分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lbShow.Text))
            {
                MessageBox.Show("请先抽签，再保存评分！");
                return;
            }

            XmlDocument xml = new XmlDocument();
            XmlNode Evaluation = xml.CreateNode("element", "Evaluation", string.Empty);
            XmlNode Points = xml.CreateNode("element", "Points", string.Empty);
            XmlNode Name = xml.CreateNode("element", "Name", string.Empty);
            XmlNode Time = xml.CreateNode("element", "Time", string.Empty);

            Points.InnerText = this.GetScore();
            Name.InnerText = this.lbShow.Text;
            Time.InnerText = DateTime.Now.ToString();

            Evaluation.AppendChild(Points);
            Evaluation.AppendChild(Name);
            Evaluation.AppendChild(Time);

            string apppath = Application.ExecutablePath;
            apppath = apppath.Substring(0, apppath.LastIndexOf("\\"));

            if (File.Exists(apppath + "\\Evaluation.xml"))
            {
                try
                {
                    xml.Load(apppath + "\\Evaluation.xml");
                }
                catch
                {
                    File.Delete(apppath + "\\Evaluation.xml");
                }
            }

            if (xml.ChildNodes.Count < 1)
            {
                XmlNode node = xml.CreateNode("element", "Evaluation", string.Empty);
                xml.AppendChild(node);
                xml.Save(apppath + "\\Evaluation.xml");
            }

            xml.ChildNodes[0].AppendChild(Evaluation);
            xml.Save(apppath + "\\Evaluation.xml");
            MessageBox.Show(string.Format("已保存\"{0}\"评分信息！", this.lbShow.Text));
        }
        #endregion

        #region Excel导出
        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            string apppath = Application.ExecutablePath;
            apppath = apppath.Substring(0, apppath.LastIndexOf("\\"));
            if (File.Exists(apppath + "\\Evaluation.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(apppath + "\\Evaluation.xml");
                XmlNodeList nodeList = xmlDoc.SelectNodes("//Evaluation//Evaluation");

                DataTable dt = new DataTable();
                dt.Columns.Add("姓名");
                dt.Columns.Add("评分");
                dt.Columns.Add("时间");

                for (int i = 0; i < nodeList.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    XmlElement xe = (XmlElement)nodeList[i];
                    dr[0] = ((XmlElement)xe.SelectNodes("//Evaluation//Name")[i]).InnerText;
                    dr[1] = ((XmlElement)xe.SelectNodes("//Evaluation//Points")[i]).InnerText;
                    dr[2] = ((XmlElement)xe.SelectNodes("//Evaluation//Time")[i]).InnerText;
                    dt.Rows.Add(dr);
                }
                ExportTo("Evaluation", "Evaluation", dt);
                MessageBox.Show("导出评分表将删除评分记录，请自行保存！");
                File.Delete(apppath + "\\Evaluation.xml");
            }
            else
            {
                MessageBox.Show("无评分记录！");
            }
        }
        #endregion

        #region 得分
        /// <summary>
        /// 得分
        /// </summary>
        /// <returns></returns>
        private string GetScore()
        {
            if (this.radioButton1.Checked)
            {
                return this.radioButton1.Text;
            }
            if (this.radioButton2.Checked)
            {
                return this.radioButton2.Text;
            }
            if (this.radioButton3.Checked)
            {
                return this.radioButton3.Text;
            }
            if (this.radioButton4.Checked)
            {
                return this.radioButton4.Text;
            }
            if (this.radioButton5.Checked)
            {
                return this.radioButton5.Text;
            }
            if (this.radioButton6.Checked)
            {
                return this.radioButton6.Text;
            }
            if (this.radioButton7.Checked)
            {
                return this.radioButton7.Text;
            }
            if (this.radioButton8.Checked)
            {
                return this.radioButton8.Text;
            }
            if (this.radioButton9.Checked)
            {
                return this.radioButton9.Text;
            }
            if (this.radioButton10.Checked)
            {
                return this.radioButton10.Text;
            }
            return "0";
        }
        #endregion
    }
}
