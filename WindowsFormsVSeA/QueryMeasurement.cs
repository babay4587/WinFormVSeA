using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsVSeA
{
    public partial class QueryMeasurement : Form
    {
        public static QueryMeasurement ClassQM = new QueryMeasurement();
        DataView DataView_Filter = new DataView();
        DataTable Dt_Cpy = new DataTable();

        public static FileHelper FileHelper = new FileHelper();

        public QueryMeasurement()
        {
            InitializeComponent();
        }

        private void Btn_MeasureQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Tb_Measure_OrdID1.Text)|| string.IsNullOrEmpty(this.Btn_Measure_SNR.Text))
                {
                    MessageBox.Show("请输入要查询的工单号，或序列号！");
                    return;
                }
                
                DataTable dt = new DataTable(); //查询物料号与物料名称 填写textbox
                dt = Form1.SSQL.Qty_MeasureValue(this.Tb_Measure_OrdID1.Text,this.Btn_Measure_SNR.Text);

               
                if (dt != null && dt.Rows.Count > 0)
                {

                    DataRow dr = dt.NewRow();
                    dr[0] = "Summary Total:";
                    dr[1] = dt.Rows.Count;
                    dt.Rows.Add(dr);

                    dataGV_Measure_1.DataSource = dt;
                
                    dataGV_Measure_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                    dataGV_Measure_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    dataGV_Measure_1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_Measure_1.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_Measure_1.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    Dt_Cpy = dt.Copy();

                }
                 else
                {
                    MessageBox.Show("无此工单的数据！");
                    return;
                }

                DataView_Filter = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Measure_Filter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TB_Filter_SNR.Text))
                {

                    DataView_Filter.RowFilter = string.Format("SERIAL_NUMBER='{0}'", this.TB_Filter_SNR.Text);
                    dataGV_Measure_1.DataSource = DataView_Filter;
                }

                if (!string.IsNullOrEmpty(this.TB_Measure_ID.Text))
                {

                    DataView_Filter.RowFilter = string.Format("MEASUREMENT_ID='{0}'", this.TB_Measure_ID.Text);
                    dataGV_Measure_1.DataSource = DataView_Filter;
                }

                if (!string.IsNullOrEmpty(this.TB_Measure_Value.Text))
                {

                    DataView_Filter.RowFilter = string.Format("MEASUREMENT = '{0}'", this.TB_Measure_Value.Text.Trim());
                    dataGV_Measure_1.DataSource = DataView_Filter;
                }

                if (!string.IsNullOrEmpty(this.TB_Measure_Value.Text)&& !string.IsNullOrEmpty(this.TB_Measure_ID.Text)) //测量值id与测量值 组合检索
                {

                    DataView_Filter.RowFilter = string.Format("MEASUREMENT='{0}' and MEASUREMENT_ID='{1}'", this.TB_Measure_Value.Text, this.TB_Measure_ID.Text);
                    dataGV_Measure_1.DataSource = DataView_Filter;
                }

                if (!string.IsNullOrEmpty(this.TB_Filter_SNR.Text) && !string.IsNullOrEmpty(this.TB_Measure_Value.Text)) //序列号与测量值 组合检索 从数据库查询
                {

                    dataGV_Measure_1.DataSource =Form1.SSQL.Qty_Measure_SNR_Val(this.TB_Filter_SNR.Text, this.TB_Measure_Value.Text);
                    dataGV_Measure_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                    dataGV_Measure_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    dataGV_Measure_1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_Measure_1.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_Measure_1.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Measure_Back_Click(object sender, EventArgs e)
        {
            dataGV_Measure_1.DataSource = Dt_Cpy;
        }

        private void timer_Meas_Tick(object sender, EventArgs e)
        {
            timer_Meas.Interval = int.Parse(Tb_timerCount.Text) * 1000 * 60; //单位：分钟

            DataTable dt = new DataTable();
            dt = Form1.SSQL.Get_Meas_T_Test_SNR(int.Parse(Tb_SQLInterval.Text)); //计时器调用 数据库校验方法

            if (dt != null && dt.Rows.Count > 0)
            {
                ClassQM.Handle_SNRs(dt); //处理返回的序列号
            }
            else
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                if (System.IO.Directory.Exists(path + @"\" + "Logs"))
                {
                    
                    using(StreamWriter sw1 = new StreamWriter(path + @"\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt",true))
                    {
                        sw1.WriteLine("时间段内未有符合的SNR ;WriteTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw1.Close();
                    }
                                        
                }
                else //logs文件夹不存在 就创建
                {
                    FileHelper.MkDir(path + @"\" + "Logs");
                    using (StreamWriter sw1 = new StreamWriter(path + @"\Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true))
                    {
                        sw1.WriteLine("时间段内未有符合的SNR ;WriteTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw1.Close();
                    }
                }
            }
                       
        }

        private bool  Handle_SNRs(DataTable DT)
        {
            DataTable ddt = new DataTable();

            string path =System.IO.Directory.GetCurrentDirectory();
            path=path+@"\TOOLS\T_TEST\Monitor";

            try
            {
                for(int i = 0; i < DT.Rows.Count; i++)
                {
                   ddt= Form1.SSQL.Qty_Meas_T_Test_SNR(DT.Rows[i]["LotName"].ToString());

                    if (ddt == null) //发现: 不存在电测测量值的序列号 写入txt文件。
                    {
                        if(System.IO.File.Exists(path + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt")) //如果文件存在 再判断是否有相同内容!
                        {
                            string readfile = System.IO.File.ReadAllText(path + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

                            if (readfile.Contains(DT.Rows[i]["LotName"].ToString())) //如果存在相同的SNR 表示已经写过，不再写入txt
                            {
                                continue; //判断下一个SNR
                            }
                            else
                            {
                                FileHelper.WriteTxt(path, "Error: "+DT.Rows[i][0].ToString() + ";" + DT.Rows[i][1].ToString() + ";" + Convert.ToDateTime(DT.Rows[i][2]).ToString("yyyy-MM-dd HH:mm:ss")); //处理返回的序列号 写入txt文件
                            }
                        }
                        else //文件不存在 直接调用写入方法！
                        {
                            FileHelper.WriteTxt(path, "Error: " +DT.Rows[i][0].ToString() + ";" + DT.Rows[i][1].ToString() + ";" + Convert.ToDateTime(DT.Rows[i][2]).ToString("yyyy-MM-dd HH:mm:ss")); //处理返回的序列号 写入txt文件
                        }
                        
                       
                    }
                    else //写入日志，将此SNR及测量值信息写入txt 作为log记录
                    {
                        FileHelper.WriteTxt(path, "Monitor: "+DT.Rows[i]["LotName"].ToString() + ";;" + ddt.Rows[i]["ORDER_ID"] + ";;" + ddt.Rows[i]["TERMINAL_ID"]
                            + ";;" + ddt.Rows[i]["MEASUREMENT_ID"] + ";;" + "Value: "+ddt.Rows[i]["MEASUREMENT"] + ";;" +Convert.ToDateTime(ddt.Rows[i]["ChinaTime"]).ToString("yyyy-MM-dd HH:mm:ss"));
                        
                    }
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Btn_MeasMonitorSTOP_Click(object sender, EventArgs e)
        {
            timer_Meas.Stop();
            MessageBox.Show("监控停止！");
        }

        private void Btn_MeasMonitor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_timerCount.Text))
            {
                if (int.Parse(Tb_timerCount.Text) >= 3)
                {
                    timer_Meas.Start();
                    MessageBox.Show("监控开始！");
                }
            }
            else
            {
                MessageBox.Show("读取数据的时间间隔未设置 不能小于3分钟");
                return;
            }
        }

        private void QueryMeasurement_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1190, 570);
            this.Tb_SQLInterval.Text = "8"; //数据库查询间隔数 默认 8小时!
        }

        private void Tb_timerCount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
