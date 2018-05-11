using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loaner
{
    public partial class FrmMain : Form
    {
        private double fTotal = 0f;
        private double fpay = 0f;
        private string format="000000.000000";
        private bool isNum;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.txtGongMoney.KeyPress += txt_KeyPress;
            this.txtGongMoney.KeyDown += txt_KeyDown;
            this.txtGongRate.KeyPress += txt_KeyPress;
            this.txtGongRate.KeyDown += txt_KeyDown;
            this.txtPay.KeyPress += txt_KeyPress;
            this.txtPay.KeyDown += txt_KeyDown;
            this.txtShangMoney.KeyPress += txt_KeyPress;
            this.txtShangMoney.KeyDown += txt_KeyDown;
            this.txtShangRate.KeyPress += txt_KeyPress;
            this.txtShangRate.KeyDown += txt_KeyDown;
            this.txtShangUp.KeyPress += txt_KeyPress;
            this.txtShangUp.KeyDown += txt_KeyDown;
            this.txtTotalMoney.KeyPress += txt_KeyPress;
            this.txtTotalMoney.KeyDown += txt_KeyDown;
            this.txtTotalMoney.TextChanged += txtTotalMoney_TextChanged;
            this.txtPay.TextChanged += txtPay_TextChanged;
            this.txtGongMoney.TextChanged += txtGongMoney_TextChanged;
        }
        #endregion

        #region 系统载入
        /// <summary>
        /// 系统载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            this.cmbYear.Items.Add("20");
            this.cmbYear.Items.Add("21");
            this.cmbYear.Items.Add("22");
            this.cmbYear.Items.Add("23");
            this.cmbYear.Items.Add("24");
            this.cmbYear.Items.Add("25");
            this.cmbYear.Items.Add("26");
            this.cmbYear.Items.Add("27");
            this.cmbYear.Items.Add("28");
            this.cmbYear.Items.Add("29");
            this.cmbYear.Items.Add("30");
            this.cmbYear.SelectedIndex = 10;

            this.txtGongRate.Text = "3.25";
            this.txtShangRate.Text = "4.9";
            this.txtShangUp.Text = "25";
        }
        #endregion

        #region 计算
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            //[贷款本金×月利率×（1+月利率）^还款月数]÷[（1+月利率）^还款月数－1]

            double yearNum = Z.Base.Util.Parser.TryToDouble(this.cmbYear.Text, this.format);
            double monthNum = yearNum * 12;
            double gMoney = Z.Base.Util.Parser.TryToDouble(this.txtGongMoney.Text, this.format);//公积金
            double sMoney = Z.Base.Util.Parser.TryToDouble(this.txtShangMoney.Text, this.format);//商贷

            double gRate = Z.Base.Util.Parser.TryToDouble(this.txtGongRate.Text, this.format) / 100f;//公积金利率
            double sRate = Z.Base.Util.Parser.TryToDouble(this.txtShangRate.Text, this.format) / 100f;//商贷利率
            double sUp = Z.Base.Util.Parser.TryToDouble(this.txtShangUp.Text, this.format) / 100f;//商贷上浮

            double gMonthRate = gRate / 12f;
            double sMonthRate = (sRate * (1 + sUp)) / 12f;

            double gPower = Math.Pow(1 + gMonthRate, monthNum);
            double sPower = Math.Pow(1 + sMonthRate, monthNum);

            double gMonth = (gMoney * gMonthRate * gPower) / (gPower - 1);
            double sMonth = (sMoney * sMonthRate * sPower) / (sPower - 1);

            this.txt.Clear();
            this.txt.AppendText(string.Format("公积金贷款金额：{0} \r\n", gMoney));
            this.txt.AppendText(string.Format("公积金每月还款：{0} \r\n", gMonth));

            this.txt.AppendText(string.Format("商业贷款金额：{0} \r\n", sMoney));
            this.txt.AppendText(string.Format("商业贷款每月还款：{0} \r\n", sMonth));

            this.txt.AppendText(string.Format("总贷款金额：{0} \r\n", sMoney + gMoney));
            this.txt.AppendText(string.Format("总贷款每月还款：{0} \r\n", sMonth + gMonth));

            this.txt.AppendText(string.Format("还款月数：{0} \r\n", monthNum));
        }
        #endregion

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            double fGong = this.fTotal - this.fpay;
            this.txtGongMoney.Text = Z.Base.Util.Parser.TryToDoubleStr(fGong, this.format);//填入公积金金额
            this.txtShangMoney.Text = "";
        }
        #endregion

        #region 总金额计算变化
        /// <summary>
        /// 总金额计算变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTotalMoney.Text))
                return;
            this.fTotal = Z.Base.Util.Parser.TryToDouble(this.txtTotalMoney.Text, this.format);//获取总金额

            this.fpay = this.fTotal * 0.3f;
            this.txtPay.Text = Z.Base.Util.Parser.TryToDoubleStr(this.fpay, this.format);//填入首付金额

            double fGong = this.fTotal - this.fpay;
            this.txtGongMoney.Text = Z.Base.Util.Parser.TryToDoubleStr(fGong, this.format);//填入公积金金额
        }
        #endregion

        #region 首付金额计算变化
        /// <summary>
        /// 首付金额计算变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            this.fpay = Z.Base.Util.Parser.TryToDouble(this.txtPay.Text, this.format);//获取首付金额
            double fGong = this.fTotal - this.fpay;
            this.txtGongMoney.Text = Z.Base.Util.Parser.TryToDoubleStr(fGong, this.format);//填入公积金金额
        }
        #endregion

        #region 公积金金额计算变化
        /// <summary>
        /// 公积金金额计算变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGongMoney_TextChanged(object sender, EventArgs e)
        {
            double fGong = Z.Base.Util.Parser.TryToDouble(this.txtGongMoney.Text, this.format);//获取公积金金额
            double fShang = this.fTotal - this.fpay - fGong;
            this.txtShangMoney.Text = Z.Base.Util.Parser.TryToDoubleStr(fShang, this.format);//填入商贷金额
        }
        #endregion

        #region Text按键事件
        /// <summary>
        /// Text按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) )
            //{
            //    e.Handled = true;
            //}
            if (this.isNum)
                e.Handled = true;
        }
        #endregion

        #region Text按下事件
        /// <summary>
        /// Text按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            this.isNum = false;
            if (e.KeyData == Keys.Back || e.KeyData == Keys.Delete
                || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                return;
            if (!e.Shift && e.KeyValue >= '0' && e.KeyValue <= '9')
                return;
            if (!e.Shift && e.KeyValue == 229)
                return;
            if ((e.KeyValue >= 96 && e.KeyValue <= 105) || e.KeyValue == 110)
                return;
            this.isNum = true;
        }
        #endregion
    }
}
