using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WindowsFormsVSeA
{
    class Class_User
    {

    }

    #region //XML 文件处理
    public class XmlDo
    {

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
                        dr[3] = SSAP.Any() ? port.ElementAt(0) : "NOK";

                        var TSAP = (from da in Dnod.Descendants("PARAMETERS").Descendants("TSAP")
                                    select da.Value);
                        dr[4] = TSAP.Any() ? port.ElementAt(0) : "NOK";

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

}
