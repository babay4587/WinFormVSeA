﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsVSeA
{
    public partial class FrmHUT : Form
    {

        public static Class_User Class_User = new Class_User();
        public FrmHUT()
        {
            InitializeComponent();
        }

        private void FrmHUT_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1180, 570);

            Btn_HUT_Del.Enabled = false;

            //if (Form1.Updated_P_DB)
            //{
            //    Btn_HUT_Del.Enabled = true;//无数据库更新权限 不能点击。
            //}

        }

        private void Btn_Hut_Qty_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.Tb_Hut_SNR.Text)&& string.IsNullOrEmpty(this.Tb_Hut_Num.Text))
                {
                    MessageBox.Show("至少输入一个查询条件 可用 % 模糊查询");
                    return;
                }

                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_HUT_SNR(this.Tb_Hut_Num.Text, this.Tb_Hut_SNR.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    DataGridV_Hut.DataSource = dt;
                    //DataGridV_Hut.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
                    
                    DataGridV_Hut.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Class_User.DataGridView_UI_Setup(this.DataGridV_Hut);//设置datagridview显示UI

                    Btn_HUT_Del.Enabled = true;
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

        private void Btn_HUT_Del_Click(object sender, EventArgs e)
        {
            
            try
            {
                int a = this.DataGridV_Hut.CurrentRow.Index;
                string PK_Del = this.DataGridV_Hut.Rows[a].Cells["PK"].Value.ToString();//获取 选择的 PK值


                if (!string.IsNullOrEmpty(PK_Del))
                {
                    if (Form1.Updated_P_DB)
                    {
                        StringBuilder Sbuilder = new StringBuilder();
                        DialogResult dr = MessageBox.Show("确定要执行 删除 指定的载具关联关系操作吗？", "删除载具", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            Sbuilder.AppendLine(string.Format(@"delete 
  FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_HUT_ALLOCATION_$80$] 
  where [$IDArchiveValue]={0}", PK_Del));

                            if (Form1.SSQL.RunProc(Sbuilder.ToString()))
                            {
                                MessageBox.Show("执行成功 ！");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("无数据库操作权限！");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("未得到要删除行的：PK 值");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void Btn_Hut_monitor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_Hut_Num.Text))
            {
                MessageBox.Show("需要输入要监控载具号的模糊特征值");
                return;
            }
            if (!string.IsNullOrEmpty(tB_timerInterval.Text))
            {
                if (int.Parse(tB_timerInterval.Text) >= 3)
                {
                    timer1.Start();
                   
                }
            }
            else
            {
                MessageBox.Show("读取数据的时间间隔未设置 不能小于3秒");
                return;
            }
        }

    

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(tB_timerInterval.Text) * 1000;

            Form1.SSQL.Insertinto_HUT_SNR(Tb_Hut_Num.Text);
        }

        private void btn_StopMonitor_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Btn_Hut_His_Click(object sender, EventArgs e)
        {
            try
            {
                string DTimePickerDay=DTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                DataTable dt1 = new DataTable();

                if (string.IsNullOrEmpty(this.Tb_Hut_Num.Text))
                {
                    MessageBox.Show("载具号至少输入% 通配符");
                    return;
                }

                dt1 = Form1.SSQL.Qty_HUT_History(this.Tb_Hut_Num.Text, this.Tb_Hut_SNR.Text, DTimePickerDay);
                if (dt1 != null && dt1.Rows.Count > 0)
                {

                    DataGridV_Hut.DataSource = dt1;
                    DataGridV_Hut.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    DataGridV_Hut.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss:fff";
                    DataGridV_Hut.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    DataGridV_Hut.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss:fff";
                    Class_User.DataGridView_UI_Setup(this.DataGridV_Hut);//设置datagridview显示UI

                    TB_Hut_count.Text = dt1.Rows.Count.ToString();
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
    }
}
