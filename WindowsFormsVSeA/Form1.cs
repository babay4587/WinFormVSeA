﻿using System;
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

        public DataView Dv_SNRs_Filter = new DataView();

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

                        CUModel.CUModel_DateTable = Ddt;

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

                        dataGridView2.DataSource = null;
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

            checkBox4.Enabled = false;
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
                        dataGridView4.DataSource = null;
                        dataGridView4.DataSource = dt;

                        TB_Mat_Fert.Text = dataGridView4.Rows[0].Cells[0].Value.ToString();
                        TB_MatDesc.Text = dataGridView4.Rows[0].Cells[1].Value.ToString();

                        Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI

                        dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

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
            //string SNR = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string Unicode= dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            //string MatDesc = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();

            //CUModel.TranSerialNumber = SNR;
            //CUModel.MaterialDesc = MatDesc;
            //CUModel.UniqueMatCode = Unicode;


            //new FormMatTrace().Show();
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

                    //dt = SSQL.Qty_Single_SNR(this.tB_SNR.Text);

                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    tB_5.Text = dt.Rows[0][2].ToString();
                    //    tB_4.Text = dt.Rows[0][1].ToString();
                    //    tB_3.Text = dt.Rows[0][0].ToString();

                    //}
                    

                    dt=SSQL.Qty_SNR_Rework_Temp(this.tB_SNR.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dataGridView5.DataSource = dt;
                        dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        Class_User.DataGridView_UI_Setup(this.dataGridView5);//设置datagridview显示UI

                    }
                    else
                    {
                        MessageBox.Show("未查询到有效数据 请检查SNR是否正确 ！");
                        
                        return;
                    }

                    dt.Dispose();
                    
                }
                else
                {
                    MessageBox.Show("Please input Serial Number first ！");
                    dataGridView5.Rows.Clear();
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

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (!string.IsNullOrEmpty(this.TB_Temp_Order.Text) || !string.IsNullOrEmpty(this.TB_Temp_SNR.Text))
                {
                    

                    if (checkBox3.CheckState == CheckState.Checked)
                    {
                        dt = SSQL.Qty_Mat_Setup_Temp_Db(this.TB_Temp_Order.Text);

                        button8.Enabled = true;

                        if (dt != null && dt.Rows.Count > 0)
                        {

                            dataGridView6.DataSource = null;
                            dataGridView6.DataSource = dt.Copy();
                            dataGridView6.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                            dataGridView6.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                            DV_RealTrace = dt.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("查无数据 ！");
                            return;
                        }
                    }
                    else
                    {

                        button8.Enabled = false;

                        dt1 = SSQL.Qty_Mat_Setup_Db(this.TB_Temp_Order.Text);

                        if (dt1 != null && dt1.Rows.Count > 0)
                        {

                            dataGridView6.DataSource = null;
                            dataGridView6.DataSource = dt1;

                            dataGridView6.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            //dataGridView6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView6.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            
                        }
                        else
                        {
                            MessageBox.Show("查无数据 ！");
                            return;
                        }
                    }

                    //DV_RealTrace = dt.DefaultView;
                    

                }
                else
                {
                    MessageBox.Show("Please input Serial Number first ！");
                    return;
                }

                dt.Dispose();
                dt1.Dispose();
                
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

                        dataGridView7.DataSource = null;
                        dataGridView7.DataSource = dt;
                                               

                        dataGridView7.Columns[0].Visible = false;
                        dataGridView7.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView7.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        
                        Class_User.DataGridView_UI_Setup(this.dataGridView7);//设置datagridview显示UI
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
                    dt = SSQL.Qty_Order_SNRs(this.tB_Order.Text.Trim());
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
                    dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    Dv_SNRs_Filter = dt.DefaultView;

                    checkBox4.Enabled = true;
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
                    dataGridView2.DataSource = null;
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
                        dataGridView7.DataSource = null;
                         dataGridView7.DataSource = dt;
                                                
                        Class_User.DataGridView_UI_Setup(this.dataGridView7);//设置datagridview显示UI
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

                    //dataGridView6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                               
                int rws = dataGridView6.Rows.Count;
                int delRow = 0;

                if (rws < 0)
                {
                    MessageBox.Show("没有要删除的数据记录 ！");
                    return;
                }

                for (int i = 0; i < rws; i++)
                {
                    if (dataGridView6.Rows[i].Selected == true)
                    {
                        delRow = i;
                    }
                }

                StringBuilder Sbuilder = new StringBuilder();

                DialogResult dr = MessageBox.Show("确定删除 : " + dataGridView6.Rows[delRow].Cells[1].Value.ToString() +
                    " ; "+ dataGridView6.Rows[delRow].Cells[3].Value.ToString() + "  数据吗？", "Title: 删除零时表物料", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    
                            Sbuilder.AppendLine(string.Format(@"  delete 
	    FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SETUP_MAT_LABEL_TEMP_$102$]
        where [$IDArchiveValue]='{0}'  ", dataGridView6.Rows[delRow].Cells[13].Value.ToString()));
                        

                    if (Form1.SSQL.RunProc(Sbuilder.ToString()))
                    {
                        MessageBox.Show("删除操作执行成功 ！");
                    }
                    else
                    {
                        MessageBox.Show("数据库执行出现问题 ！");
                    }
                }
                if (dr == DialogResult.Cancel)
                {
                    delRow = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_rework_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (dataGridView5.Rows.Count == 0)
                {
                    MessageBox.Show("请先执行 查询 操作再进行清除 ！");
                    return;
                }

                string Del_reworkLotpk = dataGridView5.Rows[0].Cells[1].Value.ToString();

                if (!string.IsNullOrEmpty(Del_reworkLotpk))
                {
                    StringBuilder Sbuilder = new StringBuilder();

                    DialogResult dr = MessageBox.Show("确定清除 " + this.tB_SNR.Text + " 的返工数据吗？", "Title: 清除返工临时表", MessageBoxButtons.OKCancel);

                    if (dr == DialogResult.OK)
                    {
                       
                      Sbuilder.AppendLine(string.Format(@"  use SITMesDB 
update [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_PROP_EXT_$111$]
  set [REWORK_DATA_TMP]='',[REWORK_DATA_TMP_2]=''
  where LOT_PK='{0}'  ", Del_reworkLotpk));
                            

                        if (Form1.SSQL.RunProc(Sbuilder.ToString()))
                        {
                            MessageBox.Show("清除操作执行成功 ！");
                        }
                        else
                        {
                            MessageBox.Show("数据库执行出现问题 ！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未获取到SNR的PK值 不能完成清除 ！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            CUModel.OrderID = this.tB_Order.Text;

            ttst pc = new ttst();
            pc.or1 = "D321244";
            pc.c1 = 32325;
            pc.or2 = "FileDialogCustomPlacesCollection.";

            try
            {
                if (string.IsNullOrEmpty(Form1.SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }
                else
                {
                    new FrmQtyWOgetOrder().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public class ttst
        {
            public string or1 { get; set; }
            public int c1 { get; set; }
            public string or2 { get; set; }
        }

        private void tB_Order_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form1.CUModel.OrderID != "" || !string.IsNullOrEmpty(Form1.CUModel.OrderID))
            {
                this.tB_Order.Text = Form1.CUModel.OrderID;
            }

            if (Form1.CUModel.OrderID != "" || !string.IsNullOrEmpty(Form1.CUModel.OrderID))
            {
                this.TB_Mat_Real_Trace.Text = Form1.CUModel.OrderID;
            }

        }

        private void TB_Temp_Order_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Form1.CUModel.OrderID != "" || !string.IsNullOrEmpty(Form1.CUModel.OrderID))
            {
                this.TB_Temp_Order.Text = Form1.CUModel.OrderID;
            }

                        
        }

        private void tB_Order_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            this.button8.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                button8.Enabled = true;
            }
            else
            {
                button8.Enabled = false;
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void 参数配置校验ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    new ParameterCheck().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_importExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string GetFullPath_Filename = openFileDialog1.FileName;

                    string Fn = string.Empty;
                    Fn = Path.GetExtension(openFileDialog1.FileName);

                    string ExlPath = Path.GetDirectoryName(GetFullPath_Filename);

                    string ExcelSaveFile = string.Empty;

                    if (!string.IsNullOrEmpty(this.textBox_ExcelPath.Text)|| this.textBox_ExcelPath.Text!="")
                    {
                        ExcelSaveFile = Path.Combine(ExlPath, this.textBox_ExcelPath.Text+".xlsx");
                    }
                    else
                    {
                        MessageBox.Show("输入要保存的Excel文件名!");
                        return;
                    }
                    

                    DataTable DtUniqueList = new DataTable();

                    if (Fn.ToUpper() == ".XLSX")
                    {

                        if (!string.IsNullOrEmpty(GetFullPath_Filename))
                        {

                            DtUniqueList = ExcelHelper.ExcelToDataTableNew(GetFullPath_Filename, 1, false);
                            DtUniqueList.Rows.RemoveAt(0); //去掉表头行

                            DataTable dt = new DataTable();
                            dt.Columns.Add("LotID", typeof(string));
                            dt.Columns.Add("FinalMat", typeof(string));
                            dt.Columns.Add("FertMatName", typeof(string));
                            dt.Columns.Add("LotName", typeof(string));
                            dt.Columns.Add("targetlotpk", typeof(Int32));
                            dt.Columns.Add("changetime", typeof(DateTime));

                            //DataTable dt = ToDataTable1(DTExcel);
                            if (DtUniqueList != null && DtUniqueList.Rows.Count > 0)
                            {
                                DataSet DtSet = new DataSet();
                                
                                for(int i=0;i< DtUniqueList.Rows.Count; i++)
                                {
                                    dt=SSQL.Qty_Unique_Digui(DtUniqueList.Rows[i][0].ToString());

                                    if (dt==null || dt.Rows.Count == 0) //如没有查到数据，插入SNR，写“No result”
                                    {
                                        dt = new DataTable(); //没有数据时，被方法初始化，只能再次new 新的对象 并在下面添加列。
                                        dt.Columns.Add("LotID", typeof(string));
                                        dt.Columns.Add("FinalMat", typeof(string));
                                        dt.Columns.Add("FertMatName", typeof(string));
                                        dt.Columns.Add("LotName", typeof(string));
                                        dt.Columns.Add("targetlotpk", typeof(Int32));
                                        dt.Columns.Add("changetime", typeof(DateTime));

                                        DataRow newRow = dt.NewRow();
                                        newRow["LotID"] = "查询的唯一码:" + DtUniqueList.Rows[i][0].ToString();
                                        newRow["FinalMat"] = "未装配";
                                        newRow["FertMatName"] = "";
                                        newRow["LotName"] = "";
                                        newRow["targetlotpk"] = 0;
                                        newRow["changetime"] = DateTime.Now;
                                        dt.Rows.Add(newRow);

                                        DtSet.Tables.Add(dt); //查到数据加载到Dataset 中
                                    }
                                    else
                                    {
                                        DataRow newRow = dt.NewRow();
                                        newRow["LotID"] ="查询的唯一码:"+ DtUniqueList.Rows[i][0].ToString();
                                        newRow["FinalMat"] = "装配参考LotName列:";
                                        newRow["FertMatName"] = "";
                                        newRow["LotName"] = "";
                                        newRow["targetlotpk"] = dt.Rows.Count;
                                        newRow["changetime"] = DateTime.Now;
                                        dt.Rows.Add(newRow);

                                        DtSet.Tables.Add(dt); //查到数据加载到Dataset 中
                                    }
                                                                     
                                 
                                }
                                DataTable newdts = new DataTable();
                                newdts.Columns.Add("LotID", typeof(string));
                                newdts.Columns.Add("FinalMat", typeof(string));
                                newdts.Columns.Add("FertMatName", typeof(string));
                                newdts.Columns.Add("LotName", typeof(string));
                                newdts.Columns.Add("targetlotpk", typeof(Int32));
                                newdts.Columns.Add("changetime", typeof(DateTime));

                                for (int j = 0; j < DtSet.Tables.Count; j++) //合并Dataset中所有的表
                                {
                                    
                                        newdts = combinDt(DtSet.Tables[j], newdts);
                                     
                                }

                                this.dataGridView4.DataSource = newdts;

                                Form1.Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI
                                this.dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                                dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridView4.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                                //DTExcel.Columns["column9"].SetOrdinal(4);
                                //DTExcel.Columns["column5"].SetOrdinal(8);

                                //DGV_fromExcel.DataSource = null;
                                //DGV_fromExcel.DataSource = DTExcel;


                                //Class_Dv_Filter.DataviewFilter_MachineID = DTExcel.DefaultView;
                                this.textBox_ExcelPath.Text = ExcelSaveFile;
                                int WriteRows = ExcelHelper.DataTableToExcel(newdts, ExcelSaveFile);
                                MessageBox.Show("写入 EXCEL文件共："+ WriteRows.ToString()+" 行");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Excel文件路径必须存在!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("非 Excel 文件");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

             
        }

        public DataTable combinDt(DataTable DT1, DataTable DT2)
        {
            DataTable NewDT = DT1.Clone();

            object[] obj = new object[NewDT.Columns.Count];

            for(int i = 0; i < DT1.Rows.Count; i++)
            {
                DT1.Rows[i].ItemArray.CopyTo(obj, 0);
                NewDT.Rows.Add(obj);
            }
            for (int i = 0; i < DT2.Rows.Count; i++)
            {
                DT2.Rows[i].ItemArray.CopyTo(obj, 0);
                NewDT.Rows.Add(obj);
            }

            return NewDT;

        }

        private void btn_Uni_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SSQL.DBConnStr))
                {
                    MessageBox.Show("数据库未连接 ！");
                    return;
                }

                string StrDate = DTPicker_UniStartT.Value.ToString("yyyy-MM-dd");
                string EndDate = DTPicker_UniEndT.Value.ToString("yyyy-MM-dd");
                
                if (DTPicker_UniStartT.Value >= DTPicker_UniEndT.Value)
                {
                    MessageBox.Show("开始时间不能大于结束时间 ！");
                    return;
                }

                StrDate = StrDate + " 00:00:00";
                EndDate = EndDate + " 23:59:59";

                if (this.textBox_shortName.Text == "" || string.IsNullOrEmpty(this.textBox_shortName.Text))
                {
                    MessageBox.Show("工站的短名为空！从查询结果界面复制到TextBox");
                    return;
                }

                DataTable dt_SNRs = new DataTable();

                dt_SNRs=SSQL.Qty_WO_NG_SNRs(StrDate, EndDate, this.textBox_shortName.Text);

                if (dt_SNRs == null || dt_SNRs.Rows.Count < 0)
                {
                    MessageBox.Show("查无数据 ！");
                    return;
                }
                else
                {
                    this.dataGridView4.DataSource = null;
                    this.dataGridView4.DataSource = dt_SNRs;

                    Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI

                    dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView4.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.label31.Text = ":";
                    this.label31.Text = dt_SNRs.Rows.Count.ToString()+"  行";

                    CUModel.CUModel_DateTable = dt_SNRs.Copy();

                }

               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox_NG_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_NG.CheckState == CheckState.Checked)
                {

                    if (string.IsNullOrEmpty(SSQL.DBConnStr))
                    {
                        MessageBox.Show("数据库未连接 ！");
                        return;
                    }

                    DataTable dt_NG = new DataTable();

                    if (this.textBox_shortName.Text == "" || string.IsNullOrEmpty(this.textBox_shortName.Text))
                    {
                        MessageBox.Show("需要先输入 要查询NG序列号工站的短名，可模糊查询");
                        return;
                    }

                    dt_NG = SSQL.Qty_NG_ShortName(textBox_shortName.Text.ToUpper());

                    if (dt_NG != null || dt_NG.Rows.Count > 0)
                    {
                        this.dataGridView4.DataSource = null;
                        this.dataGridView4.DataSource = dt_NG;

                        Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI

                        dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        textBox_shortName.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox_toExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_toExcel.CheckState == CheckState.Checked)
            {
                openFileDialog1.Title = "选择要保存的路径，可以选择一个文件，只是获取其路径";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string GetFullPath_Filename = openFileDialog1.FileName;

                    string Fn = string.Empty;
                    Fn = Path.GetExtension(openFileDialog1.FileName);

                    string ExlPath = Path.GetDirectoryName(GetFullPath_Filename);

                    string ExcelSaveFile = string.Empty;

                    if (!string.IsNullOrEmpty(this.textBox_ExcelPath.Text) || this.textBox_ExcelPath.Text != "")
                    {
                        ExcelSaveFile = Path.Combine(ExlPath, this.textBox_ExcelPath.Text + ".xlsx");
                    }
                    else
                    {
                        MessageBox.Show("输入要保存的Excel文件名!");
                        return;
                    }

                    if (CUModel.CUModel_DateTable == null || CUModel.CUModel_DateTable.Copy().Rows.Count < 0)
                    {
                        MessageBox.Show("到导入的原始DATa Table表为空！ 在“查找SNR”按钮中是否未获取到数据？");
                        return;
                    }

                    DataTable Dt_DtUnikat2Excel = CUModel.CUModel_DateTable.Copy();

                    #region //To Excel文件操作部分
                    if (!string.IsNullOrEmpty(GetFullPath_Filename))
                    {
                                               
                        DataTable dt = new DataTable();
                        dt.Columns.Add("LotID", typeof(string));
                        dt.Columns.Add("FinalMat", typeof(string));
                        dt.Columns.Add("FertMatName", typeof(string));
                        dt.Columns.Add("LotName", typeof(string));
                        dt.Columns.Add("targetlotpk", typeof(Int32));
                        dt.Columns.Add("changetime", typeof(DateTime));

                        //DataTable dt = ToDataTable1(DTExcel);
                        if (Dt_DtUnikat2Excel != null && Dt_DtUnikat2Excel.Rows.Count > 0)
                        {
                            DataSet DtSet = new DataSet();

                            for (int i = 0; i < Dt_DtUnikat2Excel.Rows.Count; i++)
                            {
                                dt = SSQL.Qty_Unique_Digui(Dt_DtUnikat2Excel.Rows[i][0].ToString());

                                if (dt == null || dt.Rows.Count == 0) //如没有查到数据，插入SNR，写“No result”
                                {
                                    dt = new DataTable(); //没有数据时，被方法初始化，只能再次new 新的对象 并在下面添加列。
                                    dt.Columns.Add("LotID", typeof(string));
                                    dt.Columns.Add("FinalMat", typeof(string));
                                    dt.Columns.Add("FertMatName", typeof(string));
                                    dt.Columns.Add("LotName", typeof(string));
                                    dt.Columns.Add("targetlotpk", typeof(Int32));
                                    dt.Columns.Add("changetime", typeof(DateTime));

                                    DataRow newRow = dt.NewRow();
                                    newRow["LotID"] = "查询的唯一码:" + Dt_DtUnikat2Excel.Rows[i][0].ToString();
                                    newRow["FinalMat"] = "未装配";
                                    newRow["FertMatName"] = "";
                                    newRow["LotName"] = "";
                                    newRow["targetlotpk"] = 0;
                                    newRow["changetime"] = DateTime.Now;
                                    dt.Rows.Add(newRow);

                                    DtSet.Tables.Add(dt); //查到数据加载到Dataset 中
                                }
                                else
                                {
                                    DataRow newRow = dt.NewRow();
                                    newRow["LotID"] = "查询的唯一码:" + Dt_DtUnikat2Excel.Rows[i][0].ToString();
                                    newRow["FinalMat"] = "装配参考LotName列:";
                                    newRow["FertMatName"] = "";
                                    newRow["LotName"] = "";
                                    newRow["targetlotpk"] = dt.Rows.Count;
                                    newRow["changetime"] = DateTime.Now;
                                    dt.Rows.Add(newRow);

                                    DtSet.Tables.Add(dt); //查到数据加载到Dataset 中
                                }


                            }
                            DataTable newdts = new DataTable();
                            newdts.Columns.Add("LotID", typeof(string));
                            newdts.Columns.Add("FinalMat", typeof(string));
                            newdts.Columns.Add("FertMatName", typeof(string));
                            newdts.Columns.Add("LotName", typeof(string));
                            newdts.Columns.Add("targetlotpk", typeof(Int32));
                            newdts.Columns.Add("changetime", typeof(DateTime));

                            for (int j = 0; j < DtSet.Tables.Count; j++) //合并Dataset中所有的表
                            {

                                newdts = combinDt(DtSet.Tables[j], newdts);

                            }

                            this.dataGridView4.DataSource = newdts;

                            Form1.Class_User.DataGridView_UI_Setup(this.dataGridView4);//设置datagridview显示UI
                            this.dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                            dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView4.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridView4.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                            //DTExcel.Columns["column9"].SetOrdinal(4);
                            //DTExcel.Columns["column5"].SetOrdinal(8);

                            //DGV_fromExcel.DataSource = null;
                            //DGV_fromExcel.DataSource = DTExcel;


                            //Class_Dv_Filter.DataviewFilter_MachineID = DTExcel.DefaultView;
                            this.textBox_ExcelPath.Text = ExcelSaveFile;
                            int WriteRows = ExcelHelper.DataTableToExcel(newdts, ExcelSaveFile);
                            MessageBox.Show("写入 EXCEL文件共：" + WriteRows.ToString() + " 行");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Excel文件路径必须存在!");
                    }

                    #endregion

                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            this.label31.Text = ":";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new FormMatTrace().Show();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Checked)
            {
                if (this.dataGridView2.Rows.Count != 0)
                {
                    
                    Dv_SNRs_Filter.RowFilter = string.Format("SNR_Status<>'{0}' and SNR_Status<>'{1}'", "prcs","cmplt");
                    this.dataGridView2.DataSource = Dv_SNRs_Filter;
                  
                }
            }
            
        }
    }
}
