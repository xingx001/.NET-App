using Covid19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Covid19
{
    public partial class FrmMain : Form
    {

        private HttpRequest _httpRequest = new HttpRequest();

        private Point mouseP = new Point();

        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.timer.Enabled = true;
            this.timer.Start();
            this.timer.Interval = 60 * 1000;
            this.InitChart();
            this.InitAddChart();
            this.OnHttp();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            OnHttp();
        }

        private void OnHttp()
        {
            string result = _httpRequest.Get("https://view.inews.qq.com/g2/getOnsInfo?name=disease_h5", null, null);
            nCoVData data = JsonConvert.DeserializeObject<nCoVData>(result);
            nCoVDataDetail nCoVDataDetail = JsonConvert.DeserializeObject<nCoVDataDetail>(data.Data);

            this.lbConfirm.Text = nCoVDataDetail.ChinaTotal.Confirm.ToString();
            this.lbSuspect.Text = nCoVDataDetail.ChinaTotal.Suspect.ToString();
            this.lbHeal.Text = nCoVDataDetail.ChinaTotal.Heal.ToString();
            this.lbDead.Text = nCoVDataDetail.ChinaTotal.Dead.ToString();

            this.lbAddConfirm.Text = nCoVDataDetail.ChinaAdd.Confirm.ToString();
            this.lbAddSuspect.Text = nCoVDataDetail.ChinaAdd.Suspect.ToString();
            this.lbAddHeal.Text = nCoVDataDetail.ChinaAdd.Heal.ToString();
            this.lbAddDead.Text = nCoVDataDetail.ChinaAdd.Dead.ToString();

            this.chartTotal.Series[0].Points.Clear();
            this.chartTotal.Series[1].Points.Clear();
            foreach (var child in nCoVDataDetail.ChinaDayList)
            {
                this.chartTotal.Series[0].Points.AddXY(child.Date,child.Confirm);
            }

            foreach (var child in nCoVDataDetail.ChinaDayList)
            {
                this.chartTotal.Series[1].Points.AddXY(child.Date, child.Suspect);
            }
            this.chartAdd.Series[0].Points.Clear();
            foreach (var child in nCoVDataDetail.ChinaDayAddList)
            {
                this.chartAdd.Series[0].Points.AddXY(child.Date, child.Confirm);
            }
        }

        #region 初始化累计图表
        /// <summary>
        /// 初始化累计图表
        /// </summary>
        private void InitChart()
        {
            //定义图表区域
            this.chartTotal.ChartAreas.Clear();
            ChartArea chartAreaTotal = new ChartArea("C1");
            this.chartTotal.ChartAreas.Add(chartAreaTotal);

            chartAreaTotal.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartAreaTotal.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;

            chartAreaTotal.AxisX.ScrollBar.Enabled = true;
            chartAreaTotal.AxisX.ScaleView.Zoomable = false;
            chartAreaTotal.AxisX.ScaleView.Size = 10;
            chartAreaTotal.AxisX.ScaleView.MinSize = 1;
            chartAreaTotal.AxisX.ScrollBar.Size = 20;
            chartAreaTotal.AxisX.ScrollBar.IsPositionedInside = true;

            chartAreaTotal.AxisX.Interval = 1;
            chartAreaTotal.AxisX.Title = "时间（日）";
            chartAreaTotal.AxisY.Title = "人数";

            //定义存储和显示点的容器
            this.chartTotal.Series.Clear();
            Series seriesConfirm = new Series("累计确诊");
            Series seriesSuspect = new Series("累计疑似");

            seriesConfirm.ChartArea = "C1";
            seriesSuspect.ChartArea = "C1";

            this.chartTotal.Series.Add(seriesConfirm);
            this.chartTotal.Series.Add(seriesSuspect);

            seriesConfirm.Color = Color.Blue;
            //设置显式类型
            seriesConfirm.ChartType = SeriesChartType.Line;
            //设置X轴类型
            seriesConfirm.XValueType = ChartValueType.String;
            seriesConfirm.IsValueShownAsLabel = false;
            seriesConfirm.MarkerStyle = MarkerStyle.Cross;

            seriesConfirm.ToolTip = "#VALY";

            seriesSuspect.Color = Color.Green;
            seriesSuspect.ChartType = SeriesChartType.Line;
            //设置X轴类型
            seriesSuspect.XValueType = ChartValueType.String;
            seriesSuspect.IsValueShownAsLabel = false;
            seriesSuspect.MarkerStyle = MarkerStyle.Cross;
            seriesSuspect.ToolTip = "#VALY";
        }
        #endregion

        #region 初始化新增图表
        /// <summary>
        /// 初始化新增图表
        /// </summary>
        private void InitAddChart()
        {
            //定义图表区域
            this.chartAdd.ChartAreas.Clear();
            ChartArea chartAreaAdd = new ChartArea("C2");
            this.chartAdd.ChartAreas.Add(chartAreaAdd);

            chartAreaAdd.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartAreaAdd.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;

            chartAreaAdd.AxisX.ScrollBar.Enabled = true;
            chartAreaAdd.AxisX.ScaleView.Zoomable = false;
            chartAreaAdd.AxisX.ScaleView.Size = 10;
            chartAreaAdd.AxisX.ScaleView.MinSize = 1;
            chartAreaAdd.AxisX.ScrollBar.Size = 20;
            chartAreaAdd.AxisX.ScrollBar.IsPositionedInside = true;

            chartAreaAdd.AxisX.Interval = 1;
            chartAreaAdd.AxisX.Title = "时间（日）";
            chartAreaAdd.AxisY.Title = "人数";

            //定义存储和显示点的容器
            this.chartAdd.Series.Clear();
            Series seriesAddConfirm = new Series("新增确诊");
            seriesAddConfirm.ChartArea = "C2";
            this.chartAdd.Series.Add(seriesAddConfirm);

            seriesAddConfirm.Color = Color.Blue;
            //设置显式类型
            seriesAddConfirm.ChartType = SeriesChartType.Line;
            //设置X轴类型
            seriesAddConfirm.XValueType = ChartValueType.String;
            seriesAddConfirm.IsValueShownAsLabel = false;
            seriesAddConfirm.MarkerStyle = MarkerStyle.Cross;

            seriesAddConfirm.ToolTip = "#VALY";

        }
        #endregion

        #region 获取提示信息
        /// <summary>
        /// 获取提示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            //鼠标移动到值上，显示数值
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                this.Cursor = Cursors.Cross;

                int mouseOffsetX = Math.Abs(e.X - mouseP.X);
                int mouseOffsetY = Math.Abs(e.Y - mouseP.Y);

                if (mouseOffsetX < 3 && mouseOffsetY < 3)
                {
                }
                else
                {
                    mouseP.X = e.X;
                    mouseP.Y = e.Y;

                    int i = e.HitTestResult.PointIndex;
                    DataPoint dp = e.HitTestResult.Series.Points[i];

                    e.Text = dp.YValues[0].ToString();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion
    }
}
