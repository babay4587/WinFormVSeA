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
    public partial class FrmECConfig : Form
    {
        public  WindowsFormsVSeA.ExcelHelper ExcelHelper = new ExcelHelper();
        public static Class_User Class_User = new Class_User();
        public DataView DVTrace = new DataView();

        public FrmECConfig()
        {
            InitializeComponent();
        }

        private void Btn_CO_Qty_Click(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.DateGridV_ECConfig_1);//设置datagridview显示UI

            try
            {
                if (!string.IsNullOrEmpty(TB_MachineID.Text))
                {
                    DataTable dt = new DataTable();
                    dt = Form1.SSQL.EC_Config_Qty(TB_MachineID.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DateGridV_ECConfig_1.DataSource = dt;

                    }
                }
                else
                {
                    MessageBox.Show("输入Work Operation ID ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void FrmECConfig_Load(object sender, EventArgs e)
        {
            this.Size = new Size(980, 560);
        }

        private void Btn_NPOI_Excel_Chk_Click(object sender, EventArgs e)
        {
            string Path = @"../../TOOLS";
            string[] files = Directory.GetFiles(Path);
            
            List<DataTable>LstDt= ExcelHelper.ExcelToDataTable(files[0], 1, false);//暂时限定读取TOOLS下1个Excel文件;1:只读一个sheet；读表头：false

            if(LstDt.Count > 0 && LstDt[0].Rows.Count > 0)
            {
                DataTable dt = LstDt[0];
                DateGridV_ECConfig_1.DataSource = dt;
            }
            DataTable dt2 = LstDt[1];
            

        }
    }
}
