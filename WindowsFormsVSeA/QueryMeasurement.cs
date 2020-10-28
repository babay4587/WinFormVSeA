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
    public partial class QueryMeasurement : Form
    {

        DataView DataView_Filter = new DataView();
        DataTable Dt_Cpy = new DataTable();

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
    }
}
