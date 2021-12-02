using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Drawing;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;



namespace WindowsFormsVSeA
{
    
    public class Class_User
    {
        
        public class UserModel
        {
            private string equipmentID;

            private string TranSNR;
            private string Matdescription;
            private string UniqueCode;
            private string Order_ID;
            private List<string> LstStr;
            private List<string> all_files;

            public string EquipmentID
            {
                set { equipmentID = value; }
                get { return equipmentID; }
            }

            public string TranSerialNumber
            {
                set { TranSNR = value; }
                get { return TranSNR; }
            }
            public string MaterialDesc
            {
                set { Matdescription =value; }
                get { return Matdescription; }
            }
            public string UniqueMatCode
            {
                set { UniqueCode = value; }
                get { return UniqueCode; }
            }

            public string OrderID
            {
                set { Order_ID = value; }
                get { return Order_ID; }
            }

            public List<string> List_Str
            {
                set { LstStr = value; }
                get { return LstStr; }
            }

            public List<string> AllFiles
            {
                set { all_files = value; }
                get { return all_files; }
            }
        }

        public void DataGridView_UI_Setup(DataGridView GV)
        {
            GV.ColumnHeadersDefaultCellStyle.Font = new Font("雅黑", 10, FontStyle.Bold);
            GV.DefaultCellStyle.Font = new Font("雅黑", 9, FontStyle.Regular);
            GV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Purple;
        }

    }

    public  class ExcelHelper
    {
        #region //NOIP Excel 处理

        public static List<T> IExcelToEntityList<T>(Dictionary<string, string> cellHeader, string filePath, out StringBuilder errorMsg, int startIndex = 1) where T : new()
        {
            errorMsg = new StringBuilder(); // 错误信息,Excel转换到实体对象时，会有格式的错误信息
            List<T> enlist = new List<T>(); // 转换后的集合
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fs);
                    XSSFSheet sheet = (XSSFSheet)workbook.GetSheetAt(0); // 获取此文件第一个Sheet页
                    for (int rowIndex = startIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                    {
                        // 1.判断当前行是否空行，若空行就不在进行读取下一行操作，结束Excel读取操作
                        IRow row = sheet.GetRow(rowIndex);
                        if (row == null)
                        {
                            break;
                        }
                        // 2.每一个Excel row转换为一个实体对象
                        T en = new T();
                        ExcelRowToEntity<T>(cellHeader, row, rowIndex, en, ref errorMsg);
                        enlist.Add(en);
                    }
                }
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public static void ExcelRowToEntity<T>(Dictionary<string, string> cellHeader, IRow row, int rowIndex, T en, ref StringBuilder errorMsg)
        {
            List<string> keys = cellHeader.Keys.ToList(); // 要赋值的实体对象属性名称
            string errStr = ""; // 当前行转换时，是否有错误信息，格式为：第1行数据转换异常：XXX列；
            for (int i = 0; i < keys.Count; i++)
            {
                // 1.若属性头的名称包含'.',就表示是子类里的属性，那么就要遍历子类，eg：UserEn.TrueName
                if (keys[i].IndexOf(".") >= 0)
                {
                    // 1)解析子类属性
                    string[] properotyArray = keys[i].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    string subClassName = properotyArray[0]; // '.'前面的为子类的名称
                    string subClassProperotyName = properotyArray[1]; // '.'后面的为子类的属性名称
                    System.Reflection.PropertyInfo subClassInfo = en.GetType().GetProperty(subClassName); // 获取子类的类型
                    if (subClassInfo != null)
                    {
                        // 2)获取子类的实例
                        var subClassEn = en.GetType().GetProperty(subClassName).GetValue(en, null);
                        // 3)根据属性名称获取子类里的属性信息
                        System.Reflection.PropertyInfo properotyInfo = subClassInfo.PropertyType.GetProperty(subClassProperotyName);
                        if (properotyInfo != null)
                        {
                            try
                            {
                                // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                properotyInfo.SetValue(subClassEn, GetExcelCellToProperty(properotyInfo.PropertyType, row.GetCell(i)), null);
                            }
                            catch (Exception e)
                            {
                                if (errStr.Length == 0)
                                {
                                    errStr = "第" + rowIndex + "行数据转换异常：";
                                }
                                errStr += cellHeader[keys[i]] + "列；";
                            }

                        }
                    }
                }
                else
                {
                    // 2.给指定的属性赋值
                    System.Reflection.PropertyInfo properotyInfo = en.GetType().GetProperty(keys[i]);
                    if (properotyInfo != null)
                    {
                        try
                        {
                            // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                            properotyInfo.SetValue(en, GetExcelCellToProperty(properotyInfo.PropertyType, row.GetCell(i)), null);
                        }
                        catch (Exception e)
                        {
                            if (errStr.Length == 0)
                            {
                                errStr = "第" + rowIndex + "行数据转换异常：";
                            }
                            errStr += cellHeader[keys[i]] + "列；";
                        }
                    }
                }
            }
            // 若有错误信息，就添加到错误信息里
            if (errStr.Length > 0)
            {
                errorMsg.AppendLine(errStr);
            }
        }

        /// <summary>
        /// Excel Cell转换为实体的属性值
        /// </summary>
        /// <param name="distanceType">目标对象类型</param>
        /// <param name="sourceCell">对象属性的值</param>
        private static Object GetExcelCellToProperty(Type distanceType, ICell sourceCell)
        {
            object rs = distanceType.IsValueType ? Activator.CreateInstance(distanceType) : null;

            // 1.判断传递的单元格是否为空
            if (sourceCell == null || string.IsNullOrEmpty(sourceCell.ToString()))
            {
                return rs;
            }

            // 2.Excel文本和数字单元格转换，在Excel里文本和数字是不能进行转换，所以这里预先存值
            object sourceValue = null;
            switch (sourceCell.CellType)
            {
                case CellType.Blank:
                    break;

                case CellType.Boolean:
                    break;

                case CellType.Error:
                    break;

                case CellType.Formula:
                    break;

                case CellType.Numeric:
                    sourceValue = sourceCell.NumericCellValue;
                    break;

                case CellType.String:
                    sourceValue = sourceCell.StringCellValue;
                    break;

                case CellType.Unknown:
                    break;

                default:
                    sourceValue = sourceCell.StringCellValue;
                    break;
            }

            string valueDataType = distanceType.Name;

            // 在这里进行特定类型的处理
            switch (valueDataType.ToLower()) // 以防出错，全部小写
            {
                case "string":
                    rs = sourceValue.ToString();
                    break;
                case "int":
                    rs = (float)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "int16":
                    rs = (float)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "int32":
                    rs = (int)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "float":
                    rs = (float)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "single":
                    rs = (float)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "datetime":
                    rs = sourceCell.DateCellValue;
                    break;
                case "guid":
                    rs = (Guid)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType); return rs;
                default: rs = (int)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType); break;



            }
            return rs;
        }


        #region //Excel to Datatable

        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="sheetCount">sheet总数</param> 
        /// <param name="isColumnName">第一行是否是列名</param> 
        /// <returns>返回datatable</returns>  
        public static List<DataTable> ExcelToDataTable(string filePath, int sheetCount, bool isColumnName)
        {
            List<DataTable> tableList = new List<DataTable>();
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") >= 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") >= 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        tableList.Clear();
                        for (int k = 0; k < sheetCount; k++)
                        {
                            sheet = workbook.GetSheetAt(k);//读取第k个sheet//读取第一个sheet，当然也可以循环读取每个sheet  
                            dataTable = new DataTable();
                            if (sheet != null)
                            {
                                int rowCount = sheet.LastRowNum;//总行数  
                                if (rowCount > 0)
                                {
                                    IRow firstRow = sheet.GetRow(0);//第一行  
                                    int cellCount = firstRow.LastCellNum;//列数  

                                    //构建datatable的列  
                                    if (isColumnName)
                                    {

                                        IRow firstRowt = sheet.GetRow(1);//第一行  
                                        int cellCountt = firstRow.LastCellNum;//列数  
                                        startRow = 2;//如果第一行是列名，则从第二行开始读取  
                                        for (int i = firstRowt.FirstCellNum; i < cellCount; ++i)
                                        {
                                            cell = firstRowt.GetCell(i);
                                            if (cell != null)
                                            {

                                                {
                                                    column = new DataColumn(cell.ToString());
                                                    dataTable.Columns.Add(column);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            column = new DataColumn("column" + (i + 1));
                                            dataTable.Columns.Add(column);
                                        }
                                    }

                                    //填充行  
                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        row = sheet.GetRow(i);
                                        if (row == null) continue;

                                        dataRow = dataTable.NewRow();
                                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                                        {
                                            cell = row.GetCell(j);
                                            if (cell == null)
                                            {
                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                                switch (cell.CellType)
                                                {
                                                    case CellType.Blank:
                                                        dataRow[j] = "";
                                                        break;
                                                    case CellType.Numeric:
                                                        short format = cell.CellStyle.DataFormat;
                                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                        if (format == 14 || format == 22 || format == 31 || format == 57 || format == 58)
                                                            dataRow[j] = cell.DateCellValue;
                                                        else
                                                            dataRow[j] = cell.NumericCellValue;
                                                        break;
                                                    case CellType.String:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                    default:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                }
                                            }
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                            }
                            tableList.Add(dataTable);
                        }

                    }
                }
                return tableList;
            }
            catch (Exception e)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
        }

        #endregion


    }


    #region //XML 文件处理
    public class XmlDo
    {
        private readonly Class_User.UserModel UModels= new Class_User.UserModel();
       
        #region 处理Shopfloor_Connections

        public DataTable Sfloor_Conn(string Fname)
        {
            XmlSerial xmlCls = new XmlSerial();
            XmlDocument XmlDoc = xmlCls.XmlReplace(Fname);
            
            XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment
            
            XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment
            XElement Xele = xd.Root;
            DataTable dt = new DataTable();

            dt.Columns.Add("PROTOCOL", typeof(string));
            dt.Columns.Add("IP_ADDRESS", typeof(string));
            dt.Columns.Add("IP_PORT", typeof(string));
            dt.Columns.Add("SSAP", typeof(string));
            dt.Columns.Add("TSAP", typeof(string));
            dt.Columns.Add("WORKCENTER_ID", typeof(string));
            dt.Columns.Add("EQUIPMENT_ID", typeof(string));
            
            try
            {
                //IEnumerable<XElement> elements = Xele.XPathSelectElements("CONNECTION/PARAMETERS");
                //foreach(XElement x in elements)
                //{
                //    Console.WriteLine(x.Element("IP_ADDRESS").Value);
                //}

                var queryXml = xd.Descendants("CONNECTION");
                 foreach(var Dnod in queryXml)
                {
                    DataRow dr = dt.NewRow();

                    if (Dnod.Attribute("PROTOCOL").Value == "XML_STREAM")
                    {
                        
                        dr[0] = Dnod.Attribute("PROTOCOL").Value;
                        var ipadd = (from da in Dnod.Descendants("PARAMETERS").Descendants("IP_ADDRESS")
                                     select da.Value);
                        dr[1] = ipadd.Any() ? ipadd.ElementAt(0) : "blank ip add";

                        var port = (from da in Dnod.Descendants("PARAMETERS").Descendants("IP_PORT")
                                     select da.Value);
                        dr[2] = port.Any() ? port.ElementAt(0) :"blank port";
                        //var Para = xd.Descendants("PARAMETERS")
                        //    .Select(Pa => new { IP_ADDRESS = Pa.Element("IP_ADDRESS").Value,
                        //        IP_PORT = Pa.Element("IP_PORT").Value,
                        //        TIMEOUT_CONNECT = Pa.Element("TIMEOUT_CONNECT").Value,
                        //        TIMEOUT_SEND = Pa.Element("TIMEOUT_SEND").Value
                        //    });

                        //if (Para.Any())
                        //{

                        //    dr[0] = Dnod.Attribute("PROTOCOL").Value;
                        //    dr[1] = Para.ElementAt(0).IP_ADDRESS.ToString();
                        //    dr[2] = Para.ElementAt(0).IP_PORT.ToString();

                        //}

                    }

                    if (Dnod.Attribute("PROTOCOL").Value == "RFC1006")
                    {

                        dr[0] = Dnod.Attribute("PROTOCOL").Value;

                        var ipadd = (from da in Dnod.Descendants("PARAMETERS").Descendants("IP_ADDRESS")
                                     select da.Value);
                        dr[1] = ipadd.Any() ? ipadd.ElementAt(0) : "blank ip add";

                        var port = (from da in Dnod.Descendants("PARAMETERS").Descendants("IP_PORT")
                                    select da.Value);
                        dr[2] = port.Any() ? port.ElementAt(0) : "blank port";

                        var SSAP = (from da in Dnod.Descendants("PARAMETERS").Descendants("SSAP")
                                    select da.Value);
                        dr[3] = SSAP.Any() ? SSAP.ElementAt(0) : "NOK";

                        var TSAP = (from da in Dnod.Descendants("PARAMETERS").Descendants("TSAP")
                                    select da.Value);
                        dr[4] = TSAP.Any() ? TSAP.ElementAt(0) : "NOK";

                    }

                    var WORKCENTER_ID = (from da in Dnod.Descendants("EQUIPMENT").Descendants("WORKCENTER_ID")
                                         select da.Value);
                    dr[5] = WORKCENTER_ID.Any() ? WORKCENTER_ID.ElementAt(0) : "NOK";

                    var EQUIPMENT_ID = (from da in Dnod.Descendants("EQUIPMENT").Descendants("EQUIPMENT_ID")
                                        select da.Value);
                    dr[6] = EQUIPMENT_ID.Any() ? EQUIPMENT_ID.ElementAt(0) : "NOK";
                                       
                    dt.Rows.Add(dr);
                }


                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        

        #endregion

        public class XList
        {
            public string ShortName { get; set; }
        }

        #region 处理Loipro Equip ID

        public DataTable Get_LOIP_EQid(string Fname)
        {

            DoSQL df = new DoSQL();

            string sh = df.getShortName();
            //List<string> sh = df.GetConnectionStringsConfig();
            XmlSerial xmlCls = new XmlSerial();
            XmlDocument XmlDoc = xmlCls.XmlReplace(Fname);

            XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment

            XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment
            XElement Xele = xd.Root;
            DataTable dt = new DataTable();

            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("OrderType", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));

            dt.Columns.Add("EntryID", typeof(string));
            dt.Columns.Add("ObjectID", typeof(string));
            dt.Columns.Add("ShortName", typeof(string));
            dt.Columns.Add("EQUIPMENT_ID", typeof(string));
            dt.Columns.Add("WorkCenter", typeof(string));

            try
            {
                
                var queryXml = xd.Descendants("E1AFKOL");
                foreach (var Dnod in queryXml)
                {
                    DataRow dr = dt.NewRow();

                    dr[0] = Dnod.Element("AUFNR").Value;
                    dr[1] = Dnod.Element("AUART").Value;
                    dr[2] = Dnod.Element("AUFLD").Value;

                    dt.Rows.Add(dr);
                }

                var Vnr = xd.Descendants("E1AFVOL");
                foreach(var P in Vnr)
                {
                    DataRow dr = dt.NewRow();

                    var VORNR = (from da in P.Descendants("VORNR")
                                 select da.Value);
                    dr[3] = VORNR.Any() ? VORNR.ElementAt(0) : "blank";

                    var Obj = (from da in P.Descendants("ARBID")
                                 select da.Value);
                    dr[4] = Obj.Any() ? Obj.ElementAt(0) : "blank";

                    
                    var shortNm1 = (from da1 in P.Descendants("ZE1AUSPM_EXT1")
                                  
                                   select (da1.Element("ATWRT").Value));

                    /* XList 是public class 在XMLDo 类中定义！    */
                    List<XList> Shorts = (from item in P.Elements("ZE1AFDFO_TOOLS")
                                          select new XList
                                          {

                                              ShortName = item.Element("TEXT").Value
                                          }).ToList<XList>();

                    for(int i = 0; i < Shorts.Count; i++)
                    {
                        if (Shorts[i].ShortName.Length <= 13)
                        {
                            dr[5] = dr[5] + Shorts[i].ShortName + ";";
                        }
                    }
                   
                    //var ff =( from pp in P.Elements("ZE1AFDFO_TOOLS")
                    //         where pp!=null
                    //         where  pp.Element("EQTYP").Value == "G"
                    //         select pp.Element("TEXT").Value).ToList();
                    
                    //if (ff.Any())
                    //{
                    //    string d = string.Empty;
                    //    foreach (var v in ff)
                    //    {
                    //        d = d + ";" + v.ToString();

                    //    }
                    //    dr[5] = d;
                    //}

                   
                    //dr[5] = shortNm.Any() ? shortNm.ElementAt(0) : "blank";

                    var EquipID = (from da in P.Descendants("ZE1AFDFO_TOOLS").Descendants("FHMNR")
                                   //where da.Element("EQTYP").Value == "G"
                                   select da.Value);
                   
                    if (EquipID.Any())
                    {
                        foreach(var s in EquipID)
                        {
                            
                            dr[6] = dr[6] + s.ToString()+";";
                            
                        }
                    }

                    //dr[6] = EquipID.Any() ? EquipID.ElementAt(0) : "blank";

                    var WorkCenter = (from da in P.Descendants("ARBPL")
                               select da.Value);
                    if (WorkCenter.Count()>1)
                    {
                        for (int i=0; i<WorkCenter.Count();i++)
                        {
                            dr[7] = WorkCenter.ElementAt(i);
                            dt.Rows.Add(dr);
                        }
                    }
                    dr[7] = WorkCenter.Any() ? WorkCenter.ElementAt(0) : "blank";

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        #region test!!
        public void updateTest(string Fname)
        {
            XmlSerial xmlCls = new XmlSerial();
            XmlDocument XmlDoc = xmlCls.XmlReplace(Fname);

            XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment

            XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment
            XElement Xele = xd.Root;

            //var EquipID = (from da in xd.Descendants("ZE1AFDFO_TOOLS").Descendants("FHMNR")
            //               select da.Value);
            //var a = EquipID.Single<XElement>();

            //获取config路径
            string path = System.Windows.Forms.Application.ExecutablePath + ".config";
            XDocument doc = XDocument.Load(path);
            //查找所有节点
            IEnumerable<XElement> element = doc.Element("configuration").Element("appSettings").Elements();
            //遍历节点
            foreach (XElement item in element)
            {
                if (item.Attribute("key") != null && item.Attribute("key").Value == "节点名称")
                {
                    if (item.Attribute("value") != null)
                    {
                        item.Attribute("value").SetValue(DateTime.Now.ToString("d"));
                    }
                }
            }
            //保存
            doc.Save(path);

            //a.ReplaceWith(new XElement("9000100"));
            //Xele.Descendants("ZE1AFDFO_TOOLS").Descendants("FHMNR")
            xd.Save("11.xml");
        }
        #endregion


        #endregion

        public DataTable XmlList(List<string> XmlFile)
        {
            XmlDocument XmlDoc = new XmlDocument();

            DataTable dt = new DataTable();

            dt.Columns.Add("File Name", typeof(string));
            dt.Columns.Add("iDoc Type", typeof(string));
            dt.Columns.Add("SAP Type", typeof(string));
            dt.Columns.Add("Create Data", typeof(string));
            dt.Columns.Add("Order ID", typeof(string));
            dt.Columns.Add("Line Type", typeof(string));
            dt.Columns.Add("Production Number", typeof(string));

            XmlSerial xmlCls = new XmlSerial();

            try
            {
                for (int i = 0; i < XmlFile.Count; i++)
                {
                    DataRow dr = dt.NewRow();

                    if (Path.GetFileName(XmlFile[i]).Length < 19) { continue; }//过滤不正确文件名

                    XmlDoc = xmlCls.XmlReplace(XmlFile[i]);//XML 文件载入 清除不合规字符


                    XmlNode rootNode = XmlDoc.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/EDI_DC40");
                    if (rootNode == null)//过滤非 LOIPRO 文件
                    {
                        continue;
                    }

                    XmlDoc.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/EDI_DC40");

                    if (rootNode.ChildNodes.Count < 0)
                    {
                        MessageBox.Show("<script>alert('非SAP下发LOIPRO文件!');</script>");
                        return null;
                    }

                    if (rootNode.SelectSingleNode("IDOCTYP").InnerText != "LOIPRO02") { continue; } //只处理LOIPRO 在此过滤loipro 需优化

                    dr[0] = Path.GetFileName(XmlFile[i]); //文件名
                    dr[1] = rootNode.SelectSingleNode("MANDT").InnerText;
                    dr[2] = rootNode.SelectSingleNode("IDOCTYP").InnerText;
                    dr[3] = rootNode.SelectSingleNode("CREDAT").InnerText;

                    XmlNode xmlnode_Order = XmlDoc.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/E1AFKOL");

                    dr[4] = xmlnode_Order.SelectSingleNode("AUFNR").InnerText;
                    dr[5] = xmlnode_Order.SelectSingleNode("MATNR").InnerText;
                    dr[6] = xmlnode_Order.SelectSingleNode("GAMNG").InnerText;

                    //for (int k = 0; k < rootNode.ChildNodes.Count; k++)
                    //{
                    //    dr[2] = rootNode.ChildNodes[k].Name == "MANDT" ? rootNode.ChildNodes[k].InnerText : "";
                    //    dr[3] = rootNode.ChildNodes[k].Name == "CREDAT"? rootNode.ChildNodes[k].InnerText : "";

                    //}

                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("<script>alert('" + ex.ToString() + "!');</script>");
                return null;
            }

        }

        #region //处理 LOIPRO 查询
        public DataTable xmlLoipro(string fName)
        {
            XmlDocument XmlDoc = new XmlDocument();


            XmlSerial xmlCls = new XmlSerial();

            try
            {

                XmlDoc = xmlCls.XmlReplace(fName);

                XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment

                //XmlNode NodeHead = XmlDoc.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/E1AFKOL");
                //XmlNode NodeVORNR = XmlDoc.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/E1AFKOL/E1AFFLL/E1AFVOL");

                XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment

                //IEnumerable<XElement> elementCollection = xd.Elements("ZLOIPRO_SIMATIC_IT");

                DataTable dtVOR = new DataTable();
                dtVOR.Columns.Add("Station", typeof(string));
                dtVOR.Columns.Add("AVO DESC", typeof(string));
                dtVOR.Columns.Add("WorkCenter", typeof(string));
                dtVOR.Columns.Add("InterLock_17", typeof(string));
                dtVOR.Columns.Add("InterLock_16", typeof(string));
                dtVOR.Columns.Add("LoopCycle", typeof(string));
                dtVOR.Columns.Add("Operation type", typeof(string));
                dtVOR.Columns.Add("EquipmentID", typeof(string));
                dtVOR.Columns.Add("ShortName", typeof(string));
                dtVOR.Columns.Add("Materials", typeof(string));

                var query1 = xd.Descendants("E1AFVOL");
                foreach (var Pt in query1)
                {
                    DataRow dr = dtVOR.NewRow();

                    dr[0] = Pt.Element("VORNR").Value;
                    dr[1] = Pt.Element("LTXA1").Value;
                    dr[2] = Pt.Element("ARBPL").Value;

                    var L17 = (from da in Pt.Descendants("ZE1AUSPM_EXT1")
                               where da.Element("ATNAM").Value == "INTERLOCKING_17"
                               select da);
                    var L16 = (from da in Pt.Descendants("ZE1AUSPM_EXT1")
                               where da.Element("ATNAM").Value == "INTERLOCKING_16"
                               select da);
                    var LoopCycle = (from da in Pt.Descendants("ZE1AUSPM_EXT1")
                                     where da.Element("ATNAM").Value == "ERLAUBTEWIEDERHOLLOOPCYCLE"
                                     select new { Loops = da.Element("ATFLV").Value });
                    var StType = (from da in Pt.Descendants("ZE1AUSPM_EXT1")
                                  where da.Element("ATNAM").Value == "FERTIGUNGSVERFAHREN_AVO"
                                  select (da.Element("ATWRT").Value));
                    var EquipID = (from da in Pt.Descendants("ZE1AFDFO_TOOLS").Descendants("FHMNR")

                                   select da.Value);//select da.Element("FHMNR").Value
                    var shortNm = (from da in Pt.Descendants("ZE1AUSPM_EXT1")
                                   where da.Element("ATNAM").Value == "VORGANGSKURZTXT"
                                   select (da.Element("ATWRT").Value));
                    var Material = (from da in Pt.Descendants("E1RESBL")

                                    select (da.Element("MATNR").Value));


                    dr[3] = L17.Any() ? "已配置" : "NO";
                    dr[4] = L16.Any() ? "已配置" : "NO";
                    dr[5] = LoopCycle.Any() ? LoopCycle.ElementAt(0).Loops : "NO";
                    dr[6] = StType.Any() ? StType.ElementAt(0) : "NO";
                    dr[7] = EquipID.Any() ? EquipID.ElementAt(0) : "NO";
                    dr[8] = shortNm.Any() ? shortNm.ElementAt(0) : "NO";

                    if (Material.Any())
                    {
                        foreach (var mat in Material)
                        {
                            dr[9] += mat.ToString() + "||";
                        }
                    }
                    else
                    {
                        dr[9] = "未配置";
                    }

                    dtVOR.Rows.Add(dr);
                }

                #region //参考代码
                //var itlock = xd.Descendants("ZE1AUSPM_EXT1") //第二列值
                //            .Where(p => p.Element("ATNAM").Value == "VORGANGSKURZTXT")
                //            .Select(p => new { ATWRT = p.Element("ATWRT").Value });


                //DataTable dtShortN = new DataTable();
                //dtShortN.Columns.Add("ShortName", typeof(string));

                //foreach (var shortNm in itlock)
                //{
                //    DataRow dr = dtShortN.NewRow();
                //    dr[0]=shortNm.ATWRT;
                //    dtShortN.Rows.Add(dr);
                //}

                //dt = dtVOR.Copy(); //拷贝数据至新表

                //dt = dtVOR.Clone();//拷贝表1的结构

                //for(int i = 0; i < dtShortN.Columns.Count; i++) //新表添加表2结构
                //{
                //    dt.Columns.Add(dtShortN.Columns[i].ColumnName);
                //}

                //object[] Obj = new object[dt.Columns.Count];

                //for(int j = 0; j < dtVOR.Rows.Count; j++)//写表1 数据
                //{
                //    dtVOR.Rows[j].ItemArray.CopyTo(Obj, 0);
                //    dt.Rows.Add(Obj);
                //}

                //for(int i = 0; i < dtShortN.Rows.Count; i++)//写表2 数据
                //{
                //    for(int j = 0; j < dtShortN.Columns.Count; j++)
                //    {
                //        dt.Rows[i][j + dtVOR.Columns.Count] = dtShortN.Rows[i][j];
                //    }
                //}
                #endregion

                #region //interlock

                //var query2 = xd.Descendants("E1AFVOL") 
                //    .Descendants("ZE1OCLFM")
                //    .Descendants("ZE1AUSPM_EXT1")
                //    .Where(p => p.Element("ATNAM").Value == "INTERLOCKING_17")
                //    .Select(p => new { MaterialCheck = p.Element("ATFLV").Value });

                //var Intlckloop = xd.Descendants("ZE1AUSPM_EXT1") 
                //            .Where(p => p.Element("ATNAM").Value == "ERLAUBTEWIEDERHOLLOOPCYCLE")
                //            .Select(p => new { LoopCycle = p.Element("ATFLV").Value });

                //var Intlck17 = xd.Descendants("ZE1AUSPM_EXT1") 
                //            .Where(p => p.Element("ATNAM").Value == "INTERLOCKING_17")
                //            .Select(p => new { MaterialCheck = p.Element("ATFLV").Value });

                //var Intlck16 = xd.Descendants("ZE1AUSPM_EXT1")
                //            .Where(p => p.Element("ATNAM").Value == "INTERLOCKING_16")
                //            .Select(p => new { SetupCheck = p.Element("ATFLV").Value });

                //DataTable dtInterlock = new DataTable();
                //dtInterlock.Columns.Add("LoopCycle", typeof(string));
                //dtInterlock.Columns.Add("InterLock_16", typeof(string));
                //dtInterlock.Columns.Add("InterLock_17", typeof(string));

                //foreach (var It in Intlckloop)
                //{
                //    DataRow dr = dtInterlock.NewRow();
                //    dr[0] = It.LoopCycle;
                //    dtInterlock.Rows.Add(dr);
                //}

                #endregion

                return dtVOR;
            }
            catch (Exception ex)
            {
                MessageBox.Show("<script>alert('" + ex.ToString() + "!');</script>");
                return null;
            }
        }
        #endregion

        #region //处理move-type=101
        public DataTable Qry_MBGMCR03(List<string> fName)
        {
            //XmlDocument XmlDoc = new XmlDocument();

            DataTable dt = new DataTable();

            XmlSerial xmlCls = new XmlSerial();

            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("CreateDate", typeof(string));
            dt.Columns.Add("MoveType", typeof(string));
            dt.Columns.Add("MaterialNumber", typeof(string));
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("Yield", typeof(string));
            dt.Columns.Add("SerialNO", typeof(string));
            dt.Columns.Add("Mark262", typeof(string));


            try
            {
                for (int i = 0; i < fName.Count; i++)
                {
                    XmlDocument XmlDoc = xmlCls.XmlReplace(fName[i]);

                    XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment

                    XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment


                    if (xd.Root.Name == "MBGMCR03")
                    {
                        var query1 = xd.Descendants("E1BP2017_GM_ITEM_CREATE")
                            //.Where(mat => mat.Element("MOVE_TYPE").Value == "101")
                            .Select(mat => new {
                                MatID = mat.Element("MATERIAL").Value,
                                Yield = mat.Element("ENTRY_QNT").Value,
                                OrdID = mat.Element("ORDERID").Value,
                                MoveType = mat.Element("MOVE_TYPE").Value,
                                XSTOB = mat.Element("XSTOB").Value
                            });

                        if (query1.Any())
                        {
                            DataRow dr = dt.NewRow();

                            dr[0] = Path.GetFileName(fName[i]);
                            dr[1] = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(fName[i]));
                            dr[4] = query1.ElementAt(0).OrdID.ToString();
                            dr[2] = query1.ElementAt(0).MoveType.ToString();

                            foreach (var v in query1)
                            {

                                dr[3] += v.MatID.ToString() + "||";

                                dr[5] += v.Yield.ToString() + "||";
                                dr[7] += v.XSTOB.ToString() + "||";
                            }


                            var Mats = xd.Descendants("E1BP2017_GM_SERIALNUMBER")
                            .Select(h => new { SNR = h.Element("SERIALNO").Value });

                            if (Mats.Any())
                            {
                                foreach (var m in Mats)
                                {
                                    dr[6] += m.SNR.ToString() + "\r\n";
                                }
                            }

                            dt.Rows.Add(dr);
                        }


                    }
                }//for 循环

                return dt;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }
        }
        #endregion //处理move-type=101

        #region //处理报文Event_Code

        public DataTable Qry_Tele_EventCode(List<string> vs)
        {
            DataTable dt = new DataTable();

            XmlSerial xmlCls = new XmlSerial();

            dt.Columns.Add("Telegram", typeof(string));
            dt.Columns.Add("EventCode", typeof(string));
            dt.Columns.Add("WorkOperationCenter", typeof(string));
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("TimeUpdate", typeof(string));
            dt.Columns.Add("SNR", typeof(string));
            dt.Columns.Add("TELEGRAM_ID", typeof(string));


            try
            {
                for (int i = 0; i < vs.Count; i++)
                {
                    XmlDocument XmlDoc = xmlCls.XmlReplace(vs[i]);

                    XmlNodeReader Xmlnode = new XmlNodeReader(XmlDoc);// XmlDocument 转 XDocment

                    XDocument xd = XDocument.Load(Xmlnode);// XmlDocument 转 XDocment

                    string TeleName = xd.Root.Name.ToString();

                    var query1 = xd.Descendants("HEADER")
                         .Where(EC => EC.Element("EVENT_CODE").Value != "0")
                         .Select(EC => new {
                             EventCode = EC.Element("EVENT_CODE").Value,
                             WORK_OPERATION_ID = EC.Element("WORK_OPERATION_ID").Value,
                             OrdID = EC.Element("ORDER_ID").Value,
                             TIMES = EC.Element("TIMESTAMP").Value,
                             SERIAL_NUMBER = EC.Element("SERIAL_NUMBER").Value,
                             TELEGRAM_ID = EC.Element("TELEGRAM_NUMBER").Value
                         });

                    if (query1.Any())
                    {

                        DataRow dr = dt.NewRow();

                        dr[0] = TeleName;
                        dr[1] = query1.ElementAt(0).EventCode.ToString();
                        dr[2] = query1.ElementAt(0).WORK_OPERATION_ID.ToString();
                        dr[3] = query1.ElementAt(0).OrdID.ToString();
                        dr[4] = query1.ElementAt(0).TIMES.ToString();
                        dr[5] = query1.ElementAt(0).SERIAL_NUMBER.ToString();

                        dt.Rows.Add(dr);
                    }

                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }
        }

        #endregion //处理报文Event_Code


    }

    #endregion//XML 文件处理


    

    public class XmlSerial
    {


        /// <summary>
        /// 替换 XML 文件中的 0X00 字符
        /// </summary>
        /// <param name="xFile"></param>
        /// <returns></returns>
        public XmlDocument XmlReplace(string xFile)
        {
            StreamReader stream = new StreamReader(xFile);
            string xmlfile = stream.ReadToEnd();
            stream.Close();

            string text = "";

            XmlDocument xmlFi = new XmlDocument();

            for (int i = 0; i < 128; i++)
            {
                char t = (char)i;

                text = xmlfile.Replace('П', t);

                try
                {
                    xmlFi.LoadXml(text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("<script>alert('" + ex.ToString() + "!');</script>");
                    continue;
                }

                //Console.WriteLine("Char(" + i.ToString() + "): " + t + " => fine!");
            }

            return xmlFi;

        }

        public XDocument XERreplace(string xFile)
        {
            StreamReader stream = new StreamReader(xFile);
            string xmlfile = stream.ReadToEnd();
            stream.Close();

            string text = "";

            XDocument xdt = new XDocument();


            for (int i = 0; i < 128; i++)
            {
                char t = (char)i;

                text = xmlfile.Replace('П', t);

                try
                {
                    xdt = XDocument.Load(text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("<script>alert('" + ex.ToString() + "!');</script>");
                    continue;
                }

                //Console.WriteLine("Char(" + i.ToString() + "): " + t + " => fine!");
            }

            return xdt;
        }

        public void ForeachXml(XmlDocument xmlFile)
        {
            XmlElement xmlel = xmlFile.DocumentElement;

            XmlSerial xmlSS = new XmlSerial();

            xmlSS.DiguiNode(xmlel);

        }

        public void DiguiNode(XmlNode node)
        {
            List<string> Nodes = new List<string>();
            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (node1.ChildNodes.Count > 1)
                {
                    DiguiNode(node1);
                }
                else
                {
                    Nodes.Add(node1.InnerText);
                }
            }

        }

        public void getXmlNodes(XmlDocument xFiles)
        {
            XmlNodeList Lists = xFiles.DocumentElement.ChildNodes;

            Dictionary<string, string> DicNodsVal = new Dictionary<string, string>();

            XmlNode xmlNd = xFiles.SelectSingleNode("/ZLOIPRO_SIMATIC_IT/IDOC/EDI_DC40");

            for (int i = 0; i < xmlNd.ChildNodes.Count; i++)
            {
                DicNodsVal.Add(xmlNd.ChildNodes[i].Name, xmlNd.ChildNodes[i].InnerText);
            }

        }
    }

    public class DoSQL
    {

        public string DBConnStr = string.Empty;
        

        public  List<string> GetConnectionStringsConfig()
        {
            //指定config文件读取
            string file = System.Windows.Forms.Application.ExecutablePath;

            List<string> lis = new List<string>();
            
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach(ConnectionStringSettings it in ConfigurationManager.ConnectionStrings)
            {
                lis.Add(it.Name.ToString());
            }
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == "connectionStrings")
                {
                    lis.Add(config.AppSettings.Settings["connectionStrings"].Value.ToString());
                    
                }
            }
            return lis;
        }

        public string getShortName()
        {

            try
            {
                // string ShortName= ConfigurationManager.AppSettings[KeyNa].ToString();
                string file = System.Windows.Forms.Application.ExecutablePath;
               
                List<string> lis = new List<string>();
                string cd = string.Empty;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                ////foreach (ConnectionStringSettings it in ConfigurationManager.AppSettings)
                //{
                //    lis.Add(it.Name.ToString());
                //}

                foreach (string key in config.AppSettings.Settings.AllKeys)
                {
                    if (key == "ShortName")
                    {
                        cd = config.AppSettings.Settings[key].Value.ToString();

                    }
                }

                return cd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }

        }

        public string DbConn(string items)
        {
            try
            {
                if(items== "P_Update")
                {
                    DBConnStr = ConfigurationManager.ConnectionStrings[items].ConnectionString.ToString();
                    return "P_DB_Activity";
                }

                DBConnStr = ConfigurationManager.ConnectionStrings[items].ConnectionString.ToString();
                               
                return "ok";

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "无此连接参数";
            }
            
        }

        public SqlCommand CreateCmd(string SQL, SqlConnection Conn)
        {
            SqlCommand Cmd;
            Cmd = new SqlCommand(SQL, Conn);
            return Cmd;
        }

        public bool RunProc(string sql)
        {
                        
            SqlConnection conn = new SqlConnection(DBConnStr);
            conn.Open();
            SqlCommand cmd = CreateCmd(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                throw new Exception(sql);
               
            }
            finally
            {
               
                conn.Close();
                conn.Dispose();
                
            }
        }


        /// <summary>
        /// 数据集查询 返回 DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  DataTable SQLSet(string sql)
        {
            
            SqlConnection conn = new SqlConnection(DBConnStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                sda.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }


        /// <summary>
        /// 根据工单号 查询工单段名称，设备号，NC程序号等信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable Qty_Batch_Order(string order)
        {
            string sql = string.Format(@"SELECT     
                                                        POMV_ETRY.pom_order_id AS Order_ID, 
                                                        POMV_ETRY.pom_entry_type_id AS AVO, 
                                                        EEES.FHM_ID, 
                                                        EEES.FHM_TYPE, 
                                                        EEES.FHM_TEXT, 
                                                        EEES.FHM_POS, 
                                                        EEES.MACHINE_PROGRAM, 
                                                        EEES.PROGRAM_VERSION, 
                                                        EEES.RowUpdated
                                                        FROM
                                                        [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_SHOPFLOOR] EEES
                                                        INNER JOIN
                                                        POMV_ETRY ON EEES.MES_RECORD_PK = POMV_ETRY.pom_entry_pk
                                                        where POMV_ETRY.pom_order_id like '{0}'",order);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过工单号查询 每个工序需扫描的物料信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable Qty_Mat_Order(string order)
        {
            string sql = string.Format(@"SELECT  
                                        (select pom_ordr.matl_def_id from [SITMesDB].[dbo].[POMV_ORDR] pom_ordr 
	                                        where POMV_ETRY.pom_order_id=pom_ordr.pom_order_id) as FERT_MAT_ID,
                                        (select mmlot.defname from [SitMesDB].[dbo].[MMDefinitions] mmlot
	                                        where mmlot.DefID in (select pom_ordr.matl_def_id from [SITMesDB].[dbo].[POMV_ORDR] pom_ordr 
		                                        where POMV_ETRY.pom_order_id=pom_ordr.pom_order_id)) as FERT_Name,
                                        POMV_ETRY.pom_order_id as Order_ID,
                                        ESW.MACHINE_ID as WorkOperationID,
                                        replace(POMV_ETRY.pom_entry_id,POMV_ETRY.pom_order_id+'-','') as AVO_ID,
                                        FHM.FHM_ID as EquipmentID,
                                        isnull(POMV_MATL_SPEC_ITM.def_id,'-') as Matnr,
                                        isnull(MMwDefVers.DefName,'-') as Mat_Description,
                                        isnull(POMV_MATL_SPEC_ITM.uom_id,'-') as UoM,
                                        isnull(POMV_MATL_SPEC_ITM.seq,0) as Sort,
                                        isnull(MMwDefVerPrpVals.PValue,'-') as Traceability,
                                        isnull(pmlpv7.pom_cf_value,'-') as Dummy,
                                        isnull(POMV_MATL_SPEC_ITM.quantity,0) as Quantity,
                                        isnull(MMwDefVers.ClassID,'-') as CLASS,
                                        isnull(MMwDefVers.TypeID,'-') as Mat_TYPE,
                                        isnull(v2.PValue,'-') as ProcType
                                        FROM 
                                        POMV_ETRY with(nolock)
                                        LEFT JOIN POMV_MATL_SPEC_ITM on POMV_ETRY.pom_entry_id = POMV_MATL_SPEC_ITM.pom_entry_id
                                        LEFT JOIN MMwDefVerPrpVals on MMwDefVerPrpVals.DefID = POMV_MATL_SPEC_ITM.def_id and MMwDefVerPrpVals.PropertyName = 'TRACEABILITY_SCOPE'
                                        LEFT JOIN MMwDefVerPrpVals v2 on v2.DefID = POMV_MATL_SPEC_ITM.def_id and v2.PropertyName = 'PROC_TYPE'
                                        LEFT JOIN MMwDefVers on MMwDefVerPrpVals.DefVerPK = MMwDefVers.DefVerPK

                                        LEFT JOIN POMV_MATL_LST_PRP_VAL pmlpv7 on POMV_MATL_SPEC_ITM.pom_entry_id = pmlpv7.pom_entry_id and POMV_MATL_SPEC_ITM.def_id = pmlpv7.def_id and POMV_MATL_SPEC_ITM.seq = pmlpv7.pom_mat_list_seq and pmlpv7.pom_custom_fld_name = 'DUMMY_COMPONENT'

                                        LEFT JOIN [ArchSitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS] ESW on ESW.WORKCENTER_ID = POMV_ETRY.ERP_WRKCNTR
                                        left join dbo.[ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_SHOPFLOOR] FHM
                                        on POMV_ETRY.pom_entry_pk=FHM.MES_RECORD_PK
                                        WHERE     
                                        POMV_ETRY.pom_order_id = '{0}'
                                        order by 3", order);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过唯一码 查询唯一码装配及拆解状态 以及装配到的目标序列号
        /// </summary>
        /// <param name="UniqueCode"></param>
        /// <returns></returns>
        public DataTable Qty_UniqueMat(string UniqueCode)
        {
            string sql = string.Format(@"select 
			(select top 1 					
				(select DefName from mmwdefvers						
					where defid=ev.PRODUCT_ID) 
					FROM [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EV] ev with(nolock)						
				where SERIAL=Gen.TARGET_LOT) as FinalProductName,
				(select top 1 	ev.PRODUCT_ID 
				FROM [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EV] ev with(nolock)						
				where SERIAL=Gen.TARGET_LOT) as FinalProductID,
				(select top 1 	ev.ORDER_ID 
				FROM [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EV] ev with(nolock)						
				where SERIAL=Gen.TARGET_LOT) as ORDER_ID,
	            TARGET_LOT as AssembleTo_SNR,MACHINE_ID as Terminal_ID,COMPONENT_ID as Unique_MatNum
                    ,(select DefName from [SitMesDB].[dbo].MMwDefVers  where DefID=Gen.COMPONENT_ID ) as Unique_MatName
                    ,LOT_ID as UniqueCode,QUANTITY
                    ,(case when ASSEMBLE_CONFIRMED=1 then N'已装配' else N'未装配' end) as Assembled,
                    DISASSEMBLE_CONFIRMED as DisassembledCount
                   ,(case when DISASSEMBLED=1 then N'已拆解' else N'未拆解' end) as DisassembleStatus,
                    REUSED
                    ,(case when REUSED=0 and DISASSEMBLED=1 then 'Scrp'
                             when REUSED=1 and  DISASSEMBLE_CONFIRMED>0 and DISASSEMBLED=1 then 'Code Reused'
                             when REUSED>0 and  ASSEMBLE_CONFIRMED=1 and DISASSEMBLED=0 then 'Code Un-Disassembled'
                    end) UniqueCode_Status
                    ,TRACEABILITY_SCOPE as TraceCategoary,RowUpdated
                    FROM [SitMesDB].[dbo].[ARCH_T_SitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_GENEALOGY_MATLABEL_$107$] Gen with(nolock)
                    where LOT_ID like '%{0}%'", UniqueCode);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据唯一码 查询绑定的序列号
        /// </summary>
        /// <param name="UniqueCode"></param>
        /// <returns></returns>
        public DataTable Qty_MMlot_TargetPK2SNR(string UniqueCode)
        {
            string sql = string.Format(@"select snr.LotID,snr.LotName SerialNumber,uniqueID.LotName as uniqueCode
                                                        ,snr.RowUpdated as changetime
                                                        FROM [SitMesDb].[dbo].[MMLots] snr
                                                        with(nolock)
                                                        inner join [SitMesDb].[dbo].[MMLots] uniqueID
                                                        on snr.LotPK=uniqueID.TargetLotPK
                                                        where uniqueID.LotName = '{0}'", UniqueCode);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// input single snr then get order id; final material number and name
        /// </summary>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_Single_SNR(string SNR)
        {
            string sql = string.Format(@"select top 1	
                                            (select DefName from [SitMesDb].[dbo].mmwdefvers	
	                                            where defid=ev.PRODUCT_ID) FinalProductName,ev.PRODUCT_ID as FinalProductID,ORDER_ID
                                            FROM [SitMesDb].[dbo].[Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EV] ev with(nolock)	
                                            where SERIAL='{0}'", SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 单个工单号 查询 产品料号与名称
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable Qty_Single_Order(string OrderID)
        {
            string sql = string.Format(@"select top 1  (select POMV.matl_def_id from [SITMesDB].[dbo].[POMV_ORDR] POMV 
	                                        where POMV_ETRY.pom_order_id=POMV.pom_order_id) as FERT_MAT_ID,
                                           (select mmlot.defname from [SitMesDB].[dbo].[MMDefinitions] mmlot
		                                        where mmlot.DefID in (select pom_ordr.matl_def_id from [SITMesDB].[dbo].[POMV_ORDR] pom_ordr 
			                                        where POMV_ETRY.pom_order_id=pom_ordr.pom_order_id)) as FERT_Name,
	                                        POMV_ETRY.pom_order_id as OrderID	
                                           from POMV_ETRY with(nolock)
                                            where POMV_ETRY.pom_order_id='{0}'", OrderID);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询返工数据临时表
        /// </summary>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_SNR_Rework_Temp(string SNR)
        {
            string sql = string.Format(@"select 
                                                            dateadd(hour,8,RowUpdated) ReworkTime
                                                           ,LOT_PK,HUT_ASSIGNMENT
                                                          ,REWORK_STATE
                                                          ,CNT_ASSEMBLED
                                                          ,REWORK_DATA_TMP
                                                          ,REWORK_DATA_TMP_2
                                                          ,REWORK_DATA_TMP_3
                                                          ,REWORK_DATA_TMP_4
                                                           from [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_PROP_EXT_$111$]
                                                          where LOT_PK=(SELECT [LotPK]
                                                             FROM [SitMesDB].[dbo].[MMLots]
                                                          where LotName='{0}' )", SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据SNR，Order查询物料临时表  EC_SETUP_MAT_LABEL_TEMP
        /// </summary>
        /// <param name="SNR"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        public DataTable Qty_Mat_Setup_Temp_Db(string Order)
        {
            string sql = string.Format(@"SELECT	
                                                    [$IDArchiveValue] as  RecordID,
                                                    ORDER_ID,	
                                                    SERIALNUMBER,	
                                                    [MACHINE_ID]	
                                                    ,[PROCESS_STEP]	
                                                    ,[COMPONENT_ID] as MatNumber	
	                                                    ,(select DefName from
                                                    [SITMesDB].[dbo].[MMwDefVers] where	
                                                    defid=Mst.[COMPONENT_ID]) as MatName	
                                                    ,[COMPONENT_POS]	
                                                    ,[LIFNR]	
                                                    ,[PACKID]	
                                                    ,[UNIKAT]	
                                                    ,[EQUIPMENT_ID]	
                                                    ,dateadd(hour,8,[RowUpdated])as dateTimes	
                                                    ,[SETUP_STATE]
                                                    FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SETUP_MAT_LABEL_TEMP_$102$] Mst with(nolock)	
                                                    where order_id='{0}'", Order);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public DataTable Qty_Mat_Setup_Db(string Order)
        {
            string sql = string.Format(@"select 
													ORDER_ID,MACHINE_ID,
													PROCESS_STEP as WorkOperationID,
													COMPONENT_ID as MaterialID,
													(select DefName from
                                                    [SITMesDB].[dbo].[MMwDefVers] where	
                                                    defid=Mst.[COMPONENT_ID]) as MatName,
													LIFNR as SupplierID,
													PACKID as PackageID,
													[EQUIPMENT_ID],
													dateadd(hour,8,[RowUpdated])as dateTimes
													FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SETUP_MAT_LABEL_$101$] Mst with(nolock)	
                                                    where order_id='{0}'", Order);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据工单号查询 实际 物料扫描记录
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        public DataTable Qty_Mat_Real_Genealogy(string Order)
        {
            string sql = string.Format(@"SELECT POMV_ETRY.pom_order_id as Order_ID
                                        ,gen.TARGET_LOT as SNR, gen.MACHINE_ID as Terminal_ID
                                        ,EEP.ERP_OPERATION_ID as AVO_ID, POMV_ETRY.pom_entry_type_id as WorkOperationID
                                        ,gen.COMPONENT_ID as MatNumber
                                        ,MMwDefVers.DefName as MatName
                                        ,gen.LIFNR
                                        , gen.PACKID
                                        , gen.LOT_ID as UniqueCode
                                        , gen.QUANTITY as BoM_QUANTITY
                                        , dateadd(hour,8,gen.RowUpdated)as dateTimes
                                        from [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_GENEALOGY_MATLABEL] gen		
                                        INNER JOIN POMV_ETRY on gen.MES_RECORD_PK = POMV_ETRY.pom_entry_pk		
                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP on POMV_ETRY.pom_entry_pk = EEP.MES_RECORD_PK		
                                        INNER JOIN MMwDefVers ON MMwDefVers.DefID = gen.COMPONENT_ID		
                                        where		
                                        POMV_ETRY.pom_order_id='{0}'",  Order);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据单个SNR序列号 查询所关联的物料信息
        /// </summary>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_SNR_Real_Genealogy(string SNR)
        {
            string sql = string.Format(@"SELECT POMV_ETRY.pom_order_id as Order_ID
                                        ,gen.TARGET_LOT as SNR, gen.MACHINE_ID as Terminal_ID
                                        ,EEP.ERP_OPERATION_ID as AVO_ID, POMV_ETRY.pom_entry_type_id as WorkOperationID
                                        ,gen.COMPONENT_ID as MatNumber
                                        ,MMwDefVers.DefName as MatName
                                        ,gen.LIFNR
                                        , gen.PACKID
                                        , gen.LOT_ID as UniqueCode
                                        , gen.QUANTITY as BoM_QUANTITY
                                        , dateadd(hour,8,gen.RowUpdated)as dateTimes
                                        from [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_GENEALOGY_MATLABEL] gen		
                                        INNER JOIN POMV_ETRY on gen.MES_RECORD_PK = POMV_ETRY.pom_entry_pk		
                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP on POMV_ETRY.pom_entry_pk = EEP.MES_RECORD_PK		
                                        INNER JOIN MMwDefVers ON MMwDefVers.DefID = gen.COMPONENT_ID		
                                        where		
                                        gen.TARGET_LOT='{0}'", SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 输入SNR 查询eCar 报表类似数据
        /// </summary>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_eCar_Product_SNR(string SNR)
        {
            string sql = string.Format(@"declare @snr nvarchar(4000)

                                            declare @orderFromLot nvarchar(4000)

                                            set @snr = '{0}'

                                            declare @lops TABLE
                                            (
                                            LotPk int,
                                            NewName NVARCHAR(4000),
                                            OperationDate DATETIME,
                                            UserID NVARCHAR(4000),
                                            AssociateTo NVARCHAR(4000),
                                            Comments NVARCHAR(4000),
                                            SrvCrtBias SMALLINT,
                                            NewLocPk INT,
                                            NewStatusPk INT
                                            );

                                            -- can be empty, when snr is not yet running
                                            insert into @lops
                                            select LotPk, NewName, OperationDate, UserID, AssociateTo, Comments, SrvCrtBias, NewLocPK, NewStatusPK from MMvLotOperations with(nolock)
                                            where NewName = @snr and LotOpeTypePK = 9

                                            declare @lot_route TABLE
                                            (
                                            LOT_PK INT,
                                            ROUTE_POS INT,
                                            ENTRY_TYPE NVARCHAR(4000),
                                            POM_ENTRY_PK INT,
                                            CTX_ID NVARCHAR(4000),
                                            ROUTE_POS_STATUS NVARCHAR(4000),
                                            FLAG_REWORK NVARCHAR(4000)
                                            );

                                            set @orderFromLot = (select CommitTo from MMLotCommitTo WITH(NOLOCK) where LotPK = (select LotPk from MMvLots with(nolock) where LotName = @snr))

                                            insert into @lot_route
                                            select LOT_PK, ROUTE_POS, pet.id, POMV_ETRY.pom_entry_pk, CTX_ID, ROUTE_POS_STATUS, FLAG_REWORK
                                            from [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_ROUTE] lot_route with(nolock)
                                            LEFT JOIN POM_ENTRY_TYPE pet on pet.pom_entry_type_pk = lot_route.ENTRY_TYPE_PK
                                            LEFT JOIN POMV_ETRY on POMV_ETRY.pom_order_id = @orderFromLot and pet.id = POMV_ETRY.pom_entry_type_id
                                            where LOT_PK = (select LotPk from MMvLots where LotName = @snr)

                                            declare @history TABLE
                                            (
                                            ROUTE_POS NVARCHAR(100),
                                            ORDER_ID NVARCHAR(4000),
                                            SNR NVARCHAR(4000),
                                            TERMINAL NVARCHAR(4000),
                                            AVO_ID NVARCHAR(4000),
                                            AVO NVARCHAR(4000),
                                            AVO_BESCHREIBUNG NVARCHAR(4000),
                                            WORKFLOW NVARCHAR(4000),
                                            SNR_STATUS NVARCHAR(4000),
                                            REWORK_STEP NVARCHAR(100),
                                            InterlockingCode NVARCHAR(4000),
                                            InterlockingError NVARCHAR(4000),
                                            USER_ID NVARCHAR(4000),
                                            TIMESTAMP DATETIME
                                            );

                                            insert into @history
                                            select 
                                            isnull(ROUTE_POS,'-') as 'ROUTE_POS',
                                            @orderFromLot as Order_ID,
                                            @snr as SNR,
                                            isnull(lops.AssociateTo,'...') as Terminal,
                                            isnull(EEP.ERP_OPERATION_ID,'...') as AVO_ID, 
                                            isnull(lot_route.ENTRY_TYPE,loc.LocID) as AVO,
                                            isnull(EEP.WO_DESCR,loc.LocID) as AVO_Beschreibung,
                                            isnull(EEP.WORKFLOW,'...') as Workflow,
                                            isnull(NULLIF(isnull(ROUTE_POS_STATUS,stat.LotStatusID),''),'...') as SNR_Status,
                                            isnull(FLAG_REWORK,'') as 'Rework_Step',
                                            '--' as InterlockingCode,
                                            '--' as InterlockingError,
                                            isnull(UserID,'...') as User_ID,
                                            isnull(lops.OperationDate,'2999-01-01 00:00:00.000') as Timestamp
                                            /*IEV-Timestamp cannot be converted to local => EV-timestamp has to be in UTC, too.*/
                                            --isnull(dateadd(minute,-lops.SrvCrtBias, lops.OperationDate),'2999-01-01 00:00:00.000') as Timestamp
                                            FROM 
                                            @lot_route as lot_route
                                            INNER JOIN SITMesDB.dbo.[ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP on EEP.MES_RECORD_PK = lot_route.POM_ENTRY_PK
                                            FULL OUTER JOIN @lops as lops on lot_route.LOT_PK = lops.LotPk and lot_route.CTX_ID = lops.Comments 
                                            LEFT JOIN MMLocations loc on loc.LocPK = lops.NewLocPk
                                            LEFT JOIN MMLotStatuses stat on stat.LotStatusPK = lops.NewStatusPk

                                            /*
                                            Merge with interlocking checks
                                            */
                                            insert into @history
                                            select
                                            '      Itlk' as 'ROUTE_POS',
                                            @orderFromLot as Order_ID,
                                            @snr as SNR,
                                            iev.TERM_ID as Terminal,
                                            EEP.ERP_OPERATION_ID as AVO_ID,
                                            iev.WO_IDT as AVO,
                                            EEP.WO_DESCR as 'AVO_Beschreibung',
                                            EEP.WORKFLOW as Workflow,
                                            iev.STATUS as SNR_Status,
                                            '' as 'Rework_Step',
                                            iev.ITLK_CODE as InterlockingCode,
                                            iev.ERROR_ID as InterlockingError,
                                            'Itlk-Check' as User_ID,
                                            dateadd(hour,8,iev.EVENT_DATE_TIME) as Timestamp
                                            from [ArchSitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/IEV] iev with(nolock)
                                            LEFT JOIN POMV_ETRY on iev.ORDER_ID = pomv_etry.pom_order_id and iev.WO_IDT = POMV_ETRY.pom_entry_type_id
                                            LEFT JOIN MMLocations on MMLocations.LocID = POMV_ETRY.pom_entry_type_id
                                            LEFT JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP on POMV_ETRY.pom_entry_pk = EEP.MES_RECORD_PK 
                                            where 
                                            iev.ORDER_ID = @orderFromLot and 
                                            iev.SERIAL = @snr
                                            order by iev.EVENT_DATE_TIME

                                            select * from @history history
                                            where 
                                            --history.Timestamp > convert(datetime,@from)
                                            --and history.Timestamp < convert(datetime,@to) and
                                            history.Terminal like '%'
                                            and history.AVO like '%'
                                            order by TIMESTAMP", SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过工单号查询 工单Setup状态
        /// </summary>
        /// <param name="Orderid"></param>
        /// <returns></returns>
        public DataTable Qty_Order_Setup(string Orderid)
        {
            string sql = string.Format(@"SELECT [MACHINE_ID]	
                                                        ,[PROCESS_STEP]	
                                                        ,[ORDER_ID]	
                                                        ,[PLC_SETUP_FLAG]	
                                                        ,dateadd(hour,8,[RowUpdated]) as Times	
                                                        ,[EQUIPMENT_ID]	
                                                        FROM [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SETUP_SHOPFLOOR_$106$]	
                                                        with(nolock)	
                                                        where ORDER_ID='{0}'", Orderid);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询工单下所有SNRs 及其状态 工单号可模糊查询
        /// </summary>
        /// <param name="Orderid"></param>
        /// <returns></returns>
        public DataTable Qty_Order_SNRs(string Orderid)
        {
            string sql = string.Format(@"Use SITMesDB

                                                        SELECT
                                                        MMLots.LotName AS SerialNumber, 
                                                        POM_ORDER_STATUS.id AS Order_Status,
                                                        MMLotStatuses.LotStatusID AS SNR_Status,
                                                        POM_ENTRY.initial_qty AS Quantity, 
                                                        dateadd(hour,8,POM_ORDER.RowUpdated) as LatestChange,
                                                        dateadd(hour,8,oep.RowUpdated) as ImportDate
                                                        FROM
                                                        POM_ORDER 
                                                        INNER JOIN POM_ORDER_STATUS ON POM_ORDER.pom_order_status_pk = POM_ORDER_STATUS.pom_order_status_pk 
                                                        INNER JOIN MMLotCommitTo ON POM_ORDER.pom_order_id = MMLotCommitTo.CommitTo
                                                        INNER JOIN MMLots ON MMLotCommitTo.LotPK = MMLots.LotPK 
                                                        INNER JOIN MMLotStatuses ON MMLotStatuses.LotStatusPK = MMLots.LotStatusPK
                                                        INNER JOIN POM_ENTRY ON POM_ORDER.pom_order_pk = POM_ENTRY.pom_order_pk AND POM_ENTRY.order_extended_data = N'Y' 
                                                        INNER JOIN POM_CUSTOM_FIELD_RT ON POM_ENTRY.pom_entry_pk = POM_CUSTOM_FIELD_RT.pom_entry_pk AND POM_CUSTOM_FIELD_RT.pom_custom_fld_name = N'BOM_NAME'
                                                        inner JOIN MMDefinitions on MMDefinitions.DefID = POM_ENTRY.matl_def_id
                                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ORDER_EXT_PROPERTIES] oep on oep.MES_RECORD_PK = POM_ORDER.pom_order_pk
                                                        where POM_ORDER.pom_order_id like '%{0}%'", Orderid);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 基于工单的SAP报工 查询 包括物料号与SNR
        /// </summary>
        /// <param name="Orderid"></param>
        /// <returns></returns>
        public DataTable Qty_MES2SAP_Order_Bas(string Orderid)
        {
            string sql = string.Format(@"if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#XMLTab') and type='U')
                                                          drop table #XMLTab
                                                          else
                                                          CREATE TABLE #XMLTab(ID   int IDENTITY (1,1) not null,TransData xml,TransTime  datetime)

	                                                        INSERT INTO #XMLTab(TransData,TransTime)
                                                        SELECT items.ITEM+trans.OPERATION_DATA as TransData,trans.RowUpdated as TransTime   
	                                                        FROM [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_TRANSFER_ITEMS_$118$] items with(nolock),
	                                                          [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_TRANSFER_$117$] trans
                                                          where trans.[$IDArchiveValue]=items.SAP_TRANSFER_PK and trans.SAP_ORDER ='{0}'

                                                          select t1.SNR as SerialNumber,
                                                          t1.matid as MatNumber,
                                                          (select DefName from [SITMesDB].[dbo].[MMwDefVers] where	
                                                           defid=t1.matid) as MatName,
                                                            (case t1.MoveType when '' then '261'
															when 'X' then '262' end) as MoveType,
                                                            t1.dateTimes as Tran_Date,
                                                           t1.quan as Quantity,
                                                           t1.uom as UOM
                                                          from(
                                                          select 
		                                                        node.c.value('MATERIAL[1]','varchar(20)') as matid,
		                                                        node.c.value('QUANTITY[1]','varchar(8)') as quan,
		                                                        node.c.value('UOM[1]','varchar(8)') as uom,
		                                                        op.v.value('LWO[1]','varchar(20)') as AVO,
		                                                        op.v.value('SERIAL[1]','varchar(20)') as SNR,
                                                                node.c.value('MOVEMENT_TYPE[1]','varchar(5)') as MoveType,
		                                                        node.c.value('PLANT[1]','varchar(20)') as Plant,
		                                                        dateadd(hour,8,bg.TransTime)as dateTimes
		                                                        from #XMLTab bg with(nolock) cross apply TransData.nodes('/ITEM') as node(c) 
					                                                        cross apply TransData.nodes('OPERATION_DATA') as op(v)
		                                                        )t1
                                                        ", Orderid);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据时间段 查询发送至SAP的101物料数据
        /// </summary>
        /// <param name="S_Datetime"></param>
        /// <param name="E_Datetime"></param>
        /// <returns></returns>
        public DataTable Qty_MES2SAP_MatMas_101(string S_Datetime, string E_Datetime)
        {
            string sql = string.Format(@"if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#XMLTab') and type='U')
                                                      drop table #XMLTab
                                                      else
                                                      CREATE TABLE #XMLTab(ID   int IDENTITY (1,1) not null,TransData xml,TransTime  datetime)

	                                                    INSERT INTO #XMLTab(TransData,TransTime)
                                                      select MESSAGE+OPERATION_DATA,dateadd(hour,8,RowUpdated) from [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_TRANSFER_$117$] trans with(nolock)
                                                      where trans.MESSAGE_TYPE='GOODS_RECEIPT' and dateadd(hour,8,RowUpdated) between '{0}' and '{1}'
                                                        
                                                        select dt.MatID,
                                                      (select DefName from
                                                        [SITMesDB].[dbo].[MMwDefVers] where	
                                                        defid=dt.MatID) as MatName,
	                                                    dt.Quantity,
	                                                    dt.OrderID,
	                                                    dt.SerialNumber,
	                                                    dt.WorkOperationID,
	                                                    dt.DateTimes
                                                      from(
                                                      select 
		                                                    node.c.value('MATERIAL[1]','varchar(20)') as MatID,
		                                                    node.c.value('QUANTITY[1]','varchar(8)') as Quantity,
		                                                    substring(node.c.value('ORDER_ID[1]','varchar(12)'),6,12) as OrderID,
		                                                    op.v.value('LWO[1]','varchar(20)') as WorkOperationID,
		                                                    op.v.value('SERIAL[1]','varchar(20)') as SerialNumber,
		                                                    dateadd(hour,8,bg.TransTime)as DateTimes
		                                                    from #XMLTab bg with(nolock) cross apply TransData.nodes('/MESSAGE/ITEM') as node(c) 
					                                                    cross apply TransData.nodes('OPERATION_DATA') as op(v)
					                                                    )dt", S_Datetime, E_Datetime);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过 order id查询 interlock object FHM等
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable Qty_Order_ItlkObj(string OrderID)
        {
            string sql = string.Format(@"
                                                        Use SITMesDB
                                                        SELECT distinct
                                                        EP.ERP_OPERATION_ID as AVO_ID,
                                                        POMV_ETRY.pom_entry_type_id as AVO,
                                                        EP.WO_DESCR as AVO_Desc,
                                                        EP.WORKFLOW as Workflow,
                                                        WC.MACHINE_ID as Terminal,
                                                        Mapping.TERMINAL as T_Terminal,
                                                        POMV_ETRY.ERP_WRKCNTR as SAP_OBJID,
                                                        EEES.FHM_ID as S7_Equipment,
                                                        cast(prp2.VAL as Integer) as LoopCycleMax,
                                                        EP.CONTROL_KEY as CONTROL_KEY,
                                                        cast(POMV_ETRY_PRP.VAL as integer) as Interlocking_Code,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 1 as Itlk_LoopCycle,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 2 as Itlk_ProcessRouting,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 4 as Itlk_SNRStatus,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 512 as Itlk_OrderStatus,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 32768 as Itlk_SetupShopfloor,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 65536 as Itlk_SetupMatlabel,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 131072 as Itlk_SetupTools,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 262144 as Itlk_DelayBtwnAvos,
                                                        dateadd(hour,8,EP.RowUpdated) as DateTimes
                                                        FROM POMV_ETRY with(nolock)
                                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EP ON POMV_ETRY.pom_entry_pk = EP.MES_RECORD_PK
                                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_SHOPFLOOR] EEES ON EEES.MES_RECORD_PK = EP.MES_RECORD_PK and EEES.FHM_TYPE = 'G'
                                                        INNER JOIN [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS] WC ON POMV_ETRY.ERP_WRKCNTR = WC.WORKCENTER_ID
                                                        INNER JOIN POMV_ETRY_PRP ON POMV_ETRY.pom_entry_pk = POMV_ETRY_PRP.pom_entry_pk and POMV_ETRY_PRP.pom_custom_fld_name = 'ITLK_CODE'
                                                        INNER JOIN POMV_ETRY_PRP  prp2 ON POMV_ETRY.pom_entry_pk = prp2.pom_entry_pk and prp2.pom_custom_fld_name = 'ITLK_MAX_LOOPS'
                                                        INNER JOIN [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_TERMINAL_MAPPING_$91$] Mapping on Mapping.MACHINE_ID=WC.MACHINE_ID and Mapping.EQUIPMENT_ID=''
                                                        WHERE
                                                        POMV_ETRY.pom_order_id = '{0}'
                                                        --order by 1
														union all

                                                        SELECT distinct
                                                        EP.ERP_OPERATION_ID as AVO_ID,
                                                        POMV_ETRY.pom_entry_type_id as AVO,
                                                        EP.WO_DESCR as AVO_Desc,
                                                        EP.WORKFLOW as Workflow,
                                                        WC.MACHINE_ID as Terminal,
                                                        Mapping.TERMINAL as T_Terminal,
                                                        POMV_ETRY.ERP_WRKCNTR as SAP_OBJID,
                                                        EEES.FHM_ID as S7_Equipment,
                                                        cast(prp2.VAL as Integer) as LoopCycleMax,
                                                        EP.CONTROL_KEY as CONTROL_KEY,
                                                        cast(POMV_ETRY_PRP.VAL as integer) as Interlocking_Code,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 1 as Itlk_LoopCycle,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 2 as Itlk_ProcessRouting,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 4 as Itlk_SNRStatus,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 512 as Itlk_OrderStatus,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 32768 as Itlk_SetupShopfloor,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 65536 as Itlk_SetupMatlabel,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 131072 as Itlk_SetupTools,
                                                        cast(POMV_ETRY_PRP.VAL as integer) & 262144 as Itlk_DelayBtwnAvos,
                                                        dateadd(hour,8,EP.RowUpdated) as DateTimes
                                                        FROM POMV_ETRY with(nolock)
                                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EP ON POMV_ETRY.pom_entry_pk = EP.MES_RECORD_PK
                                                        INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_SHOPFLOOR] EEES ON EEES.MES_RECORD_PK = EP.MES_RECORD_PK and EEES.FHM_TYPE = 'G'
                                                        INNER JOIN [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS] WC ON POMV_ETRY.ERP_WRKCNTR = WC.WORKCENTER_ID
                                                        INNER JOIN POMV_ETRY_PRP ON POMV_ETRY.pom_entry_pk = POMV_ETRY_PRP.pom_entry_pk and POMV_ETRY_PRP.pom_custom_fld_name = 'ITLK_CODE'
                                                        INNER JOIN POMV_ETRY_PRP  prp2 ON POMV_ETRY.pom_entry_pk = prp2.pom_entry_pk and prp2.pom_custom_fld_name = 'ITLK_MAX_LOOPS'
                                                        INNER JOIN [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_TERMINAL_MAPPING_$91$] Mapping on Mapping.MACHINE_ID=WC.MACHINE_ID and Mapping.EQUIPMENT_ID=EEES.FHM_ID
                                                        WHERE
                                                        POMV_ETRY.pom_order_id = '{0}'
                                                        order by 1", OrderID);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 工单的简单字段查询
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public DataTable Qty_Order_Simple(string OrderID)
        {
            string sql = string.Format(@"
                                                        Use SITMesDB
                SELECT distinct
                EP.ERP_OPERATION_ID as AVO_ID,
		        WC.MACHINE_ID as Terminal,
                POMV_ETRY.pom_entry_type_id as AVO,
                EP.WO_DESCR as AVO_Desc,
                EP.WORKFLOW as Workflow,
		        EP.CONTROL_KEY as CONTROL_KEY,
        
                dateadd(hour,8,EP.RowUpdated) as DateTimes
                FROM POMV_ETRY with(nolock)
                INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EP ON POMV_ETRY.pom_entry_pk = EP.MES_RECORD_PK
                INNER JOIN [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS] WC ON POMV_ETRY.ERP_WRKCNTR = WC.WORKCENTER_ID
                WHERE
                POMV_ETRY.pom_order_id = '{0}'", OrderID);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }




        /// <summary>
        /// 通过工单号，SNR号查询测量值数据，序列号可以模糊查询 查询条件可为 %
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_MeasureValue(string OrderID,string SNR)
        {
            string sql = string.Format(@"
                                                        USE SITMesDB							
                                                        SELECT							
                                                        EC_MEAS.SERIAL_NUMBER,							
                                                        PMG.GROUP_ID as LINE_ID,							
                                                        EC_MEAS.TERMINAL_ID as TERMINAL,							
                                                        EEP.ERP_OPERATION_ID as AVO_ID,							
                                                        EC_MEAS.WO_ID as WorkOperationID,							
                                                        EEP.WO_DESCR as AVO_Desc,							
                                                        EC_MEAS.EQUIPMENT_ID as EQUIPMENT_ID,							
                                                        (case EC_MEAS.STATUS when '0' then 'Good'							
	                                                        when '1' then 'Failed' end) as ValueStatus,						
                                                        EC_MEAS.MEASUREMENT_ID,							
                                                        EC_MEAS.MEASUREMENT_TYPE,							
                                                        EC_MEAS.LOWER_LIMIT,							
                                                        EC_MEAS.MEASUREMENT,							
                                                        EC_MEAS.UPPER_LIMIT,							
                                                        EC_MEAS.TARGET_VALUE,							
                                                        EC_MEAS.UNIT,							
                                                        EC_MEAS.MACHINE_CYCLE,							
                                                        EC_MEAS.DEVICE,							
                                                        dateadd(hour,8,EC_MEAS.TIMESTAMP) as PLC_Time,							
                                                        dateadd(hour,8,EC_MEAS.RowUpdated) as MES_Time,							
                                                        EEP.WORKFLOW as Workflow,							
                                                        EC_MEAS.FILE_PATH,							
                                                        EC_MEAS.FILE_NAME							
                                                        FROM							
                                                        [ArchSitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_MEASUREMENTS] EC_MEAS WITH (NOLOCK)							
                                                        LEFT JOIN POMV_ETRY WITH (NOLOCK) ON POMV_ETRY.pom_order_id = EC_MEAS.ORDER_ID and POMV_ETRY.pom_entry_type_id = EC_MEAS.WO_ID							
                                                        LEFT JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP WITH (NOLOCK) on POMV_ETRY.pom_entry_pk = EEP.MES_RECORD_PK							
                                                        LEFT JOIN [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/ML_PROCESS_MACHINE_GROUP] PMG WITH (NOLOCK) on PMG.MACHINE_ID = EC_MEAS.TERMINAL_ID and PMG.PROCESS_STEP = EC_MEAS.WO_ID							
                                                        WHERE							
                                                        EC_MEAS.MEASUREMENT like '%' and							
                                                        ORDER_ID like '{0}' and							
                                                        SERIAL_NUMBER like '{1}' and							
                                                        TERMINAL_ID like '%' and							
                                                        WO_ID like '%' and							
                                                        MEASUREMENT_ID like '%' and							
                                                        STATUS like '%' -- 0 = 'IO' / 1 = 'NIO'							
                                                        order by 4,18							
                                                        ", OrderID, SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过序列号与数值联合查询，查询测量值记录
        /// </summary>
        /// <param name="SNR"></param>
        /// <param name="Vals"></param>
        /// <returns></returns>
        public DataTable Qty_Measure_SNR_Val(string SNR, string Vals)
        {
            string sql = string.Format(@"
                                                        USE SITMesDB							
                                                        SELECT							
                                                        EC_MEAS.SERIAL_NUMBER,							
                                                        PMG.GROUP_ID as LINE_ID,							
                                                        EC_MEAS.TERMINAL_ID as TERMINAL,							
                                                        EEP.ERP_OPERATION_ID as AVO_ID,							
                                                        EC_MEAS.WO_ID as WorkOperationID,							
                                                        EEP.WO_DESCR as AVO_Desc,							
                                                        EC_MEAS.EQUIPMENT_ID as EQUIPMENT_ID,							
                                                        (case EC_MEAS.STATUS when '0' then 'Good'							
	                                                        when '1' then 'Failed' end) as ValueStatus,						
                                                        EC_MEAS.MEASUREMENT_ID,							
                                                        EC_MEAS.MEASUREMENT_TYPE,							
                                                        EC_MEAS.LOWER_LIMIT,							
                                                        EC_MEAS.MEASUREMENT,							
                                                        EC_MEAS.UPPER_LIMIT,							
                                                        EC_MEAS.TARGET_VALUE,							
                                                        EC_MEAS.UNIT,							
                                                        EC_MEAS.MACHINE_CYCLE,							
                                                        EC_MEAS.DEVICE,							
                                                        dateadd(hour,8,EC_MEAS.TIMESTAMP) as PLC_Time,							
                                                        dateadd(hour,8,EC_MEAS.RowUpdated) as MES_Time,							
                                                        EEP.WORKFLOW as Workflow,							
                                                        EC_MEAS.FILE_PATH,							
                                                        EC_MEAS.FILE_NAME							
                                                        FROM							
                                                        [ArchSitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_MEASUREMENTS] EC_MEAS WITH (NOLOCK)							
                                                        LEFT JOIN POMV_ETRY WITH (NOLOCK) ON POMV_ETRY.pom_order_id = EC_MEAS.ORDER_ID and POMV_ETRY.pom_entry_type_id = EC_MEAS.WO_ID							
                                                        LEFT JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_PROPERTIES] EEP WITH (NOLOCK) on POMV_ETRY.pom_entry_pk = EEP.MES_RECORD_PK							
                                                        LEFT JOIN [Arch_RPT_MGR_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/ML_PROCESS_MACHINE_GROUP] PMG WITH (NOLOCK) on PMG.MACHINE_ID = EC_MEAS.TERMINAL_ID and PMG.PROCESS_STEP = EC_MEAS.WO_ID							
                                                        WHERE							
                                                        EC_MEAS.MEASUREMENT like '%{1}%' and							
                                                        ORDER_ID like '%' and							
                                                        SERIAL_NUMBER = '{0}' and							
                                                        TERMINAL_ID like '%' and							
                                                        WO_ID like '%' and							
                                                        MEASUREMENT_ID like '%' and							
                                                        STATUS like '%' -- 0 = 'IO' / 1 = 'NIO'							
                                                        order by 4,18						
                                                        ", SNR, Vals);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询接口是否有未发送数据
        /// </summary>
        /// <returns></returns>
        public DataTable Qty_MES2SAP_Blocked()
        {
            string sql = string.Format(@"
                                                        SELECT count(*) as Un_Sent_Idoc							
                                                    FROM  [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_TRANSFER_$117$]							
                                                    with (nolock)							
                                                    where sent =0					
                                                    ");

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 查看未发送的 261 101报文
        /// </summary>
        /// <returns></returns>
        public DataTable Qty_MES2SAP_UnSentRecord()
        {
            string sql = string.Format(@"
                                                        select SAP_ORDER, MESSAGE as MessageContent,OPERATION_DATA,MESSAGE_TYPE,SAP_ERROR,SENT as SentStatus,
                                                    dateadd(hour,8,RowUpdated) as DateTimes						
                                                    FROM  [SitMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_TRANSFER_$117$]							
                                                    with (nolock)							
                                                    where sent =0							
                                                    order by RowUpdated  asc");

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 找出物料A与物料B 共同装配于哪些序列号上 ！按时间段查询 防止数据量过大
        /// </summary>
        /// <param name="MatA"></param>
        /// <param name="MatB"></param>
        /// <param name="TimeS"></param>
        /// <param name="TimeE"></param>
        /// <returns></returns>
        public DataTable Qty_Material2Unique(string MatA,string MatB,string TimeS,string TimeE)
        {
            string sql = string.Format(@"
                                                        SELECT A.TARGET_LOT as TARGET_SNR,A.LOT_ID as UiqueID_A,B.LOT_ID as UiqueID_B,dateadd(hour,8,A.RowUpdated) as DateTimes  FROM									
                                    (									
                                    SELECT RowUpdated,TARGET_LOT,COMPONENT_ID,LOT_ID									
                                    FROM [SitMesDB].[dbo].[ARCH_T_SitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_GENEALOGY_MATLABEL_$107$]									
                                    with (nolock)									
                                    where COMPONENT_ID='{0}' AND dateadd(hour,8,RowUpdated) between '{2}' and '{3}'									
                                    ) A LEFT JOIN  [SitMesDB].[dbo].[ARCH_T_SitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ENTRY_EXT_GENEALOGY_MATLABEL_$107$]									
                                    B WITH (NOLOCK) ON A.TARGET_LOT=B.TARGET_LOT WHERE B.COMPONENT_ID='{1}'",MatA,MatB,TimeS,TimeE);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 通过成品物料号 查询对应的工单号
        /// </summary>
        /// <param name="MatA"></param>
        /// <returns></returns>
        public DataTable Qty_GetOrderFromMat(string MatA)
        {
            string sql = string.Format(@"
                                                        SELECT																								
	                                                    POM_ORDER.pom_order_id AS OrderID,																								
	                                                    MMDefinitions.DefName AS MaterialDescription,																								
	                                                    MMDefinitions.DefID AS MaterialNum,																								
	                                                    POM_ORDER_STATUS.id AS Order_Status,																																											
	                                                    POM_ENTRY.initial_qty AS Quantity,																								
	                                                    POM_ORDER.RowUpdated as MESUpdateTime,																								
	                                                    oep.RowUpdated as ImportMESTime																								
	                                                    FROM																								
	                                                    POM_ORDER																								
	                                                    INNER JOIN POM_ORDER_STATUS ON POM_ORDER.pom_order_status_pk = POM_ORDER_STATUS.pom_order_status_pk																								
																							
	                                                    INNER JOIN POM_ENTRY ON POM_ORDER.pom_order_pk = POM_ENTRY.pom_order_pk AND POM_ENTRY.order_extended_data = N'Y'																								
	                                                    INNER JOIN POM_CUSTOM_FIELD_RT ON POM_ENTRY.pom_entry_pk = POM_CUSTOM_FIELD_RT.pom_entry_pk AND POM_CUSTOM_FIELD_RT.pom_custom_fld_name = N'BOM_NAME'																								
	                                                    inner JOIN MMDefinitions on MMDefinitions.DefID = POM_ENTRY.matl_def_id																								
	                                                    INNER JOIN [ArchSitMesPomRTF8F959F4-452B-462E-BA33-DB852EFDA899/EC_ORDER_EXT_PROPERTIES] oep on oep.MES_RECORD_PK = POM_ORDER.pom_order_pk	
	                                                    where MMDefinitions.DefID like '%{0}%'
	                                                    order by oep.RowUpdated desc		
	                                                    ", MatA);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 输入 过滤字符串 查看表：EC_SETUP_MAT_LABEL_TEMP 时候存在不合理SNRs
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public DataTable Qty_SNR_Std_Filter(string Str)
        {
            string sql = string.Format(@"Use SITMesDB

                                                        select 
                                                        MACHINE_ID as WorkOperationID, 
                                                        PROCESS_STEP as TerminalID,
                                                        ORDER_ID,
                                                        SERIALNUMBER,
                                                        COMPONENT_ID as MaterialNum,
                                                        UNIKAT as UniqueID,
                                                        EQUIPMENT_ID,
                                                        SETUP_STATE,
                                                        dateadd(hour,8,rowupdated) as ChangeTime,
                                                        LIFNR as SupplierID,
                                                        PACKID as PackageID,
                                                        [$IDArchiveValue]
                                                        FROM [SITMesDB].[dbo].[ArchSitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SETUP_MAT_LABEL_TEMP]
                                                            WHERE SERIALNUMBER IN
                                                            (
                                                            SELECT LotName
                                                            FROM [SitMesDB].[dbo].MMLots
                                                            where LotStatusPK in ({0})
                                                            )
                                                        ", Str);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询产线打印机配置情况!
        /// </summary>
        /// <returns></returns>
        public DataTable Qty_EC_Printer()
        {
            string sql = string.Format(@"Use SITMesDB
             SELECT [$IDArchiveValue]
                  ,[PRINTER]
                 ,[GROUP_ID]
                  ,[LAYOUT_ID]
                  ,[PRINTER_TYPE]
                  ,convert(char(16),dateadd(hour,8,[RowUpdated]),120) as DateTimes
                  ,[EQUIPMENT_ID]
                  ,[MACHINE_ID]
              FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_PRINTER_$94$] ");

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// get printer layout table data
        /// </summary>
        /// <returns></returns>
        public DataTable EC_PRINTER_LAYOUTS()
        {
            string sql = string.Format(@"Use SITMesDB
             SELECT 
      [$IDArchiveValue]
      ,[LAYOUT]
      ,[LAYOUT_TYPE]
  FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_PRINTER_LAYOUTS_$95$]");

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据 equipment id设备号查询 CO表配置
        /// </summary>
        /// <param name="MachineID"></param>
        /// <returns></returns>
        public DataTable EC_Config_Qty(string MachineID)
        {
            string sql = string.Format(@"Use SITMesDB
              SELECT distinct									
ML_process.GROUP_ID as LineID,									
Mapping.MACHINE_ID,									
Mapping.PROCESS_STEP,									
Mapping.TERMINAL MappingTerminal,									
TerName.TERMINAL as TerminalName,									
sap.WORKCENTER_ID as ObjectID,									
Mapping.EQUIPMENT_ID,									
Mapping.RowUpdated									
FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_TERMINAL_MAPPING_$91$] Mapping with(nolock)									
left join  [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_TERMINAL_NAMES_$92$] TerName									
on Mapping.TERMINAL=TerName.TERMINAL									
inner join [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/ML_PROCESS_MACHINE_GROUP_$8$] ML_process									
on Mapping.MACHINE_ID=ML_process.MACHINE_ID									
left join [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_SAP_WORKCENTERS_$97$] Sap									
on Mapping.MACHINE_ID=sap.MACHINE_ID									
where mapping.MACHINE_ID like '%{0}%'									
",MachineID);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据载具号 序列号查询信息 序列号和载具号不能同时存在！
        /// </summary>
        /// <param name="Hut"></param>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_HUT_SNR(string Hut,string SNR)
        {

            string sql = string.Empty;

            if (!string.IsNullOrEmpty(Hut))
            {
                sql = string.Format(@"Use SITMesDB
            SELECT  
      [$IDArchiveValue] as PK
      ,[HUT_ID]
      ,[SERIAL_NUMBER]
      ,dateadd(hour,8,[RowUpdated]) as DateTimes
  FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_HUT_ALLOCATION_$80$] with(nolock)
  where HUT_ID like '%{0}%' ", Hut);
            }

            if (!string.IsNullOrEmpty(SNR))
            {
                sql = string.Format(@"Use SITMesDB
            SELECT  
      [$IDArchiveValue] as PK
      ,[HUT_ID]
      ,[SERIAL_NUMBER]
      ,dateadd(hour,8,[RowUpdated]) as DateTimes
  FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_HUT_ALLOCATION_$80$] with(nolock)
  where SERIAL_NUMBER like '%{0}%' ", SNR);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询CO 自定义载具历史记录表
        /// </summary>
        /// <param name="Hut"></param>
        /// <param name="SNR"></param>
        /// <returns></returns>
        public DataTable Qty_HUT_History(string Hut, string SNR,string DTimePickerDay)
        {

            string sql = string.Empty;

            if (!string.IsNullOrEmpty(Hut))
            {
                sql = string.Format(@" Use [EC_SitMesDB-Extension]
                          SELECT  
                              [ArcPK] 
                              ,[HUT_Number]
                              ,[SNRs] as [SERIAL_NUMBER]
                              ,[HUT_ID]
	                          ,[RowUpdated]
                              ,[CurrentDateTime]
                              ,[Remark1]
                          FROM [EC_SitMesDB-Extension].[dbo].[EC_CO_HUT_History] with(nolock)
                          where HUT_ID like '%{0}%' and convert(char(10),[RowUpdated],120)='{1}'", Hut, DTimePickerDay);
            }

            if (!string.IsNullOrEmpty(SNR))
            {
                sql = string.Format(@" Use [EC_SitMesDB-Extension]
                          SELECT  
                              [ArcPK] 
                              ,[HUT_Number]
                              ,[SNRs] as [SERIAL_NUMBER]
                              ,[HUT_ID]
	                          ,[RowUpdated]
                              ,[CurrentDateTime]
                              ,[Remark1]
                          FROM [EC_SitMesDB-Extension].[dbo].[EC_CO_HUT_History] with(nolock)
                          where [SNRs]  like '%{0}%'", SNR);
            }

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// 载具历史数据自定义表 在Q中插入时间周期数据
        /// </summary>
        /// <param name="Hut"></param>
        /// <returns></returns>
        public  DataTable Insertinto_HUT_SNR(string Hut)
        {

            string sql_ReadFrom_P = string.Empty;

            string sql_ReadFrom_Q = string.Empty;

            DataTable dt_From_P = new DataTable();

            DataTable dt_ReadFrom_Q = new DataTable();

            DataTable dt3 = new DataTable();

            
            dt3.Columns.Add("ArcPK", typeof(string));
            dt3.Columns.Add("HUT_Number", typeof(string));
            dt3.Columns.Add("SERIAL_NUMBER", typeof(string));
            dt3.Columns.Add("HUT_ID", typeof(string));
            dt3.Columns.Add("RowUpdated", typeof(string));
            dt3.Columns.Add("CurrentDateTime", typeof(string));
            dt3.Columns.Add("ProductionLine", typeof(string));

            if (DbConn("NewServer") == "ok")
            {
                if (!string.IsNullOrEmpty(Hut))
                {
                    sql_ReadFrom_P = string.Format(@"
                  SELECT [$IDArchiveValue] as ArcPK,								
                [HUT_ID],								
                SERIAL_NUMBER,								
                dateadd(HOUR,8,RowUpdated) as RowUpdated								
                FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_HUT_ALLOCATION_$80$] a with(nolock)								
                where a.HUT_ID like  '%{0}%' ", Hut);

                }
                dt_From_P = SQLSet(sql_ReadFrom_P);
            }

            if (DbConn("Q_connString") == "ok") //此处操作Q系统库
            {
                if (dt_From_P != null && dt_From_P.Rows.Count > 0)
                {
                    sql_ReadFrom_Q= string.Format(@"
                  SELECT  [Hut_Num]
                      ,[Hut_ID]
                      ,[Production_Line]
                      ,getdate() as [CurrentDateTime]
                  FROM [EC_SitMesDB-Extension].[dbo].[EC_CO_HutName_Mapping]");

                    dt_ReadFrom_Q = SQLSet(sql_ReadFrom_Q);

                    if (dt_From_P != null && dt_From_P.Rows.Count > 0)
                    {
                        var query = from p in dt_From_P.AsEnumerable()
                                  join q in dt_ReadFrom_Q.AsEnumerable()
                                 on p["HUT_ID"].ToString() equals q["Hut_ID"].ToString()
                                  select new
                                  {
                                      P_ArcPK=p["ArcPK"],
                                      HutNum = q["Hut_Num"],
                                      SerialNumber=p["SERIAL_NUMBER"],
                                      HutID = p["HUT_ID"],
                                      RowUpdated =p["RowUpdated"],
                                      CurrentDateTime =q["CurrentDateTime"],
                                      ProdLine = q["Production_Line"]
                                  };

                        query.ToList().ForEach(qr => dt3.Rows.Add(qr.P_ArcPK,qr.HutNum, qr.SerialNumber, qr.HutID, qr.RowUpdated,qr.CurrentDateTime,qr.ProdLine));
                    }


                                           
                    using (SqlConnection destinationConnection = new SqlConnection(DBConnStr))
                    {
                        destinationConnection.Open();
                        using (SqlBulkCopy sqlbulecopy = new SqlBulkCopy(destinationConnection))
                        {
                            try
                            {
                                sqlbulecopy.DestinationTableName = "[EC_SitMesDB-Extension].[dbo].[EC_CO_HUT_History]";
                                sqlbulecopy.BatchSize = dt_From_P.Rows.Count;
                                sqlbulecopy.ColumnMappings.Add("ArcPK", "[ArcPK]"); //第一个是dt中的字段，第二个是写入表的字段
                                sqlbulecopy.ColumnMappings.Add("HUT_Number", "[HUT_Number]");
                                sqlbulecopy.ColumnMappings.Add("SERIAL_NUMBER", "[SNRs]");
                                sqlbulecopy.ColumnMappings.Add("HUT_ID", "[HUT_ID]");
                                sqlbulecopy.ColumnMappings.Add("RowUpdated", "[RowUpdated]");
                                sqlbulecopy.ColumnMappings.Add("CurrentDateTime", "[CurrentDateTime]");
                                sqlbulecopy.ColumnMappings.Add("ProductionLine", "[Remark1]");

                                sqlbulecopy.WriteToServer(dt3);
                            }
                            catch (Exception e)
                            {
                                return null;
                            }
                        }

                        destinationConnection.Close();
                    }
                    
                                        
                }
                    
            }
            
            return dt_From_P;
        }


        /// <summary>
        /// 监控定子电测及浸漆 测量值
        /// </summary>
        /// <param name="Interval"></param>
        /// <returns></returns>
        public DataTable Get_Meas_T_Test_SNR(int Interval)
        {
            //string sql = string.Format(@"select LOT_PK,(select mmlot.LotName FROM [SITMesDB].[dbo].[MMLots] mmlot with(nolock)
            //     where LOT_PK=mmlot.LotPK) LotName,DATEADD(hour,8,RowUpdated) as ChinaTime
            //      FROM [SitMesDb].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_ROUTE_$112$] rt with(nolock)
            //      where entry_type_pk=102 and ROUTE_POS_STATUS='prcs' --1小时内 过电测站的件
            //       and DATEADD(hour,{0},RowUpdated)>= '2020-04-30 06:01:22.250' and DATEADD(hour,{0},RowUpdated)<='2020-05-07 07:39:19.127'
            //       and LOT_PK in 
            //       (select LOT_PK
            //       FROM [SitMesDb].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_ROUTE_$112$] im with(nolock)
            //       where entry_type_pk=202 and ROUTE_POS_STATUS='' --1小时内 未过浸漆站的件
            //        and DATEADD(hour,{0},RowUpdated)>= '2020-04-30 06:01:22.250' and DATEADD(hour,{0},RowUpdated)<='2020-05-07 07:39:19.127')
            //    ", Interval);

            string sql = string.Format(@"select LOT_PK,(select mmlot.LotName FROM [SITMesDB].[dbo].[MMLots] mmlot with(nolock)
                 where LOT_PK=mmlot.LotPK) LotName,DATEADD(hour,8,RowUpdated) as ChinaTime
                  FROM [SitMesDb].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_ROUTE_$112$] rt with(nolock)
                  where entry_type_pk=2114 and ROUTE_POS_STATUS='prcs' --1小时内 过电测站的件
                   and DATEADD(hour,8,RowUpdated)>= DATEADD(hour,-{0},getdate()) and DATEADD(hour,8,RowUpdated)<=GETDATE()
                   and LOT_PK in 
                   (select LOT_PK
                   FROM [SitMesDb].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_LOT_ROUTE_$112$] im with(nolock)
                   where entry_type_pk=2094 and ROUTE_POS_STATUS='' --1小时内 未过浸漆站的件
                    and DATEADD(hour,8,RowUpdated)>= DATEADD(hour,-{0},getdate()) and DATEADD(hour,8,RowUpdated)<=GETDATE())", Interval);


            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public DataTable Qty_Meas_T_Test_SNR(string SNR)
        {
            string sql = string.Format(@"select MEASUREMENT_TYPE,EQUIPMENT_ID,DEVICE,ORDER_ID,TERMINAL_ID,MEASUREMENT_ID,MEASUREMENT,DATEADD(hour,8,RowUpdated) as ChinaTime
		FROM [SITMesDB].[dbo].[ARCH_T_SitMesComponentRT1A8997AF-5067-47d5-80DB-AF14C4BD2402/EC_MEASUREMENTS_$86$] with(nolock)
		where SERIAL_NUMBER='{0}' and WO_ID='T_TEST'", SNR);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }





        /// <summary>
        /// 通过唯一件 唯一码进行递归查询
        /// LotID 料号+唯一码；SerialNumber 序列号；uniqueCode 唯一码；时间
        /// </summary>
        /// <param name="UniqueCode"></param>
        /// <returns></returns>
        public DataTable Qty_CTEMat(string UniqueCode)
        {
            //string sql = string.Format(@"with cte as
            //                                            (
            //                                            select snr.LotID,snr.LotName SerialNumber,uniqueID.LotName as uniqueCode
            //                                            ,snr.RowUpdated as changetime
            //                                            FROM [SitMesDb].[dbo].[MMLots] snr
            //                                            with(nolock)
            //                                            inner join [SitMesDb].[dbo].[MMLots] uniqueID
            //                                            on snr.LotPK=uniqueID.TargetLotPK
            //                                            where uniqueID.LotName = '{0}'
            //                                            union all
            //                                             select A.LotID,A.SerialNumber,A.uniqueCode,A.changetime from
            //                                             (select snr.LotID,snr.LotName SerialNumber,uniqueID.LotName as uniqueCode
            //                                              ,snr.RowUpdated as changetime
            //                                              FROM [SitMesDb].[dbo].[MMLots] snr
            //                                              with(nolock)
            //                                              inner join [SitMesDb].[dbo].[MMLots] uniqueID
            //                                              on snr.LotPK=uniqueID.TargetLotPK

            //                                             ) A inner join cte
            //                                             on A.uniqueCode=cte.SerialNumber
            //                                            )
            //                                            select * from cte", UniqueCode);

            string sql = string.Format(@"with cte as
                                                        (
                                                        select snr.LotID,snr.LotName SerialNumber,uniqueID.LotName as uniqueCode
                                                        ,snr.RowUpdated as changetime
                                                        FROM [SitMesDb].[dbo].[MMLots] snr
                                                        with(nolock)
                                                        inner join [SitMesDb].[dbo].[MMLots] uniqueID
                                                        on snr.LotPK=uniqueID.TargetLotPK
                                                        where uniqueID.LotName = '{0}'
                                                        union all
	                                                        select A.LotID,A.SerialNumber,A.uniqueCode,A.changetime from
	                                                        (select snr.LotID,snr.LotName SerialNumber,uniqueID.LotName as uniqueCode
		                                                        ,snr.RowUpdated as changetime
		                                                        FROM [SitMesDb].[dbo].[MMLots] snr
		                                                        with(nolock)
		                                                        inner join [SitMesDb].[dbo].[MMLots] uniqueID
		                                                        on snr.LotPK=uniqueID.TargetLotPK
		
	                                                        ) A inner join cte
	                                                        on A.uniqueCode=cte.SerialNumber
                                                        )
                                                        select * from cte
                                                        union all
                                                        select '1','{0}','1',''
                                                        order by changetime desc", UniqueCode);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// DefVerPK, DefID,DefName 通过物料号 获取物料名称与PK号
        /// </summary>
        /// <param name="MatID"></param>
        /// <returns></returns>
        public DataTable Qty_MMwDefVers_MatDesc(string MatID)
        {
            string sql = string.Format(@"select DefVerPK, DefID,DefName from MMwDefVers
                                                            where defid='{0}'", MatID);

            DataTable dt = new DataTable();

            try
            {
                dt = SQLSet(sql);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


    /// <summary>
    /// 文件处理类
    /// </summary>
    public class FileHelper
    {
        public static Class_User.UserModel Umodel = new Class_User.UserModel();
        public static FileHelper fileHelper = new FileHelper();

        /// <summary>
        /// 得到当前路径下所有子目录
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public static List<string> GetAllDirectories(string rootPath)
        {
            
            string[] subPaths = System.IO.Directory.GetDirectories(rootPath);//得到所有子目录
            List<string> lis = new List<string>();

            foreach (string path in subPaths)
            {

                GetAllDirectories(path);//对每一个子目录做与根目录相同的操作：即找到子目录并将当前目录的文件名存入List

            }

            string[] files = System.IO.Directory.GetFiles(rootPath);

            foreach (string file in files)
            {

                Umodel.AllFiles.Add(file);//将当前目录中的所有文件全名存入文件List

            }

            return Umodel.AllFiles;


        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool MkDir(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);

                return true;
            }

            return false;
        }

        public bool WriteTxt(string path,string txts)
        {
            
            try
            {
                if (!System.IO.Directory.Exists(path)) //不存在文件夹
                {
                    FileHelper.MkDir(path);
                         
                    using (StreamWriter sw1 = new StreamWriter(path + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true))
                    {
                        sw1.WriteLine(txts + ";WriteTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw1.WriteLine("-", 0, 10);
                        sw1.Close();
                    }
                    
                }
                else //文件夹已存在
                {
                    using (StreamWriter sw1 = new StreamWriter(path + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true))
                    {
                        sw1.WriteLine(txts + ";WriteTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw1.WriteLine("-", 0, 10);
                        sw1.Close();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}
