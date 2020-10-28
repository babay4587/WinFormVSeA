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
    public partial class MES2SAPMonitor : Form
    {
        public MES2SAPMonitor()
        {
            InitializeComponent();
        }

        private void Btn_SAP_Monitor_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_MES2SAP_UnSentRecord();
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    if (Convert.ToInt32(dt.Rows[0][0].ToString())>= 1)
                    {
                        dt = Form1.SSQL.Qty_MES2SAP_UnSentRecord();

                        dataGV_Monitor_1.DataSource = dt;

                        dataGV_Monitor_1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGV_Monitor_1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        dataGV_Monitor_1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_Monitor_1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    dt.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MES2SAPMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable(); //查询物料号与物料名称 填写textbox
                dt = Form1.SSQL.Qty_MES2SAP_Blocked();

                if (dt == null && dt.Rows.Count == 0)
                {
                    TB_UnsentCount.Text = "0";
                }
                else
                {
                    TB_UnsentCount.Text = this.TB_UnsentCount.Text = dt.Rows[0][0].ToString();
                }

                dt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
