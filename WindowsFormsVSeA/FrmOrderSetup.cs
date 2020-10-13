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
    public partial class FrmOrderSetup : Form
    {
        public WindowsFormsVSeA.DoSQL SSQL = new DoSQL(); //新申明的实例化对象 SSQL，其中DBConnStr连接参数为空！

        public FrmOrderSetup()
        {
            InitializeComponent();
        }

        private void FrmOrderSetup_Load(object sender, EventArgs e)
        {
            string ddb = Form1.SSQL.DBConnStr;

            DataTable dt = new DataTable();
            this.Lb_orderSetup.Text = Form1.CUModel.OrderID;
            if (!string.IsNullOrEmpty(this.Lb_orderSetup.Text))
            {
               
                dt = Form1.SSQL.Qty_Order_Setup(this.Lb_orderSetup.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;

                    dataGridView2.Columns[2].Visible = false;
                    
                    dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dt.Dispose();
                }
                else
                {
                    MessageBox.Show("工单无 Setup 数据 ！");
                }
            }

            
        }
    }
}
