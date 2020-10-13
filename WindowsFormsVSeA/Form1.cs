using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;




namespace WindowsFormsVSeA
{
    public partial class Form1 : Form
    {
        public WindowsFormsVSeA.XmlDo xmlDo = new XmlDo();

        public static WindowsFormsVSeA.DoSQL  SSQL = new DoSQL();

        public TextBox tb = new TextBox();

        //public static string DBConnStr = string.Empty;

        DataView DV_RealTrace = new DataView();

        DataTable Dt_Cpy = new DataTable();
        
        public static Class_User.UserModel CUModel = new Class_User.UserModel();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb1.Text = openFileDialog1.FileName;

                string Fn = string.Empty;
                Fn = Path.GetExtension(openFileDialog1.FileName);

                if (Fn.ToUpper() == ".XML")
                {
                    DataTable Ddt = new DataTable();

                    Ddt = xmlDo.Sfloor_Conn(Tb1.Text);

                    if(Ddt.Rows.Count>0 || Ddt != null)
                    {
                        dataGridView1.DataSource = Ddt;

                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        tB_RowCount.Text = dataGridView1.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("非XML文件");
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                dataGridView1.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }

            for (int i = e.RowIndex + e.RowCount; i < this.dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btn_duplicate_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDuplicate=false;
                for(int nbRow = 0; nbRow < dataGridView1.Rows.Count-1; nbRow++)
                {
                    for(int NextRow = nbRow+ 1; NextRow <= dataGridView1.Rows.Count-2; NextRow++)
                    {
                        if (dataGridView1.Rows[nbRow].Cells[6].Value.ToString() == dataGridView1.Rows[NextRow].Cells[6].Value.ToString())
                        {
                            isDuplicate = true;
                            dataGridView1.Rows[nbRow].Cells[6].Style.BackColor = Color.LightGreen;
                            dataGridView1.Rows[NextRow].Cells[6].Style.BackColor = Color.LightGreen;
                        }
                    }
                   

                        if (isDuplicate)
                        {
                            //MessageBox.Show(dataGridView1[6, nbRow].Value.ToString());
                            isDuplicate = false;
                        }

                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                if (this.tB_Order.Text !="" || !string.IsNullOrEmpty( this.tB_Order.Text) )
                {
                    DataTable dt = new DataTable();
                    dt=SSQL.Qty_Mat_Order(this.tB_Order.Text);


                    if(dt!=null && dt.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dt;

                        TB_Mat_Fert.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();

                        dataGridView2.Columns[0].Visible =false;
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;

                        dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("未查询到 Order 数据");
                    }
                }
                else
                {
                    MessageBox.Show("order id is null");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string coboSele = comboBox1.SelectedItem.ToString();

            string connStatus = SSQL.DbConn(coboSele); //根据combo选项更改数据库连接
        }

        

        private void button3_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb2.Text = openFileDialog1.FileName;

                string Fn = string.Empty;
                Fn = Path.GetExtension(openFileDialog1.FileName);

                if (Fn.ToUpper() == ".XML")
                {
                    DataTable Ddt = new DataTable();

                   
                    Ddt = xmlDo.Get_LOIP_EQid(Tb2.Text);

                    if (Ddt.Rows.Count > 0 || Ddt != null)
                    {
                        dataGridView3.DataSource = Ddt;

                        dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView3.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView3.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        //tB_RowCount.Text = dataGridView1.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("非XML文件");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // xmlDo.updateTest(this.Tb2.Text);
            Class_User.UserModel Equip = new Class_User.UserModel();
            Equip.EquipmentID = textBox2.Text;
            dataGridView3.DefaultCellStyle.BackColor = Color.White;
            if (dataGridView3.RowCount <= 1||textBox2.Text=="")
            {
                MessageBox.Show("无数据可查询 或 要查询的数据为空!");
                return;
            }

            for(int i=0;i< dataGridView3.Rows.Count; i++)
            {
                for(int j = 0; j < dataGridView3.Columns.Count; j++)
                {

                    if (Convert.ToString( dataGridView3[j,i].Value).Contains(textBox2.Text))
                    {
                        dataGridView3.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        dataGridView3.Rows[i].Cells[j].Style.BackColor = Color.White;//清除上次查询的颜色
                    }
                }
                
            }
            

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            Dictionary<int, string> dict = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Select((x, i) => new { x = (x.Cells[0].Value ?? "").ToString(), i })
            .ToDictionary(x => x.i + 1, x => x.x);
            if (dict.Any(x => x.Key != e.RowIndex + 1 && x.Value == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
            {
                MessageBox.Show("和" + dict.First(x => x.Key != e.RowIndex + 1 && x.Value == dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()).Key.ToString() + "行重复");
            }
        }

      

        private void comboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (comboBox1.Items.Count == 0)
                {
                    List<string> Conns = SSQL.GetConnectionStringsConfig();

                    if (Conns.Count != 0)
                    {
                        foreach (string i in Conns)
                        {
                            comboBox1.Items.Add(i);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void qSYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("Q_connString") == "ok")
                {
                    
                    this.tBColorQ.BackColor = Color.SpringGreen;
                    this.tBColorP.BackColor = Color.Empty;
                    //MessageBox.Show("Q-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pSYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("P_connString") == "ok")
                {
                    this.tBColorP.BackColor = Color.SpringGreen;
                    this.tBColorQ.BackColor = Color.Empty;
                    //MessageBox.Show("P-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                List<string> Conns = SSQL.GetConnectionStringsConfig();

                if (comboBox1.Text== "Q_connString")
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (string.IsNullOrEmpty(this.TB_UniMat.Text))
                {
                    MessageBox.Show("请输入要查询的唯一码 ！");
                    return;
                }
                

                if (this.TB_UniMat.Text != "" || !string.IsNullOrEmpty(this.TB_UniMat.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_UniqueMat(this.TB_UniMat.Text);
                    
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView4.DataSource = dt;

                        TB_Mat_Fert.Text = dataGridView4.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView4.Rows[0].Cells[1].Value.ToString();

                        
                        dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Bold);
                        dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                    else
                    {
                        MessageBox.Show("未查询到 Unique Code 数据");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string SNR = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //MessageBox.Show(SNR);
        }


       
private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string SNR = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            string Unicode= dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            string MatDesc = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();

            CUModel.TranSerialNumber = SNR;
            CUModel.MaterialDesc = MatDesc;
            CUModel.UniqueMatCode = Unicode;


            new FormMatTrace().Show();
        }

        private void btn_Rework_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (this.tB_SNR.Text != "" || !string.IsNullOrEmpty(this.tB_SNR.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_Single_SNR(this.tB_SNR.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        tB_5.Text = dt.Rows[0][2].ToString();
                        tB_4.Text = dt.Rows[0][1].ToString();
                        tB_3.Text = dt.Rows[0][0].ToString();

                    }

                    dt=SSQL.Qty_SNR_Rework_Temp(this.tB_SNR.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView5.DataSource = dt;
                        dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    dt.Dispose();
                    
                }
                else
                {
                    MessageBox.Show("Please input Serial Number first ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (!string.IsNullOrEmpty(this.TB_Temp_Order.Text) || !string.IsNullOrEmpty(this.TB_Temp_SNR.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_Mat_Temp_Db(this.TB_Temp_SNR.Text, this.TB_Temp_Order.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        dataGridView6.DataSource = dt;
                        dataGridView6.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView6.Columns[6].Visible = false;

                        if (!string.IsNullOrEmpty(this.TB_Temp_Order.Text)) //如果输入工单号 则不显示工单号列
                        {
                            dataGridView6.Columns[0].Visible = false;

                        }
                        if (!string.IsNullOrEmpty(this.TB_Temp_SNR.Text)) //如果输入序列号 则不显示序列号列
                        {
                            dataGridView6.Columns[1].Visible = false;
                            this.TB_Temp_SNR.Text = dt.Rows[0][1].ToString();
                            dataGridView6.Columns[0].Visible = false;
                            this.TB_Temp_Order.Text= dt.Rows[0][0].ToString();
                        }
                
                    }

                    dt.Dispose();

                }
                else
                {
                    MessageBox.Show("Please input Serial Number first ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (this.TB_Mat_Real_Trace.Text != "" || !string.IsNullOrEmpty(this.TB_Mat_Real_Trace.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_Mat_Real_Genealogy(this.TB_Mat_Real_Trace.Text);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                       
                        DataRow dr = dt.NewRow();
                        dr[1] = "Summary Total:";
                        dr[2] = dt.Rows.Count;
                        dt.Rows.Add(dr);

                        dataGridView7.DataSource = dt;
                        dataGridView7.Columns[0].Visible = false;
                        dataGridView7.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }

                    DV_RealTrace = dt.DefaultView;

                    Dt_Cpy = dt.Copy();
                    //DV_History = dt.DefaultView;

                    dt.Dispose();

                }
                else
                {
                    MessageBox.Show("Please input Serial Number first ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TB_Filter_SNR.Text))
            {
                
                DV_RealTrace.RowFilter = string.Format("SNR='{0}'", this.TB_Filter_SNR.Text);
                dataGridView7.DataSource = DV_RealTrace;
            }
            if (!string.IsNullOrEmpty(this.TB_Filter_WO.Text))
            {
                DV_RealTrace.RowFilter = string.Format("WorkOperationID='{0}'", this.TB_Filter_WO.Text);
                dataGridView7.DataSource = DV_RealTrace;
            }
            if (!string.IsNullOrEmpty(this.TB_Filter_UniCode.Text))
            {
                DV_RealTrace.RowFilter = string.Format("UniqueCode like '%{0}%'", this.TB_Filter_UniCode.Text);
                dataGridView7.DataSource = DV_RealTrace;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            dataGridView7.DataSource = Dt_Cpy;
        }

        private void Btn_eCar_Report_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(this.TB_eCar_Product.Text))
                {
                    dt = SSQL.Qty_eCar_Product_SNR(this.TB_eCar_Product.Text);
                }
                                
                if (dt != null && dt.Rows.Count > 0)
                {
                    //dataGridView8.AutoGenerateColumns = false;
                    dataGridView8.DataSource = dt;
                    dataGridView8.Columns[1].Visible = false;
                    dataGridView8.Columns[2].Visible = false;
                    dataGridView8.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView8.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView8.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView8.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView8.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    TB_eCar_OrderID.Text = dt.Rows[0][1].ToString();

                }

                DataTable dtt1 = new DataTable();
                dtt1 = SSQL.Qty_Single_SNR(this.TB_eCar_Product.Text);
                TB_eCar_Product_Matid.Text = dtt1.Rows[0][1].ToString();
                TB_eCar_Product_MatName.Text = dtt1.Rows[0][0].ToString();

                Dt_Cpy = dt.Copy();
                
                dt.Dispose();
                dtt1.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                

                if(checkBox1.CheckState == CheckState.Checked)
                {
                    if (this.dataGridView8.Rows.Count != 0)
                    {
                        DataView dv = new DataView(Dt_Cpy);

                        dv.RowFilter = string.Format("ROUTE_POS<>'{0}'", "      Itlk");
                        this.dataGridView8.DataSource = dv;
                       
                    }
                }

                if (checkBox1.CheckState == CheckState.Unchecked)
                {
                   
                    this.dataGridView8.DataSource = Dt_Cpy;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                CUModel.OrderID = this.tB_Order.Text;
                new FrmOrderSetup().Show();
            }
                
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gOODSMOVEMENTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
            {
                MessageBox.Show("数据库未连接 ！");
                return;
            }
            else
            {
                 new SAP_Report().Show();
            }
           
        }

        private void gOODSMOVEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
            {
                MessageBox.Show("数据库未连接 ！");
                return;
            }
            else
            {
                new FrmSAP101().Show();
            }

        }
    }
}
