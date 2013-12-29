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
using NVelocity;
using NVelocity.App;
using SAPINTDB.CodeManager;
using SAPINT.Screen;

namespace SAPINT.Gui.CodeManager
{
    public partial class FormScreenGernerator : Form
    {
        DataTable dt = null;

        private FormCodeManager m_FormCodeManager = null;
        List<SAPINT.Screen.CScreenField> fields = null;

        Form form = null;

        public FormScreenGernerator()
        {
            InitializeComponent();
            this.cbxSystem.DataSource = null;
            this.cbxSystem.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cbxSystem.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

            this.cbxDynnr.Enter += cbxDynnr_Enter;

            this.txtProg.Text = "SAPLSZA1";
            this.cbxDynnr.Text = "0213";

        }

        void cbxDynnr_Enter(object sender, EventArgs e)
        {

            try
            {
                var ds = SAPINT.Screen.CSapScreen.getScreenList(this.cbxSystem.Text, this.txtProg.Text);
                cbxDynnr.DataSource = null;
                cbxDynnr.DataSource = ds;
                cbxDynnr.DisplayMember = "DNUM";
                //throw new NotImplementedException();
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);
            }

        }

        private void btnGetScreenFields_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = null;
                this.dt = null;
                CSapScreen.GetFieldList(this.cbxSystem.Text, this.txtProg.Text, this.cbxDynnr.Text);

                this.dt = CSapScreen.Fields;
                this.TotalLine = CSapScreen.TotalLine;
                this.UsedLine = CSapScreen.UsedLine;
                this.TotalCol = CSapScreen.TotalCol;
                this.UsedCol = CSapScreen.UsedCol;

                this.txtTotalCol.Text = CSapScreen.TotalCol.ToString();
                this.txtUsdLine.Text = CSapScreen.UsedLine.ToString();
                this.txtTotalLine.Text = CSapScreen.TotalLine.ToString();
                this.txtUsedCol.Text = CSapScreen.UsedCol.ToString();
                this.txtTitle.Text = CSapScreen.Title;


                this.dataGridView1.DataSource = dt;
                SAPINT.Screen.CScreenField.ConfigDgv(this.dataGridView1);
                this.dataGridView1.AutoResizeColumns();
                MessageBox.Show("读取完毕");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGernerateCode_Click(object sender, EventArgs e)
        {
            this.fields = null;

            fields = dt.ToList<SAPINT.Screen.CScreenField>() as List<SAPINT.Screen.CScreenField>;
            Gernerate();


        }
        public void setFormCodeManager(FormCodeManager p_FormCodeManager)
        {
            m_FormCodeManager = p_FormCodeManager;
        }


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


                if (fields != null)
                {
                    ct.Put("fields", fields);
                }
                ct.Put("height", CSapScreen.TotalLine);
                ct.Put("width", CSapScreen.TotalCol);
                ct.Put("title", CSapScreen.Title);
                ct.Put("id", this.txtProg.Text + "-" + this.cbxDynnr.Text);
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

        private void btnGernerateScreen_Click(object sender, EventArgs e)
        {

            int lastline = 0;

            try
            {
                fields = dt.ToList<SAPINT.Screen.CScreenField>() as List<SAPINT.Screen.CScreenField>;
                if (this.fields == null)
                {
                    MessageBox.Show("字段列表为空");
                    return;
                }

                 form = new Form();
                //Panel p = new Panel();
                 Screen.CSapScreen.TotalLine++;

                form.Width = Screen.CSapScreen.TotalCol * 10;
                form.Height = Screen.CSapScreen.TotalLine * 25;
                form.AutoScroll = true;
                //p.VerticalScroll.Enabled = true;
                //p.HorizontalScroll.Enabled = true;
                //p.VerticalScroll.Visible = true;
                //p.HorizontalScroll.Visible = true;

                foreach (var item in fields)
                {
                    if (item.fill != "")
                    {

                    }
                    if (item.gtyp == "文本" || item.gtyp == "Text")
                    {
                        Label l = new Label();
                        l.Top = Convert.ToInt32(item.line) * 25;
                        l.Left = Convert.ToInt32(item.coln) * 10;
                        l.Width = Convert.ToInt32(item.vleng) * 10;
                        l.Text = item.stxt;
                        l.Name = item.name;
                        l.Click += item_Click;
                        l.MouseHover += item_GotFocus;
                        form.Controls.Add(l);
                        lastline = Convert.ToInt32(item.line);
                    }
                    else if (item.gtyp == "按" || item.gtyp == "Push")
                    {

                        Button b = new Button();
                        b.Top = Convert.ToInt32(item.line) * 25;
                        b.Left = Convert.ToInt32(item.coln) * 10;
                        b.Width = Convert.ToInt32(item.vleng) * 10;
                        b.Text = item.stxt;
                        b.Name = item.name;
                        b.Click += item_Click;
                        b.MouseHover += item_GotFocus;
                        form.Controls.Add(b);
                        lastline = Convert.ToInt32(item.line);
                    }
                    else if (item.gtyp == "输入/输出" || item.gtyp == "I/O")
                    {

                        if (item.fill != "")
                        {

                        }
                        TextBox box = new TextBox();
                        box.Top = Convert.ToInt32(item.line) * 25;
                        box.Left = Convert.ToInt32(item.coln) * 10;
                        box.Width = Convert.ToInt32(item.vleng) * 10;
                        if (item.fein == "")
                        {
                           // box.Enabled = false;
                            box.ReadOnly = true;
                            box.Text = item.name;
                        }
                        box.Name = item.name;
                        box.Click += item_Click;
                        box.MouseHover += item_GotFocus;
                        form.Controls.Add(box);
                        lastline = Convert.ToInt32(item.line);
                    }
                    else if (item.gtyp == "Check")
                    {

                        if (item.fill != "")
                        {

                        }
                        CheckBox chx = new CheckBox();

                        chx.Top = Convert.ToInt32(item.line) * 25;
                        chx.Left = Convert.ToInt32(item.coln) * 10;
                        chx.Width = Convert.ToInt32(item.vleng) * 10;
                        if (item.fein == "")
                        {
                            chx.Enabled = false;
                            
                            chx.Text = item.name;
                        }
                        chx.Name = item.name;
                        chx.Click += item_Click;
                        chx.MouseHover += item_GotFocus;
                        form.Controls.Add(chx);
                        lastline = Convert.ToInt32(item.line);
                    }
                    else if (item.gtyp == "框")
                    {
                        Label l = new Label();
                        l.Top = Convert.ToInt32(item.line) * 25;
                        l.Left = Convert.ToInt32(item.coln) * 10;
                        l.Width = Convert.ToInt32(item.vleng) * 10;
                        l.Text = item.stxt;
                        l.Name = item.name;

                        l.MouseHover += item_GotFocus;
                        form.Controls.Add(l);
                        lastline = Convert.ToInt32(item.line);
                        //GroupBox grpbox = new GroupBox();
                        //grpbox.Top = Convert.ToInt32(item.line) * 25;
                        //grpbox.Left = Convert.ToInt32(item.coln) * 10;
                        //grpbox.Width = Convert.ToInt32(item.vleng) * 10;
                        //grpbox.Text = item.stxt;
                        //grpbox.Name = item.name;

                        //form.Controls.Add(grpbox);
                        //grpbox.SendToBack();

                    }
                    
                    // form.Controls.Add(
                }

                lastline++;

                Label labelInfo = new Label();
                labelInfo.Text = "控件名称:";
                labelInfo.Top = lastline * 25;
                
                //labelInfo.Width = 200;
                labelInfo.Left = 10;
                form.Controls.Add(labelInfo);

                TextBox controlid = new TextBox();
                controlid.Top = lastline  * 25 ;
                controlid.Width = form.Width - 100 - labelInfo.Width;
                controlid.Left = labelInfo.Width + 100;
              //  controlid.Text = ".......................................................";
                controlid.Name = "CONTROL_NAME";
                form.Controls.Add(controlid);


                form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        void item_GotFocus(object sender, EventArgs e)
        {

            Control c = (Control)sender;
            if (String.IsNullOrEmpty(c.Name))
            {
                return;
            }

            TextBox t = (TextBox)form.Controls["CONTROL_NAME"];
            if (t != null)
            {
                t.Text = c.Name;
                form.Text = c.Name;
            }
            //t.Update();
            //form.Update();
        }

        void item_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;

            TextBox t = (TextBox)form.Controls["CONTROL_NAME"];
            if (t!=null)
            {
                t.Text = c.Name;
            }
            
           
        }


        public int TotalLine { get; set; }

        public int UsedLine { get; set; }

        public int TotalCol { get; set; }

        public int UsedCol { get; set; }
    }
}
