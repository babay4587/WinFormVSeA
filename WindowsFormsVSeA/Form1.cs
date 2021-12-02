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

        public static Class_User Class_User = new Class_User();

        DataView DV_RealTrace = new DataView();

        DataTable Dt_Cpy = new DataTable();

        public DataTable Dt_Trans_Eqid = new DataTable();
        
        public static Class_User.UserModel CUModel = new Class_User.UserModel();

        public static bool Updated_P_DB = false;

        Cursor cursorTmp = Cursor.Current;

        Color colorTmp = Color.White;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable Ddt = new DataTable();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Tb1.Text = openFileDialog1.FileName;

                string Fn = string.Empty;
                Fn = Path.GetExtension(openFileDialog1.FileName);

                if (Fn.ToUpper() == ".XML")
                {
                   

                    Ddt = xmlDo.Sfloor_Conn(Tb1.Text);

                    if(Ddt.Rows.Count>0 || Ddt != null)
                    {
                        dataGridView1.DataSource = Ddt;

                        Class_User.DataGridView_UI_Setup(this.dataGridView1);//设置datagridview显示UI

                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        tB_RowCount.Text = dataGridView1.Rows.Count.ToString();

                        Dt_Trans_Eqid = Ddt.DefaultView.ToTable(false,"EQUIPMENT_ID");//true 表示去除重复行

                       
                        #region//通过条件筛选行，并赋值给 Dt_Trans_Eqid表 注释的参考代码
                        //DataRow[] EqRows = Ddt.Select("EQUIPMENT_ID<>''");

                        //foreach (DataRow row in EqRows)
                        //{
                        //    Dt_Trans_Eqid.ImportRow(row);
                        //}
                        #endregion 
                    }

                }
                else
                {
                    MessageBox.Show("非XML文件");
                }
            }
            //Ddt.Clear();
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
                int i = 0;
                bool isDuplicate=false;
                for(int nbRow = 0; nbRow < dataGridView1.Rows.Count-1; nbRow++) //Equipment ID 查重
                {
                    for(int NextRow = nbRow+ 1; NextRow <= dataGridView1.Rows.Count-2; NextRow++)
                    {
                        if (dataGridView1.Rows[nbRow].Cells[6].Value.ToString() == dataGridView1.Rows[NextRow].Cells[6].Value.ToString())
                        {
                            isDuplicate = true;
                            dataGridView1.Rows[nbRow].Cells[6].Style.BackColor = Color.LightGreen;
                            dataGridView1.Rows[NextRow].Cells[6].Style.BackColor = Color.LightGreen;
                            i++;
                        }
                    }
                   

                        if (isDuplicate)
                        {
                            //MessageBox.Show(dataGridView1[6, nbRow].Value.ToString());
                            isDuplicate = false;
                        }

                }

                for (int nbRow = 0; nbRow < dataGridView1.Rows.Count - 1; nbRow++) //SSAP 查重
                {
                    for (int NextRow = nbRow + 1; NextRow <= dataGridView1.Rows.Count - 2; NextRow++)
                    {
                        if (dataGridView1.Rows[nbRow].Cells[0].Value.ToString() == "RFC1006")
                        {
                            if (dataGridView1.Rows[nbRow].Cells[3].Value.ToString() == dataGridView1.Rows[NextRow].Cells[3].Value.ToString())
                            {
                                isDuplicate = true;
                                dataGridView1.Rows[nbRow].Cells[3].Style.BackColor = Color.LightGreen;
                                dataGridView1.Rows[NextRow].Cells[3].Style.BackColor = Color.LightGreen;
                                i++;
                            }
                        }
                    }
                    
                    if (isDuplicate)
                    {
                        //MessageBox.Show(dataGridView1[6, nbRow].Value.ToString());
                        isDuplicate = false;
                    }

                }

                for (int nbRow = 0; nbRow < dataGridView1.Rows.Count - 1; nbRow++) //TSAP 查重
                {
                    for (int NextRow = nbRow + 1; NextRow <= dataGridView1.Rows.Count - 2; NextRow++)
                    {
                        if (dataGridView1.Rows[nbRow].Cells[0].Value.ToString()== "RFC1006")
                        {
                            if (dataGridView1.Rows[nbRow].Cells[4].Value.ToString() == dataGridView1.Rows[NextRow].Cells[4].Value.ToString())
                            {
                                isDuplicate = true;
                                dataGridView1.Rows[nbRow].Cells[4].Style.BackColor = Color.LightGreen;
                                dataGridView1.Rows[NextRow].Cells[4].Style.BackColor = Color.LightGreen;
                                i++;
                            }
                        }
                        
                    }

                    if (isDuplicate)
                    {
                        //MessageBox.Show(dataGridView1[6, nbRow].Value.ToString());
                        isDuplicate = false;
                    }

                }

                tb_dul.Text = "共发现 " + i.ToString() + " 个重复记录";
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
                        DataRow dr = dt.NewRow();
                        dr[4] = "Summary Total:";
                        dr[5] = dt.Rows.Count;
                        dt.Rows.Add(dr);

                        dataGridView2.DataSource = dt;
                                                
                        TB_Mat_Fert.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();

                        dataGridView2.Columns[0].Visible =false;
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;

                        dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        this.Btn_Ordr_detail.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("未查询到 Order 数据");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("order id is null");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

                        Class_User.DataGridView_UI_Setup(dataGridView3);//设置datagridview显示UI

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

      

        

        private void qSYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("Q_connString") == "ok")
                {
                    
                    this.tBColorQ.BackColor = Color.SpringGreen;
                    this.tBColorP.BackColor = Color.Empty;
                    this.tBColorNewSvr.BackColor = Color.Empty;

                    Lb_P_DB.Visible = false;

                    Updated_P_DB = true;//Q系统 操作数据库权限开放

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
                if (SSQL.DbConn("NewServer") == "ok")
                {
                    this.tBColorP.BackColor = Color.SpringGreen;
                    this.tBColorQ.BackColor = Color.Empty;

                    this.tBColorNewSvr.BackColor = Color.Empty;
                    Lb_P_DB.Visible = false;

                    Updated_P_DB = false;//操作数据库权限关闭
                    //MessageBox.Show("P-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Btn_Ordr_detail.Enabled = false;

            Lb_P_DB.Visible = false;
            Lb_P_DB.BackColor = Color.RosyBrown;
            this.Size = new Size(1340, 675);
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

                        Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI

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
                        Class_User.DataGridView_UI_Setup(this.dataGridView5);//设置datagridview显示UI

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
                Class_User.DataGridView_UI_Setup(this.dataGridView6);//设置datagridview显示UI

                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (!string.IsNullOrEmpty(this.TB_Temp_Order.Text) || !string.IsNullOrEmpty(this.TB_Temp_SNR.Text))
                {
                    DataTable dt = new DataTable();

                    if (checkBox3.CheckState == CheckState.Checked)
                    {
                        dt = SSQL.Qty_Mat_Setup_Temp_Db(this.TB_Temp_Order.Text);
                    }
                    else
                    {
                        dt = SSQL.Qty_Mat_Setup_Db(this.TB_Temp_Order.Text);
                    }

                    if (dt != null && dt.Rows.Count > 0)
                    {

                        dataGridView6.DataSource = dt;

                        if (checkBox3.CheckState != CheckState.Checked)
                        {
                            dataGridView6.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            
                            dataGridView6.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        }
                        else
                        {
                            dataGridView6.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            //dataGridView6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[7].Visible = false;
                            dataGridView6.Columns[1].Visible = false;
                        }
                      
                        DV_RealTrace = dt.DefaultView;

                        //if (!string.IsNullOrEmpty(this.TB_Temp_Order.Text)) //如果输入工单号 则不显示工单号列
                        //{
                        //    dataGridView6.Columns[0].Visible = false;

                        //}
                        //if (!string.IsNullOrEmpty(this.TB_Temp_SNR.Text)) //如果输入序列号 则不显示序列号列
                        //{
                        //    dataGridView6.Columns[1].Visible = false;
                        //    this.TB_Temp_SNR.Text = dt.Rows[0][1].ToString();
                        //    dataGridView6.Columns[0].Visible = false;
                        //    this.TB_Temp_Order.Text= dt.Rows[0][0].ToString();
                        //}

                    }
                    else
                    {
                        MessageBox.Show("查无数据 ！");
                        return;
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

                        Class_User.DataGridView_UI_Setup(this.dataGridView7);//设置datagridview显示UI

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
                    MessageBox.Show("Please input Order Number first ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_MeasureFilter_Click(object sender, EventArgs e)
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

        private void Btn_MeasureBack_Click(object sender, EventArgs e)
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

                    Class_User.DataGridView_UI_Setup(this.dataGridView8);//设置datagridview显示UI

                    TB_eCar_OrderID.Text = dt.Rows[0][1].ToString();

                }

                DataTable dtt1 = new DataTable();
                dtt1 = SSQL.Qty_Single_SNR(this.TB_eCar_Product.Text);
                if (dtt1 != null && dt.Rows.Count > 0)
                {
                    TB_eCar_Product_Matid.Text = dtt1.Rows[0][1].ToString();
                    TB_eCar_Product_MatName.Text = dtt1.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("未查询到数据 !");
                    return;
                }
                   

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

        private void Btn_Ordr_detail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(this.tB_Order.Text))
                {
                    dt = SSQL.Qty_Order_SNRs(this.tB_Order.Text);
                }
                else
                {
                    MessageBox.Show("order id is null");
                    return;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "Summary Total:";
                    dr[2] = dt.Rows.Count;
                    dt.Rows.Add(dr);
                    //dataGridView8.AutoGenerateColumns = false;
                    dataGridView2.DataSource = dt;
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                    dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    MessageBox.Show("查无数据 ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_OrderItlk_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(this.tB_Order.Text))
                {
                    dt = SSQL.Qty_Order_ItlkObj(this.tB_Order.Text);
                }
                else
                {
                    MessageBox.Show("order id is null");
                    return;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "Summary Total:";
                    dr[2] = dt.Rows.Count;
                    dt.Rows.Add(dr);
                    //dataGridView8.AutoGenerateColumns = false;
                    dataGridView2.DataSource = dt;
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    MessageBox.Show("查无数据 ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Order_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(this.tB_Order.Text))
                {
                    dt = SSQL.Qty_Order_ItlkObj(this.tB_Order.Text);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[1] = "Summary Total:";
                    dr[2] = dt.Rows.Count;
                    dt.Rows.Add(dr);
                    //dataGridView8.AutoGenerateColumns = false;
                    dataGridView2.DataSource = dt;
                    dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                    dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void celianghziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new QueryMeasurement().Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void 接口堵塞监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new MES2SAPMonitor().Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 唯一件装配查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new Material2Uniques().Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_MatReal_SNR_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (this.TB_Filter_SNR.Text != "" || !string.IsNullOrEmpty(this.TB_Filter_SNR.Text))
                {
                    DataTable dt = new DataTable();
                    dt = SSQL.Qty_SNR_Real_Genealogy(this.TB_Filter_SNR.Text.Trim());

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        
                        dataGridView7.DataSource = dt;

                        dataGridView7.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
                        dataGridView7.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        dataGridView7.Columns[0].Visible = false;
                        dataGridView7.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        DataRow dr = dt.NewRow();
                        dr[1] = "Summary Total:";
                        dr[2] = dt.Rows.Count;
                        dt.Rows.Add(dr);

                    }
                    else
                    {
                        MessageBox.Show("查无数据 ！");
                        return;
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

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                colorTmp = dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor;
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                if (e.ColumnIndex == 1)//改变第二列鼠标形状
                {
                    cursorTmp = this.Cursor;
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        private void dataGridView2_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorTmp;
                if (e.ColumnIndex == 1)
                {
                    this.Cursor = cursorTmp;
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.dataGridView2);//设置datagridview显示UI

        }

        private void Btn_Temp_Filrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TB_Temp_SNR.Text))
                {

                    DV_RealTrace.RowFilter = string.Format("SERIALNUMBER='{0}'", this.TB_Temp_SNR.Text.Trim());
                    dataGridView6.DataSource = DV_RealTrace;
                }
                else
                {
                    MessageBox.Show("请输入 序列号 ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 工单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new FrmOrderMgr().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sNR状态查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new FrmSNR_Status().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eC线打印机操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new Frm_EC_Printer().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void pACTIVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("P_Update") == "P_DB_Activity")
                {

                    Lb_P_DB.Visible = true;

                    this.tBColorQ.BackColor = Color.Empty;
                    this.tBColorP.BackColor = Color.Empty;
                    this.tBColorNewSvr.BackColor = Color.Empty;

                    Updated_P_DB = true;
                    //MessageBox.Show("Q-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eCConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new FrmECConfig().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_LOI_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.Rows.Count > 0)
                {
                    List<string> Loipro_Eqid = new List<string>();//清洗LOIPRO 设备号字段 去掉 ；

                    List<string> Shopfloor_Issue = new List<string>();//获取找到的 存在问题的设备号;

                    for (int i = 0; i < dataGridView3.Rows.Count; i++)//idoc LOIPRO文件 Equipment id的循环。
                    {
                        if (Convert.ToString(dataGridView3.Rows[i].Cells["EQUIPMENT_ID"].Value).Split(';').Length > 2)
                        {
                            string[] Arr = Convert.ToString(dataGridView3.Rows[i].Cells["EQUIPMENT_ID"].Value).Split(';');
                            foreach(string d in Arr)// remove blank or empty string
                            {
                                if (!string.IsNullOrEmpty(d))
                                {
                                    Loipro_Eqid.Add(d);
                                }
                                
                            }
                            
                        }
                        if (Convert.ToString(dataGridView3.Rows[i].Cells["EQUIPMENT_ID"].Value).Split(';').Length ==2)
                        {
                            string[] Arr = Convert.ToString(dataGridView3.Rows[i].Cells["EQUIPMENT_ID"].Value).Split(';');
                            foreach (string d in Arr)
                            {
                                if (!string.IsNullOrEmpty(d))
                                {
                                    Loipro_Eqid.Add(d);
                                }

                            }
                        }
                            

                    }

                    if (Dt_Trans_Eqid.Rows.Count>0&& Dt_Trans_Eqid != null)//连接配置参表 不能为空
                    {
                        foreach(string s in Loipro_Eqid)//遍历Loipro 工单中的设备号 是否存在与 shopfloor connection 连接文件中
                        {
                            if (Dt_Trans_Eqid.Select(string.Format(@"EQUIPMENT_ID='{0}'",s )).Length > 0)//查到 连接配置文件不存在的设备号
                            {
                                continue;
                                
                            }
                            else
                            {
                                Shopfloor_Issue.Add(s);
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("先运行 Shopfloor Connections 获取连接设备号参数 再运行此校验！");
                    }

                    if (Shopfloor_Issue.Count > 0)
                    {
                        CUModel.List_Str = Shopfloor_Issue;
                        new FrmConnIssue().Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Shopfloor Connections 中Equipment ID配置与LOIPRO文件中相同 无漏项！");
                    }
                }
                else
                {
                    MessageBox.Show("无需要对比的数据");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 载具查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new FrmHUT().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void newServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SSQL.DbConn("NewServer") == "ok")
                {

                    this.tBColorQ.BackColor = Color.Empty;
                    this.tBColorP.BackColor = Color.Empty;
                    this.tBColorNewSvr.BackColor = Color.SpringGreen;

                    Lb_P_DB.Visible = false;

                    Updated_P_DB = false;//操作数据库权限关闭

                    //MessageBox.Show("Q-Sys 连接参数读取完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dBConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_order_simple_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (!string.IsNullOrEmpty(this.tB_Order.Text))
                {
                    DataTable dt_Simple = new DataTable();

                    dt_Simple = SSQL.Qty_Order_Simple(this.tB_Order.Text);

                    if (dt_Simple != null && dt_Simple.Rows.Count > 0)
                    {
                        DataRow dr = dt_Simple.NewRow();
                        dr[1] = "Summary Total:";
                        dr[2] = dt_Simple.Rows.Count;
                        dt_Simple.Rows.Add(dr);
                        //dataGridView8.AutoGenerateColumns = false;
                        dataGridView2.DataSource = dt_Simple;
                        dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                        dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("查无数据 ！");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("order id is null");
                    return;
                }

            }
            catch
            {

            }
        }
    }
}
