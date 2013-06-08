using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SAPINTGUI
{
    public partial class DockWindow : DockContent
    {
        public DockWindow()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        private void CloseAllDocuments()
        {
            var dockPanel = this.DockPanel;
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        if (content.DockHandler.DockState == DockState.Document)
                        {
                            content.DockHandler.Close();

                        }

                    }
                }
            }
        }

        private void CloseOtherDocuments()
        {
            var dockPanel = this.DockPanel;
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (form != this)
                    {
                        form.Close();
                    }

                }

            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {

                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        if (content != this as IDockContent)
                        {
                            if (content.DockHandler.DockState == DockState.Document)
                            {
                                content.DockHandler.Close();
                            }
                        }

                    }
                }
            }
        }

        private void closeOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOtherDocuments();
        }

    }
}
