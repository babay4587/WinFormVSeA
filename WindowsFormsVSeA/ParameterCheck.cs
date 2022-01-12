using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsVSeA
{
    public partial class ParameterCheck : Form
    {
        public ExcelHelper ExcelHelper = new ExcelHelper();

        public DataTable DTExcel = new DataTable();

        public DataTable dtMES = new DataTable();

        public DataView DataViewFilter=new DataView();

        DataTable DtExcept = new DataTable(); //infra与MES DB差集 数据的表，用于展示和 批量更新 Object ID 至 MES系统

        Class_dv_filter Class_Dv_Filter = new Class_dv_filter();

        public class Class_dv_filter
        {
            private DataView dataview_MachineID;
            private DataView dataview_ShortName;
            private DataTable Dt_Shopfloor;

            public DataView DataviewFilter_MachineID
            {
                get { return dataview_MachineID; }
                set { dataview_MachineID = value; }
            }

            public DataView DataviewFilter_ShortName
            {
                get { return dataview_ShortName; }
                set { dataview_ShortName = value; }
            }

            public DataTable DataTable_Shopfloor
            {
                get { return Dt_Shopfloor; }
                set { Dt_Shopfloor = value; }
            }
        }


        public ParameterCheck()
        {
            InitializeComponent();
        }

        private void ParameterCheck_Load(object sender, EventArgs e)
        {
            try
            {
                this.Size = new Size(1180, 800);
                this.Text = "参数校验";
                //this.label1.BackColor = Color.AliceBlue;
                
                //this.TB_Orderid.Text = Form1.CUModel.OrderID;
                //this.TB_Orderid.Enabled = false;

                //Tb_Filter1.BackColor = Color.YellowGreen;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BT_importExcel_Click(object sender, EventArgs e)
        {

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TB_filepath.Text = openFileDialog1.FileName;

                    string Fn = string.Empty;
                    Fn = Path.GetExtension(openFileDialog1.FileName);

                    if (Fn.ToUpper() == ".XLSX")
                    {

                        if (!string.IsNullOrEmpty(this.TB_filepath.Text))
                        {

                            DTExcel = ExcelHelper.ExcelToDataTableNew(TB_filepath.Text, 1, false);
                            DTExcel.Rows.RemoveAt(0); //去掉表头行

                            //DataTable dt = ToDataTable1(DTExcel);
                            if (DTExcel != null && DTExcel.Rows.Count > 0)
                            {
                                Form1.Class_User.DataGridView_UI_Setup(this.DGV_fromExcel);//设置datagridview显示UI
                                DGV_fromExcel.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                                DTExcel.Columns["column9"].SetOrdinal(4);
                                DTExcel.Columns["column5"].SetOrdinal(8);

                                DGV_fromExcel.DataSource = null;
                                DGV_fromExcel.DataSource = DTExcel;


                                Class_Dv_Filter.DataviewFilter_MachineID = DTExcel.DefaultView;
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

        private DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        public static DataTable ToDataTable1<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new System.Collections.ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        private void BT_Crosschk_Click(object sender, EventArgs e)
        {
            try
            {
                checkBox_MachineID.Enabled = false;
                checkBox_Shortname.Enabled = false;

                if (DTExcel == null || DTExcel.Rows.Count == 0)
                {
                    MessageBox.Show("Infra List 配置表必须导入，否在不能交叉检查！");
                    return;
                }

                FileHelper fileHelper = new FileHelper();

                DataTable dt2 = new DataTable();
                dt2 = Form1.CUModel.CUModel_DateTable.Copy();

                if (Form1.CUModel.CUModel_DateTable != null && Form1.CUModel.CUModel_DateTable.Rows.Count > 0)
                {
                    #region //SSAP TSAP EQUIPMENTID 联合校验

                    DataTable InfraConnectXml = fileHelper.Dt_ToNewDtByCol(DTExcel, "column7", "column8", "column9");
                    InfraConnectXml.Rows.RemoveAt(0); //首行是RUESTUN SSAP TSAP是空的，所以去除首行；

                    DataTable ShopfloorConnections = fileHelper.Dt_ToNewDtByCol(dt2, "TSAP", "SSAP", "EQUIPMENT_ID");

                    IEnumerable<DataRow> Exceptrow = InfraConnectXml.AsEnumerable().Except(ShopfloorConnections.AsEnumerable(), DataRowComparer.Default);
                    //查询目的：infra表里的记录，还没配置在shopfloor connections里

                    DataTable DtConnectExcep = new DataTable();

                    if (Exceptrow.Any() && Exceptrow != null) //必须加此判断 ：否在出现 没有datarow 的错误！
                    {
                        DtConnectExcep = Exceptrow.CopyToDataTable();
                    }

                    #endregion

                    if (DtConnectExcep != null || DtConnectExcep.Rows.Count > 0)
                    {
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.DataSource = DtConnectExcep;

                    }


                    #region //单列查重 res输出重复记录结果集
                    //var res = from item in dt2.AsEnumerable()
                    //          group item by item.Field<string>("EQUIPMENT_ID").ToString() into g
                    //          where g.Count() > 1
                    //          select g;

                    //foreach(var it in res)
                    //{

                    //}

                    #endregion

                    #region//多列查重

                    //var res = from item in dt2.AsEnumerable()
                    //          group item by new
                    //          {
                    //              ssap = item.Field<string>("SSAP"),
                    //              tsap = item.Field<string>("TSAP"),
                    //              equipid = item.Field<string>("EQUIPMENT_ID")
                    //          } into g
                    //          select new
                    //          {
                    //              ssap1 = g.Key.ssap,
                    //              equipid1 = g.Key.equipid,
                    //              tsap1 = g.Key.tsap,
                    //              rws = g.Count()   //多列数据查重 只有以上三个数据都相同时，rws才大于 1，否则都认为不重复！
                    //          };
                    //        foreach(var itt in res)
                    //        {
                    //            if (itt.rws > 1)
                    //            {
                    //                MessageBox.Show(itt.ToString());
                    //            }
                    //        }

                    #endregion


                }
                else
                {
                    MessageBox.Show("需要提前在“主界面：Shopfloor Connections 中导入 Shopfloor Connections.xml配置文件”");
                    return;

                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Bt_Mes_Para_Click(object sender, EventArgs e)
        {
            try
            {
                
                dtMES = Form1.SSQL.Qty_MES_ParaConfig();

                if (dtMES != null && dtMES.Rows.Count > 0)
                {
                    dataGV_MESPara.DataSource = null;
                    dataGV_MESPara.DataSource = dtMES;

                    Form1.Class_User.DataGridView_UI_Setup(this.dataGV_MESPara);//设置datagridview显示UI
                    dataGV_MESPara.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                    dataGV_MESPara.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    DataViewFilter = dtMES.DefaultView;
                }
                else
                {
                    MessageBox.Show("查无数据");
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// MES_Table_Col是MES数据库要查的列名，Excel_Col是Excel Infra要查的列名;Col_Name自定义列名 需唯一！！
        /// </summary>
        /// <returns>得到：Excel Infra中存在，MES数据库不存在的值</returns>
        public DataTable ChktwoDt(string MES_Table_Col,string Excel_Col,string Col_Name)
        {
            try
            {
                DataTable dt = new DataTable();

                var result = from infraShortName in DTExcel.AsEnumerable()
                             where
                            !(from DBShortName in dtMES.AsEnumerable()
                              select DBShortName.Field<string>(MES_Table_Col)).Contains(infraShortName.Field<string>(Excel_Col))
                             select infraShortName;

                dt.Columns.Add(Col_Name, typeof(string));
                foreach (var R in result)
                {

                    if (!R.IsNull(Excel_Col) && R[Excel_Col].ToString() != "") //成功过滤空值
                    {
                        DataRow newrow = dt.NewRow();
                        newrow[0] = R[Excel_Col].ToString();
                        dt.Rows.Add(newrow);
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }



        public DataTable ChktwoDtMultiCol(string MES_Table_Col1,string MES_Table_Col2, string Excel_Col1, string Excel_Col2)
        {
            try
            {
                DataTable dt = new DataTable();

                //var result = from infraMachineID,infraShortName in DTExcel.AsEnumerable()
                //             where
                //            !(from DBMachineID,DBShortName in dtMES.AsEnumerable()
                //              select DBMachineID.Field<string>(MES_Table_Col1), DBShortName.Field<string>(MES_Table_Col2)).Contains(infraMachineID.Field<string>(Excel_Col1),infraShortName.Field<string>(Excel_Col2))
                //             select infraMachineID, infraShortName;

                //dt.Columns.Add("Chk_Result", typeof(string));
                //foreach (var R in result)
                //{

                //    if (!R.IsNull(Excel_Col) && R[Excel_Col].ToString() != "") //成功过滤空值
                //    {
                //        DataRow newrow = dt.NewRow();
                //        newrow[0] = R[Excel_Col].ToString();
                //        dt.Rows.Add(newrow);
                //    }

                //}
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }



        private void Bt_StartCHK_Click(object sender, EventArgs e)
        {
            FileHelper fileHelper = new FileHelper();

            try
            {
                DataTable ddt_Machine = new DataTable();
                DataTable ddt_ShortName = new DataTable();
                DataTable ddt_ObjectID = new DataTable();

                if(dtMES.Rows.Count == 0 || dtMES == null)
                {
                    MessageBox.Show("MES 数据库读取必须完成，否在不能交叉检查！");
                    return;
                }

                dataGV_ResultDisplay.DataSource = null; //如果不勾选 不显示任何数据

                if (DTExcel == null || DTExcel.Rows.Count ==0)
                {
                    MessageBox.Show("Infra List 配置表必须导入，否在不能交叉检查！");
                    return;
                }

                #region//单列重复数据查询部分
                if (checkBox_ColCHK.CheckState == CheckState.Checked)
                {
                    
                    ddt_Machine = ChktwoDt("MACHINE_ID", "column2", "MachineID");
                    if (ddt_Machine.Rows.Count == 0 || ddt_Machine == null)
                    {
                        MessageBox.Show("Infra表中WorkOperation ID 与MES数据库记录全部匹配");
                    }

                    ddt_ObjectID = ChktwoDt("Object_ID", "column3", "ObjectID");
                    if (ddt_ObjectID.Rows.Count == 0 || ddt_ObjectID == null)
                    {
                        MessageBox.Show("Infra表中Object ID 与MES数据库记录全部匹配");
                    }

                    ddt_ShortName = ChktwoDt("PROCESS_STEP", "column4", "Shortname");
                    if (ddt_ShortName.Rows.Count == 0 || ddt_ShortName == null)
                    {
                        MessageBox.Show("Infra表中Short Name 与MES数据库记录全部匹配");
                    }

                    DataTable NewDt = fileHelper.DatatableToCombinN1(ddt_Machine, ddt_ShortName);//NewDt用来显示多个存在问题的列信息，合并在一个datagridview显示

                    if (ddt_ObjectID.Rows.Count > 0 || ddt_ObjectID != null)
                    {
                        NewDt = fileHelper.DatatableToCombinN1(NewDt, ddt_ObjectID);
                    }

                    if (NewDt.Rows.Count > 0 || NewDt != null)
                    {

                        dataGV_ResultDisplay.DataSource = null;
                        dataGV_ResultDisplay.DataSource = NewDt;

                        Form1.Class_User.DataGridView_UI_Setup(this.dataGV_ResultDisplay);//设置datagridview显示UI
                        dataGV_ResultDisplay.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        dataGV_ResultDisplay.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("查无数据 !");
                    }


                }
                #endregion

                #region //2个datatable 差集查询部分!
                if (checkBox_Chaji.CheckState == CheckState.Checked)
                {
                    
                    DataTable InfraDt2Col = fileHelper.Dt_ToNewDtByCol(DTExcel, "column2", "column3", "column4");//得到只有3列结构的表 
                                                                                                //SAP-Workcenter : column2; Object-ID:column3; Shortname:column4
                                                                                              //MACHINE_ID: EC304000 ; Object_ID:1000XXXX ; PROCESS_STEP:S_OP1000


                    InfraDt2Col = fileHelper.RemoveEmptyRow(InfraDt2Col); //去除空行
                   // InfraDt2Col.Rows.RemoveAt(0); //去掉第一行;取消此操作，不能把REUSET行去掉了

                    DataTable MESDbDt2Col = fileHelper.Dt_ToNewDtByCol(dtMES, "MACHINE_ID", "Object_ID", "PROCESS_STEP");


                    IEnumerable<DataRow> Exceptrow = InfraDt2Col.AsEnumerable().Except(MESDbDt2Col.AsEnumerable(), DataRowComparer.Default);

                    
                    if (Exceptrow.Any()&& Exceptrow!=null) //必须加此判断 ：否在出现 没有datarow 的错误！
                    {
                        DtExcept = Exceptrow.CopyToDataTable();
                    }
                    else
                    {
                        MessageBox.Show("根据“Infra表”未查到与“MES系统”配置表的[差集]数据 !");
                        return;
                    }

                    #region //解决 ：datarow 的错误
                    //DataRow[] drs = DtExcept.Select();
                    //DataTable newDt = DtExcept.Clone();
                    //drs.ToList<DataRow>().ForEach((r) => newDt.ImportRow(r));
                    #endregion

                    if (DtExcept!=null || DtExcept.Rows.Count > 0)
                    {
                        dataGV_ResultDisplay.DataSource = null;
                        dataGV_ResultDisplay.DataSource = DtExcept;
                        dataGV_ResultDisplay.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                        //dataGV_ResultDisplay.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("查无数据 !");
                    }
                }

                #endregion

                #region //临时 已注释 

                //var result = from infraShortName in DTExcel.AsEnumerable()
                //             where
                //            !(from DBShortName in dtMES.AsEnumerable()
                //              select DBShortName.Field<string>("PROCESS_STEP")).Contains(infraShortName.Field<string>("column3"))
                //             select infraShortName;
                //List<string> lst = new List<string>();

                //DataTable dtres = new DataTable();
                //dtres.Columns.Add("Col1", typeof(string));
                //foreach (var R in result)
                //{

                //    if (!R.IsNull("column3") && R["column3"].ToString() != "") //成功过滤空值dataGV_ResultDisplay
                //    {
                //        DataRow newrow = dtres.NewRow();
                //        newrow[0] = R["column3"].ToString();
                //        dtres.Rows.Add(newrow);
                //    }

                //}
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                if (this.TB_WorkOP.Text == "")
                {
                    MessageBox.Show("请输入要查询的关键字 可模糊查询");
                    return;
                }
                int i = 0;

                if (dataGV_MESPara != null || dataGV_MESPara.Rows.Count > 0)
                {
                    //foreach(DataGridViewRow dr in dataGV_MESPara.Rows)
                    //{
                    //    if (dr.Cells["MACHINE_ID"].Value.ToString().Contains(this.TB_WorkOP.Text))
                    //    {
                    //        dataGV_MESPara.FirstDisplayedScrollingRowIndex = i;
                    //        dataGV_MESPara.CurrentCell = dr.Cells[0];
                    //        dr.Selected = true;
                    //        return;
                    //    }
                    //    i++;
                    //}

                    DataViewFilter.RowFilter = string.Format("MACHINE_ID like '%{0}%'", (this.TB_WorkOP.Text));

                    dataGV_MESPara.DataSource = DataViewFilter;
                }
            }
            else
            {
                dataGV_MESPara.DataSource = null;
                dataGV_MESPara.DataSource = dtMES;
            }
            
        }

        private void Bt_UpdateObjID_Click(object sender, EventArgs e)
        {
            try
            {
                if(DtExcept!=null || DtExcept.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("确定要更新Object ID 数据吗？", "Title: 更新Object ID", MessageBoxButtons.OKCancel);

                    if(dr== DialogResult.OK)
                    {
                        StringBuilder sqlBuilder = new StringBuilder();
                        int updatecount = 0;

                        for (int i=0;i< DtExcept.Rows.Count; i++)
                        {
                            sqlBuilder.AppendLine(string.Format(@" update  [SitMesDB].[dbo].[Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS] 
                             set WORKCENTER_ID='{0}' 
                             where MACHINE_ID='{1}' and WORKCENTER_NAME='{2}'
                            ", DtExcept.Rows[i][1].ToString(), DtExcept.Rows[i][0].ToString(), DtExcept.Rows[i][0].ToString()));

                            if (Form1.SSQL.RunProc(sqlBuilder.ToString()))
                            {
                                updatecount += 1;
                            }
                            else
                            {
                                MessageBox.Show("执行第："+ DtExcept.Rows[i][1].ToString() + "数据库更新时出现问题 ！");
                                return;
                            }

                        }

                        MessageBox.Show("执行完成：共" + updatecount.ToString() + " 条数据！");

                    }
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("不能更新任何Object ID 数据！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void checkBox_MachineID_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_MachineID.CheckState == CheckState.Checked)
                {
                    if (dataGridView1 != null || dataGridView1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(textBox_machineid.Text) || textBox_machineid.Text != "")
                        {
                            Class_Dv_Filter.DataviewFilter_MachineID.RowFilter = string.Format(@"WORKCENTER_ID like '%{0}%'", this.textBox_machineid.Text);

                            this.dataGridView1.DataSource = Class_Dv_Filter.DataviewFilter_MachineID;
                        }
                        else
                        {
                            MessageBox.Show("工站名过滤信息框不能为空！");
                            return;
                        }


                    }
                    else
                    {
                        MessageBox.Show("无数据可以过滤！");
                        return;
                    }
                }

                if(checkBox_MachineID.CheckState == CheckState.Unchecked)
                {
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = Class_Dv_Filter.DataTable_Shopfloor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button_importShopfloor_Click(object sender, EventArgs e)
        {
            checkBox_MachineID.Enabled = true;
            checkBox_Shortname.Enabled = true;

            
            FileHelper fileHelper = new FileHelper();
            

            if (Form1.CUModel.CUModel_DateTable != null && Form1.CUModel.CUModel_DateTable.Rows.Count > 0)
            {

                Class_Dv_Filter.DataTable_Shopfloor = Form1.CUModel.CUModel_DateTable.Copy();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Form1.CUModel.CUModel_DateTable;

                Class_Dv_Filter.DataviewFilter_MachineID = Form1.CUModel.CUModel_DateTable.DefaultView; //给过滤器赋值

                Form1.Class_User.DataGridView_UI_Setup(this.dataGridView1);//设置datagridview显示UI
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;

                #region //单列查重 res输出重复记录结果集
                //var res = from item in dt2.AsEnumerable()
                //          group item by item.Field<string>("EQUIPMENT_ID").ToString() into g
                //          where g.Count() > 1
                //          select g;

                //foreach(var it in res)
                //{

                //}

                #endregion

                #region//多列查重

                //var res = from item in dt2.AsEnumerable()
                //          group item by new
                //          {
                //              ssap = item.Field<string>("SSAP"),
                //              tsap = item.Field<string>("TSAP"),
                //              equipid = item.Field<string>("EQUIPMENT_ID")
                //          } into g
                //          select new
                //          {
                //              ssap1 = g.Key.ssap,
                //              equipid1 = g.Key.equipid,
                //              tsap1 = g.Key.tsap,
                //              rws = g.Count()   //多列数据查重 只有以上三个数据都相同时，rws才大于 1，否则都认为不重复！
                //          };
                //        foreach(var itt in res)
                //        {
                //            if (itt.rws > 1)
                //            {
                //                MessageBox.Show(itt.ToString());
                //            }
                //        }

                #endregion


            }
            else
            {
                MessageBox.Show("需要提前在“主界面：Shopfloor Connections 中导入 Shopfloor Connections.xml配置文件”");
                return;

            }

        }
    }
}
