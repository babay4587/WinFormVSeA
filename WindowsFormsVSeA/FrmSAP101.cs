using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsVSeA
{
    public partial class FrmSAP101 : Form
    {

        public DataTable PubDt = new DataTable();

        public FrmSAP101()
        {
            InitializeComponent();
        }

        private void DTPicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmSAP101_Load(object sender, EventArgs e)
        {
            DTPicker_E.Enabled = false;
        }

        private void Btn_MatmasQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.TB_IntvalDay.Text))
                {
                    MessageBox.Show("请输入要查询的间隔天数！");
                    return;
                }
                                
                string StrDate = DTPicker1.Value.ToString("yyyy-MM-dd");
                double d = Convert.ToDouble(TB_IntvalDay.Text);

                if (d > 15)
                {
                    MessageBox.Show("时间间隔不能大于15天！");
                    return;
                }

                DTPicker_E.Value = DTPicker1.Value.AddDays(d);
                string EndDate = DTPicker_E.Value.ToString("yyyy-MM-dd");

                StrDate = StrDate + "  00:00";
                EndDate = EndDate + " 23:59";

                DataTable dt = new DataTable();
                dt=Form1.SSQL.Qty_MES2SAP_MatMas_101(StrDate, EndDate);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DateGridV_MatMas101_1.DataSource = dt;
                    //LB_RowsCount.Text = dt.Rows.Count.ToString();

                    DateGridV_MatMas101_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                    DateGridV_MatMas101_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    DateGridV_MatMas101_1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MatMas101_1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MatMas101_1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MatMas101_1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DateGridV_MatMas101_1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    PubDt = dt.Copy(); //在增加汇总行前 给全局datatable 赋值

                    DataRow dr = dt.NewRow();
                    dr[1] = "Summary Total:";
                    dr[2] = dt.Rows.Count;
                    dt.Rows.Add(dr);


                    dt.Dispose();
                }
                else
                {
                    MessageBox.Show("无此工单的数据！");
                    return;
                }
                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Btn_Matid_Click(object sender, EventArgs e)
        {
            try
            {
                if (PubDt != null && PubDt.Rows.Count > 0)
                {
                    var V = from t in PubDt.AsEnumerable()
                            group t by new { t1 = t.Field<string>("MatID"), t2 = t.Field<string>("MatName") } into m
                            select new
                            {
                                Material_ID = m.Key.t1,
                                Material_Desc = m.Key.t2,
                                Report_Count = m.Count(),
                            };
                    if (V.ToList().Count > 0)
                    {
                        DateGridV_MatMas101_2.DataSource = V.ToList();
                        DateGridV_MatMas101_2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        DateGridV_MatMas101_2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        DateGridV_MatMas101_2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        DateGridV_MatMas101_2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                    }
                                        
                }
                else
                {
                    MessageBox.Show("无处理的数据！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Orderid_Click(object sender, EventArgs e)
        {
            try
            {
                if (PubDt != null && PubDt.Rows.Count > 0)
                {
                    var V = from t in PubDt.AsEnumerable()
                            group t by new { t1 = t.Field<string>("MatID"), t2 = t.Field<string>("MatName"),t3=t.Field<string>("OrderID") } into m
                            select new
                            {
                                Material_ID = m.Key.t1,
                                Material_Desc = m.Key.t2,
                                OrderID=m.Key.t3,
                                Report_Count = m.Count(),
                            };
                    if (V.ToList().Count > 0)
                    {
                        DateGridV_MatMas101_2.DataSource = V.ToList();
                        DateGridV_MatMas101_2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        DateGridV_MatMas101_2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        DateGridV_MatMas101_2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        DateGridV_MatMas101_2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    
                }
                else
                {
                    MessageBox.Show("无处理的数据！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_SNRChk_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;

                for (int nbRow = 0; nbRow < DateGridV_MatMas101_1.Rows.Count - 2; nbRow++)
                {
                    
                    if (string.IsNullOrEmpty(DateGridV_MatMas101_1.Rows[nbRow].Cells[4].Value.ToString()))
                    {

                        DateGridV_MatMas101_1.Rows[nbRow].Cells[4].Style.BackColor = Color.YellowGreen;
                        i++;
                    }
                    
                }

                MessageBox.Show("Serial Number 筛查完成：共找到 "+i.ToString()+" 个");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
