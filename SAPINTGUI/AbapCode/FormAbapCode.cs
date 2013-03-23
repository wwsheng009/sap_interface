using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Utils;
using System.IO;
using NVelocity;
using NVelocity.App;
using SyntaxHighlighter;
//using System.Data.SQLite;


namespace SAPINTCODE
{
    public partial class FormAbapCode : Form
    {
        private List<string> NVelocityKeyWordList = new List<string>();
        private List<string> ABAPKeyWordList = new List<string>();
        private string DB_NAME = null;
        // private SQLiteDataAdapter dataAdapter = null;
        // private DataSet dataSet = null;

        DataGridViewCell dgvSelectedCell = null;
        public FormAbapCode()
        {
            InitializeComponent();
            SAPINT.SAPLogonConfigList.InitSystemList();
            //   InitKeyWordList();
            this.WindowState = FormWindowState.Maximized;
        }


        private void WordColorInit()
        {

            foreach (string keyword in ABAPKeyWordList)
            {
                this.textResultCode.Settings.Keywords.Add(keyword);
            }


        }

        private string ExcuteAbapCode(string Code)
        {
            SAPINT.Utils.ABAPCode abap = new SAPINT.Utils.ABAPCode(this.sapTableField1.SystemName.Trim().ToUpper());

            abap.ResetCode();
            //使用TEXTBOX转换字符串。
            TextBox box = new TextBox();
            box.Text = Code;

            foreach (string line in box.Lines)
            {
                abap.AddCodeLine(line);
            }
            box.Text = "";
            try
            {
                if (abap.Execute())
                {
                    for (int i = 0; i < abap.ResultLineCount; i++)
                    {
                        box.Text += abap.GetResultLine(i) + "\r\n";
                    }
                }
                else
                {
                    box.Text = "ABAP Error: " + abap.LastABAPSyntaxError;
                }


            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
            return box.Text;
        }

        /// <summary>
        /// 在SAP系统中执行生成的ABAP代码，并返回执行结果。
        /// </summary>
        private void ExcuteCode()
        {
            if (string.IsNullOrEmpty(this.sapTableField1.SystemName))
            {
                textResult.Text = "请选择系统";
                return;
            }

            textResult.Text = "";
            textResult.Text = ExcuteAbapCode(this.textResultCode.Text);
        }
        private void tspRunAbapCode_Click(object sender, EventArgs e)
        {
            ExcuteCode();

        }


        /// <summary>
        /// 使用模板引擎进行处理。
        /// </summary>
        private void processTemplate()
        {
            if (this.sapTableField1.TableList == null)
            {
                MessageBox.Show("没有选中的字段");
                return;
            }
            if (this.sapTableField1.TableList.Count == 0 )
            {
                MessageBox.Show("没有选中的字段");
                return;
            }
            try
            {
                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                VelocityContext ct = new VelocityContext();

                ct.Put("tables", this.sapTableField1.TableList);
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                ve.Evaluate(ct, vltWriter, null, this.textTemplate.Text);
                textResultCode.Text = vltWriter.GetStringBuilder().ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void tspProcessTemplate_Click(object sender, EventArgs e)
        {
            processTemplate();
        }


        private void tspGenerateCode_Click(object sender, EventArgs e)
        {
            AbapCode code = new AbapCode();
            code.Tables = this.sapTableField1.TableList;
            this.textResultCode.Text = code.Excute();
        }

        private void InitKeyWordList()
        {
            //ABAPKeyWordList.Add("-");
            //ABAPKeyWordList.Add("!");
            //ABAPKeyWordList.Add("%");
            ABAPKeyWordList.Add("&GT;");
            ABAPKeyWordList.Add("&LT;");
            //ABAPKeyWordList.Add("(");
            //ABAPKeyWordList.Add(")");
            ////ABAPKeyWordList.Add("*");
            ////ABAPKeyWordList.Add("**");
            ////ABAPKeyWordList.Add(",");
            ////ABAPKeyWordList.Add(".");
            //ABAPKeyWordList.Add("/");
            //ABAPKeyWordList.Add("?");
            //ABAPKeyWordList.Add("[");
            //ABAPKeyWordList.Add("]");
            //ABAPKeyWordList.Add("^");
            //ABAPKeyWordList.Add("{");
            //ABAPKeyWordList.Add("|");
            //ABAPKeyWordList.Add("}");
            //ABAPKeyWordList.Add("+");
            //ABAPKeyWordList.Add("+,-,*,/");
            ABAPKeyWordList.Add("ABS");
            ABAPKeyWordList.Add("ACOS");
            ABAPKeyWordList.Add("ADD");
            ABAPKeyWordList.Add("ADD-CORRESPONDING");
            ABAPKeyWordList.Add("ALL");
            ABAPKeyWordList.Add("AND");
            ABAPKeyWordList.Add("ANY");
            ABAPKeyWordList.Add("APPEND");
            ABAPKeyWordList.Add("ASC");
            ABAPKeyWordList.Add("ASIN");
            ABAPKeyWordList.Add("ASSIGN");
            ABAPKeyWordList.Add("AT");
            ABAPKeyWordList.Add("AT END OF");
            ABAPKeyWordList.Add("AT FG");
            ABAPKeyWordList.Add("AT FIRST");
            ABAPKeyWordList.Add("AT LAST");
            ABAPKeyWordList.Add("AT LINE-SELECTION");
            ABAPKeyWordList.Add("AT NEW");
            ABAPKeyWordList.Add("AT PFN");
            ABAPKeyWordList.Add("AT SELECTION-SCREEN");
            ABAPKeyWordList.Add("AT USER-COMMAND");
            ABAPKeyWordList.Add("ATAN");
            ABAPKeyWordList.Add("AUTHORITY-CHCK");
            ABAPKeyWordList.Add("AUTHORITY-CHECK");
            ABAPKeyWordList.Add("BACK");
            ABAPKeyWordList.Add("BEGIN");
            ABAPKeyWordList.Add("BETWEEN");
            ABAPKeyWordList.Add("BINARY");
            ABAPKeyWordList.Add("BLANK");
            ABAPKeyWordList.Add("BREAK");
            ABAPKeyWordList.Add("BREAK-POINT");
            ABAPKeyWordList.Add("BY");
            ABAPKeyWordList.Add("CA");
            ABAPKeyWordList.Add("CALL");
            ABAPKeyWordList.Add("CALL FUNCTION");
            ABAPKeyWordList.Add("CASCADE");
            ABAPKeyWordList.Add("CASE");
            ABAPKeyWordList.Add("CEIL");
            ABAPKeyWordList.Add("CENTERED");
            ABAPKeyWordList.Add("CHECK");
            ABAPKeyWordList.Add("CHECKBOX");
            ABAPKeyWordList.Add("CHECKPOINT");
            ABAPKeyWordList.Add("CLEAR");
            ABAPKeyWordList.Add("CLIENT SPECIFIED");
            ABAPKeyWordList.Add("CLOSE");
            ABAPKeyWordList.Add("CLOSE CURSOR");
            ABAPKeyWordList.Add("CN");
            ABAPKeyWordList.Add("CNT");
            ABAPKeyWordList.Add("CO");
            ABAPKeyWordList.Add("COALESCE");
            ABAPKeyWordList.Add("COLLATE");
            ABAPKeyWordList.Add("COLLECT");
            ABAPKeyWordList.Add("COLUMN");
            ABAPKeyWordList.Add("COMMIT");
            ABAPKeyWordList.Add("COMMIT WORK");
            ABAPKeyWordList.Add("COMMUNICATION");
            ABAPKeyWordList.Add("COMPUTE");
            ABAPKeyWordList.Add("CONCATENATE");
            ABAPKeyWordList.Add("CONDENSE");
            ABAPKeyWordList.Add("CONSTANTS");
            ABAPKeyWordList.Add("CONSTRAINT");
            ABAPKeyWordList.Add("CONTAINS");
            ABAPKeyWordList.Add("CONTINUE");
            ABAPKeyWordList.Add("CONVERT");
            ABAPKeyWordList.Add("COS");
            ABAPKeyWordList.Add("COSH");
            ABAPKeyWordList.Add("COUNTRY");
            ABAPKeyWordList.Add("CP");
            ABAPKeyWordList.Add("CREATE");
            ABAPKeyWordList.Add("CREATE OBJECT");
            ABAPKeyWordList.Add("CROSS");
            ABAPKeyWordList.Add("CS");
            ABAPKeyWordList.Add("CURSOR");
            ABAPKeyWordList.Add("CUSTOMER-FUNCTION");
            ABAPKeyWordList.Add("DATA");
            ABAPKeyWordList.Add("DATABASE");
            ABAPKeyWordList.Add("DATASET");
            ABAPKeyWordList.Add("DECLARE");
            ABAPKeyWordList.Add("DEFAULT");
            ABAPKeyWordList.Add("DEFINE");
            ABAPKeyWordList.Add("DELETE");
            ABAPKeyWordList.Add("DELETE DYNPRO");
            ABAPKeyWordList.Add("DELETE FROM ");
            ABAPKeyWordList.Add("DESC");
            ABAPKeyWordList.Add("DESCRIBE");
            ABAPKeyWordList.Add("DIALOG");
            ABAPKeyWordList.Add("DISTINCT");
            ABAPKeyWordList.Add("DIV");
            ABAPKeyWordList.Add("DIVIDE");
            ABAPKeyWordList.Add("DIVIDE-CORRESPONDING");
            ABAPKeyWordList.Add("DO");
            ABAPKeyWordList.Add("DOUBLE");
            ABAPKeyWordList.Add("DROP");
            ABAPKeyWordList.Add("DYNPRO");
            ABAPKeyWordList.Add("EDITOR-CALL");
            ABAPKeyWordList.Add("EDITOR-CALL FOR");
            ABAPKeyWordList.Add("ELSE");
            ABAPKeyWordList.Add("ELSEIF");
            ABAPKeyWordList.Add("END");
            ABAPKeyWordList.Add("ENDAT");
            ABAPKeyWordList.Add("ENDCASE");
            ABAPKeyWordList.Add("ENDDO");
            ABAPKeyWordList.Add("ENDEXEC");
            ABAPKeyWordList.Add("ENDFORM");
            ABAPKeyWordList.Add("ENDFUNCTION");
            ABAPKeyWordList.Add("ENDIF");
            ABAPKeyWordList.Add("ENDLOOP");
            ABAPKeyWordList.Add("ENDMODULE");
            ABAPKeyWordList.Add("ENDMOULE");
            ABAPKeyWordList.Add("END-OF-DEFINITION");
            ABAPKeyWordList.Add("END-OF-PAGE");
            ABAPKeyWordList.Add("END-OF-SELECTION");
            ABAPKeyWordList.Add("ENDON");
            ABAPKeyWordList.Add("ENDPROVIDE");
            ABAPKeyWordList.Add("ENDSELECT");
            ABAPKeyWordList.Add("ENDWHILE");
            ABAPKeyWordList.Add("EQ");
            ABAPKeyWordList.Add("ESCAPE");
            ABAPKeyWordList.Add("EXCEPT");
            ABAPKeyWordList.Add("EXEC");
            ABAPKeyWordList.Add("EXEC SQL");
            ABAPKeyWordList.Add("EXECUTE");
            ABAPKeyWordList.Add("EXISTS");
            ABAPKeyWordList.Add("EXIT");
            ABAPKeyWordList.Add("EXLORT");
            ABAPKeyWordList.Add("EXP");
            ABAPKeyWordList.Add("EXPORT");
            ABAPKeyWordList.Add("EXPORT DYNPRO");
            ABAPKeyWordList.Add("EXTEND CHECK");
            ABAPKeyWordList.Add("EXTRACT");
            ABAPKeyWordList.Add("FETCH");
            ABAPKeyWordList.Add("FETCH NEXT CURSOR");
            ABAPKeyWordList.Add("FETCH  ");
            ABAPKeyWordList.Add("FIELD-GROUPS");
            ABAPKeyWordList.Add("FIELD-SYMBOLS");
            ABAPKeyWordList.Add("FILED-GROUPS");
            ABAPKeyWordList.Add("FILL");
            ABAPKeyWordList.Add("FLOOR");
            ABAPKeyWordList.Add("FOR");
            ABAPKeyWordList.Add("FORM");
            ABAPKeyWordList.Add("FORMAT");
            ABAPKeyWordList.Add("FRAC");
            ABAPKeyWordList.Add("FREE");
            ABAPKeyWordList.Add("FREE OBJECT");
            ABAPKeyWordList.Add("FROM");
            ABAPKeyWordList.Add("FULL");
            ABAPKeyWordList.Add("FUNCTION");
            ABAPKeyWordList.Add("FUNCTION-POOL");
            ABAPKeyWordList.Add("GE");
            ABAPKeyWordList.Add("GENERATE");
            ABAPKeyWordList.Add("GET");
            ABAPKeyWordList.Add("GET CURSOR FIELD");
            ABAPKeyWordList.Add("GET PARAMETER");
            ABAPKeyWordList.Add("GET RUN TIME");
            ABAPKeyWordList.Add("GET TIME");
            ABAPKeyWordList.Add("GO");
            ABAPKeyWordList.Add("GOTO");
            ABAPKeyWordList.Add("GROUP");
            ABAPKeyWordList.Add("GT");
            ABAPKeyWordList.Add("HAVING");
            ABAPKeyWordList.Add("HIDE");
            ABAPKeyWordList.Add("IDENTITY");
            ABAPKeyWordList.Add("IDENTITY_INSERT");
            ABAPKeyWordList.Add("IDENTITYCOL");
            ABAPKeyWordList.Add("IF");
            ABAPKeyWordList.Add("IMPORT");
            ABAPKeyWordList.Add("IMPORT DYNPRO");
            ABAPKeyWordList.Add("IN");
            ABAPKeyWordList.Add("INCLUDE");
            ABAPKeyWordList.Add("INCLUDE STRUCTURE");
            ABAPKeyWordList.Add("INDEX STRUCTURE");
            ABAPKeyWordList.Add("INFOTYPES");
            ABAPKeyWordList.Add("INITIAL");
            ABAPKeyWordList.Add("INITIALIZATION");
            ABAPKeyWordList.Add("INITILIZATION");
            ABAPKeyWordList.Add("INNER");
            ABAPKeyWordList.Add("INSERT");
            ABAPKeyWordList.Add("INTO");
            ABAPKeyWordList.Add("INTO TABLE");
            ABAPKeyWordList.Add("INVERSE");
            ABAPKeyWordList.Add("IS");
            ABAPKeyWordList.Add("JOIN");
            ABAPKeyWordList.Add("KEY");
            ABAPKeyWordList.Add("LANGUAGE");
            ABAPKeyWordList.Add("LE");
            ABAPKeyWordList.Add("LEAVE");
            ABAPKeyWordList.Add("LEAVE PROGRAM");
            ABAPKeyWordList.Add("LEAVE TO");
            ABAPKeyWordList.Add("LEFT");
            ABAPKeyWordList.Add("LIKE");
            ABAPKeyWordList.Add("LIMIT");
            ABAPKeyWordList.Add("LINE");
            ABAPKeyWordList.Add("LIST-PROCESSING");
            ABAPKeyWordList.Add("LOAD");
            ABAPKeyWordList.Add("LOCAL");
            ABAPKeyWordList.Add("LOG");
            ABAPKeyWordList.Add("LOG10");
            ABAPKeyWordList.Add("LOOP");
            ABAPKeyWordList.Add("LOOP AT");
            ABAPKeyWordList.Add("LOOP ATWHERE");
            ABAPKeyWordList.Add("LT");
            ABAPKeyWordList.Add("MARGIN");
            ABAPKeyWordList.Add("MARK");
            ABAPKeyWordList.Add("MATCHCODE");
            ABAPKeyWordList.Add("MEMORY");
            ABAPKeyWordList.Add("MESSAGE");
            ABAPKeyWordList.Add("MESSGAE");
            ABAPKeyWordList.Add("MOD");
            ABAPKeyWordList.Add("MODIFY");
            ABAPKeyWordList.Add("MODIFY …");
            ABAPKeyWordList.Add("MODULE");
            ABAPKeyWordList.Add("MOVE");
            ABAPKeyWordList.Add("MOVE-CORRESPONDING");
            ABAPKeyWordList.Add("MULTIPLY");
            ABAPKeyWordList.Add("MULTIPLY-CORRESPONGING");
            ABAPKeyWordList.Add("NA");
            ABAPKeyWordList.Add("NE");
            ABAPKeyWordList.Add("NEW-LINE");
            ABAPKeyWordList.Add("NEW-PAGE");
            ABAPKeyWordList.Add("NOCHECK");
            ABAPKeyWordList.Add("NOT");
            ABAPKeyWordList.Add("NP");
            ABAPKeyWordList.Add("NS");
            ABAPKeyWordList.Add("NULL");
            ABAPKeyWordList.Add("NULLIF");
            ABAPKeyWordList.Add("OBJECT");
            ABAPKeyWordList.Add("OCCURS");
            ABAPKeyWordList.Add("OF");
            ABAPKeyWordList.Add("OFF");
            ABAPKeyWordList.Add("OFFSETS");
            ABAPKeyWordList.Add("ON");
            ABAPKeyWordList.Add("ON CHANGE OF");
            ABAPKeyWordList.Add("OPEN");
            ABAPKeyWordList.Add("OPEN CURSOR");
            ABAPKeyWordList.Add("OPENDATASOURCE");
            ABAPKeyWordList.Add("OR");
            ABAPKeyWordList.Add("ORDER");
            ABAPKeyWordList.Add("OUTER");
            ABAPKeyWordList.Add("OVER");
            ABAPKeyWordList.Add("OVERLAY");
            ABAPKeyWordList.Add("PACK");
            ABAPKeyWordList.Add("PARAMETER");
            ABAPKeyWordList.Add("PARAMETERS");
            ABAPKeyWordList.Add("PERFORM");
            ABAPKeyWordList.Add("PF-STATUS");
            ABAPKeyWordList.Add("POSITION");
            ABAPKeyWordList.Add("PRECISION");
            ABAPKeyWordList.Add("PRINT");
            ABAPKeyWordList.Add("PRINT-CONTROL");
            ABAPKeyWordList.Add("PROC");
            ABAPKeyWordList.Add("PROCEDURE");
            ABAPKeyWordList.Add("PROGRAM");
            ABAPKeyWordList.Add("PROVIDE");
            ABAPKeyWordList.Add("PUBLIC");
            ABAPKeyWordList.Add("PUT");
            ABAPKeyWordList.Add("RAISE");
            ABAPKeyWordList.Add("RAISERROR");
            ABAPKeyWordList.Add("RAISING");
            ABAPKeyWordList.Add("RANGES");
            ABAPKeyWordList.Add("READ");
            ABAPKeyWordList.Add("READ …");
            ABAPKeyWordList.Add("READTEXT");
            ABAPKeyWordList.Add("REFERENCES");
            ABAPKeyWordList.Add("REFRESH");
            ABAPKeyWordList.Add("REJECT");
            ABAPKeyWordList.Add("REPLACE");
            ABAPKeyWordList.Add("REPORT");
            ABAPKeyWordList.Add("RESERVE");
            ABAPKeyWordList.Add("RESET");
            ABAPKeyWordList.Add("RESTORE");
            ABAPKeyWordList.Add("RESTRICT");
            ABAPKeyWordList.Add("RETURN");
            ABAPKeyWordList.Add("RIGHT");
            ABAPKeyWordList.Add("ROLLBACK");
            ABAPKeyWordList.Add("ROLLBACK WORK");
            ABAPKeyWordList.Add("ROWCOUNT");
            ABAPKeyWordList.Add("RULE");
            ABAPKeyWordList.Add("SAVE");
            ABAPKeyWordList.Add("SCAN");
            ABAPKeyWordList.Add("SCREEN");
            ABAPKeyWordList.Add("SCROOL");
            ABAPKeyWordList.Add("SEARCH");
            ABAPKeyWordList.Add("SELECT");
            ABAPKeyWordList.Add("SELECTION-SCREEN");
            ABAPKeyWordList.Add("SELECT-OPTIONS");
            ABAPKeyWordList.Add("SELECT-OPTIONS ");
            ABAPKeyWordList.Add("SELECT-SCREEN");
            ABAPKeyWordList.Add("SET");
            ABAPKeyWordList.Add("SET CURSOR");
            ABAPKeyWordList.Add("SET PARAMETER");
            ABAPKeyWordList.Add("SETUSER");
            ABAPKeyWordList.Add("SHIFT");
            ABAPKeyWordList.Add("SIGN");
            ABAPKeyWordList.Add("SIN");
            ABAPKeyWordList.Add("SINH");
            ABAPKeyWordList.Add("SKIP");
            ABAPKeyWordList.Add("SOME");
            ABAPKeyWordList.Add("SORT");
            ABAPKeyWordList.Add("SPLIT");
            ABAPKeyWordList.Add("SQRT");
            ABAPKeyWordList.Add("START-OF-SELECTION");
            ABAPKeyWordList.Add("STATICS");
            ABAPKeyWordList.Add("STOP");
            ABAPKeyWordList.Add("STRLEN");
            ABAPKeyWordList.Add("STRUCTURE");
            ABAPKeyWordList.Add("SUBMIT");
            ABAPKeyWordList.Add("SUBSTRACT");
            ABAPKeyWordList.Add("SUBSTRACT-CORRESPONDING");
            ABAPKeyWordList.Add("SUBTRACT");
            ABAPKeyWordList.Add("SUBTRACT-CORRESPONDING");
            ABAPKeyWordList.Add("SUM");
            ABAPKeyWordList.Add("SUMMING");
            ABAPKeyWordList.Add("SUPPRESS");
            ABAPKeyWordList.Add("SYMBOL");
            ABAPKeyWordList.Add("SYNTAX-CHECK");
            ABAPKeyWordList.Add("SYNTAX-TRACT");
            ABAPKeyWordList.Add("TABLE");
            ABAPKeyWordList.Add("TABLE ");
            ABAPKeyWordList.Add("TABLES");
            ABAPKeyWordList.Add("TAN");
            ABAPKeyWordList.Add("TANH");
            ABAPKeyWordList.Add("TEXTPOOL");
            ABAPKeyWordList.Add("THEN");
            ABAPKeyWordList.Add("TIME");
            ABAPKeyWordList.Add("TITLEBAR");
            ABAPKeyWordList.Add("TO");
            ABAPKeyWordList.Add("TOP");
            ABAPKeyWordList.Add("TOP-OF-PAGE");
            ABAPKeyWordList.Add("TOP-OF-PAGE DURING LINE-SELECTION");
            ABAPKeyWordList.Add("TRAN");
            ABAPKeyWordList.Add("TRANSACTION");
            ABAPKeyWordList.Add("TRANSFER");
            ABAPKeyWordList.Add("TRANSLATE");
            ABAPKeyWordList.Add("TRIGGER");
            ABAPKeyWordList.Add("TRUNC");
            ABAPKeyWordList.Add("TRUNCATE");
            ABAPKeyWordList.Add("TYPE-POOL");
            ABAPKeyWordList.Add("TYPE-POOLS");
            ABAPKeyWordList.Add("TYPES");
            ABAPKeyWordList.Add("ULINE");
            ABAPKeyWordList.Add("UNION");
            ABAPKeyWordList.Add("UNIQUE");
            ABAPKeyWordList.Add("UNPACK");
            ABAPKeyWordList.Add("UPDATE");
            ABAPKeyWordList.Add("USE");
            ABAPKeyWordList.Add("USER");
            ABAPKeyWordList.Add("USING");
            ABAPKeyWordList.Add("VALUES");
            ABAPKeyWordList.Add("VARYING");
            ABAPKeyWordList.Add("VIEW");
            ABAPKeyWordList.Add("WAITFOR");
            ABAPKeyWordList.Add("WHEN");
            ABAPKeyWordList.Add("WHERE");
            ABAPKeyWordList.Add("WHILE");
            ABAPKeyWordList.Add("WINDOW");
            ABAPKeyWordList.Add("WITH");
            ABAPKeyWordList.Add("WORK");
            ABAPKeyWordList.Add("WRITE");

        }

        private void prettyCode()
        {
            //WordColorInit();
            textResultCode.Settings.Comment = "\"";

            // Set the colors that will be used.
            textResultCode.Settings.KeywordColor = Color.Blue;
            textResultCode.Settings.CommentColor = Color.Green;
            textResultCode.Settings.StringColor = Color.Gray;
            textResultCode.Settings.IntegerColor = Color.Red;

            // Let's not process strings and integers.
            textResultCode.Settings.EnableStrings = true;
            textResultCode.Settings.EnableIntegers = true;

            // Let's make the settings we just set valid by compiling
            // the keywords to a regular expression.
            textResultCode.CompileKeywords();
            textResultCode.ProcessAllLines();



            // Add the keywords to the list.
            textTemplate.Settings.Keywords.Add("$");
            // textTemplate.Settings.Keywords.Add("if");
            // textTemplate.Settings.Keywords.Add("then");
            //  textTemplate.Settings.Keywords.Add("else");
            //  textTemplate.Settings.Keywords.Add("elseif");
            //  textTemplate.Settings.Keywords.Add("end");

            // Set the comment identifier. For Lua this is two minus-signs after each other (--). 
            // For C++ we would set this property to "//".
            textTemplate.Settings.Comment = "#";

            // Set the colors that will be used.
            textTemplate.Settings.KeywordColor = Color.Blue;
            textTemplate.Settings.CommentColor = Color.Green;
            textTemplate.Settings.StringColor = Color.Gray;
            textTemplate.Settings.IntegerColor = Color.Red;

            // Let's not process strings and integers.
            textTemplate.Settings.EnableStrings = true;
            textTemplate.Settings.EnableIntegers = false;

            // Let's make the settings we just set valid by compiling
            // the keywords to a regular expression.
            textTemplate.CompileKeywords();


            textTemplate.ProcessAllLines();
        }
        private void tspLoadSystax_Click(object sender, EventArgs e)
        {
            prettyCode();

        }

        private void btnOpenDb_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DB_NAME))
            {
                openSqliteDbfile();
                // btnOpenDb.Text = "关闭模板文件";
            }
            else
            {

                closeSqliteDbfile();
                //  btnOpenDb.Text = "打开模板文件";
            }


        }

        private void closeSqliteDbfile()
        {
            //lblconnected.Text = "Disconnected";

            //DB_NAME = string.Empty;
            //userDataGridView.DataSource = null;
            //dataAdapter = null;
            //tablecombobox.Items.Clear();
        }

        private void openSqliteDbfile()
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    opnfiledlg.CheckPathExists = true;
            //    opnfiledlg.CheckFileExists = true;
            //    opnfiledlg.Filter = "DB Files (*.db)|*.db|All Files(*.*)|*.*";
            //    opnfiledlg.Multiselect = false;
            //    opnfiledlg.Title = "Select SQLite Database File";

            //    if (opnfiledlg.ShowDialog() == DialogResult.OK)
            //    {
            //        //Connects To SQLiteDatabase

            //      //  lblconnected.Text = "Connected";

            //        DB_NAME = opnfiledlg.FileName;

            //        reload_tables();
            //    }
            //}
            //catch (SQLiteException sqliteex)
            //{
            //    MessageBox.Show(sqliteex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void tablecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DB_NAME == null)
            //    {
            //        MessageBox.Show("Open an existing database or Create a new database");
            //        return;
            //    }

            //    this.dataSet = new DataSet();
            //    string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);

            //    SQLiteConnection sqlconn = new SQLiteConnection(connString);
            //    sqlconn.Open();

            //    string CommandText = String.Format("Select * from {0};", tablecombobox.Text);

            //    this.dataAdapter = new SQLiteDataAdapter(CommandText, sqlconn);
            //    SQLiteCommandBuilder builder = new SQLiteCommandBuilder(this.dataAdapter);

            //    this.dataAdapter.Fill(this.dataSet, tablecombobox.Text);

            //    userDataGridView.DataSource = this.dataSet;
            //    userDataGridView.DataMember = tablecombobox.Text;

            //}
            //catch (SQLiteException sqlex)
            //{
            //    MessageBox.Show(sqlex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //加载数据库中所有的数据。
        private void reload_tables()
        {
            //try
            //{
            //    tablecombobox.Items.Clear();

            //    DataSet ds = new DataSet();

            //    if (DB_NAME == null)
            //    {
            //        MessageBox.Show("Open an existing database or Create a new database");
            //        return;
            //    }

            //    string connString = String.Format("Data Source={0};New=False;Version=3", DB_NAME);

            //    SQLiteConnection sqlconn = new SQLiteConnection(connString);

            //    sqlconn.Open();

            //    string CommandText = "Select name from sqlite_master;";

            //    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(CommandText, sqlconn);
            //    dataAdapter.Fill(ds);

            //    DataRowCollection dataRowCol = ds.Tables[0].Rows;

            //    foreach (DataRow dr in dataRowCol)
            //    {
            //        tablecombobox.Items.Add(dr["name"]);
            //    }

            //    if (tablecombobox.Items.Count > 0)
            //    {
            //        tablecombobox.SelectedIndex = 0;
            //       // btnDelete.Enabled = true;
            //    }
            //    else
            //    {
            //        tablecombobox.Text = " ";
            //      //  btnDelete.Enabled = false;
            //    }

            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            return;
        }


        DataTable dt;
        private void btnOpenTemplateTable_Click(object sender, EventArgs e)
        {
            String dbName = ConfigFileTool.SAPGlobalSettings.GetTemplateDb();
            dt = new DataTable();
            SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(dbName);
            dbhelper.LogEvents = true;

            dbhelper.DataTableFill(dt, "Select * from codeTemplate");
            this.userDataGridView.DataSource = null;
            this.userDataGridView.DataSource = dt;
        }

        private void btnUpdateTemplate_Click(object sender, EventArgs e)
        {
            String dbName = ConfigFileTool.SAPGlobalSettings.GetTemplateDb();
            SAPINTDB.netlib7 dbhelper = new SAPINTDB.netlib7(dbName);
            dbhelper.LogEvents = true;
            dbhelper.DataTableUpdate(dt, "Select * from codeTemplate");
            dt.AcceptChanges();
            this.userDataGridView.DataSource = dt;
        }

        private void btnInserTemplate_Click(object sender, EventArgs e)
        {
            if (dgvSelectedCell != null)
            {
                dgvSelectedCell.Value = this.textTemplate.Text;

            }
            else
            {
                MessageBox.Show("请选择单元格！！！");
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            this.processTemplate();
        }

        private void btnExcuteCode_Click(object sender, EventArgs e)
        {
            ExcuteCode();
        }

        private void btnPrettyCode_Click(object sender, EventArgs e)
        {
            prettyCode();
        }

        private void userDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSelectedCell = userDataGridView[e.ColumnIndex, e.RowIndex];
            try
            {
                //if (checkboxAuto.Checked == true)
                //{
                    this.textTemplate.Text = dgvSelectedCell.Value.ToString();
                //}
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }
        }

        private void userDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSelectedCell = userDataGridView[e.ColumnIndex, e.RowIndex];
            try
            {
                if (checkboxAuto.Checked == true)
                {
                    this.textTemplate.Text = dgvSelectedCell.Value.ToString();
                }
            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }


        }


    }

}
