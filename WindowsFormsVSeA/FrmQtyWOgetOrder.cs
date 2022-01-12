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
    public partial class FrmQtyWOgetOrder : Form
    {

        public DataView DV_RT_Filter = new DataView();

        public FrmQtyWOgetOrder()
        {
            InitializeComponent();
        }



        private void FrmQtyWOgetOrder_Load(object sender, EventArgs e)
        {
            try
            {
                this.Size = new Size(1180, 570);
                this.Text = "根据工站查询工单";
                this.label1.BackColor = Color.AliceBlue;
                
                this.TB_Orderid.Text = Form1.CUModel.OrderID;
                this.TB_Orderid.Enabled = false;

                Tb_Filter1.BackColor = Color.YellowGreen;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public class Attr
        {
            public string WOType { get; set; }
            public string Ctrlkey { get; set; }
            public string WONum { get; set; }

            public string orderid { get; set; }
        }

        private void Btn_Qty1_Click(object sender, EventArgs e)
        {
            try
            {
                Attr vl = new Attr
                {
                    WOType = "%",
                    WONum = "%",
                    Ctrlkey = "%"
                };

                string Ctrlkey = string.Empty;
                string WONum = string.Empty;

                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(this.TB_WoType.Text))
                {
                    if (!string.IsNullOrEmpty(this.TB_ControlKey.Text))
                    {
                        Ctrlkey = this.TB_ControlKey.Text;
                    }
                    else
                    {
                        Ctrlkey = vl.Ctrlkey;
                    }

                    if (!string.IsNullOrEmpty(this.TB_EC_Number.Text))
                    {
                        WONum = this.TB_EC_Number.Text;
                    }
                    else
                    {
                        WONum = vl.WONum;
                    }

                    dt = Form1.SSQL.Qty_WO_GetOrders(this.TB_WoType.Text.ToUpper(), Ctrlkey.ToUpper(), WONum.ToUpper());

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGV_WoGet.DataSource = null;
                        dataGV_WoGet.DataSource = dt;

                        //dataGV_WoGet.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        Form1.Class_User.DataGridView_UI_Setup(this.dataGV_WoGet);//设置datagridview显示UI
                        dataGV_WoGet.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGV_WoGet.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGV_WoGet.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        DV_RT_Filter = dt.DefaultView;

                        this.TBRowCount.Text = dt.Rows.Count.ToString();

                    }
                    else
                    {
                        MessageBox.Show("查无数据! ");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("工站类型，如GUI ；SFL 必须输入 ");
                    return;

                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BT_DVFilter_Click(object sender, EventArgs e)
        {
            if (DV_RT_Filter.Count > 0)
            {
                DV_RT_Filter.RowFilter = string.Format("FERT_MAT_ID='{0}'", this.Tb_Filter1.Text.Trim());
                dataGV_WoGet.DataSource = DV_RT_Filter;

                this.TBRowCount.Text = DV_RT_Filter.Count.ToString();

            }
            else
            {
                MessageBox.Show("没有可以筛选的数据");
                return;
            }
            
        }

        private void dataGV_WoGet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Ordid = string.Empty;

            
        }

        private void dataGV_WoGet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Ordid = string.Empty;

            //Ordid = dataGV_WoGet.Rows(e.rowindex).cell(e.columnindex).values;
            Ordid = dataGV_WoGet.CurrentRow.Cells["OrderID"].Value.ToString();
            Form1.CUModel.OrderID = Ordid;
        }
    }
}
