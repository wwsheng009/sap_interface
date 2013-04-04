namespace SAPINT.Utils
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using SAP.Middleware.Connector;
    using SAPINT.Function;
    using System.Collections.Generic;


   public class CTADIR
    {
        public String PGMID { get; set; } // 请求和任务中的程序标识
        public String OBJECT { get; set; } // 对象类型
        public String OBJ_NAME { get; set; } // 对象目录中的对象名
        public String KORRNUM { get; set; } // 升级请求/任务并包括版本 3.0
        public String SRCSYSTEM { get; set; } // 对象的原始系统
        public String AUTHOR { get; set; } // 仓库对象的负责人
        public String SRCDEP { get; set; } // 开发对象的修复标志
        public String DEVCLASS { get; set; } // 传输组织器的开发类
        public String GENFLAG { get; set; } // 生成标志
        public String EDTFLAG { get; set; } // 标志：对象仅可使用特定编辑器编辑
        public String CPROJECT { get; set; } // 内部使用
        public String MASTERLANG { get; set; } // 资源库对象中的原始语言
        public String VERSID { get; set; } // 内部使用
        public String PAKNOCHECK { get; set; } // Exception Indicator for Package Check
        public String OBJSTABLTY { get; set; } // Release Status of a Development Object
        public String COMPONENT { get; set; } // Software Component
        public String CRELEASE { get; set; } // SAP R/3 版本
        public String DELFLAG { get; set; } // Deletion Flag
        public String TRANSLTTXT { get; set; } // Translate Technical Texts into Development Language
    }


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

        public List<CTADIR> ProgramList = null;
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

        public List<CTADIR> SearchProgram(String searchTerm,String devClass)
        {
            //if (String.IsNullOrEmpty(searchTerm))
            //{
            //    throw new SAPException(String.Format("{0} 不能为空",searchTerm));
            //}
            SourceCode = new List<string>();
            //ProgramList = new List<string>();
            
            try
            {
                var destination = SAPDestination.GetDesByName(_sysName);
                IRfcFunction function = destination.Repository.CreateFunction("Z_SAPINT_READ_PROGRAM");
                function.SetValue("PROGRAMNAME", searchTerm);
                function.SetValue("I_DEVCLASS", devClass);
                function.Invoke(destination);
               // IRfcTable source = function.GetTable("ET_PROGRAM");
               // IRfcTable programlist = function.GetTable("ET_TADIR");


                IRfcTable rfctable_TADIR = function.GetTable("ET_TADIR");
                ProgramList = new List<CTADIR>();
                // CTADIR _CTADIR;
                for (int i = 0; i < rfctable_TADIR.RowCount; i++)
                {
                    var _Program = new CTADIR();
                    _Program.PGMID = rfctable_TADIR[i].GetString("PGMID"); // PgID
                    _Program.OBJECT = rfctable_TADIR[i].GetString("OBJECT"); // 对象
                    _Program.OBJ_NAME = rfctable_TADIR[i].GetString("OBJ_NAME"); // 对象名
                    _Program.KORRNUM = rfctable_TADIR[i].GetString("KORRNUM"); // 请求/任务 (版本 3.0)
                    _Program.SRCSYSTEM = rfctable_TADIR[i].GetString("SRCSYSTEM"); // 初始状态
                    _Program.AUTHOR = rfctable_TADIR[i].GetString("AUTHOR"); // 开发对象的负责人
                    _Program.SRCDEP = rfctable_TADIR[i].GetString("SRCDEP"); // 修复标志
                    _Program.DEVCLASS = rfctable_TADIR[i].GetString("DEVCLASS"); // 开发类
                    _Program.GENFLAG = rfctable_TADIR[i].GetString("GENFLAG"); // 生成
                    _Program.EDTFLAG = rfctable_TADIR[i].GetString("EDTFLAG"); // Edt.
                    _Program.CPROJECT = rfctable_TADIR[i].GetString("CPROJECT"); // 内部使用
                    _Program.MASTERLANG = rfctable_TADIR[i].GetString("MASTERLANG"); // L
                    _Program.VERSID = rfctable_TADIR[i].GetString("VERSID"); // 版本号码
                    _Program.PAKNOCHECK = rfctable_TADIR[i].GetString("PAKNOCHECK"); // Check exception
                    _Program.OBJSTABLTY = rfctable_TADIR[i].GetString("OBJSTABLTY"); // Release
                    _Program.COMPONENT = rfctable_TADIR[i].GetString("COMPONENT"); // Software Component
                    _Program.CRELEASE = rfctable_TADIR[i].GetString("CRELEASE"); // 释放
                    _Program.DELFLAG = rfctable_TADIR[i].GetString("DELFLAG"); // Object Deleted
                    _Program.TRANSLTTXT = rfctable_TADIR[i].GetString("TRANSLTTXT"); // Translate
                    ProgramList.Add(_Program);
         
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
                return ProgramList;
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
                IRfcFunction function = destination.Repository.CreateFunction("Z_SAPINT_READ_PROGRAM");
                function.SetValue("PROGRAMNAME", program);
                function.Invoke(destination);
                IRfcTable programlist = function.GetTable("ET_TADIR");
                if (programlist.RowCount != 1)
                {
                    throw new SAPException("无法找到程序");
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
                    
                    bool hasFunction = SAPFunction.CheckFunction(_sysName, "ZRFC_ABAP_INSTALL_AND_RUN");
                    if (hasFunction)
                    {
                        function = _des.Repository.CreateFunction("ZRFC_ABAP_INSTALL_AND_RUN");
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
    }
}
