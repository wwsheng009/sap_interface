using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace SAPINTGUI.Http
{
    public partial class FormRestClient : DockWindow
    {
        private String m_Uri;
        private String m_BodyReq;
        private String m_bodyRes;
        private DataTable m_FormFieldsReq = null;
        private DataTable m_FormFieldsRes = null;
        private DataTable m_HeaderReq = null;
        private DataTable m_HeaderRes = null;

        private string m_HeaderType = null;
        private string m_Charset = null;

        public FormRestClient()
        {
            InitializeComponent();
            m_FormFieldsReq = new DataTable();
            m_FormFieldsReq.Columns.Add("Name", typeof(string));
            m_FormFieldsReq.Columns.Add("Value", typeof(string));

            this.dgvFormFieldsReq.DataSource = m_FormFieldsReq;

            m_FormFieldsRes = new DataTable();
            m_FormFieldsRes.Columns.Add("Name", typeof(string));
            m_FormFieldsRes.Columns.Add("Value", typeof(string));

            m_HeaderReq = new DataTable();
            m_HeaderReq.Columns.Add("Name", typeof(string));
            m_HeaderReq.Columns.Add("Value", typeof(string));

            m_HeaderRes = new DataTable();
            m_HeaderRes.Columns.Add("Name", typeof(string));
            m_HeaderRes.Columns.Add("Value", typeof(string));

            this.dgvHeadersRes.DataSource = m_HeaderReq;
            this.dgvHeadersReq.DataSource = m_HeaderReq;
            this.dgvFormFieldsReq.DataSource = m_FormFieldsReq;

            this.cbxAcceptType.Items.Add("application/x-www-form-urlencoded");
            this.cbxAcceptType.Items.Add("multipart/form-data request");
            this.cbxAcceptType.Items.Add("application/json");
            this.cbxAcceptType.Items.Add("application/javascript");
            this.cbxAcceptType.Items.Add("application/xml");
            this.cbxAcceptType.Items.Add("text/html");
            this.cbxAcceptType.Items.Add("text/plain");
            this.cbxAcceptType.Items.Add("text/xml");
            this.cbxAcceptType.Text = "text/xml";

            this.cbxCharSet.Items.Add("UTF-8");
            this.cbxCharSet.Text = "UTF-8";

            this.radioBtnGET.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Run();
            }

        }
        private bool Check()
        {
            if (string.IsNullOrEmpty(this.cbxUrl.Text))
            {
                MessageBox.Show("链接不可为空！");
                return false;
            }
            return true;
        }
        private void Run2()
        {

            
        }
        private void Run()
        {
            m_Uri = this.cbxUrl.Text;
            m_BodyReq = this.txtBodyReq.Text;
            m_HeaderType = this.cbxAcceptType.Text;
            m_Charset = this.cbxCharSet.Text;


            RestRequest request = new RestRequest();
            if (radioBtnDELETE.Checked)
            {
                request.Method = Method.DELETE;
            }
            if (radioBtnGET.Checked)
            {
                request.Method = Method.GET;
            }
            if (this.radioBtnHEAD.Checked)
            {
                request.Method = Method.HEAD;
            }
            if (this.radioBtnOPTIONS.Checked)
            {
                request.Method = Method.OPTIONS;
            }
            if (this.radioBtnPOST.Checked)
            {
                request.Method = Method.POST;
            }
            if (this.radioBtnPUT.Checked)
            {
                request.Method = Method.PUT;
            }
            if (this.radioBtnPATCH.Checked)
            {
                request.Method = Method.PATCH;
            }

            foreach (DataRow item in m_FormFieldsReq.Rows)
            {
                request.AddParameter(item["Name"].ToString(), item["Value"]);
            }
            foreach (DataRow item in m_HeaderReq.Rows)
            {
                request.AddHeader(item["Name"].ToString(), item["Value"].ToString());
            }

            if (!string.IsNullOrEmpty(m_BodyReq))
            {
                var value = m_BodyReq;
                request.AddParameter(m_HeaderType, value, ParameterType.RequestBody);
            }


            if (!string.IsNullOrEmpty(m_HeaderType))
            {
                request.AddParameter("Accept", m_HeaderType + ";charset=" + m_Charset, ParameterType.HttpHeader);
                //request.AddHeader("Content-Type", m_HeaderType + ";charset=" + m_Charset);
                
            }

            var client = new RestClient(m_Uri);
            
            var response = client.Execute(request);
            var content = response.Content; // raw content as string
            m_bodyRes = response.Content;

            txtStatus.Text = response.StatusDescription;
            this.txtStatusCode.Text = response.StatusCode.ToString();
            this.m_HeaderRes.Rows.Clear();
            foreach (var item in response.Headers)
            {
                var row = m_HeaderRes.NewRow();
                row["Name"] = item.Name;
                row["Value"] = item.Value;
                this.m_HeaderRes.Rows.Add(row);
            }
            this.dgvHeadersRes.DataSource = m_HeaderRes;
            this.dgvHeadersRes.AutoResizeColumns();
            this.txtBodyRes.Text = m_bodyRes;

            if (!this.cbxUrl.Items.Contains(this.cbxUrl.Text))
            {
                this.cbxUrl.Items.Add(this.cbxUrl.Text);
            }

        }
        private void demo()
        {
            //request.AddHeader
            //var request = new RestRequest(Method.POST);
            //var bizdata = "<?xml version=\"1.0\" encoding=\"utf-18\"?><SyncProductInfo><customerCode>85000241</customerCode><products/></SyncProductInfo>";

            //var data = "partnerId=BREO&bizData=" + bizdata + "&partnerKey=123456&msgId=&msgType=sync&serviceType=SyncProductInfo&serviceVersion=1.0&notifyUrl=";
            //var md5str = CalculateMD5Hash(data);
            //request.AddParameter("bizData", bizdata);
            //request.AddParameter("msgType", "sync");
            //request.AddParameter("serviceType", "SyncProductInfo");
            //request.AddParameter("msgId", "");
            //request.AddParameter("notifyUrl", "");
            //request.AddParameter("serviceVersion", "1.0");
            //request.AddParameter("partnerId", "BREO");

            //request.AddParameter("sign", md5str);
            //request.AddParameter("partnerKey", "123456");

        }

    }
}
