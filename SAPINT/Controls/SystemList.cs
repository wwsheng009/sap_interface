using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SAPINT.Controls
{
    //专门用于SAP系统连接的列表。

    public partial class CboxSystemList : ComboBox
    {
        public CboxSystemList()
        {
            InitializeComponent();

        }
        protected override void InitLayout()
        {
            base.InitLayout();
            DataSource = null;
           // base.DataSource = SAPINT.SAPLogonConfigList.SystemNameList;
            List<String> clients = new ConfigFileTool.SAPGlobalSettings().getSAPClientList();
            DataSource = clients;
            Text = new ConfigFileTool.SAPGlobalSettings().GetDefaultSapCient();
            
           // this.Parent.Enter += new EventHandler(Parent_Enter);
        }

     
    }
}
