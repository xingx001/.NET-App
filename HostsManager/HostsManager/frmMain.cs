using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Principal;
using System.Diagnostics;

namespace HostsManager
{
    public partial class frmMain : Form
    {
        protected string host_path;
        protected string temp_path;

        public frmMain()
        {
            InitializeComponent();
        }

        #region 窗体载入
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            this.temp_path = Path.GetTempPath() + "hosts";
            this.host_path = folderPath + @"\drivers\etc";
            this.InitHostList();
            this.Check_Security();
            this.txthost.Focus();
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public void InitHostList()
        {
            if (File.Exists(this.host_path + @"\hosts"))
            {
                File.Copy(this.host_path + @"\hosts", this.temp_path, true);
            }
            else
            {
                FileStream stream = new FileStream(this.temp_path, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine("# <HostManager> has rewritten this hosts file\r\n# ******************************************\r\n# IP                Hosts");
                writer.Close();
                stream.Close();
            }
            this.dgv.DataSource = this.DataBind(this.temp_path);
            this.dgv.Columns[0].Visible = false;
            this.dgv.Columns[1].Width = 130;
            this.dgv.Columns[2].Width = 0x73;
            this.dgv.Columns[1].HeaderText = "主机头（域名）";
            this.dgv.Columns[2].HeaderText = "IP地址";
        }
        #endregion

        #region 窗体关闭
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strhost = this.txthost.Text.Trim();
            string strip = this.txtip.Text.Trim();
            if (string.IsNullOrEmpty(strhost))
            {
                MessageBox.Show("请填写域名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txthost.Focus();
            }
            else if (string.IsNullOrEmpty(strip))
            {
                MessageBox.Show("请填写IP地址！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtip.Focus();
            }
            else
            {
                try
                {
                    File.SetAttributes(this.temp_path, FileAttributes.Normal);
                    FileStream stream = new FileStream(this.temp_path, FileMode.Append);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(strip + "     " + strhost);
                    writer.Close();
                    stream.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                try
                {
                    File.Copy(this.temp_path, this.host_path + @"\hosts", true);
                }
                catch (Exception)
                {
                    MessageBox.Show("暂无权限修改！请尝试以管理员身份运行此程序再试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.txthost.Text = "";
                this.txtip.Text = "";
                this.InitHostList();
            }
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.InitHostList();
        }
        #endregion

        #region 打开目录
        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.host_path))
            {
                Process.Start("Explorer.exe", this.host_path);
            }
            else
            {
                MessageBox.Show("Host目录不存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region 检测管理员权限
        /// <summary>
        /// 检测管理员权限
        /// </summary>
        private void Check_Security()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("当前程序不处于管理员身份运行下,请尝试以管理员身份运行此程序再试。");
            }
        }
        #endregion

        #region 获取hosts的DataTable
        /// <summary>
        /// 获取hosts的DataTable
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable DataBind(string path)
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "row",
                AutoIncrement = false,
                Caption = "行号",
                ReadOnly = false,
                Unique = true
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "host",
                AutoIncrement = false,
                Caption = "主机头（域名）",
                ReadOnly = false,
                Unique = false
            };
            table.Columns.Add(column);
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ip",
                AutoIncrement = false,
                Caption = "IP地址",
                ReadOnly = false,
                Unique = false
            };
            table.Columns.Add(column);
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                string str = reader.ReadLine();
                for (int i = 0; str != null; i++)
                {
                    str = str.Trim();
                    if (!string.IsNullOrEmpty(str) && (str.IndexOf("#") != 0))
                    {
                        string[] strArray = str.Split(new char[] { '\t' });
                        if (strArray.Length == 1)
                        {
                            strArray = str.Split(new char[] { ' ' });
                        }
                        DataRow row = table.NewRow();
                        row["row"] = i;
                        row["host"] = strArray[strArray.Length - 1];
                        row["ip"] = strArray[0];
                        table.Rows.Add(row);
                    }
                    str = reader.ReadLine();
                }
                reader.Close();
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table;
        }
        #endregion

        #region 右键菜单按钮
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InitHostList();
        }
        /// <summary>
        /// 删除选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = Convert.ToInt32(this.dgv.CurrentRow.Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("你选择的当前行无效，请重新选择！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("你确定要删除该记录吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                List<string> list = new List<string>(File.ReadAllLines(this.temp_path));
                list.RemoveAt(num);
                File.WriteAllLines(this.temp_path, list.ToArray());
                try
                {
                    File.Copy(this.temp_path, this.host_path + @"\hosts", true);
                }
                catch (Exception)
                {
                    MessageBox.Show("暂无权限修改！请尝试以管理员身份运行此程序再试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.InitHostList();
            }
        }
        #endregion

    }
}
