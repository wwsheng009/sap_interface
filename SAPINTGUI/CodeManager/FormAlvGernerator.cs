using NVelocity;
using NVelocity.App;
using SAPINT.RFCTable;
using SAPINTDB.CodeManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAPINT.Utils;
using SAPINTDB;


namespace SAPINT.Gui.CodeManager
{
    public partial class FormAlvGernerator : Form
    {

        private List<SAPTableInfo> m_tableList = null;
        private FormCodeManager m_FormCodeManager = null;

        private static readonly String CKey = "Key";
        private static readonly String CValue = "Value";
        private static readonly String CComment = "Comment";
        private static readonly String CSelect = "Select";
        private static readonly String CInput = "Input";
        private static readonly String CCategory = "Category";

        private static readonly String CLength = "Length";
        private static readonly String CLayout = "Layout";
        private static readonly String CEvent = "Event";
        //设置集合
        Dictionary<string, object> m_template_items = null;

        //设置集合，用于用户直接输入或修改简单数据
        DataTable dt_settings = new DataTable();

        DataTable dt_layout = new DataTable();

        //List<AlvSetting> m_alvsetting = new List<AlvSetting>();

        //FCAT设置。
        DataTable dtFieldCat = null;
        List<CLVC_S_FCAT> listFcat = null;//用于保存模板设置，使用对象的方式方便模板处理

        //程序抬头文本。
        String headerTxt = string.Empty;

        public FormAlvGernerator()
        {
            InitializeComponent();

            //初始化一个dt,用于保存设置.
            dt_settings.Columns.Add(new DataColumn() { DataType = typeof(String), ColumnName = CKey });
            dt_settings.Columns.Add(new DataColumn() { DataType = typeof(object), ColumnName = CValue });
            dt_settings.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = CComment });



            //构造一个字段设置内表.
            dtFieldCat = CLVC_S_FCAT.buildDtSchma();

            m_template_items = new Dictionary<string, object>();


            //初始化抬头信息.
            this.txtAuthor.Text = Properties.Settings.Default.Author;
            this.txtProgramName.Text = Properties.Settings.Default.Program_name;
            this.txtProjectName.Text = Properties.Settings.Default.Project_name;
            this.txtTitle.Text = Properties.Settings.Default.Title_text;

            updateHeaderInfo();

            this.WindowState = FormWindowState.Maximized;

            this.chxEditable.CheckStateChanged += chxEditable_CheckStateChanged;

            //初始化一个dt,用于保存布局设置.
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(String), ColumnName = CKey });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = CComment });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(bool), ColumnName = CSelect });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = CInput });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(object), ColumnName = CValue, Expression = "IIF((Select = 'true' AND (ISNULL(Input,'') = '')),'X',Input)" });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(string), ColumnName = CCategory });
            dt_layout.Columns.Add(new DataColumn() { DataType = typeof(int), ColumnName = CLength });


            InitLayoutSettings();
            dgvLayout.DataSource = dt_layout;

            new DgvFilterPopup.DgvFilterManager(this.dgvLayout);

            this.cbxCategory.SelectedIndexChanged += cbxCategory_SelectedIndexChanged;
            this.cbxCategory.TextChanged += cbxCategory_TextChanged;
        }

        void cbxCategory_TextChanged(object sender, EventArgs e)
        {

            DataView v = dt_layout.DefaultView;
            var str = string.Format("{0} = '{1}'", CCategory, cbxCategory.Text);
            if (String.IsNullOrEmpty(cbxCategory.Text))
            {
                v.RowFilter = null;
            }
            else
            {
                v.RowFilter = str;
            }
            dgvLayout.DataSource = v;




            //throw new NotImplementedException();

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dt_layout;

            //dgvLayout.DataSource = bs;
            //bs.Filter = str;
        }

        void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataView v = dt_layout.DefaultView;

            var str = string.Format("{0} = {1}", CCategory, cbxCategory.SelectedValue);
            v.RowFilter = str;
            dgvLayout.DataSource = v;
            //throw new NotImplementedException();
        }
        void InitLayoutSettings()
        {
            CodeGerneratorHelper db = new CodeGerneratorHelper();

            var dt = db.GetAlvSettings();

            dt_layout.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DataRow r = dt_layout.NewRow();
                r[CKey] = row[CKey];
                r[CComment] = row[CComment];
                r[CSelect] = row[CSelect];
                if (row[CInput] == DBNull.Value)
                {
                    r[CInput] = "";
                }
                else
                {
                    r[CInput] = row[CInput];
                }

                // r[CValue] = row[CValue];
                r[CCategory] = row[CCategory];
                r[CLength] = row[CLength];
                dt_layout.Rows.Add(r);

                if (!cbxCategory.Items.Contains(r[CCategory]))
                {
                    cbxCategory.Items.Add(r[CCategory]);
                }


            }



        }

        void chxEditable_CheckStateChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;

            foreach (DataRow item in dtFieldCat.Rows)
            {
                var keyflag = false;

                if (String.IsNullOrEmpty(item[CLVC_S_FCAT.C_KEY].ToString()))
                {
                    keyflag = false;
                }
                else
                {
                    keyflag = (bool)item[CLVC_S_FCAT.C_KEY];
                }

                if (keyflag != true)
                {
                    item[CLVC_S_FCAT.C_EDIT] = checkBox.Checked;
                }
                else
                {
                    item[CLVC_S_FCAT.C_EDIT] = false;
                }




            }

            //throw new NotImplementedException();
        }
        /// <summary>
        /// 增加默认设置
        /// </summary>
        private void InitSettings()
        {
            //add the default event options
            //初始化设置
            foreach (var item in chxList_alv_grid_events.Items)
            {
                m_template_items.Add(item.ToString(), false);
            }
            m_template_items.Add(AlvSetting.ADD_BOX, false);
            m_template_items.Add(AlvSetting.ADD_HEADER_PAGE, false);
        }

        public void setTableList(List<SAPTableInfo> pTableList)
        {
            m_tableList = pTableList;
            if (m_tableList.Count > 0)
            {
                m_template_items.Add("tables", m_tableList);
            }

            setFieldCat();


        }
        /// <summary>
        /// 设置字段清单
        /// </summary>
        public void setFieldCat()
        {
            int i = 1;
            foreach (var table in m_tableList)
            {
                foreach (var item in table.Fields)
                {
                    if (item.Selected == false)
                    {
                        continue;
                    }
                    DataRow dr = dtFieldCat.NewRow();
                    dr["Index"] = i;
                    dr[CLVC_S_FCAT.C_SELECT] = true;


                    //dr["ROW_POS"] =
                    dr["COL_POS"] = i;
                    dr["FIELDNAME"] = item.FIELDNAME.ToUpper();
                    dr["TABNAME"] = table.name.ToUpper();
                    //dr["CURRENCY"] = 
                    //dr["CFIELDNAME"] =
                    //dr["QUANTITY"] = 
                    //dr["QFIELDNAME"] =
                    //dr["IFIELDNAME"] =
                    //dr["ROUND"] =
                    //dr["EXPONENT"] =
                    if (item.KEYFLAG == "X")
                    {
                        dr["KEY"] = true;
                    }

                    //dr["KEY_SEL"] =
                    //dr["ICON"] =
                    //dr["SYMBOL"] =
                    if (item.OUTPUTLEN == 1)
                    {
                        dr["CHECKBOX"] = true;
                    }

                    //dr["JUST"] =
                    //dr["LZERO"] =
                    //dr["NO_SIGN"] =
                    dr["NO_ZERO"] = true;
                    //dr["NO_CONVEXT"] =
                    //dr["EDIT_MASK"] =
                    dr["EMPHASIZE"] = true;
                    //dr["FIX_COLUMN"] =
                    //dr["DO_SUM"] =
                    //dr["NO_SUM"] =
                    //dr["NO_OUT"] =
                    //dr["TECH"] =
                    dr["OUTPUTLEN"] = item.OUTPUTLEN;
                    //dr["CONVEXIT"] =

                    dr["TOOLTIP"] = item.FIELDTEXT;
                    dr["ROLLNAME"] = item.ROLLNAME;
                    dr["DATATYPE"] = item.DATATYPE;
                    //dr["INTTYPE"] = item.INTTYPE;
                    //dr["INTLEN"] = item.INTTYPE;
                    //dr["LOWERCASE"] =
                    dr["REPTEXT"] = item.REPTEXT;
                    //dr["HIER_LEVEL"] =
                    //dr["REPREP"] =
                    //dr["DOMNAME"] =
                    //dr["SP_GROUP"] =
                    //dr["HOTSPOT"] =
                    //dr["DFIELDNAME"] =
                    //dr["COL_ID"] =
                    if (!String.IsNullOrEmpty(item.REFTABLE) && !String.IsNullOrEmpty(item.REFFIELD))
                    {
                        dr["F4AVAILABL"] = true;
                    }
                    if (!String.IsNullOrEmpty(item.CHECKTABLE))
                    {
                        dr["F4AVAILABL"] = true;
                    }

                    //dr["AUTO_VALUE"] =
                    dr["CHECKTABLE"] = item.CHECKTABLE;
                    //dr["VALEXI"] =
                    //dr["WEB_FIELD"] =
                    //dr["HREF_HNDL"] =
                    //dr["STYLE"] =
                    //dr["STYLE2"] =
                    //dr["STYLE3"] =
                    //dr["STYLE4"] =
                    //dr["DRDN_HNDL"] =
                    //dr["DRDN_FIELD"] =
                    //dr["NO_MERGING"] =
                    //dr["H_FTYPE"] =
                    dr["COL_OPT"] = true;
                    //dr["NO_INIT_CH"] =
                    //dr["DRDN_ALIAS"] =
                    //dr["DECFLOAT_STYLE"] =
                    //dr["PARAMETER0"] =
                    //dr["PARAMETER1"] =
                    //dr["PARAMETER2"] =
                    //dr["PARAMETER3"] =
                    //dr["PARAMETER4"] =
                    //dr["PARAMETER5"] =
                    //dr["PARAMETER6"] =
                    //dr["PARAMETER7"] =
                    //dr["PARAMETER8"] =
                    //dr["PARAMETER9"] =
                    dr["REF_FIELD"] = item.REFFIELD.ToUpper();
                    dr["REF_TABLE"] = table.name.ToUpper();
                    //dr["TXT_FIELD"] =
                    //dr["ROUNDFIELD"] =
                    //dr["intS_O"] =
                    //dr["DECMLFIELD"] =
                    //dr["DD_OUTLEN"] = item.OUTPUTLEN;
                    //dr["intS"] = item.intS;
                    dr["COLTEXT"] = item.SCRTEXT_M;
                    dr["SELTEXT"] = item.FIELDTEXT;
                    dr["SCRTEXT_L"] = item.SCRTEXT_L;
                    dr["SCRTEXT_M"] = item.SCRTEXT_M;
                    dr["SCRTEXT_S"] = item.SCRTEXT_S;
                    //dr["COLDDICTXT"] =
                    //dr["SELDDICTXT"] =
                    //dr["TIPDDICTXT"] =
                    if (this.chxEditable.Checked == true && item.KEYFLAG != "X")
                    {
                        dr["EDIT"] = true;

                    }

                    //dr["TECH_COL"] =
                    //dr["TECH_FORM"] =
                    //dr["TECH_COMP"] =
                    //dr["HIER_CPOS"] =
                    //dr["H_COL_KEY"] =
                    //dr["H_SELECT"] =
                    //dr["DD_ROLL"] =
                    //dr["DRAGDROPID"] =
                    //dr["MAC"] =
                    //dr["INDX_FIELD"] =
                    //dr["INDX_CFIEL"] =
                    //dr["INDX_QFIEL"] =
                    //dr["INDX_IFIEL"] =
                    //dr["INDX_ROUND"] =
                    //dr["INDX_DECML"] =
                    //dr["GET_STYLE"] =
                    //dr["MARK"] =

                    i++;
                    dtFieldCat.Rows.Add(dr);
                }
            }

            this.dgvFieldCat.DataSource = dtFieldCat;
            // this.dgvFieldCat.AutoResizeColumns();

            dgvFieldCat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvFieldCat.AutoResizeColumns();
            // this.dgvFieldCat.AutoResizeColumns();

            CLVC_S_FCAT.ConfigDgv(dgvFieldCat);

        }

        public void setFormCodeManager(FormCodeManager p_FormCodeManager)
        {
            m_FormCodeManager = p_FormCodeManager;
        }
        /// <summary>
        /// 生成代码
        /// </summary>
        public void Gernerate()
        {
            try
            {
                string template = string.Empty;
                if (m_FormCodeManager.TemplateCode == null)
                {
                    MessageBox.Show("请选择代码模板");
                    return;
                }
                var _Code = m_FormCodeManager.GetLatestCode(m_FormCodeManager.TemplateCode);

                if (_Code == null)
                {
                    MessageBox.Show("无法读取模板！");
                    return;
                }
                template = _Code.Content;
                VelocityContext ct = new VelocityContext();

                if (m_template_items != null)
                {
                    foreach (var pair in m_template_items)
                    {
                        ct.Put(pair.Key, pair.Value);
                    }
                }

                VelocityEngine ve = new VelocityEngine();
                ve.Init();
                //ct.Put("tables", m_tableList);


                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                bool ok = ve.Evaluate(ct, vltWriter, null, template);
                if (!ok)
                {
                    MessageBox.Show("生成模板出错");
                    return;
                }

                String result = vltWriter.ToString();

                var _newCode = new Code();
                _newCode.Content = result;
                _newCode.Category = _Code.Category;
                _newCode.Title = m_FormCodeManager.TemplateCode.Title + "_NEW*";
                m_FormCodeManager.AddNewCodeToTempFolder(_newCode, true);
                // newCode.TreeId = m_FormCodeManager.SelectedTree.Id;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }


        private void updateOptions(string key, object obj)
        {
            if (m_template_items.Keys.Contains(key))
            {
                m_template_items[key] = obj;
            }
            else
            {
                m_template_items.Add(key, obj);
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            updateOptionsToSetting();
            dt_settings.Clear();
            foreach (var item in m_template_items)
            {
                dt_settings.Rows.Add(new object[] { item.Key, item.Value, AlvSettingCollection.getSetting(item.Key).Description });
            }

            this.dataGridView1.DataSource = dt_settings;
            this.dataGridView1.AutoResizeColumns();
            tabPage3.BringToFront();

        }



        /// <summary>
        /// 更新所有的选项
        /// </summary>
        private void updateOptionsToSetting()
        {
            //try
            //{
            if (m_tableList != null)
            {

                if (m_tableList.Count > 0)
                {
                    updateOptions(AlvSetting.TABLES_COUNT, m_tableList.Count);
                    updateOptions(AlvSetting.FIRST_TABLE_NAME, m_tableList.First().name);
                    updateOptions(AlvSetting.LAST_TABLE_NAME, m_tableList.Last().name);
                }
            }
            else
            {
                MessageBox.Show("字段列表不存在");
            }

            updateOptions(AlvSetting.HEADER_TXT, this.txtHeaderInfo.Text);
            updateOptions(AlvSetting.PROGRAM_NAME, this.txtProgramName.Text);

            updateOptions(AlvSetting.EDITABLE, this.chxEditable.Checked);
            updateOptions(AlvSetting.TRAFFIC_LIGHT, this.chxTrafficLight.Checked);
            updateOptions(AlvSetting.ADD_BOX, this.chxAddBox.Checked);
            updateOptions(AlvSetting.ADD_HEADER_PAGE, this.chxAddHeaderPage.Checked);
            updateOptions(AlvSetting.TITLE_TEXT, this.txtTitle.Text);

            for (int i = 0; i < chxList_alv_grid_events.Items.Count; i++)
            {
                var state = chxList_alv_grid_events.GetItemCheckState(i);

                if (state == CheckState.Checked)
                {
                    updateOptions(chxList_alv_grid_events.Items[i].ToString(), true);
                }
                else if (state == CheckState.Unchecked)
                {
                    updateOptions(chxList_alv_grid_events.Items[i].ToString(), false);
                }
            }

            foreach (DataRow item in dt_layout.Rows)
            {
                updateOptions(item[CKey].ToString(), item[CValue]);
            }
            //for (int i = 0; i < this.chxListLayout.Items.Count; i++)
            //{
            //    var state = chxListLayout.GetItemCheckState(i);

            //    if (state == CheckState.Checked)
            //    {
            //        updateOptions(chxListLayout.Items[i].ToString(), true);
            //    }
            //    else if (state == CheckState.Unchecked)
            //    {
            //        updateOptions(chxListLayout.Items[i].ToString(), false);
            //    }
            //}


            this.listFcat = dtFieldCat.ToList<CLVC_S_FCAT>() as List<CLVC_S_FCAT>;
            updateOptions(AlvSetting.FCAT, this.listFcat);

            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message);
            //}

        }

        private void updateGridValuesToSetting()
        {
            if (dt_settings != null)
            {

                foreach (DataRow dr in dt_settings.Rows)
                {
                    updateOptions(dr[CKey].ToString(), dr[CValue]);
                }
            }
        }
        private void btnUpdateSettings_Click(object sender, EventArgs e)
        {
            try
            {
                updateGridValuesToSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnUpdateHeaderInfo_Click(object sender, EventArgs e)
        {
            updateHeaderInfo();

        }
        private void updateHeaderInfo()
        {

            headerTxt = Properties.Settings.Default.HeaderDesc;

            this.txtHeaderInfo.Text = string.Format(headerTxt,
                this.txtProgramName.Text,
                this.txtProjectName.Text,
                this.txtTitle.Text,
                this.txtAuthor.Text,
                this.dateTimePicker1.Value.ToShortDateString(),
                this.txtDescription.Text
                );
        }

        private void btnGernerate_Click(object sender, EventArgs e)
        {
            if (m_FormCodeManager == null)
            {
                MessageBox.Show("代码管理器无法启动");
                return;
            }
            //if (m_tableList == null)
            //{
            //    MessageBox.Show("字段清单不存在");
            //    return;
            //}
            Gernerate();
        }


    }


    class AlvSetting
    {
        public static readonly String HEADER_TXT = "header_info";
        public static readonly String TITLE_TEXT = "title";
        public static readonly String PROGRAM_NAME = "program_name";

        public static readonly String ADD_BOX = "have_box";
        public static readonly String ADD_HEADER_PAGE = "add_header_page";
        public static readonly String EDITABLE = "eitable";
        public static readonly String TRAFFIC_LIGHT = "traffic_light";

        public static readonly String FCAT = "fcats";


        //表
        public static readonly String TABLES_COUNT = "tables_count";
        public static readonly String FIRST_TABLE_NAME = "first_table_name";
        public static readonly String LAST_TABLE_NAME = "last_table_name";
        //事件
        public static readonly String ITEM_DATA_EXPAND = "ITEM_DATA_EXPAND";
        public static readonly String REPREP_SEL_MODIFY = "REPREP_SEL_MODIFY";
        public static readonly String CALLER_EXIT = "CALLER_EXIT";
        public static readonly String USER_COMMAND = "USER_COMMAND";
        public static readonly String TOP_OF_PAGE = "TOP_OF_PAGE";
        public static readonly String DATA_CHANGED = "DATA_CHANGED";
        public static readonly String TOP_OF_COVERPAGE = "TOP_OF_COVERPAGE";
        public static readonly String END_OF_COVERPAGE = "END_OF_COVERPAGE";
        public static readonly String FOREIGN_TOP_OF_PAGE = "FOREIGN_TOP_OF_PAGE";
        public static readonly String FOREIGN_END_OF_PAGE = "FOREIGN_END_OF_PAGE";
        public static readonly String PF_STATUS_SET = "PF_STATUS_SET";
        public static readonly String LIST_MODIFY = "LIST_MODIFY";
        public static readonly String END_OF_PAGE = "END_OF_PAGE";


        String key;
        object value;
        String desc;
        public String Key
        {
            get { return key; }
            set { key = value; }
        }


        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public String Description
        {
            get { return desc; }
            set { desc = value; }
        }




    }

    class AlvSettingCollection
    {
        static Dictionary<string, AlvSetting> settingList = new Dictionary<string, AlvSetting>();

        public AlvSettingCollection()
        {
            settingList.Add(AlvSetting.TITLE_TEXT, new AlvSetting() { Key = AlvSetting.TITLE_TEXT, Value = false, Description = "标题" });
            settingList.Add(AlvSetting.PROGRAM_NAME, new AlvSetting() { Key = AlvSetting.PROGRAM_NAME, Value = false, Description = "程序名" });

            settingList.Add(AlvSetting.ADD_BOX, new AlvSetting() { Key = AlvSetting.ADD_BOX, Value = false, Description = "增加先择框" });
            settingList.Add(AlvSetting.ADD_HEADER_PAGE, new AlvSetting() { Key = AlvSetting.ADD_HEADER_PAGE, Value = false, Description = "增加抬头页" });
            settingList.Add(AlvSetting.EDITABLE, new AlvSetting() { Key = AlvSetting.EDITABLE, Value = false, Description = "可编辑" });

            settingList.Add(AlvSetting.TRAFFIC_LIGHT, new AlvSetting() { Key = AlvSetting.TRAFFIC_LIGHT, Value = false, Description = "增加交通灯" });

            settingList.Add(AlvSetting.ITEM_DATA_EXPAND, new AlvSetting() { Key = AlvSetting.ITEM_DATA_EXPAND, Value = false, Description = "ITEM_DATA_EXPAND" });
            settingList.Add(AlvSetting.REPREP_SEL_MODIFY, new AlvSetting() { Key = AlvSetting.REPREP_SEL_MODIFY, Value = false, Description = "REPREP_SEL_MODIFY" });
            settingList.Add(AlvSetting.CALLER_EXIT, new AlvSetting() { Key = AlvSetting.CALLER_EXIT, Value = false, Description = "CALLER_EXIT" });
            settingList.Add(AlvSetting.USER_COMMAND, new AlvSetting() { Key = AlvSetting.USER_COMMAND, Value = false, Description = "用户参数" });
            settingList.Add(AlvSetting.TOP_OF_PAGE, new AlvSetting() { Key = AlvSetting.TOP_OF_PAGE, Value = false, Description = "TOP_OF_PAGE" });
            settingList.Add(AlvSetting.DATA_CHANGED, new AlvSetting() { Key = AlvSetting.DATA_CHANGED, Value = false, Description = "数据改动" });
            settingList.Add(AlvSetting.TOP_OF_COVERPAGE, new AlvSetting() { Key = AlvSetting.TOP_OF_COVERPAGE, Value = false, Description = "TOP_OF_COVERPAGE" });
            settingList.Add(AlvSetting.END_OF_COVERPAGE, new AlvSetting() { Key = AlvSetting.END_OF_COVERPAGE, Value = false, Description = "END_OF_COVERPAGE" });
            settingList.Add(AlvSetting.FOREIGN_TOP_OF_PAGE, new AlvSetting() { Key = AlvSetting.FOREIGN_TOP_OF_PAGE, Value = false, Description = "FOREIGN_TOP_OF_PAGE" });
            settingList.Add(AlvSetting.FOREIGN_END_OF_PAGE, new AlvSetting() { Key = AlvSetting.FOREIGN_END_OF_PAGE, Value = false, Description = "FOREIGN_END_OF_PAGE" });
            settingList.Add(AlvSetting.PF_STATUS_SET, new AlvSetting() { Key = AlvSetting.PF_STATUS_SET, Value = false, Description = "PF_STATUS_SET" });
            settingList.Add(AlvSetting.LIST_MODIFY, new AlvSetting() { Key = AlvSetting.LIST_MODIFY, Value = false, Description = "LIST_MODIFY" });
            settingList.Add(AlvSetting.END_OF_PAGE, new AlvSetting() { Key = AlvSetting.END_OF_PAGE, Value = false, Description = "END_OF_PAGE" });

        }
        public static AlvSetting getSetting(String key)
        {
            if (settingList.Count == 0)
            {
                new AlvSettingCollection();
            }
            AlvSetting s = null;
            if (settingList.TryGetValue(key, out s))
            {
                return s;
            }
            else
            {
                return new AlvSetting() { Description = string.Empty };
            }

        }

    }
    public class CLVC_S_FCAT
    {
        public static readonly string C_INDEX = "INDEX";
        public static readonly string C_SELECT = "SELECT";
        public static readonly string C_ROW_POS = "ROW_POS";// 输出行 (内部使用)
        public static readonly string C_COL_POS = "COL_POS";// 输出列
        public static readonly string C_FIELDNAME = "FIELDNAME";// 内部表字段的字段名称
        public static readonly string C_TABNAME = "TABNAME";// LVC 标签名称
        public static readonly string C_CURRENCY = "CURRENCY";// 货币单位
        public static readonly string C_CFIELDNAME = "CFIELDNAME";// 参考的当前单位的字段名称
        public static readonly string C_QUANTITY = "QUANTITY";// 计量单位
        public static readonly string C_QFIELDNAME = "QFIELDNAME";// 参考计量单位的字段名称
        public static readonly string C_IFIELDNAME = "IFIELDNAME";// 内部表字段的字段名称
        public static readonly string C_ROUND = "ROUND";// ROUND 值
        public static readonly string C_EXPONENT = "EXPONENT";// ALV 控制：流动表示的指数
        public static readonly string C_KEY = "KEY";// 关键字段
        public static readonly string C_KEY_SEL = "KEY_SEL";// 可以被隐藏的关键列
        public static readonly string C_ICON = "ICON";// 作为图标输出
        public static readonly string C_SYMBOL = "SYMBOL";// 输出作为符号
        public static readonly string C_CHECKBOX = "CHECKBOX";// 作为复选框输出
        public static readonly string C_JUST = "JUST";// 对齐
        public static readonly string C_LZERO = "LZERO";// 输出前导零
        public static readonly string C_NO_SIGN = "NO_SIGN";// ALV 控制：输出抑制符号
        public static readonly string C_NO_ZERO = "NO_ZERO";// 为输出隐藏零
        public static readonly string C_NO_CONVEXT = "NO_CONVEXT";// 不考虑输出的转换退出
        public static readonly string C_EDIT_MASK = "EDIT_MASK";// 为输出编辑掩码
        public static readonly string C_EMPHASIZE = "EMPHASIZE";// 带有颜色的高亮列
        public static readonly string C_FIX_COLUMN = "FIX_COLUMN";// 固定列
        public static readonly string C_DO_SUM = "DO_SUM";// 总计列值
        public static readonly string C_NO_SUM = "NO_SUM";// 没有总计列值
        public static readonly string C_NO_OUT = "NO_OUT";// 列没有输出
        public static readonly string C_TECH = "TECH";// 技术字段
        public static readonly string C_OUTPUTLEN = "OUTPUTLEN";// 列的字符宽度
        public static readonly string C_CONVEXIT = "CONVEXIT";// 转换例程
        public static readonly string C_SELTEXT = "SELTEXT";// 对话功能的列标识符
        public static readonly string C_TOOLTIP = "TOOLTIP";// 列抬头的工具提示
        public static readonly string C_ROLLNAME = "ROLLNAME";// F1 帮助的数据元素
        public static readonly string C_DATATYPE = "DATATYPE";// ABAP 字典中的数据类型
        public static readonly string C_INTTYPE = "INTTYPE";// ABAP 数据类型 (C,D,N,...)
        public static readonly string C_INTLEN = "INTLEN";// 内部长度（字节）
        public static readonly string C_LOWERCASE = "LOWERCASE";// 允许/不允许小写字母
        public static readonly string C_REPTEXT = "REPTEXT";// 标题
        public static readonly string C_HIER_LEVEL = "HIER_LEVEL";// 内部使用
        public static readonly string C_REPREP = "REPREP";// 价值是补充/补充接口的选择标准
        public static readonly string C_DOMNAME = "DOMNAME";// 定义域名
        public static readonly string C_SP_GROUP = "SP_GROUP";// 组代码
        public static readonly string C_HOTSPOT = "HOTSPOT";// 单击敏感
        public static readonly string C_DFIELDNAME = "DFIELDNAME";// 数据库中列组的字段名称
        public static readonly string C_COL_ID = "COL_ID";// 列 ID
        public static readonly string C_F4AVAILABL = "F4AVAILABL";// 字段有输入帮助吗
        public static readonly string C_AUTO_VALUE = "AUTO_VALUE";// 自动复制值
        public static readonly string C_CHECKTABLE = "CHECKTABLE";// 表名
        public static readonly string C_VALEXI = "VALEXI";// 固定值存在
        public static readonly string C_WEB_FIELD = "WEB_FIELD";// 内部表字段的字段名称
        public static readonly string C_HREF_HNDL = "HREF_HNDL";// 自然数
        public static readonly string C_STYLE = "STYLE";// 样式
        public static readonly string C_STYLE2 = "STYLE2";// 样式
        public static readonly string C_STYLE3 = "STYLE3";// 样式
        public static readonly string C_STYLE4 = "STYLE4";// 样式
        public static readonly string C_DRDN_HNDL = "DRDN_HNDL";// 自然数
        public static readonly string C_DRDN_FIELD = "DRDN_FIELD";// 内部表字段的字段名称
        public static readonly string C_NO_MERGING = "NO_MERGING";// 字符字段长度 1
        public static readonly string C_H_FTYPE = "H_FTYPE";// ALV 树控制: 功能类型 (总计,平均,最大.最小, ...)
        public static readonly string C_COL_OPT = "COL_OPT";// 可选列优化的条目
        public static readonly string C_NO_INIT_CH = "NO_INIT_CH";// 字符字段长度 1
        public static readonly string C_DRDN_ALIAS = "DRDN_ALIAS";// 字符字段长度 1
        public static readonly string C_DECFLOAT_STYLE = "DECFLOAT_STYLE";// DD: Output Style (Output Style) for Decfloat Types
        public static readonly string C_PARAMETER0 = "PARAMETER0";// 30 个字符
        public static readonly string C_PARAMETER1 = "PARAMETER1";// 30 个字符
        public static readonly string C_PARAMETER2 = "PARAMETER2";// 30 个字符
        public static readonly string C_PARAMETER3 = "PARAMETER3";// 30 个字符
        public static readonly string C_PARAMETER4 = "PARAMETER4";// 30 个字符
        public static readonly string C_PARAMETER5 = "PARAMETER5";// 自然数
        public static readonly string C_PARAMETER6 = "PARAMETER6";// 自然数
        public static readonly string C_PARAMETER7 = "PARAMETER7";// 自然数
        public static readonly string C_PARAMETER8 = "PARAMETER8";// 自然数
        public static readonly string C_PARAMETER9 = "PARAMETER9";// 自然数
        public static readonly string C_REF_FIELD = "REF_FIELD";// 内部表字段的参考字段名称
        public static readonly string C_REF_TABLE = "REF_TABLE";// 内部表字段的参考表名称
        public static readonly string C_TXT_FIELD = "TXT_FIELD";// 内部表字段的字段名称
        public static readonly string C_ROUNDFIELD = "ROUNDFIELD";// 带有 ROUND 说明的字段名称
        public static readonly string C_intS_O = "intS_O";// 输出小数位的编号
        public static readonly string C_DECMLFIELD = "DECMLFIELD";// 带有 intS 说明的字段名称
        public static readonly string C_DD_OUTLEN = "DD_OUTLEN";// 输出字符长度
        public static readonly string C_intS = "intS";// 小数位数
        public static readonly string C_COLTEXT = "COLTEXT";// 列标题
        public static readonly string C_SCRTEXT_L = "SCRTEXT_L";// 长字段标签
        public static readonly string C_SCRTEXT_M = "SCRTEXT_M";// 中字段标签
        public static readonly string C_SCRTEXT_S = "SCRTEXT_S";// 短字段标签
        public static readonly string C_COLDDICTXT = "COLDDICTXT";// 确定 DDIC 文本参考
        public static readonly string C_SELDDICTXT = "SELDDICTXT";// 确定 DDIC 文本参考
        public static readonly string C_TIPDDICTXT = "TIPDDICTXT";// 确定 DDIC 文本参考
        public static readonly string C_EDIT = "EDIT";// 准备输入
        public static readonly string C_TECH_COL = "TECH_COL";// 内部使用
        public static readonly string C_TECH_FORM = "TECH_FORM";// 内部使用
        public static readonly string C_TECH_COMP = "TECH_COMP";// 内部使用
        public static readonly string C_HIER_CPOS = "HIER_CPOS";// 层次列位置
        public static readonly string C_H_COL_KEY = "H_COL_KEY";// 树控制: 列名称/项目名称
        public static readonly string C_H_SELECT = "H_SELECT";// 标识是否可以选择树控制中的列
        public static readonly string C_DD_ROLL = "DD_ROLL";// 数据元素 (语义域)
        public static readonly string C_DRAGDROPID = "DRAGDROPID";// 拖&放处理拖放对象
        public static readonly string C_MAC = "MAC";// 字符字段长度 1
        public static readonly string C_INDX_FIELD = "INDX_FIELD";// 自然数
        public static readonly string C_INDX_CFIEL = "INDX_CFIEL";// 自然数
        public static readonly string C_INDX_QFIEL = "INDX_QFIEL";// 自然数
        public static readonly string C_INDX_IFIEL = "INDX_IFIEL";// 自然数
        public static readonly string C_INDX_ROUND = "INDX_ROUND";// 自然数
        public static readonly string C_INDX_DECML = "INDX_DECML";// 自然数
        public static readonly string C_GET_STYLE = "GET_STYLE";// 字符字段长度 1
        public static readonly string C_MARK = "MARK";// 字符字段长度 1

        public int Index { get; set; }
        public bool Select { get; set; }
        public int row_pos { get; set; } // 输出行 (内部使用)
        public int col_pos { get; set; } // 输出列
        public String fieldname { get; set; } // 内部表字段的字段名称
        public String tabname { get; set; } // LVC 标签名称
        public String currency { get; set; } // 货币单位
        public String cfieldname { get; set; } // 参考的当前单位的字段名称
        public String quantity { get; set; } // 计量单位
        public String qfieldname { get; set; } // 参考计量单位的字段名称
        public String ifieldname { get; set; } // 内部表字段的字段名称
        public int round { get; set; } // ROUND 值
        public String exponent { get; set; } // ALV 控制：流动表示的指数
        public bool key { get; set; } // 关键字段
        public bool key_sel { get; set; } // 可以被隐藏的关键列
        public bool icon { get; set; } // 作为图标输出
        public bool symbol { get; set; } // 输出作为符号
        public bool checkbox { get; set; } // 作为复选框输出
        public bool just { get; set; } // 对齐
        public bool lzero { get; set; } // 输出前导零
        public bool no_sign { get; set; } // ALV 控制：输出抑制符号
        public bool no_zero { get; set; } // 为输出隐藏零
        public bool no_convext { get; set; } // 不考虑输出的转换退出
        public String edit_mask { get; set; } // 为输出编辑掩码
        public bool emphasize { get; set; } // 带有颜色的高亮列
        public bool fix_column { get; set; } // 固定列
        public bool do_sum { get; set; } // 总计列值
        public bool no_sum { get; set; } // 没有总计列值
        public bool no_out { get; set; } // 列没有输出
        public String tech { get; set; } // 技术字段
        public int outputlen { get; set; } // 列的字符宽度
        public String convexit { get; set; } // 转换例程
        public String seltext { get; set; } // 对话功能的列标识符
        public String tooltip { get; set; } // 列抬头的工具提示
        public String rollname { get; set; } // F1 帮助的数据元素
        public String datatype { get; set; } // ABAP 字典中的数据类型
        public String inttype { get; set; } // ABAP 数据类型 (C,D,N,...)
        public int intlen { get; set; } // 内部长度（字节）
        public bool lowercase { get; set; } // 允许/不允许小写字母
        public String reptext { get; set; } // 标题
        public int hier_level { get; set; } // 内部使用
        public String reprep { get; set; } // 价值是补充/补充接口的选择标准
        public String domname { get; set; } // 定义域名
        public String sp_group { get; set; } // 组代码
        public bool hotspot { get; set; } // 单击敏感
        public String dfieldname { get; set; } // 数据库中列组的字段名称
        public int col_id { get; set; } // 列 ID
        public bool f4availabl { get; set; } // 字段有输入帮助吗
        public bool auto_value { get; set; } // 自动复制值
        public String checktable { get; set; } // 表名
        public bool valexi { get; set; } // 固定值存在
        public String web_field { get; set; } // 内部表字段的字段名称
        public int href_hndl { get; set; } // 自然数
        public String style { get; set; } // 样式
        public String style2 { get; set; } // 样式
        public String style3 { get; set; } // 样式
        public String style4 { get; set; } // 样式
        public int drdn_hndl { get; set; } // 自然数
        public String drdn_field { get; set; } // 内部表字段的字段名称
        public bool no_merging { get; set; } // 字符字段长度 1
        public String h_ftype { get; set; } // ALV 树控制: 功能类型 (总计,平均,最大.最小, ...)
        public bool col_opt { get; set; } // 可选列优化的条目
        public bool no_init_ch { get; set; } // 字符字段长度 1
        public bool drdn_alias { get; set; } // 字符字段长度 1
        public int decfloat_style { get; set; } // DD: Output Style (Output Style) for Decfloat Types
        public String parameter0 { get; set; } // 30 个字符
        public String parameter1 { get; set; } // 30 个字符
        public String parameter2 { get; set; } // 30 个字符
        public String parameter3 { get; set; } // 30 个字符
        public String parameter4 { get; set; } // 30 个字符
        public int parameter5 { get; set; } // 自然数
        public int parameter6 { get; set; } // 自然数
        public int parameter7 { get; set; } // 自然数
        public int parameter8 { get; set; } // 自然数
        public int parameter9 { get; set; } // 自然数
        public String ref_field { get; set; } // 内部表字段的参考字段名称
        public String ref_table { get; set; } // 内部表字段的参考表名称
        public String txt_field { get; set; } // 内部表字段的字段名称
        public String roundfield { get; set; } // 带有 ROUND 说明的字段名称
        public String ints_o { get; set; } // 输出小数位的编号
        public String decmlfield { get; set; } // 带有 intS 说明的字段名称
        public int dd_outlen { get; set; } // 输出字符长度
        public int ints { get; set; } // 小数位数
        public String coltext { get; set; } // 列标题
        public String scrtext_l { get; set; } // 长字段标签
        public String scrtext_m { get; set; } // 中字段标签
        public String scrtext_s { get; set; } // 短字段标签
        public bool colddictxt { get; set; } // 确定 DDIC 文本参考
        public bool selddictxt { get; set; } // 确定 DDIC 文本参考
        public bool tipddictxt { get; set; } // 确定 DDIC 文本参考
        public bool edit { get; set; } // 准备输入
        public int tech_col { get; set; } // 内部使用
        public int tech_form { get; set; } // 内部使用
        public bool tech_comp { get; set; } // 内部使用
        public int hier_cpos { get; set; } // 层次列位置
        public String h_col_key { get; set; } // 树控制: 列名称/项目名称
        public bool h_select { get; set; } // 标识是否可以选择树控制中的列
        public String dd_roll { get; set; } // 数据元素 (语义域)
        public int dragdropid { get; set; } // 拖&放处理拖放对象
        public bool mac { get; set; } // 字符字段长度 1
        public int indx_field { get; set; } // 自然数
        public int indx_cfiel { get; set; } // 自然数
        public int indx_qfiel { get; set; } // 自然数
        public int indx_ifiel { get; set; } // 自然数
        public int indx_round { get; set; } // 自然数
        public int indx_decml { get; set; } // 自然数
        // public bool get_style { get; set; } // 字符字段长度 1
        public bool mark { get; set; } // 字符字段长度 1

        public static DataTable buildDtSchma()
        {
            DataTable dt = null;
            dt = new DataTable("LVC_S_FCAT");
            dt.Columns.AddRange(new DataColumn[]{
		    	new DataColumn(C_INDEX,typeof(int)),//索引
	    		new DataColumn(C_SELECT,typeof(bool)),//是否选择
                new DataColumn(C_FIELDNAME,typeof(String)),// 内部表字段的字段名称
    			new DataColumn(C_TABNAME,typeof(String)),// LVC 标签名称
                new DataColumn(C_SCRTEXT_S,typeof(String)),// 短字段标签
                new DataColumn(C_KEY,typeof(bool)),// 关键字段
    			new DataColumn(C_EDIT,typeof(bool)),// 准备输入
    			
    			new DataColumn(C_CHECKBOX,typeof(bool)),// 作为复选框输出
    			new DataColumn(C_COL_OPT,typeof(bool)),// 可选列优化的条目
    			new DataColumn(C_LZERO,typeof(bool)),// 输出前导零
    			new DataColumn(C_NO_SIGN,typeof(bool)),// ALV 控制：输出抑制符号
    			new DataColumn(C_NO_ZERO,typeof(bool)),// 为输出隐藏零
                new DataColumn(C_DO_SUM,typeof(bool)),// 总计列值
    			new DataColumn(C_NO_SUM,typeof(bool)),// 没有总计列值
    			new DataColumn(C_NO_OUT,typeof(bool)),// 列没有输出
                new DataColumn(C_FIX_COLUMN,typeof(bool)),// 固定列
    			new DataColumn(C_LOWERCASE,typeof(bool)),// 允许/不允许小写字母
                new DataColumn(C_HOTSPOT,typeof(bool)),// 单击敏感
                new DataColumn(C_EMPHASIZE,typeof(bool)),// 带有颜色的高亮列
                new DataColumn(C_NO_MERGING,typeof(bool)),// 字符字段长度 1

                new DataColumn(C_NO_CONVEXT,typeof(bool)),// 不考虑输出的转换退出
                new DataColumn(C_F4AVAILABL,typeof(bool)),// 字段有输入帮助吗
    			new DataColumn(C_VALEXI,typeof(bool)),// 固定值存在
                
                new DataColumn(C_AUTO_VALUE,typeof(bool)),// 自动复制值
                new DataColumn(C_JUST,typeof(bool)),// 对齐
                new DataColumn(C_KEY_SEL,typeof(bool)),// 可以被隐藏的关键列
    			
    			new DataColumn(C_ICON,typeof(bool)),// 作为图标输出
    			new DataColumn(C_SYMBOL,typeof(bool)),// 输出作为符号

                new DataColumn(C_OUTPUTLEN,typeof(int)),// 列的字符宽度
                new DataColumn(C_ROUND,typeof(int)),// ROUND 值


                new DataColumn(C_ROW_POS,typeof(int)),// 输出行 (内部使用)
    			new DataColumn(C_COL_POS,typeof(int)),// 输出列

                new DataColumn(C_INTLEN,typeof(int)),// 内部长度（字节）
                //new DataColumn(C_DD_OUTLEN,typeof(int)),// 输出字符长度
    			new DataColumn(C_intS,typeof(int)),// 小数位数

                new DataColumn(C_REF_FIELD,typeof(String)),// 内部表字段的参考字段名称
    			new DataColumn(C_REF_TABLE,typeof(String)),// 内部表字段的参考表名称

                new DataColumn(C_CFIELDNAME,typeof(String)),// 参考的当前单位的字段名称
    			new DataColumn(C_QUANTITY,typeof(String)),// 计量单位
    			new DataColumn(C_QFIELDNAME,typeof(String)),// 参考计量单位的字段名称
    			new DataColumn(C_IFIELDNAME,typeof(String)),// 内部表字段的字段名称
                new DataColumn(C_DFIELDNAME,typeof(String)),// 数据库中列组的字段名称

    			
                //new DataColumn(C_EXPONENT,typeof(String)),// ALV 控制：流动表示的指数

    			
    			new DataColumn(C_EDIT_MASK,typeof(String)),// 为输出编辑掩码
    			
    			new DataColumn(C_CURRENCY,typeof(String)),// 货币单位
                new DataColumn(C_TECH,typeof(String)),// 技术字段
    			
                new DataColumn(C_CONVEXIT,typeof(String)),// 转换例程
    			
    			new DataColumn(C_TOOLTIP,typeof(String)),// 列抬头的工具提示
    			new DataColumn(C_ROLLNAME,typeof(String)),// F1 帮助的数据元素
                new DataColumn(C_DOMNAME,typeof(String)),// 定义域名
    			new DataColumn(C_DATATYPE,typeof(String)),// ABAP 字典中的数据类型
                new DataColumn(C_INTTYPE,typeof(String)),// ABAP 数据类型 (C,D,N,...)

                new DataColumn(C_SELTEXT,typeof(String)),// 对话功能的列标识符
    			new DataColumn(C_REPTEXT,typeof(String)),// 标题
                new DataColumn(C_COLTEXT,typeof(String)),// 列标题
    			new DataColumn(C_SCRTEXT_L,typeof(String)),// 长字段标签
    			new DataColumn(C_SCRTEXT_M,typeof(String)),// 中字段标签
    			
                //new DataColumn(C_COLDDICTXT,typeof(String)),// 确定 DDIC 文本参考
                //new DataColumn(C_SELDDICTXT,typeof(String)),// 确定 DDIC 文本参考
                //new DataColumn(C_TIPDDICTXT,typeof(String)),// 确定 DDIC 文本参考

                new DataColumn(C_REPREP,typeof(String)),// 价值是补充/补充接口的选择标准
    			
    			new DataColumn(C_SP_GROUP,typeof(String)),// 组代码
    			
    			
                new DataColumn(C_COL_ID,typeof(int)),// 列 ID

    			new DataColumn(C_CHECKTABLE,typeof(String)),// 表名
                
                //new DataColumn(C_HIER_LEVEL,typeof(int)),// 内部使用
                //new DataColumn(C_WEB_FIELD,typeof(String)),// 内部表字段的字段名称
                //new DataColumn(C_HREF_HNDL,typeof(int)),// 自然数
                //new DataColumn(C_STYLE,typeof(String)),// 样式
                //new DataColumn(C_STYLE2,typeof(String)),// 样式
                //new DataColumn(C_STYLE3,typeof(String)),// 样式
                //new DataColumn(C_STYLE4,typeof(String)),// 样式
                //new DataColumn(C_DRDN_HNDL,typeof(int)),// 自然数
                //new DataColumn(C_DRDN_FIELD,typeof(String)),// 内部表字段的字段名称
    			
                //new DataColumn(C_H_FTYPE,typeof(String)),// ALV 树控制: 功能类型 (总计,平均,最大.最小, ...)
    			
                //new DataColumn(C_NO_INIT_CH,typeof(String)),// 字符字段长度 1
                //new DataColumn(C_DRDN_ALIAS,typeof(String)),// 字符字段长度 1
                //new DataColumn(C_DECFLOAT_STYLE,typeof(int)),// DD: Output Style (Output Style) for Decfloat Types
                //new DataColumn(C_PARAMETER0,typeof(String)),// 30 个字符
                //new DataColumn(C_PARAMETER1,typeof(String)),// 30 个字符
                //new DataColumn(C_PARAMETER2,typeof(String)),// 30 个字符
                //new DataColumn(C_PARAMETER3,typeof(String)),// 30 个字符
                //new DataColumn(C_PARAMETER4,typeof(String)),// 30 个字符
                //new DataColumn(C_PARAMETER5,typeof(int)),// 自然数
                //new DataColumn(C_PARAMETER6,typeof(int)),// 自然数
                //new DataColumn(C_PARAMETER7,typeof(int)),// 自然数
                //new DataColumn(C_PARAMETER8,typeof(int)),// 自然数
                //new DataColumn(C_PARAMETER9,typeof(int)),// 自然数

                //new DataColumn(C_TXT_FIELD,typeof(String)),// 内部表字段的字段名称
                //new DataColumn(C_ROUNDFIELD,typeof(String)),// 带有 ROUND 说明的字段名称
                //new DataColumn(C_intS_O,typeof(String)),// 输出小数位的编号
                //new DataColumn(C_DECMLFIELD,typeof(String)),// 带有 intS 说明的字段名称
    			
    			
    			
                //new DataColumn(C_TECH_COL,typeof(int)),// 内部使用
                //new DataColumn(C_TECH_FORM,typeof(int)),// 内部使用
                //new DataColumn(C_TECH_COMP,typeof(String)),// 内部使用
                //new DataColumn(C_HIER_CPOS,typeof(int)),// 层次列位置
                //new DataColumn(C_H_COL_KEY,typeof(String)),// 树控制: 列名称/项目名称
                //new DataColumn(C_H_SELECT,typeof(String)),// 标识是否可以选择树控制中的列
                //new DataColumn(C_DD_ROLL,typeof(String)),// 数据元素 (语义域)
                //new DataColumn(C_DRAGDROPID,typeof(int)),// 拖&放处理拖放对象
                //new DataColumn(C_MAC,typeof(String)),// 字符字段长度 1
                //new DataColumn(C_INDX_FIELD,typeof(int)),// 自然数
                //new DataColumn(C_INDX_CFIEL,typeof(int)),// 自然数
                //new DataColumn(C_INDX_QFIEL,typeof(int   )),// 自然数
                //new DataColumn(C_INDX_IFIEL,typeof(int)),// 自然数
                //new DataColumn(C_INDX_ROUND,typeof(int)),// 自然数
                //new DataColumn(C_INDX_DECML,typeof(int)),// 自然数
                //new DataColumn(C_GET_STYLE,typeof(String)),// 字符字段长度 1
                //new DataColumn(C_MARK,typeof(String)),// 字符字段长度 1
  			});
            return dt;

        }
        public static void ConfigDgv(DataGridView dgv)
        {
            DataGridViewColumn dgvCol = null;
            dgvCol = dgv.Columns[C_INDEX];
            if (dgvCol != null) dgvCol.HeaderText = "索引";
            dgvCol = dgv.Columns[C_SELECT];
            if (dgvCol != null) dgvCol.HeaderText = "选择";
            dgvCol = dgv.Columns[C_ROW_POS];
            if (dgvCol != null) dgvCol.HeaderText = "输出行(内部使用)";
            dgvCol = dgv.Columns[C_COL_POS];
            if (dgvCol != null) dgvCol.HeaderText = "输出列";
            dgvCol = dgv.Columns[C_FIELDNAME];
            if (dgvCol != null) dgvCol.HeaderText = "字段名称";
            dgvCol = dgv.Columns[C_TABNAME];
            if (dgvCol != null) dgvCol.HeaderText = "表名";
            dgvCol = dgv.Columns[C_CURRENCY];
            if (dgvCol != null) dgvCol.HeaderText = "货币单位";
            dgvCol = dgv.Columns[C_CFIELDNAME];
            if (dgvCol != null) dgvCol.HeaderText = "参考的当前单位的字段名称";
            dgvCol = dgv.Columns[C_QUANTITY];
            if (dgvCol != null) dgvCol.HeaderText = "计量单位";
            dgvCol = dgv.Columns[C_QFIELDNAME];
            if (dgvCol != null) dgvCol.HeaderText = "参考计量单位的字段名称";
            dgvCol = dgv.Columns[C_IFIELDNAME];
            if (dgvCol != null) dgvCol.HeaderText = "内部表字段的字段名称";
            dgvCol = dgv.Columns[C_ROUND];
            if (dgvCol != null) dgvCol.HeaderText = "ROUND 值";
            dgvCol = dgv.Columns[C_EXPONENT];
            if (dgvCol != null) dgvCol.HeaderText = "流动表示的指数";
            dgvCol = dgv.Columns[C_KEY];
            if (dgvCol != null) dgvCol.HeaderText = "关键字段";
            dgvCol = dgv.Columns[C_KEY_SEL];
            if (dgvCol != null) dgvCol.HeaderText = "隐藏关键列";
            dgvCol = dgv.Columns[C_ICON];
            if (dgvCol != null) dgvCol.HeaderText = "输出图标";
            dgvCol = dgv.Columns[C_SYMBOL];
            if (dgvCol != null) dgvCol.HeaderText = "输出符号";
            dgvCol = dgv.Columns[C_CHECKBOX];
            if (dgvCol != null) dgvCol.HeaderText = "复选框";
            dgvCol = dgv.Columns[C_JUST];
            if (dgvCol != null) dgvCol.HeaderText = "对齐";
            dgvCol = dgv.Columns[C_LZERO];
            if (dgvCol != null) dgvCol.HeaderText = "输出前导零";
            dgvCol = dgv.Columns[C_NO_SIGN];
            if (dgvCol != null) dgvCol.HeaderText = "隐藏正负号";
            dgvCol = dgv.Columns[C_NO_ZERO];
            if (dgvCol != null) dgvCol.HeaderText = "隐藏零";
            dgvCol = dgv.Columns[C_NO_CONVEXT];
            if (dgvCol != null) dgvCol.HeaderText = "不考虑输出的转换退出";
            dgvCol = dgv.Columns[C_EDIT_MASK];
            if (dgvCol != null) dgvCol.HeaderText = "为输出编辑掩码";
            dgvCol = dgv.Columns[C_EMPHASIZE];
            if (dgvCol != null) dgvCol.HeaderText = "带有颜色的高亮列";
            dgvCol = dgv.Columns[C_FIX_COLUMN];
            if (dgvCol != null) dgvCol.HeaderText = "固定列";
            dgvCol = dgv.Columns[C_DO_SUM];
            if (dgvCol != null) dgvCol.HeaderText = "总计列值";
            dgvCol = dgv.Columns[C_NO_SUM];
            if (dgvCol != null) dgvCol.HeaderText = "没有总计列值";
            dgvCol = dgv.Columns[C_NO_OUT];
            if (dgvCol != null) dgvCol.HeaderText = "列没有输出";
            dgvCol = dgv.Columns[C_TECH];
            if (dgvCol != null) dgvCol.HeaderText = "技术字段";
            dgvCol = dgv.Columns[C_OUTPUTLEN];
            if (dgvCol != null) dgvCol.HeaderText = "列的字符宽度";
            dgvCol = dgv.Columns[C_CONVEXIT];
            if (dgvCol != null) dgvCol.HeaderText = "转换例程";
            dgvCol = dgv.Columns[C_SELTEXT];
            if (dgvCol != null) dgvCol.HeaderText = "对话功能的列标识符";
            dgvCol = dgv.Columns[C_TOOLTIP];
            if (dgvCol != null) dgvCol.HeaderText = "列抬头的工具提示";
            dgvCol = dgv.Columns[C_ROLLNAME];
            if (dgvCol != null) dgvCol.HeaderText = "F1 帮助的数据元素";
            dgvCol = dgv.Columns[C_DATATYPE];
            if (dgvCol != null) dgvCol.HeaderText = "ABAP 字典中的数据类型";
            dgvCol = dgv.Columns[C_INTTYPE];
            if (dgvCol != null) dgvCol.HeaderText = "ABAP 数据类型 (C,D,N,...)";
            dgvCol = dgv.Columns[C_INTLEN];
            if (dgvCol != null) dgvCol.HeaderText = "内部长度（字节）";
            dgvCol = dgv.Columns[C_LOWERCASE];
            if (dgvCol != null) dgvCol.HeaderText = "允许/不允许小写字母";
            dgvCol = dgv.Columns[C_REPTEXT];
            if (dgvCol != null) dgvCol.HeaderText = "标题";
            dgvCol = dgv.Columns[C_HIER_LEVEL];
            if (dgvCol != null) dgvCol.HeaderText = "内部使用";
            dgvCol = dgv.Columns[C_REPREP];
            if (dgvCol != null) dgvCol.HeaderText = "价值是补充/补充接口的选择标准";
            dgvCol = dgv.Columns[C_DOMNAME];
            if (dgvCol != null) dgvCol.HeaderText = "定义域名";
            dgvCol = dgv.Columns[C_SP_GROUP];
            if (dgvCol != null) dgvCol.HeaderText = "组代码";
            dgvCol = dgv.Columns[C_HOTSPOT];
            if (dgvCol != null) dgvCol.HeaderText = "单击敏感";
            dgvCol = dgv.Columns[C_DFIELDNAME];
            if (dgvCol != null) dgvCol.HeaderText = "数据库中列组的字段名称";
            dgvCol = dgv.Columns[C_COL_ID];
            if (dgvCol != null) dgvCol.HeaderText = "列 ID";
            dgvCol = dgv.Columns[C_F4AVAILABL];
            if (dgvCol != null) dgvCol.HeaderText = "有输入帮助吗";
            dgvCol = dgv.Columns[C_AUTO_VALUE];
            if (dgvCol != null) dgvCol.HeaderText = "自动复制值";
            dgvCol = dgv.Columns[C_CHECKTABLE];
            if (dgvCol != null) dgvCol.HeaderText = "表名";
            dgvCol = dgv.Columns[C_VALEXI];
            if (dgvCol != null) dgvCol.HeaderText = "固定值存在";
            dgvCol = dgv.Columns[C_WEB_FIELD];
            if (dgvCol != null) dgvCol.HeaderText = "内部表字段的字段名称";
            dgvCol = dgv.Columns[C_HREF_HNDL];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_STYLE];
            if (dgvCol != null) dgvCol.HeaderText = "样式";
            dgvCol = dgv.Columns[C_STYLE2];
            if (dgvCol != null) dgvCol.HeaderText = "样式2";
            dgvCol = dgv.Columns[C_STYLE3];
            if (dgvCol != null) dgvCol.HeaderText = "样式3";
            dgvCol = dgv.Columns[C_STYLE4];
            if (dgvCol != null) dgvCol.HeaderText = "样式4";
            dgvCol = dgv.Columns[C_DRDN_HNDL];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_DRDN_FIELD];
            if (dgvCol != null) dgvCol.HeaderText = "内部表字段的字段名称";
            dgvCol = dgv.Columns[C_NO_MERGING];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度 1";
            dgvCol = dgv.Columns[C_H_FTYPE];
            if (dgvCol != null) dgvCol.HeaderText = "(总计,平均,最大.最小, ...)";
            dgvCol = dgv.Columns[C_COL_OPT];
            if (dgvCol != null) dgvCol.HeaderText = "宽度优化";
            dgvCol = dgv.Columns[C_NO_INIT_CH];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度";
            dgvCol = dgv.Columns[C_DRDN_ALIAS];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度";
            dgvCol = dgv.Columns[C_DECFLOAT_STYLE];
            if (dgvCol != null) dgvCol.HeaderText = "DD: Output Style (Output Style) for Decfloat Types";
            dgvCol = dgv.Columns[C_PARAMETER0];
            if (dgvCol != null) dgvCol.HeaderText = "30 个字符";
            dgvCol = dgv.Columns[C_PARAMETER1];
            if (dgvCol != null) dgvCol.HeaderText = "30 个字符";
            dgvCol = dgv.Columns[C_PARAMETER2];
            if (dgvCol != null) dgvCol.HeaderText = "30 个字符";
            dgvCol = dgv.Columns[C_PARAMETER3];
            if (dgvCol != null) dgvCol.HeaderText = "30 个字符";
            dgvCol = dgv.Columns[C_PARAMETER4];
            if (dgvCol != null) dgvCol.HeaderText = "30 个字符";
            dgvCol = dgv.Columns[C_PARAMETER5];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_PARAMETER6];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_PARAMETER7];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_PARAMETER8];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_PARAMETER9];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_REF_FIELD];
            if (dgvCol != null) dgvCol.HeaderText = "表字段的参考字段";
            dgvCol = dgv.Columns[C_REF_TABLE];
            if (dgvCol != null) dgvCol.HeaderText = "表字段的参考表";
            dgvCol = dgv.Columns[C_TXT_FIELD];
            if (dgvCol != null) dgvCol.HeaderText = "表字段的字段名称";
            dgvCol = dgv.Columns[C_ROUNDFIELD];
            if (dgvCol != null) dgvCol.HeaderText = "带有ROUND说明的字段";
            dgvCol = dgv.Columns[C_intS_O];
            if (dgvCol != null) dgvCol.HeaderText = "输出小数位的编号";
            dgvCol = dgv.Columns[C_DECMLFIELD];
            if (dgvCol != null) dgvCol.HeaderText = "带有intS说明的字段";
            dgvCol = dgv.Columns[C_DD_OUTLEN];
            if (dgvCol != null) dgvCol.HeaderText = "输出字符长度";
            dgvCol = dgv.Columns[C_intS];
            if (dgvCol != null) dgvCol.HeaderText = "小数位数";
            dgvCol = dgv.Columns[C_COLTEXT];
            if (dgvCol != null) dgvCol.HeaderText = "列标题";
            dgvCol = dgv.Columns[C_SCRTEXT_L];
            if (dgvCol != null) dgvCol.HeaderText = "长字段标签";
            dgvCol = dgv.Columns[C_SCRTEXT_M];
            if (dgvCol != null) dgvCol.HeaderText = "中字段标签";
            dgvCol = dgv.Columns[C_SCRTEXT_S];
            if (dgvCol != null) dgvCol.HeaderText = "短字段标签";
            dgvCol = dgv.Columns[C_COLDDICTXT];
            if (dgvCol != null) dgvCol.HeaderText = "确定 DDIC 文本参考";
            dgvCol = dgv.Columns[C_SELDDICTXT];
            if (dgvCol != null) dgvCol.HeaderText = "确定 DDIC 文本参考";
            dgvCol = dgv.Columns[C_TIPDDICTXT];
            if (dgvCol != null) dgvCol.HeaderText = "确定 DDIC 文本参考";
            dgvCol = dgv.Columns[C_EDIT];
            if (dgvCol != null) dgvCol.HeaderText = "准备输入";
            dgvCol = dgv.Columns[C_TECH_COL];
            if (dgvCol != null) dgvCol.HeaderText = "内部使用";
            dgvCol = dgv.Columns[C_TECH_FORM];
            if (dgvCol != null) dgvCol.HeaderText = "内部使用";
            dgvCol = dgv.Columns[C_TECH_COMP];
            if (dgvCol != null) dgvCol.HeaderText = "内部使用";
            dgvCol = dgv.Columns[C_HIER_CPOS];
            if (dgvCol != null) dgvCol.HeaderText = "层次列位置";
            dgvCol = dgv.Columns[C_H_COL_KEY];
            if (dgvCol != null) dgvCol.HeaderText = "树控制: 列名称/项目名称";
            dgvCol = dgv.Columns[C_H_SELECT];
            if (dgvCol != null) dgvCol.HeaderText = "标识是否可以选择树控制中的列";
            dgvCol = dgv.Columns[C_DD_ROLL];
            if (dgvCol != null) dgvCol.HeaderText = "数据元素 (语义域)";
            dgvCol = dgv.Columns[C_DRAGDROPID];
            if (dgvCol != null) dgvCol.HeaderText = "拖&放处理拖放对象";
            dgvCol = dgv.Columns[C_MAC];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度";
            dgvCol = dgv.Columns[C_INDX_FIELD];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_INDX_CFIEL];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_INDX_QFIEL];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_INDX_IFIEL];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_INDX_ROUND];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_INDX_DECML];
            if (dgvCol != null) dgvCol.HeaderText = "自然数";
            dgvCol = dgv.Columns[C_GET_STYLE];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度 1";
            dgvCol = dgv.Columns[C_MARK];
            if (dgvCol != null) dgvCol.HeaderText = "字符字段长度 1";
        }

    }



}
