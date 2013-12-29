using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;
using System.Collections;
using SAPINT.Idocs;
using System.IO;
using SAPINT.Idocs.Meta;
using SAPINT.RFCTable;


namespace MiniServer
{
   public class Program
    {
        /// <summary>
        /// http://www.sdn.sap.com/irj/scn/weblogs?blog=/pub/wlg/23051
        /// </summary>
        /// <param name="args"></param>
       public static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("服务器启动，加载SAP配置！！");
            Console.WriteLine("服务器启动，加载SAP配置！！");
            try
            {
                
                SAPINT.SapConfig.SAPConfigFromFile.LoadSAPAllConfig();

                //1 Register the relevant destination object.
                //2 Get the destination corresponding to the ABAP system you want to call.
                //3 Next you need a repository for the metadata from the ABAP Dictionary of the corresponding destination system.
                //4 Create a function object (that will hold the values of the relevant parameters)
                //5 Provide the values for the relevant importing parameters of the function.
                //6 Execute the function.
                //7 Read the exporting or returning parameters and process them.


                // RfcDestinationManager.RegisterDestinationConfiguration(new MyBackendConfig());//1
                // RfcServerManager.RegisterServerConfiguration(new MyServerConfig());//2

                Type[] handlers = new Type[1] { typeof(MiniServerHandler) };//3
                string defaultServer = ConfigFileTool.SAPGlobalSettings.GetDefultSAPServer();
                Console.WriteLine("Default server is : " + defaultServer);
                RfcServer server = RfcServerManager.GetServer(defaultServer, handlers);//3

                server.RfcServerError += OnRfcServerError;
                server.RfcServerApplicationError += OnRfcServerApplicationError;

                if (server.TransactionIDHandler == null) { server.TransactionIDHandler = new MyTidHandler(); }

                server.Start();//4

                Console.WriteLine();
                Console.WriteLine("Server started: {0}", server.Parameters.ToString());
                Console.WriteLine("You can now send requests for STFC_CONNECTION (synchronous or in background task) -- press X to stop the server");
                while (true)
                {
                    if (Console.ReadLine().Equals("X")) break;
                }
                server.Shutdown(true); //Shuts down 
                server.RfcServerError -= OnRfcServerError;
                server.RfcServerApplicationError -= OnRfcServerApplicationError;
                server.TransactionIDHandler = null;
                //immediately aborting ongoing requests.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurs," + ex.Message);
                
                Console.ReadLine();
                //throw;
            }

        }

        private static void OnRfcServerError(Object server, RfcServerErrorEventArgs errorEventData)
        {
            RfcServer rfcServer = server as RfcServer;
            Console.WriteLine();
            Console.WriteLine(">>>>> RfcServerError occurred in RFC server {0}:", rfcServer.Name);
            Console.WriteLine(errorEventData.Error);
            //  ShowErrorEventData(errorEventData);
        }

        private static void OnRfcServerApplicationError(Object server, RfcServerErrorEventArgs errorEventData)
        {
            RfcServer rfcServer = server as RfcServer;
            Console.WriteLine();
            Console.WriteLine(">>>>> RfcServerApplicationError occurred in RFC server {0}:", rfcServer.Name);
            Console.WriteLine(errorEventData.Error);
            // ShowErrorEventData(errorEventData);
            RfcServerApplicationException appEx = errorEventData.Error as RfcServerApplicationException;
            if (appEx != null)
            {
                Console.WriteLine("Inner exception type: {0}", appEx.InnerException.GetType().Name);
                Console.WriteLine("Inner exception message: {0}", appEx.InnerException.Message);
            }
            else
            {
                Console.WriteLine("WARNING: errorEventData.Error is not an instance of RfcServerApplicationError");
            }
        }
    }



    public class MiniServerHandler
    {
        [RfcServerFunction(Name = "STFC_CONNECTION")]
        public static void StfcConnection(RfcServerContext context, IRfcFunction function)
        {
            Console.WriteLine("Received function call{0} from system{1}.",
                function.Metadata.Name,
                context.SystemAttributes.SystemID);
            String reqtext = function.GetString("REQUTEXT");
            Console.WriteLine("REQUTEXT = {0}\n", reqtext);
            function.SetValue("ECHOTEXT", reqtext);
            function.SetValue("RESPTEXT", "Hello from NCo 3.0!");

        }

        /// <summary>
        /// ZRFC_FUNCTION01 this functioin must be exsit in the ecc system.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="function"></param>
        [RfcServerFunction(Name = "ZRFC_FUNCTION01")]
        public static void ZRFCFUNCTION01(RfcServerContext context, IRfcFunction function)
        {
            //Console.WriteLine("Received function call{0} from system{1}.",
            //    function.Metadata.Name,
            //    context.SystemAttributes.SystemID);
            String reqtext = function.GetString("ZNAME");
            Console.WriteLine("ZNAME = {0}\n", reqtext);
        }
        [RfcServerFunction(Name = "ARFC_DEST_SHIP")]
        public static void ZARFC_DEST_SHIP(RfcServerContext context, IRfcFunction function)
        {
            IRfcTable DATA = function.GetTable("DATA");
            DataTable dt = GetDataTableFromRfcTable(DATA);
        }

        [RfcServerFunction(Name = "ZRFC_SRM_PO_DATA")]
        public static void ZRFC_SRM_PO_DATA(RfcServerContext context, IRfcFunction function)
        {
            String im = function.GetString("IM_PO");
            IRfcTable ITAB_PO = function.GetTable("ITAB_PO");

            DataTable dt = GetDataTableFromRfcTable(ITAB_PO);


        }
        [RfcServerFunction(Name = "IDOC_INBOUND_ASYNCHRONOUS")]
        public static void IDOC_INBOUND(RfcServerContext context, IRfcFunction function)
        {

            IRfcTable control = function.GetTable("IDOC_CONTROL_REC_40");
            IRfcTable data = function.GetTable("IDOC_DATA_REC_40");

            DataTable dtIdocControlData = GetDataTableFromRfcTable(control);
            DataTable dtIdocData = GetDataTableFromRfcTable(data);



            for (int i = 0; i < control.RowCount; i++)
            {
                IRfcStructure tControl = control[i];
                string client = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
                string TableName = "T" + tControl["DOCNUM"].GetValue().ToString().Trim();
                SapTable idoctable = new SapTable(client, TableName, "EDI_DD40");
                DataTable dt = GetDataTableFromRfcTable(data);
                idoctable.SaveDataTable(dt);
                processSingleIdoc(tControl, data);
            }
            

            //DataTable dtcontrol = GetDataTableFromRfcTable(control);

            //foreach (DataRow row in dtcontrol.Rows)
            //{
            //    for (int k = 0; k < dtcontrol.Columns.Count; k++)
            //    {
            //        Console.WriteLine(row[k].ToString());

            //    }
            //}
            //DataTable dtdata = GetDataTableFromRfcTable(data);


            
            //foreach (DataRow row in dtdata.Rows)
            //{
            //    for (int k = 0; k < dtdata.Columns.Count; k++)
            //    {
            //        Console.WriteLine(row[k].ToString());

            //    }
            //}


        }
        private static void processSingleIdoc(IRfcStructure tControl, IRfcTable datarows)
        {
            Idoc idoc = new Idoc
            {
                TABNAM = tControl["TABNAM"].GetValue().ToString().Trim(),
                MANDT = tControl["MANDT"].GetValue().ToString().Trim(),
                DOCNUM = tControl["DOCNUM"].GetValue().ToString().Trim(),
                DOCREL = tControl["DOCREL"].GetValue().ToString().Trim(),
                STATUS = tControl["STATUS"].GetValue().ToString().Trim(),
                DIRECT = tControl["DIRECT"].GetValue().ToString().Trim(),
                OUTMOD = tControl["OUTMOD"].GetValue().ToString().Trim(),
                EXPRSS = tControl["EXPRSS"].ToString().Trim(),
                IDOCTYP = tControl["IDOCTYP"].GetValue().ToString().Trim(),
                CIMTYP = tControl["CIMTYP"].GetValue().ToString().Trim(),
                MESTYP = tControl["MESTYP"].GetValue().ToString().Trim(),
                MESCOD = tControl["MESCOD"].GetValue().ToString().Trim(),
                MESFCT = tControl["MESFCT"].GetValue().ToString().Trim(),
                STD = tControl["STD"].GetValue().ToString().Trim(),
                STDVRS = tControl["STDVRS"].GetValue().ToString().Trim(),
                STDMES = tControl["STDMES"].GetValue().ToString().Trim(),
                SNDPOR = tControl["SNDPOR"].GetValue().ToString().Trim(),
                SNDPRT = tControl["SNDPRT"].GetValue().ToString().Trim(),
                SNDPFC = tControl["SNDPFC"].GetValue().ToString().Trim(),
                SNDPRN = tControl["SNDPRN"].GetValue().ToString().Trim(),
                SNDSAD = tControl["SNDSAD"].GetValue().ToString().Trim(),
                SNDLAD = tControl["SNDLAD"].GetValue().ToString().Trim(),
                RCVPOR = tControl["RCVPOR"].GetValue().ToString().Trim(),
                RCVPRT = tControl["RCVPRT"].GetValue().ToString().Trim(),
                RCVPFC = tControl["RCVPFC"].GetValue().ToString().Trim(),
                RCVPRN = tControl["RCVPRN"].GetValue().ToString().Trim(),
                RCVSAD = tControl["RCVSAD"].GetValue().ToString().Trim(),
                RCVLAD = tControl["RCVLAD"].GetValue().ToString().Trim(),
                CREDAT = tControl["CREDAT"].GetValue().ToString().Trim(),
                CRETIM = tControl["CRETIM"].GetValue().ToString().Trim(),
                REFINT = tControl["REFINT"].GetValue().ToString().Trim(),
                REFGRP = tControl["REFGRP"].GetValue().ToString().Trim(),
                REFMES = tControl["REFMES"].GetValue().ToString().Trim(),
                ARCKEY = tControl["ARCKEY"].GetValue().ToString().Trim(),
                SERIAL = tControl["SERIAL"].GetValue().ToString().Trim()
            };

            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < datarows.RowCount; i++)
            {
                IRfcStructure structure = datarows[i];
                if (structure["DOCNUM"].GetValue().ToString().Trim().Equals(tControl["DOCNUM"].GetValue().ToString().Trim()))
                {
                    IdocSegment newSegment = new IdocSegment();
                    if (structure["PSGNUM"].GetValue().ToString() == "000000")
                    {
                        idoc.Segments.Add(newSegment);
                    }
                    else
                    {
                        IdocSegment segment2 = (IdocSegment)hashtable[structure["PSGNUM"].GetValue().ToString()];
                        if (segment2 != null)
                        {
                            segment2.ChildSegments.Add(newSegment);
                        }
                        else
                        {
                            idoc.Segments.Add(newSegment);
                        }
                    }
                    newSegment.SegmentName = structure["SEGNAM"].GetValue().ToString();
                    string content = structure["SDATA"].GetValue().ToString();
                    newSegment.WriteDataBuffer(content, 0, 0x3e8);
                    if (!hashtable.ContainsKey(structure["SEGNUM"].GetValue().ToString()))
                    {
                        hashtable.Add(structure["SEGNUM"].GetValue().ToString(), newSegment);
                    }
                }
            }

           // IdocMeta idocMeta = new IdocMeta(ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient(), idoc);
           // idocMeta.getIdocTypeDefinition();
           // idocMeta.deCompileIdoc();

            idoc.SavePlainData(@"d:/test.txt");

            //idocsegment e1maram = idoc.segments["E2MARAM006", 0];

            //// loop through segments and find the right ones
            //for (int i = 0; i < e1maram.childsegments.count; i++)
            //    if (e1maram.childsegments[i].segmentname == "e2maktm001")
            //        console.writeline("materialtext found: " +
            //            e1maram.childsegments[i].readdatabuffer(4, 40));


        }

        //将RFC表转换DATATABLE格式
        public static DataTable GetDataTableFromRfcTable(IRfcTable rfcTable)
        {

            DataTable dtRet = new DataTable();

            for (int liElement = 0; liElement < rfcTable.ElementCount; liElement++)
            {
                RfcElementMetadata rfcEMD = rfcTable.GetElementMetadata(liElement);
                dtRet.Columns.Add(rfcEMD.Name);
            }

            foreach (IRfcStructure row in rfcTable)
            {
                DataRow dr = dtRet.NewRow();

                for (int liElement = 0; liElement < rfcTable.ElementCount; liElement++)
                {
                    RfcElementMetadata rfcEMD = rfcTable.GetElementMetadata(liElement);

                    dr[rfcEMD.Name] = row.GetString(rfcEMD.Name);
                    // Console.WriteLine("{0} is {1}", rfcEMD.Documentation, dr[rfcEMD.Name]);
                }

                dtRet.Rows.Add(dr);

            }

            return dtRet;

        }

    }


    class MyTidHandler : ITransactionIDHandler
    {

        public bool CheckTransactionID(RfcServerContextInfo ctx, RfcTID tid)
        {
            Console.WriteLine(ctx.FunctionName);
            Console.WriteLine();
            Console.Write("TRFC: Checking transaction ID {0} --> ", tid.TID);
            return true;

        }

        public void Commit(RfcServerContextInfo ctx, RfcTID tid)
        {
            // throw new NotImplementedException();
            Console.WriteLine();
            Console.WriteLine("TRFC: Commit transaction ID {0}", tid.TID);
        }

        public void ConfirmTransactionID(RfcServerContextInfo ctx, RfcTID tid)
        {
            Console.WriteLine();
            Console.WriteLine("TRFC: Confirm transaction ID {0}", tid.TID);
            //throw new NotImplementedException();
        }

        public void Rollback(RfcServerContextInfo ctx, RfcTID tid)
        {
            Console.WriteLine();
            Console.WriteLine("TRFC: Rollback transaction ID {0}", tid.TID);
            // throw new NotImplementedException();
        }
    }


    //server config，用于SAP调用注册服务器的连接配置。
    public class MyServerConfig : IServerConfiguration
    {

        public RfcConfigParameters GetParameters(String serverName)
        {
            if ("PRD_REG_SERVER".Equals(serverName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.RepositoryDestination, "PRD_000");
                //the client config name 

                parms.Add(RfcConfigParameters.GatewayHost, "192.168.1.146");
                //it's the ecc's host or the ip address

                parms.Add(RfcConfigParameters.GatewayService, "sapgw01");
                //it's the port of the ecc host
                parms.Add(RfcConfigParameters.ProgramID, "DES_RFC_SERVER");
                //registed program name in the ecc system.
                parms.Add(RfcConfigParameters.RegistrationCount, "5");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.Codepage, "8400");

                return parms;

            }
            else return null;

        }

        #region IServerConfiguration Members

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcServerManager.ConfigurationChangeHandler ConfigurationChanged;

        #endregion
    }

    //连接SAP服务器的服务文件
    public class MyBackendConfig : IDestinationConfiguration
    {

        #region IDestinationConfiguration Members

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            if ("PRD_000".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, "192.168.1.146");
                parms.Add(RfcConfigParameters.SystemNumber, "01");
                parms.Add(RfcConfigParameters.SystemID, "DM0");

                parms.Add(RfcConfigParameters.User, "wwsheng");
                parms.Add(RfcConfigParameters.Password, "wwsheng");
                parms.Add(RfcConfigParameters.Client, "800");
                parms.Add(RfcConfigParameters.Language, "en");
                parms.Add(RfcConfigParameters.PoolSize, "5");
                parms.Add(RfcConfigParameters.MaxPoolSize, "10");
                parms.Add(RfcConfigParameters.IdleTimeout, "60");


                return parms;
            }
            else return null;
        }
        #endregion
    }
}
