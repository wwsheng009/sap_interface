using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
//using System.Net.Configuration;
using System.IO;
using System.Net.Configuration;


namespace ConfigFileTool
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void txtRead_Click(object sender, EventArgs e)
		{
           // System.Configuration
            MySection1 mySectioin1 = (MySection1)SAPGlobalSettings.config.GetSection("MySection111");
            //MySection1 mySectioin1 = (MySection1)System.Configuration.ConfigurationManager.GetSection("MySection111");
			txtUsername1.Text = mySectioin1.UserName;
			txtUrl1.Text = mySectioin1.Url;


           // MySection2 mySectioin2 = (MySection2)System.Configuration.ConfigurationManager.GetSection("MySection222");
            MySection2 mySectioin2 = (MySection2)SAPGlobalSettings.config.GetSection("MySection222");
			txtUsername2.Text = mySectioin2.Users.UserName;
			txtUrl2.Text = mySectioin2.Users.Password;


           // MySection3 mySection3 = (MySection3)System.Configuration.ConfigurationManager.GetSection("MySection333");
            MySection3 mySection3 = (MySection3)SAPGlobalSettings.config.GetSection("MySection333");
			txtCommand1.Text = mySection3.Command1.CommandText.Trim();
			txtCommand2.Text = mySection3.Command2.CommandText.Trim();


            XmlKeyValueSection mySection4 = (XmlKeyValueSection)System.Configuration.ConfigurationManager.GetSection("MySection444");
			txtKeyValues.Text = string.Join("\r\n",
									(from kv in mySection4.KeyValues.Cast<XmlKeyValueSetting>()
									 let s = string.Format("{0}={1}", kv.Key, kv.Value)
									 select s).ToArray());

            SmtpSection section = System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
			labMailFrom.Text = "Mail From: " + section.From;
		}

		private void txtSave_Click(object sender, EventArgs e)
		{
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			SmtpSection section = config.GetSection("system.net/mailSettings/smtp") as SmtpSection;
			section.From = "Fish.Q.Li@newegg.com2";

            MySection1 mySectioin1 = config.GetSection("MySection111") as MySection1;
			mySectioin1.UserName = txtUsername1.Text.Trim();
			mySectioin1.Url = txtUrl1.Text.Trim();

            MySection2 mySection2 = config.GetSection("MySection222") as MySection2;
			mySection2.Users.UserName = txtUsername2.Text.Trim();
			mySection2.Users.Password = txtUrl2.Text.Trim();

			MySection3 mySection3 = config.GetSection("MySection333") as MySection3;
			mySection3.Command1.CommandText = txtCommand1.Text.Trim();
			mySection3.Command2.CommandText = txtCommand2.Text.Trim();

			XmlKeyValueSection mySection4 = config.GetSection("MySection444") as XmlKeyValueSection;
			mySection4.KeyValues.Clear();

			(from s in txtKeyValues.Lines
				 let p = s.IndexOf('=')
				 where p > 0
				 select new XmlKeyValueSetting { Key = s.Substring(0, p), Value = s.Substring(p + 1) }
			).ToList()
			.ForEach(kv => mySection4.KeyValues.Add(kv));

			config.Save();

			MessageBox.Show("OK", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static readonly string XmlFileName = Application.ExecutablePath + ".xml";

		private void btnReadXml_Click(object sender, EventArgs e)
		{
			btnWriteXml_Click(null, null);

			List<MyCommand> list = XmlHelper.XmlDeserializeFromFile<List<MyCommand>>(XmlFileName, Encoding.UTF8);

			if( list.Count > 0 )
				MessageBox.Show(list[0].CommandName + ": " + list[0].CommandText,
					this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void btnWriteXml_Click(object sender, EventArgs e)
		{
			MyCommand command = new MyCommand();
			command.CommandName = "InsretCustomer";
			command.Database = "MyTestDb";
			command.CommandText = "insret into .....";
			command.Parameters.Add(new MyCommandParameter { ParamName = "Name", ParamType = "DbType.String" });
			command.Parameters.Add(new MyCommandParameter { ParamName = "Address", ParamType = "DbType.String" });

			List<MyCommand> list = new List<MyCommand>(1);
			list.Add(command);

			XmlHelper.XmlSerializeToFile(list, XmlFileName, Encoding.UTF8);
		}
	}
}
