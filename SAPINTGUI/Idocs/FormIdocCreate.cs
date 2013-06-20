using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAPINT;
using SAPINT.Idocs;
using SAPINT.Idocs.Meta;

namespace SAPINT.Gui.Idocs
{
    public partial class FormIdocCreate : DockWindow
    {
        private SAPINT.Idocs.Idoc m_Idoc = new SAPINT.Idocs.Idoc();
        private SAPINT.Idocs.Idoc m_IdocNew = null;
        private String m_SapSystemName = null;
        private string m_IdocType = null;
        private string m_IdocEnhanceMent = null;

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

        public FormIdocCreate()
        {
            InitializeComponent();
            btnDecompile.Enabled = false;
            this.cboxSystemList1.DataSource = ConfigFileTool.SAPGlobalSettings.GetSAPClientList();
            this.cboxSystemList1.Text = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();

        }
        public SAPINT.Idocs.Idoc Idoc
        {
            get { return m_Idoc; }
            set
            {
                try
                {
                    m_Idoc = value;
                    if (m_Idoc != null)
                    {

                        this.txtIdocNumber.Text = m_Idoc.DOCNUM;

                        //IdocStatus status = m_Idoc.GetCurrentStatus(m_SapSystemName);
                        //txtDescription.Text = status.Description;
                        //txtUserName.Text = status.UserName;
                        //txtCreationDate.Text = status.CreationDate;
                        //txtCreateTime.Text = status.CreationTime;

                        //txtStatusVar1.Text = status.StatusVar1;
                        //txtStatusVar2.Text = status.StatusVar2;
                        //txtStatusVar3.Text = status.StatusVar3;
                        //txtStatusVar4.Text = status.StatusVar4;


                        this.txtARCKEY.Text = m_Idoc.ARCKEY;
                        this.txtCIMTYP.Text = m_Idoc.CIMTYP;
                        this.txtCREDAT.Text = m_Idoc.CREDAT;
                        this.txtCRETIM.Text = m_Idoc.CRETIM;
                        this.txtDIRECT.Text = m_Idoc.DIRECT;
                        this.txtDOCNUM.Text = m_Idoc.DOCNUM;
                        this.txtDOCREL.Text = m_Idoc.DOCREL;
                        this.txtEXPRSS.Text = m_Idoc.EXPRSS;
                        this.txtIDOCTYP.Text = m_Idoc.IDOCTYP;
                        this.txtLastTID.Text = m_Idoc.LastTID;
                        this.txtMANDT.Text = m_Idoc.MANDT;
                        this.txtMESCOD.Text = m_Idoc.MESCOD;
                        this.txtMESFCT.Text = m_Idoc.MESFCT;
                        this.txtMESTYP.Text = m_Idoc.MESTYP;
                        this.txtOUTMOD.Text = m_Idoc.OUTMOD;
                        this.txtRCVLAD.Text = m_Idoc.RCVLAD;
                        this.txtRCVPFC.Text = m_Idoc.RCVPFC;
                        this.txtRCVPOR.Text = m_Idoc.RCVPOR;
                        this.txtRCVPRN.Text = m_Idoc.RCVPRN;
                        this.txtRCVPRT.Text = m_Idoc.RCVPRT;
                        this.txtRCVSAD.Text = m_Idoc.RCVSAD;
                        this.txtREFGRP.Text = m_Idoc.REFGRP;
                        this.txtREFINT.Text = m_Idoc.REFINT;
                        this.txtREFMES.Text = m_Idoc.REFMES;
                        this.txtSERIAL.Text = m_Idoc.SERIAL;
                        this.txtSNDLAD.Text = m_Idoc.SNDLAD;
                        this.txtSNDPFC.Text = m_Idoc.SNDPFC;
                        this.txtSNDPOR.Text = m_Idoc.SNDPOR;
                        this.txtSNDPRN.Text = m_Idoc.SNDPRN;
                        this.txtSNDPRT.Text = m_Idoc.SNDPRT;
                        this.txtSNDSAD.Text = m_Idoc.SNDSAD;
                        this.txtSTATUS.Text = m_Idoc.STATUS;
                        this.txtSTD.Text = m_Idoc.STD;
                        this.txtSTDMES.Text = m_Idoc.STDMES;
                        this.txtSTDVRS.Text = m_Idoc.STDVRS;
                        this.txtTABNAM.Text = m_Idoc.TABNAM;
                        this.txtTEST.Text = m_Idoc.TEST;

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
            get { return m_SapSystemName; }
            set
            {
                m_SapSystemName = value;

                this.cboxSystemList1.Text = m_SapSystemName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_SapSystemName = this.cboxSystemList1.Text.Trim();
                SAPINT.Idocs.Meta.IdocUtil idocUtil = new IdocUtil(m_SapSystemName);
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
                if (m_SapSystemName != null && m_Idoc != null)
                {
                    if (idocmeta == null)
                    {
                        idocmeta = new IdocMeta(m_SapSystemName);
                    }
                    if (idocmeta.SystemName != m_SapSystemName)
                    {
                        idocmeta = new IdocMeta(m_SapSystemName);
                    }

                    m_IdocNew = idocmeta.DecompileIdoc(m_Idoc);

                    this.treeViewForIdoc.Nodes.Clear();

                    idocSegmentList = new Dictionary<string, IdocSegment>();
                    TreeNode node = new TreeNode(m_IdocNew.DOCNUM.PadLeft(16, '0'));
                    foreach (SAPINT.Idocs.IdocSegment item in m_Idoc.Segments)
                    {
                        BuildTreeNode(item, node);
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
        private void BuildTreeNode(SAPINT.Idocs.IdocSegment idocSegment, TreeNode node2)
        {
            var segmentName = string.Empty;
            if (idocSegment.SegmentNumber==null)
            {
                segmentName = idocSegment.SegmentName;
            }
            else
            {
                segmentName = idocSegment.SegmentName + " " + idocSegment.SegmentNumber.PadLeft(3, '0');
            }

            TreeNode node3 = node2.Nodes.Add(segmentName);
            idocSegmentList.Add(segmentName, idocSegment);
            if (idocSegment.HasChildren)
            {
                foreach (SAPINT.Idocs.IdocSegment item in idocSegment.ChildSegments)
                {
                    BuildTreeNode(item, node3);
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

        private void btnCreateIdoc_Click(object sender, EventArgs e)
        {
            m_SapSystemName = this.cboxSystemList1.Text.Trim();
            m_IdocType = this.txtIdocType.Text;
            m_IdocEnhanceMent = this.txtEnhancement.Text;


            if (string.IsNullOrEmpty(m_SapSystemName))
            {
                MessageBox.Show("请选择SAP系统");
                return;
            }
            if (string.IsNullOrEmpty(m_IdocType))
            {
                MessageBox.Show("请选择Idoc类型");
                return;
            }

            SAPConnection connection = new SAPConnection(m_SapSystemName);
            Idoc = connection.CreateIdoc(m_IdocType, m_IdocEnhanceMent);
            IdocToTreeControl();

        }




    }
}
