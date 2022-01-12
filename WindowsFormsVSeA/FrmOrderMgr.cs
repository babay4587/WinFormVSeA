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
    public partial class FrmOrderMgr : Form
    {

        public static Class_User Class_User = new Class_User();

        public FrmOrderMgr()
        {
            InitializeComponent();
        }

        private void Btn_FrmOrd_1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.TB_FrmOrd_Mat.Text))
                {
                    MessageBox.Show("请输入要查询的成品料号！");
                    return;
                }
                
                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_GetOrderFromMat(this.TB_FrmOrd_Mat.Text);
                if (dt != null && dt.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= 1)
                    {

                        DateGridV_FrmOrder1.DataSource = dt;

                        
                        DateGridV_FrmOrder1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        DateGridV_FrmOrder1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    dt.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmOrderMgr_Load(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.DateGridV_FrmOrder1);//设置datagridview显示UI

        }
    }
}
