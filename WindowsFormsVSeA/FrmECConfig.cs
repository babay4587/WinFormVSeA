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
    public partial class FrmECConfig : Form
    {

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
            this.Size = new Size(1200, 700);
        }
    }
}
