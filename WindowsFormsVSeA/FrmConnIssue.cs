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
    public partial class FrmConnIssue : Form
    {
        public FrmConnIssue()
        {
            InitializeComponent();
        }

        private void FrmConnIssue_Load(object sender, EventArgs e)
        {
            Form1.Class_User.DataGridView_UI_Setup(this.DateGridV_Eqid);//设置datagridview显示UI
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("EquipmetID", typeof(string)));
            
            foreach (string m in Form1.CUModel.List_Str)
            {
                DataRow dr = dt.NewRow();
                dr["EquipmetID"] = m;
                dt.Rows.Add(dr);
            }
                DateGridV_Eqid.DataSource = dt;
            richTextBox1.Text = "表中显示内容表示：ShopFloor Connection 连接配置文件中缺失的，下发到MES中LOIPRO工单" +
                "中包含的Equipment ID配置参数，请核对ShopFloor Connection 文件中的配置 ！";
        }
    }
}
