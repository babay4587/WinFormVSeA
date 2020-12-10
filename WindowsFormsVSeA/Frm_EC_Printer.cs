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
    public partial class Frm_EC_Printer : Form
    {

        public static Class_User Class_User = new Class_User();

        public DataView DVTrace = new DataView();

        public Frm_EC_Printer()
        {
            InitializeComponent();
        }

        private void Btn_ECPrinter_Qty_Click(object sender, EventArgs e)
        {
            Class_User.DataGridView_UI_Setup(this.DateGridV_EC_Printer);//设置datagridview显示UI

           
            try
            {
                DataTable dt = new DataTable();
                dt = Form1.SSQL.Qty_EC_Printer();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DateGridV_EC_Printer.DataSource = dt;

                    Tb_Printer_Name.Text=dt.Rows[0][1].ToString(); //printer name
                    Tb_Printer_Type.Text= dt.Rows[0][4].ToString(); //printer type

                    DVTrace = dt.DefaultView;//给 dataview 初始化值
                                        
                    DataRow dr = dt.NewRow();
                    dr[1] = "Summary Total:";
                    dr[2] = dt.Rows.Count;
                    dt.Rows.Add(dr);

                }
                else
                {
                    MessageBox.Show("查无数据 ！");
                }

                dt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_Add_EC_Printer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("确定要执行添加打印机操作吗？", "添加打印机", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string StrSql = string.Empty;

                    StringBuilder stringBuilder = new StringBuilder();

                    DataTable dt1 = new DataTable();
                    dt1 = Form1.SSQL.EC_PRINTER_LAYOUTS();//从此表查需要更新的数据

                    if (dt1 != null && dt1.Rows.Count > 0)// combinate sql statement
                    {
                        stringBuilder.Append(" insert into  [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_PRINTER_$94$]" +
                            "  (PRINTER, GROUP_ID, PRINTER_TYPE, MACHINE_ID, EQUIPMENT_ID, RowUpdated, LAYOUT_ID)");

                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {

                            stringBuilder.AppendLine(string.Format(@" select '{0}','{1}','{2}','','',getdate(),'{3}'"
                            , this.Tb_Printer_Name.Text, this.TB_FrmPrinter_Grp.Text.Trim().ToUpper(), this.Tb_Printer_Type.Text, dt1.Rows[i][0]).ToString());

                            stringBuilder.AppendLine(" Union all ");

                        }

                        if (Form1.SSQL.RunProc(stringBuilder.ToString().Remove(stringBuilder.ToString().LastIndexOf("Union all "))))
                        {
                            MessageBox.Show("执行成功 ！");
                        }
                        
                    }
                }//diaglog=ok
                else
                {
                    return;
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Frm_EC_Printer_Load(object sender, EventArgs e)
        {
            Btn_Add_EC_Printer.Enabled = false;
            Btn_PrinterDelete.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(TB_FrmPrinter_Grp.Text))
                {
                    if (DateGridV_EC_Printer.Rows.Count > 0)
                    {
                        DVTrace.RowFilter = string.Format("GROUP_ID like '%{0}%'", this.TB_FrmPrinter_Grp.Text.Trim().ToUpper());
                        DateGridV_EC_Printer.DataSource = DVTrace;

                        if (DVTrace.Count ==0) //查不到线体打印机，才可以添加打印机。
                        {
                            Btn_Add_EC_Printer.Enabled = true;
                        }
                        else
                        {
                            Btn_Add_EC_Printer.Enabled = false;
                        }

                        if (DVTrace.Count > 0) //查到线体打印机，才可以删除打印机。
                        {
                            Btn_PrinterDelete.Enabled = true;
                        }
                        else
                        {
                            Btn_PrinterDelete.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("dataView 视图为空");
                    }
                    
                }
                else
                {
                    MessageBox.Show("必须输入要查找的线体号 Group ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Btn_PrinterDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //for(int i= this.DateGridV_EC_Printer.SelectedRows.Count; i > 0; i--)
                //{
                //    this.DateGridV_EC_Printer.Rows.RemoveAt(DateGridV_EC_Printer.SelectedRows[i - 1].Index);
                //}

                StringBuilder Sbuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(TB_FrmPrinter_Grp.Text))
                {
                    DialogResult dr = MessageBox.Show("确定要执行 删除 指定打印机操作吗？", "删除打印机", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {

                        Sbuilder.AppendLine(string.Format(@" delete
 FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_PRINTER_$94$]  
where GROUP_ID like '%{0}%'", this.TB_FrmPrinter_Grp.Text.Trim().ToUpper()));

                        if (Form1.SSQL.RunProc(Sbuilder.ToString()))
                        {
                            MessageBox.Show("执行成功 ！");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("删除的打印机线体号不能为空");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
