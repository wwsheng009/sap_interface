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
            DataSource = ConfigFileTool.SAPGlobalSettings.SapClientList;
            //var list = ConfigFileTool.SAPGlobalSettings.SapClientList;
            //list.ForEach(x => Items.Add(x));
            Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

        }


    }
}
