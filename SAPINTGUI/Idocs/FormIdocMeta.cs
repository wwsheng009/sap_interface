using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT.Idocs;
using SAPINT.Idocs.Meta;

namespace SAPINT.Gui.Idocs
{
    public partial class FormIdocMeta : DockWindow
    {
        private SAPINT.Idocs.Idoc idoc = new SAPINT.Idocs.Idoc();
        private SAPINT.Idocs.Idoc idocNew = null;
        private String sapSystemName = null;

        private DataTable dtStatus = null;
        private IdocMeta idocmeta = null;

        public DataTable DtStatus
        {
            get { return dtStatus; }
            set
            {
                dtStatus = value;
                dgvStatusTable.DataSource = dtStatus;
                dgvStatusTable.AutoResizeColumns();
            }
        }


        private Dictionary<String, IdocSegment> idocSegmentList = null;

        public FormIdocMeta()
        {
            InitializeComponent();
            btnDecompile.Enabled = false;
            this.cboxSystemList1.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cboxSystemList1.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

        }
        public SAPINT.Idocs.Idoc Idoc
        {
            get { return idoc; }
            set
            {
                try
                {
                    idoc = value;
                    if (idoc != null)
                    {

                        this.txtIdocNumber.Text = idoc.DOCNUM;

                        IdocStatus status = idoc.GetCurrentStatus(sapSystemName);
                        txtDescription.Text = status.Description;
                        txtUserName.Text = status.UserName;
                        txtCreationDate.Text = status.CreationDate;
                        txtCreateTime.Text = status.CreationTime;

                        txtStatusVar1.Text = status.StatusVar1;
                        txtStatusVar2.Text = status.StatusVar2;
                        txtStatusVar3.Text = status.StatusVar3;
                        txtStatusVar4.Text = status.StatusVar4;


                        this.txtARCKEY.Text = idoc.ARCKEY;
                        this.txtCIMTYP.Text = idoc.CIMTYP;
                        this.txtCREDAT.Text = idoc.CREDAT;
                        this.txtCRETIM.Text = idoc.CRETIM;
                        this.txtDIRECT.Text = idoc.DIRECT;
                        this.txtDOCNUM.Text = idoc.DOCNUM;
                        this.txtDOCREL.Text = idoc.DOCREL;
                        this.txtEXPRSS.Text = idoc.EXPRSS;
                        this.txtIDOCTYP.Text = idoc.IDOCTYP;
                        this.txtLastTID.Text = idoc.LastTID;
                        this.txtMANDT.Text = idoc.MANDT;
                        this.txtMESCOD.Text = idoc.MESCOD;
                        this.txtMESFCT.Text = idoc.MESFCT;
                        this.txtMESTYP.Text = idoc.MESTYP;
                        this.txtOUTMOD.Text = idoc.OUTMOD;
                        this.txtRCVLAD.Text = idoc.RCVLAD;
                        this.txtRCVPFC.Text = idoc.RCVPFC;
                        this.txtRCVPOR.Text = idoc.RCVPOR;
                        this.txtRCVPRN.Text = idoc.RCVPRN;
                        this.txtRCVPRT.Text = idoc.RCVPRT;
                        this.txtRCVSAD.Text = idoc.RCVSAD;
                        this.txtREFGRP.Text = idoc.REFGRP;
                        this.txtREFINT.Text = idoc.REFINT;
                        this.txtREFMES.Text = idoc.REFMES;
                        this.txtSERIAL.Text = idoc.SERIAL;
                        this.txtSNDLAD.Text = idoc.SNDLAD;
                        this.txtSNDPFC.Text = idoc.SNDPFC;
                        this.txtSNDPOR.Text = idoc.SNDPOR;
                        this.txtSNDPRN.Text = idoc.SNDPRN;
                        this.txtSNDPRT.Text = idoc.SNDPRT;
                        this.txtSNDSAD.Text = idoc.SNDSAD;
                        this.txtSTATUS.Text = idoc.STATUS;
                        this.txtSTD.Text = idoc.STD;
                        this.txtSTDMES.Text = idoc.STDMES;
                        this.txtSTDVRS.Text = idoc.STDVRS;
                        this.txtTABNAM.Text = idoc.TABNAM;
                        this.txtTEST.Text = idoc.TEST;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        public String SapSystemName
        {
            get { return sapSystemName; }
            set
            {
                sapSystemName = value;

                this.cboxSystemList1.Text = sapSystemName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sapSystemName = this.cboxSystemList1.Text.Trim();
                SAPINT.Idocs.Meta.IdocUtil idocUtil = new IdocUtil(sapSystemName);
                Idoc = idocUtil.GetIodcFromSapDataBase(txtIdocNumber.Text);
                IdocToTreeControl();
                MessageBox.Show("读取完成！");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        /// <summary>
        /// 把IDOC解析成TREE CONTROL的形式。
        /// </summary>
        public void IdocToTreeControl()
        {
            try
            {
                if (sapSystemName != null && idoc != null)
                {
                    if (idocmeta==null)
                    {
                        idocmeta = new IdocMeta(sapSystemName);
                    }
                    if (idocmeta.SystemName != sapSystemName)
                    {
                        idocmeta = new IdocMeta(sapSystemName);
                    }

                    idocNew = idocmeta.DecompileIdoc(idoc);

                    this.treeViewForIdoc.Nodes.Clear();

                    idocSegmentList = new Dictionary<string, IdocSegment>();
                    TreeNode node = new TreeNode(idocNew.DOCNUM.PadLeft(16, '0'));
                    foreach (SAPINT.Idocs.IdocSegment item in idoc.Segments)
                    {
                        buildTreeNode(item, node);
                    }
                    this.treeViewForIdoc.Nodes.Add(node);
                    this.treeViewForIdoc.ExpandAll();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
        private void btnDecompile_Click(object sender, EventArgs e)
        {
            IdocToTreeControl();
            MessageBox.Show("解析完成！");
        }


        /// <summary>
        /// 根据IDOC内容，递归创建一个IDOC树。
        /// </summary>
        /// <param name="idocSegment">IDOC 段节点</param>
        /// <param name="node2"></param>
        private void buildTreeNode(SAPINT.Idocs.IdocSegment idocSegment, TreeNode node2)
        {
            var segmentName = idocSegment.SegmentName + " " + idocSegment.SegmentNumber.PadLeft(3, '0');
            TreeNode node3 = node2.Nodes.Add(segmentName);
            idocSegmentList.Add(segmentName, idocSegment);
            if (idocSegment.HasChildren)
            {
                foreach (SAPINT.Idocs.IdocSegment item in idocSegment.ChildSegments)
                {
                    buildTreeNode(item, node3);
                }
            }

        }
        /// <summary>
        /// 选择IDOC节点后,在缓存中读取IDOC节点的值。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewForIdoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (idocSegmentList != null)
            {

                IdocSegment idocSegment = null;
                idocSegmentList.TryGetValue(e.Node.Text, out idocSegment);
                if (idocSegment != null)
                {
                    this.dataGridView1.DataSource = idocSegment.Fields;
                    this.dataGridView1.AutoResizeColumns();
                }
            }
        }




    }
}
