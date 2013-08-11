namespace SAPINT.Utils
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using SAP.Middleware.Connector;
    using SAPINT.Function;
    using System.Collections.Generic;

    public class ABAPCode : Component
    {
        private List<String> _code;
        private RfcDestination _des;
        private string _LastError;
        private List<String> _result;
        public String CustomFunction { get; set; }
        private string _sysName;

        public List<String> SourceCode { get; set; }
        //public List<String> ProgramList { get; set; }


        public ABAPCode()
        {
            this._code = new List<String>();
            this._result = new List<String>();
            this._LastError = "";
        }
        public ABAPCode(string sysName)
        {
            this._sysName = sysName;
            this._des = SAPDestination.GetDesByName(sysName);
            this._code = new List<String>();
            this._result = new List<String>();
            this._LastError = "";
            if (_des == null)
            {
                throw new SAPException(Messages.Connectionisnotvalid);

            }
        }

        public List<CTRDIR> SearchProgram(String searchTerm, String objecType, String devClass, bool reportOnly = true)
        {
            //if (String.IsNullOrEmpty(searchTerm))
            //{
            //    throw new SAPException(String.Format("{0} 不能为空",searchTerm));
            //}
            //SourceCode = new List<string>();
            //ProgramList = new List<string>();

            try
            {
                var destination = SAPDestination.GetDesByName(_sysName);
                IRfcFunction function = destination.Repository.CreateFunction("ZVI_RFC_READ_PROGRAM");
                function.SetValue("I_PROG", searchTerm);
                function.SetValue("I_OBJECT", objecType);
                function.SetValue("I_DEVCLASS", devClass);
                if (true == reportOnly)
                {
                    function.SetValue("I_NOT_LIMIT", 'X');
                }
                else
                {
                    function.SetValue("I_NOT_LIMIT", ' ');
                }
                function.Invoke(destination);
                // IRfcTable source = function.GetTable("ET_PROGRAM");
                // IRfcTable programlist = function.GetTable("ET_TADIR");


                // IRfcTable rfctable_TADIR = function.GetTable("ET_TADIR");
                // var dt = SAPINT.Function.SAPFunction.RfcTableToDataTable(rfctable_TADIR);
                List<CTRDIR> _TRDIR_LIST = new List<CTRDIR>();
                IRfcTable rfctable_TRDIR = function.GetTable("ET_TRDIR");

                // CTRDIR _CTRDIR;
                for (int i = 0; i < rfctable_TRDIR.RowCount; i++)
                {
                    var _TRDIR = new CTRDIR();
                    _TRDIR.name = rfctable_TRDIR[i].GetString("NAME"); // Program
                    _TRDIR.sqlx = rfctable_TRDIR[i].GetString("SQLX"); // 
                    _TRDIR.edtx = rfctable_TRDIR[i].GetString("EDTX"); // 
                    _TRDIR.varcl = rfctable_TRDIR[i].GetString("VARCL"); // 
                    _TRDIR.dbapl = rfctable_TRDIR[i].GetString("DBAPL"); // 
                    _TRDIR.dbna = rfctable_TRDIR[i].GetString("DBNA"); // 
                    _TRDIR.clas = rfctable_TRDIR[i].GetString("CLAS"); // Class
                    _TRDIR.type = rfctable_TRDIR[i].GetString("TYPE"); // Selection screen version
                    _TRDIR.occurs = rfctable_TRDIR[i].GetString("OCCURS"); // 
                    _TRDIR.subc = rfctable_TRDIR[i].GetString("SUBC"); // Prog. type
                    _TRDIR.appl = rfctable_TRDIR[i].GetString("APPL"); // Appl.
                    _TRDIR.secu = rfctable_TRDIR[i].GetString("SECU"); // 
                    _TRDIR.cnam = rfctable_TRDIR[i].GetString("CNAM"); // Created By
                    _TRDIR.cdat = rfctable_TRDIR[i].GetString("CDAT"); // Created on
                    _TRDIR.unam = rfctable_TRDIR[i].GetString("UNAM"); // 
                    _TRDIR.udat = rfctable_TRDIR[i].GetString("UDAT"); // Changed on
                    _TRDIR.vern = rfctable_TRDIR[i].GetString("VERN"); // 
                    _TRDIR.levl = rfctable_TRDIR[i].GetString("LEVL"); // 
                    _TRDIR.rstat = rfctable_TRDIR[i].GetString("RSTAT"); // Program status
                    _TRDIR.rmand = rfctable_TRDIR[i].GetString("RMAND"); // 
                    _TRDIR.rload = rfctable_TRDIR[i].GetString("RLOAD"); // 
                    _TRDIR.fixpt = rfctable_TRDIR[i].GetString("FIXPT"); // 
                    _TRDIR.sset = rfctable_TRDIR[i].GetString("SSET"); // 
                    _TRDIR.sdate = rfctable_TRDIR[i].GetString("SDATE"); // 
                    _TRDIR.stime = rfctable_TRDIR[i].GetString("STIME"); // 
                    _TRDIR.idate = rfctable_TRDIR[i].GetString("IDATE"); // 
                    _TRDIR.itime = rfctable_TRDIR[i].GetString("ITIME"); // 
                    _TRDIR.ldbname = rfctable_TRDIR[i].GetString("LDBNAME"); // LDB name
                    _TRDIR.uccheck = rfctable_TRDIR[i].GetString("UCCHECK"); // Unicode checks
                    _TRDIR_LIST.Add(_TRDIR);

                }
                List<CD010SINF> _D010SINF_LIST = new List<CD010SINF>();

                IRfcTable rfctable_D010SINF = function.GetTable("ET_D010SINF");

                // C${rfctable.Name} _C${rfctable.Name};
                for (int i = 0; i < rfctable_D010SINF.RowCount; i++)
                {
                    var _D010SINF = new CD010SINF();
                    _D010SINF.prog = rfctable_D010SINF[i].GetString("PROG"); // 程序
                    _D010SINF.clas = rfctable_D010SINF[i].GetString("CLAS"); // 类别
                    _D010SINF.subc = rfctable_D010SINF[i].GetString("SUBC"); // 程序类型
                    _D010SINF.appl = rfctable_D010SINF[i].GetString("APPL"); // 应用
                    _D010SINF.cdat = rfctable_D010SINF[i].GetString("CDAT"); // 创建日期
                    _D010SINF.vern = rfctable_D010SINF[i].GetString("VERN"); // 
                    _D010SINF.rmand = rfctable_D010SINF[i].GetString("RMAND"); // 
                    _D010SINF.rload = rfctable_D010SINF[i].GetString("RLOAD"); // 
                    _D010SINF.unam = rfctable_D010SINF[i].GetString("UNAM"); // 
                    _D010SINF.udat = rfctable_D010SINF[i].GetString("UDAT"); // 更改日期
                    _D010SINF.utime = rfctable_D010SINF[i].GetString("UTIME"); // 
                    _D010SINF.datalg = rfctable_D010SINF[i].GetInt("DATALG"); // 长度
                    _D010SINF.varcl = rfctable_D010SINF[i].GetString("VARCL"); // 
                    _D010SINF_LIST.Add(_D010SINF);

                }
                //for (int i = 0; i < source.RowCount; i++)
                //{
                //    source.CurrentIndex = i;
                //    SourceCode.Add(source.GetString("ZEILE"));
                //}

                //for (int i = 0; i < programlist.RowCount; i++)
                //{
                //    programlist.CurrentIndex = i;
                //    ProgramList.Add(programlist.GetString("OBJ_NAME"));
                //}
                return _TRDIR_LIST;
            }
            catch (RfcAbapException abapException)
            {
                throw new SAPException(abapException.Key + abapException.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CD010SINF> SearchProgram(String searchTerm, String classType, String devClass)
        {
            //if (String.IsNullOrEmpty(searchTerm))
            //{
            //    throw new SAPException(String.Format("{0} 不能为空",searchTerm));
            //}
            //SourceCode = new List<string>();
            //ProgramList = new List<string>();

            try
            {
                var destination = SAPDestination.GetDesByName(_sysName);
                IRfcFunction function = destination.Repository.CreateFunction("ZVI_RFC_READ_PROGRAM");
                function.SetValue("I_PROG", searchTerm);
                function.SetValue("I_CLASS", classType);
                function.SetValue("I_DEVCLASS", devClass);
                function.Invoke(destination);
                
                List<CD010SINF> _D010SINF_LIST = new List<CD010SINF>();

                IRfcTable rfctable_D010SINF = function.GetTable("ET_D010SINF");

                // C${rfctable.Name} _C${rfctable.Name};
                for (int i = 0; i < rfctable_D010SINF.RowCount; i++)
                {
                    var _D010SINF = new CD010SINF();
                    _D010SINF.prog = rfctable_D010SINF[i].GetString("PROG"); // 程序
                    _D010SINF.clas = rfctable_D010SINF[i].GetString("CLAS"); // 类别
                    _D010SINF.subc = rfctable_D010SINF[i].GetString("SUBC"); // 程序类型
                    _D010SINF.appl = rfctable_D010SINF[i].GetString("APPL"); // 应用
                    _D010SINF.cdat = rfctable_D010SINF[i].GetString("CDAT"); // 创建日期
                    _D010SINF.vern = rfctable_D010SINF[i].GetString("VERN"); // 
                    _D010SINF.rmand = rfctable_D010SINF[i].GetString("RMAND"); // 
                    _D010SINF.rload = rfctable_D010SINF[i].GetString("RLOAD"); // 
                    _D010SINF.unam = rfctable_D010SINF[i].GetString("UNAM"); // 
                    _D010SINF.udat = rfctable_D010SINF[i].GetString("UDAT"); // 更改日期
                    _D010SINF.utime = rfctable_D010SINF[i].GetString("UTIME"); // 
                    _D010SINF.datalg = rfctable_D010SINF[i].GetInt("DATALG"); // 长度
                    _D010SINF.varcl = rfctable_D010SINF[i].GetString("VARCL"); // 
                    _D010SINF_LIST.Add(_D010SINF);

                }
                //for (int i = 0; i < source.RowCount; i++)
                //{
                //    source.CurrentIndex = i;
                //    SourceCode.Add(source.GetString("ZEILE"));
                //}

                //for (int i = 0; i < programlist.RowCount; i++)
                //{
                //    programlist.CurrentIndex = i;
                //    ProgramList.Add(programlist.GetString("OBJ_NAME"));
                //}
                return _D010SINF_LIST;
            }
            catch (RfcAbapException abapException)
            {
                throw new SAPException(abapException.Key + abapException.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<String> GetSourceCode(String program)
        {
            if (String.IsNullOrEmpty(program))
            {
                throw new SAPException(String.Format("{0} 不能为空", program));
            }
            try
            {

                var destination = SAPDestination.GetDesByName(_sysName);
                IRfcFunction function = destination.Repository.CreateFunction("ZVI_RFC_READ_PROGRAM");
                function.SetValue("I_PROG", program);
                //function.SetValue("I_OBJECT", objectType);
                function.Invoke(destination);
                IRfcTable programlist = function.GetTable("ET_TRDIR");
                if (programlist.RowCount != 1)
                {
                    // throw new SAPException("无法找到程序");
                }

                IRfcTable source = function.GetTable("ET_PROGRAM");
                List<String> code = new List<string>();
                for (int i = 0; i < source.RowCount; i++)
                {
                    source.CurrentIndex = i;

                    code.Add(source.GetString("ZEILE"));
                }

                return code;
            }
            catch (RfcAbapException abapException)
            {
                throw new SAPException(abapException.Key + abapException.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public String InstallAndRun(String CodeContent)
        {

            AddStringBlock(CodeContent);

            var result = string.Empty;
            if (InstallAndRun())
            {
                for (int i = 0; i < ResultLineCount; i++)
                {
                    result += GetResultLine(i) + "\r\n";
                }
            }
            else
            {
                result = "ABAP Error: " + LastABAPSyntaxError;
            }
            return result;


        }
        public bool InstallAndRun()
        {
            IRfcFunction function = null;
            this._result.Clear();
            try
            {
                if (this._des == null)
                {
                    throw new SAPException(Messages.Connectionisnotvalid);
                }

                this._LastError = "";
                if (!String.IsNullOrEmpty(CustomFunction))
                {
                    function = _des.Repository.CreateFunction(CustomFunction);
                }
                else
                {

                    bool hasFunction = SAPFunction.CheckFunction(_sysName, "ZVI_RFC_ABAP_INSTALL_AND_RUN");
                    if (hasFunction)
                    {
                        function = _des.Repository.CreateFunction("ZVI_RFC_ABAP_INSTALL_AND_RUN");
                    }
                    //else
                    //{
                    //    hasFunction = SAPFunction.CheckFunction(_sysName, "RFC_ABAP_INSTALL_AND_RUN");
                    //    if (hasFunction)
                    //    {
                    //        function = _des.Repository.CreateFunction("RFC_ABAP_INSTALL_AND_RUN");
                    //    }
                    //}
                }
                if (function == null)
                {
                    throw new SAPException("无法找到运行程序");
                }

                IRfcTable table = function.GetTable("PROGRAM");

                if (this._code.Count <= 1)
                {
                    throw new Exception(Messages.Thegivencodeisnotvalid);

                }
                foreach (string str in this._code)
                {
                    table.Append();
                    IRfcStructure row = table.CurrentRow;
                    row.SetValue("ZEILE", str);
                }

                function.Invoke(_des);
            }
            catch (RfcCommunicationException e)
            {
                throw new SAPException(e.Message);
            }
            catch (RfcAbapException e)
            {
                throw new SAPException(e.Key + e.Message);
            }
            this._LastError = function.GetString("ERRORMESSAGE");
            if (this._LastError != "")
            {
                return false;
            }

            IRfcTable table2 = function.GetTable("WRITES");
            for (int i = 0; i < table2.RowCount; i++)
            {
                this._result.Add(table2[i].GetString("ZEILE"));
            }
            return true;
        }
        public string GetResultLine(int Index)
        {
            return (string)this._result[Index];
        }
        public void ResetCode()
        {
            this._code.Clear();
        }
        public RfcDestination Destination
        {
            get
            {
                return this._des;
            }
            set
            {
                this._des = value;
            }
        }
        public string LastABAPSyntaxError
        {
            get
            {
                return this._LastError;
            }
        }
        public int ResultLineCount
        {
            get
            {
                return this._result.Count;
            }
        }

        public void AddCodeLine(string line)
        {
            this._code.Add(line);
        }

        public void AddStringBlock(String StringBlock)
        {
            ResetCode();
            string[] lines = StringBlock.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var item in lines)
            {
                AddCodeLine(item);
            }
        }
    }
}
