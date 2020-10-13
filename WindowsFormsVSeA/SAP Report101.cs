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
    public partial class SAP_Report : Form
    {

        public DataTable PubDt = new DataTable();

        public SAP_Report()
        {
            InitializeComponent();
        }

        private void SAP_Report_Load(object sender, EventArgs e)
        {
            
        }

        private void Btn_eCar_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Tb_SAP_OrdBas1.Text))
                {
                    MessageBox.Show("请输入要查询的工单号！");
                    return;
                }

                DataTable dt1 = new DataTable();
                dt1 = Form1.SSQL.Qty_Single_Order(this.Tb_SAP_OrdBas1.Text);

                TB_MatID.Text = dt1.Rows[0][0].ToString();
                TB_MatName.Text= dt1.Rows[0][1].ToString();

                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_MES2SAP_Order_Bas(this.Tb_SAP_OrdBas1.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGV_SAP_1.DataSource = dt;
                    LB_RowsCount.Text = dt.Rows.Count.ToString();

                    dataGV_SAP_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                    dataGV_SAP_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    dataGV_SAP_1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_SAP_1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    PubDt = dt.Copy();
                                        
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

        

        private void dataGV_SAP_1_CellContentClick(object sender, EventArgs e)
        {
            try
            {
                var V = from t in PubDt.AsEnumerable()
                        group t by new { t1 = t.Field<string>("SerialNumber"),t2=t.Field<string>("MatNumber") } into m
                        select new
                        {
                            SNRSum = m.Count(),
                            SNR = m.Key.t1,
                            Material_ID=m.Key.t2
                        };
                if (V.ToList().Count > 0)
                {
                    dataGV_SAP_2.DataSource = V.ToList();
                    dataGV_SAP_2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                    dataGV_SAP_2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                    dataGV_SAP_2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGV_SAP_2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                PubDt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
