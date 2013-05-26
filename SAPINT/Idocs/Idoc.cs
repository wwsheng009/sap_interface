namespace SAPINT.Idocs
{
    using SAPINT;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Xml;
    using SAP.Middleware.Connector;
    public class Idoc
    {
        private string _ARCKEY;
        private IdocSegmentCollection _ChildSegments;
        private string _CIMTYP;
        private string _CREDAT;
        private string _CRETIM;
        private string _Description;
        private string _DIRECT;
        private string _DOCNUM;
        private string _DOCREL;
        private string _EXPRSS;
        private string _IDOCTYP;
        private string _LastTID;
        private string _MANDT;
        private string _MESCOD;
        private string _MESFCT;
        private string _MESTYP;
        private string _OUTMOD;
        private string _RCVLAD;
        private string _RCVPFC;
        private string _RCVPOR;
        private string _RCVPRN;
        private string _RCVPRT;
        private string _RCVSAD;
        private string _REFGRP;
        private string _REFINT;
        private string _REFMES;
        private string _SERIAL;
        private bool _SkipHLevel;
        private string _SNDLAD;
        private string _SNDPFC;
        private string _SNDPOR;
        private string _SNDPRN;
        private string _SNDPRT;
        private string _SNDSAD;
        private string _STATUS;
        private string _STD;
        private string _STDMES;
        private string _STDVRS;
        private string _TABNAM;
        private string _TEST;
        private RfcDestination des;
        private SAPConnection con;
        private Hashtable PlainLoadSegmentHash;
        private static readonly Dictionary<char, char> plainTextEscapes;
        private static readonly Dictionary<char, char> plainTextUnescapes;
        private int SegNumForPlainFile;
        private Hashtable StoredSegments;
        static Idoc()
        {
            Dictionary<char, char> dictionary = new Dictionary<char, char>();
            dictionary.Add('\r', 'r');
            dictionary.Add('\n', 'n');
            plainTextEscapes = dictionary;
            Dictionary<char, char> dictionary2 = new Dictionary<char, char>();
            dictionary2.Add('r', '\r');
            dictionary2.Add('n', '\n');
            plainTextUnescapes = dictionary2;
        }
        public Idoc()
        {
            this._ChildSegments = new IdocSegmentCollection();
            this._LastTID = "";
            this._TABNAM = "";
            this._MANDT = "";
            this._DOCNUM = "";
            this._DOCREL = "";
            this._STATUS = "";
            this._DIRECT = "";
            this._OUTMOD = "";
            this._EXPRSS = "";
            this._TEST = "";
            this._IDOCTYP = "";
            this._CIMTYP = "";
            this._MESTYP = "";
            this._MESCOD = "";
            this._MESFCT = "";
            this._STD = "";
            this._STDVRS = "";
            this._STDMES = "";
            this._SNDPOR = "";
            this._SNDPRT = "";
            this._SNDPFC = "";
            this._SNDPRN = "";
            this._SNDSAD = "";
            this._SNDLAD = "";
            this._RCVPOR = "";
            this._RCVPRT = "";
            this._RCVPFC = "";
            this._RCVPRN = "";
            this._RCVSAD = "";
            this._RCVLAD = "";
            this._CREDAT = "";
            this._CRETIM = "";
            this._REFINT = "";
            this._REFGRP = "";
            this._REFMES = "";
            this._ARCKEY = "";
            this._SERIAL = "";
            this._Description = "";
            this.StoredSegments = new Hashtable();
            this.TABNAM = "EDI_DC40";
        }
        public Idoc(string IdocType, string Extension)
        {
            this._ChildSegments = new IdocSegmentCollection();
            this._LastTID = "";
            this._TABNAM = "";
            this._MANDT = "";
            this._DOCNUM = "";
            this._DOCREL = "";
            this._STATUS = "";
            this._DIRECT = "";
            this._OUTMOD = "";
            this._EXPRSS = "";
            this._TEST = "";
            this._IDOCTYP = "";
            this._CIMTYP = "";
            this._MESTYP = "";
            this._MESCOD = "";
            this._MESFCT = "";
            this._STD = "";
            this._STDVRS = "";
            this._STDMES = "";
            this._SNDPOR = "";
            this._SNDPRT = "";
            this._SNDPFC = "";
            this._SNDPRN = "";
            this._SNDSAD = "";
            this._SNDLAD = "";
            this._RCVPOR = "";
            this._RCVPRT = "";
            this._RCVPFC = "";
            this._RCVPRN = "";
            this._RCVSAD = "";
            this._RCVLAD = "";
            this._CREDAT = "";
            this._CRETIM = "";
            this._REFINT = "";
            this._REFGRP = "";
            this._REFMES = "";
            this._ARCKEY = "";
            this._SERIAL = "";
            this._Description = "";
            this.StoredSegments = new Hashtable();
            this.IDOCTYP = IdocType.ToUpper();
            this.CIMTYP = Extension.ToUpper();
            this.TABNAM = "EDI_DC40";
        }
        private void AppendEDIDC40(ref StringBuilder st, String IdocType)
        {
            st.Append("<xsd:element name=\"EDI_DC40\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>IDoc Control Record for Interface to External System</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:complexType>");
            st.Append("<xsd:sequence>");
            st.Append("<xsd:element name=\"TABNAM\" type=\"xsd:string\" fixed=\"EDI_DC40\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Name of table structure</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"MANDT\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Client</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"3\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"DOCNUM\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>IDoc number</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"16\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"DOCREL\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>SAP Release for IDoc</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"4\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"STATUS\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Status of IDoc</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"2\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"DIRECT\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Direction</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:enumeration value=\"1\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Outbound</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("</xsd:enumeration>");
            st.Append("<xsd:enumeration value=\"2\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Inbound</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("</xsd:enumeration>");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"OUTMOD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Output mode</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"1\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"EXPRSS\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Overriding in inbound processing</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"1\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"TEST\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Test flag</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"1\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"IDOCTYP\" type=\"xsd:string\" fixed=\"" + IdocType + "\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Name of basic type</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"CIMTYP\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Extension (defined by customer)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"30\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"MESTYP\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Message type</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"30\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"MESCOD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Message code</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"3\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"MESFCT\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Message function</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"3\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"STD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>EDI standard, flag</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"1\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"STDVRS\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>EDI standard, version and release</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"6\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"STDMES\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>EDI message type</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"6\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDPOR\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Sender port (SAP System, external subsystem)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"10\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDPRT\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner type of sender</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"2\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDPFC\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner Function of Sender</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"2\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDPRN\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner Number of Sender</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"10\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDSAD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Sender address (SADR)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"21\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SNDLAD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Logical address of sender</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"70\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVPOR\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Receiver port</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"10\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVPRT\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner Type of receiver</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"2\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVPFC\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner function of recipient</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"2\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVPRN\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Partner number of recipient</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"10\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVSAD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Recipient address (SADR)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"21\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"RCVLAD\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Logical address of recipient</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"70\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"CREDAT\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Created on</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"8\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"CRETIM\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Time Created</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"6\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"REFINT\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Transmission file (EDI Interchange)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"14\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"REFGRP\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Message group (EDI Message Group)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"14\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"REFMES\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Message (EDI Message)</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"14\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"ARCKEY\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Key for external message archive</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"70\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("<xsd:element name=\"SERIAL\" minOccurs=\"0\">");
            st.Append("<xsd:annotation>");
            st.Append("<xsd:documentation>Serialization</xsd:documentation> ");
            st.Append("</xsd:annotation>");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:maxLength value=\"20\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:element>");
            st.Append("</xsd:sequence>");
            st.Append("<xsd:attribute name=\"SEGMENT\" use=\"required\">");
            st.Append("<xsd:simpleType>");
            st.Append("<xsd:restriction base=\"xsd:string\">");
            st.Append("<xsd:enumeration value=\"1\" /> ");
            st.Append("</xsd:restriction>");
            st.Append("</xsd:simpleType>");
            st.Append("</xsd:attribute>");
            st.Append("</xsd:complexType>");
            st.Append("</xsd:element>");
        }


        public IdocSegment CreateSegment(string SegmentName)
        {
            SegmentName = SegmentName.Trim();
            if (SegmentName.Length < 3)
            {
                //  throw new ERPException(string.Format(Messages.Segment_0_notvalidforthisIdoc, SegmentName));
                throw new Exception(string.Format("{0}not valid for this Idoc", SegmentName));
            }
            IdocSegment segment = null;
            segment = (IdocSegment)this.StoredSegments[SegmentName];
            if (segment == null)
            {
                string str = SegmentName.Substring(0, SegmentName.Length - 3);
                segment = (IdocSegment)this.StoredSegments[str];
                if (segment == null)
                {
                    if (SegmentName.Substring(1, 1) == "2")
                    {
                        str = SegmentName.Substring(0, 1) + "1" + SegmentName.Substring(2);
                    }
                    else
                    {
                        str = SegmentName.Substring(0, 1) + "2" + SegmentName.Substring(2);
                    }
                    segment = (IdocSegment)this.StoredSegments[str];
                    if (segment == null)
                    {
                        str = str.Substring(0, str.Length - 3);
                        segment = (IdocSegment)this.StoredSegments[str];
                        if (segment == null)
                        {
                            segment = new IdocSegment();
                        }
                    }
                }
            }
            segment.SegmentName = SegmentName;
            return segment.Clone();
        }
        public IdocStatus GetCurrentStatus(String system)
        {
            if (String.IsNullOrWhiteSpace(system))
            {
                throw new SAPException("请指定系统连接名！");
            }
            this.des = SAPDestination.GetDesByName(system);
            return GetCurrentStatus();
        }
        private IdocStatus GetCurrentStatus()
        {
            try
            {
                if (this.des == null)
                {
                    throw new SAPException(Messages.NoConnectionAssigned);
                    //throw new Exception("NoconnectionAssigned");
                }
                if (this._DOCNUM.Trim().Equals(""))
                {
                    throw new SAPException(Messages.NoIdocnumbergiven);
                    //throw new Exception("No Idoc number given");
                }
                RfcSessionManager.BeginContext(des);
                // RFCFunction function = RFCFunctionFactory.GenerateFunctionObjectForEDI_DOCUMENT_OPEN_FOR_READ(this.con.IsUnicode);
                IRfcFunction function = des.Repository.CreateFunction("EDI_DOCUMENT_OPEN_FOR_READ");
                // function.Connection = this.con;
                function["DOCUMENT_NUMBER"].SetValue(this._DOCNUM);
                function.Invoke(des);
                //RFCFunction function2 = RFCFunctionFactory.GenerateFunctionObjectForEDI_DOCUMENT_READ_LAST_STATUS(this.con.IsUnicode);
                IRfcFunction function2 = des.Repository.CreateFunction("EDI_DOCUMENT_READ_LAST_STATUS");
                //function2.Connection = this.con;
                function2["DOCUMENT_NUMBER"].SetValue(this._DOCNUM);
                function2.Invoke(des);
                IRfcStructure structure = function2.GetStructure("STATUS");
                IdocStatus status = new IdocStatus
                {
                    UserName = structure["UNAME"].GetValue().ToString(),
                    Status = structure["STATUS"].GetValue().ToString(),
                    Description = Converts.FormatMessage(
                        structure["STATXT"].GetValue().ToString(), 
                        structure["STAPA1"].GetValue().ToString(), 
                        structure["STAPA2"].GetValue().ToString(), 
                        structure["STAPA3"].GetValue().ToString(), 
                        structure["STAPA4"].GetValue().ToString()),
                    StatusVar1 = structure["STAPA1"].GetValue().ToString(),
                    StatusVar2 = structure["STAPA2"].GetValue().ToString(),
                    StatusVar3 = structure["STAPA3"].GetValue().ToString(),
                    StatusVar4 = structure["STAPA4"].GetValue().ToString()
                };

                //注意要用GetValue来获取原始值。

                //DateTime time = new DateTime(
                //    Convert.ToInt32(structure["CREDAT"].GetValue().ToString().Substring(0, 4)),
                //    Convert.ToInt32(structure["CREDAT"].GetValue().ToString().Substring(4, 2)),
                //    Convert.ToInt32(structure["CREDAT"].GetValue().ToString().Substring(6, 2)),
                //    Convert.ToInt32(structure["CRETIM"].GetValue().ToString().Substring(0, 2)),
                //    Convert.ToInt32(structure["CRETIM"].GetValue().ToString().Substring(2, 2)),
                //    Convert.ToInt32(structure["CRETIM"].GetValue().ToString().Substring(4, 2)));
                //status.CreationDateTime = time;
                status.CreationDate = structure["CREDAT"].GetValue().ToString();
                status.CreationTime = structure["CRETIM"].GetValue().ToString();
                //RFCFunction function3 = RFCFunctionFactory.GenerateFunctionObjectForEDI_DOCUMENT_CLOSE_READ(this.con.IsUnicode);
                IRfcFunction function3 = des.Repository.CreateFunction("EDI_DOCUMENT_CLOSE_READ");
                //function3.Connection = this.con;
                function3["DOCUMENT_NUMBER"].SetValue(this._DOCNUM);
                function3.Invoke(des);
                RfcSessionManager.EndContext(des);
                return status;
            }
            catch (RfcAbapException rfcException)
            {

                throw new SAPException(rfcException.Key + rfcException.Message);
            }

        }
        private string GetIdocSchema()
        {
            string str;
            try
            {
                Idoc idoc = this.con.CreateIdoc(this.IDOCTYP, this.CIMTYP);
                StringBuilder st = new StringBuilder("");
                st.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
                st.Append("<xsd:schema xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msprop=\"urn:schemas-microsoft-com:xml-msprop\" version=\"1.0\">\n");
                st.Append("<xsd:element name=\"" + Converts.OriginalNameToXmlName(this.IDOCTYP) + "\">\n");
                st.Append("<xsd:annotation>\n");
                st.Append("<xsd:documentation>" + idoc.Description.Replace("&", string.Empty) + "</xsd:documentation> \n");
                st.Append("</xsd:annotation>\n");
                st.Append("<xsd:complexType>\n");
                st.Append("<xsd:sequence>\n");
                st.Append("<xsd:element name=\"IDOC\">\n");
                st.Append("<xsd:complexType>\n");
                st.Append("<xsd:sequence>\n");
                this.AppendEDIDC40(ref st, this.IDOCTYP);
                foreach (IdocSegment segment in idoc.Segments)
                {
                    this.WriteSegment(ref st, segment);
                }
                st.Append("</xsd:sequence>\n");
                st.Append("<xsd:attribute name=\"BEGIN\" use=\"required\">\n");
                st.Append("<xsd:simpleType>\n");
                st.Append("<xsd:restriction base=\"xsd:string\">\n");
                st.Append("<xsd:enumeration value=\"1\" />\n ");
                st.Append("</xsd:restriction>\n");
                st.Append("</xsd:simpleType>\n");
                st.Append("</xsd:attribute>\n");
                st.Append("</xsd:complexType>\n");
                st.Append("</xsd:element>\n");
                st.Append("</xsd:sequence>\n");
                st.Append("</xsd:complexType>\n");
                st.Append("</xsd:element>\n");
                st.Append("</xsd:schema>\n");
                str = st.ToString();
            }
            catch (Exception exception)
            {
                throw new SAPException("Error during IDoc schema generation", exception);
            }
            return str;
        }
        private IdocSegment GetSegmentFromNode(XmlNode node)
        {
            IdocSegment segment;
            string segmentName = Converts.XmlNameToOriginalName(node.Name);
            try
            {
                segment = this.CreateSegment(segmentName);
            }
            catch
            {
                segment = new IdocSegment
                {
                    SegmentName = segmentName
                };
            }
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode node2 = node.ChildNodes[i];
                if (node2.Name.Equals("BUFFER"))
                {
                    segment.WriteDataBuffer(node2.InnerText, 0, 0x3e8);
                    segment.Fields.Clear();
                    this.RegenerateSegment(segment);
                }
                else if ((node2.ChildNodes.Count > 0) && node2.ChildNodes[0].Name.Equals("BUFFER"))
                {
                    segment.ChildSegments.Add(this.GetSegmentFromNode(node2));
                }
                else
                {
                    string str2 = Converts.XmlNameToOriginalName(node2.Name);
                    if (this.IsSegmentValid(str2))
                    {
                        segment.ChildSegments.Add(this.GetSegmentFromNode(node2));
                    }
                    else
                    {
                        try
                        {
                            segment.Fields[str2].FieldValue = node2.InnerText;
                        }
                        catch
                        {
                            segment.WriteDataBuffer(node2.InnerText.PadRight(0x3e8), 0, 0x3e8);
                        }
                    }
                }
            }
            return segment;
        }
        private XmlDocument GetXMLDocument(string StrEncoding)
        {
            string str = Converts.OriginalNameToXmlName(this.MESTYP);
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"" + StrEncoding + "\" ?>");
            if (!string.IsNullOrEmpty(str))
            {
                builder.Append("<" + str + ">");
            }
            builder.Append("<IDOC>");
            builder.Append("<EDI_DC40>");
            builder.Append("<TABNAM>" + this.TABNAM.TrimEnd(new char[0]) + "</TABNAM>");
            builder.Append("<MANDT>" + this.MANDT.TrimEnd(new char[0]) + "</MANDT>");
            builder.Append("<DOCNUM>" + this.DOCNUM.TrimEnd(new char[0]) + "</DOCNUM>");
            builder.Append("<DOCREL>" + this.DOCREL.TrimEnd(new char[0]) + "</DOCREL>");
            builder.Append("<STATUS>" + this.STATUS.TrimEnd(new char[0]) + "</STATUS>");
            builder.Append("<DIRECT>" + this.DIRECT.TrimEnd(new char[0]) + "</DIRECT>");
            builder.Append("<OUTMOD>" + this.OUTMOD.TrimEnd(new char[0]) + "</OUTMOD>");
            builder.Append("<EXPRSS>" + this.EXPRSS.TrimEnd(new char[0]) + "</EXPRSS>");
            builder.Append("<IDOCTYP>" + this.IDOCTYP.TrimEnd(new char[0]) + "</IDOCTYP>");
            builder.Append("<CIMTYP>" + this.CIMTYP.TrimEnd(new char[0]) + "</CIMTYP>");
            builder.Append("<MESTYP>" + this.MESTYP.TrimEnd(new char[0]) + "</MESTYP>");
            builder.Append("<MESCOD>" + this.MESCOD.TrimEnd(new char[0]) + "</MESCOD>");
            builder.Append("<MESFCT>" + this.MESFCT.TrimEnd(new char[0]) + "</MESFCT>");
            builder.Append("<STD>" + this.STD.TrimEnd(new char[0]) + "</STD>");
            builder.Append("<STDVRS>" + this.STDVRS.TrimEnd(new char[0]) + "</STDVRS>");
            builder.Append("<STDMES>" + this.STDMES.TrimEnd(new char[0]) + "</STDMES>");
            builder.Append("<SNDPOR>" + this.SNDPOR.TrimEnd(new char[0]) + "</SNDPOR>");
            builder.Append("<SNDPRT>" + this.SNDPRT.TrimEnd(new char[0]) + "</SNDPRT>");
            builder.Append("<SNDPFC>" + this.SNDPFC.TrimEnd(new char[0]) + "</SNDPFC>");
            builder.Append("<SNDPRN>" + this.SNDPRN.TrimEnd(new char[0]) + "</SNDPRN>");
            builder.Append("<SNDSAD>" + this.SNDSAD.TrimEnd(new char[0]) + "</SNDSAD>");
            builder.Append("<SNDLAD>" + this.SNDLAD.TrimEnd(new char[0]) + "</SNDLAD>");
            builder.Append("<RCVPOR>" + this.RCVPOR.TrimEnd(new char[0]) + "</RCVPOR>");
            builder.Append("<RCVPRT>" + this.RCVPRT.TrimEnd(new char[0]) + "</RCVPRT>");
            builder.Append("<RCVPFC>" + this.RCVPFC.TrimEnd(new char[0]) + "</RCVPFC>");
            builder.Append("<RCVPRN>" + this.RCVPRN.TrimEnd(new char[0]) + "</RCVPRN>");
            builder.Append("<RCVSAD>" + this.RCVSAD.TrimEnd(new char[0]) + "</RCVSAD>");
            builder.Append("<RCVLAD>" + this.RCVLAD.TrimEnd(new char[0]) + "</RCVLAD>");
            builder.Append("<CREDAT>" + this.CREDAT.TrimEnd(new char[0]) + "</CREDAT>");
            builder.Append("<CRETIM>" + this.CRETIM.TrimEnd(new char[0]) + "</CRETIM>");
            builder.Append("<REFINT>" + this.REFINT.TrimEnd(new char[0]) + "</REFINT>");
            builder.Append("<REFGRP>" + this.REFGRP.TrimEnd(new char[0]) + "</REFGRP>");
            builder.Append("<REFMES>" + this.REFMES.TrimEnd(new char[0]) + "</REFMES>");
            builder.Append("<ARCKEY>" + this.ARCKEY.TrimEnd(new char[0]) + "</ARCKEY>");
            builder.Append("<SERIAL>" + this.SERIAL.TrimEnd(new char[0]) + "</SERIAL>");
            builder.Append("</EDI_DC40>");
            builder.Append("</IDOC>");
            if (!string.IsNullOrEmpty(str))
            {
                builder.Append("</" + str + ">");
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(builder.ToString());
            XmlElement element = (XmlElement)doc.DocumentElement.ChildNodes[0];
            for (int i = 0; i < this.Segments.Count; i++)
            {
                element.AppendChild(this.GetXMLNodeFromSegment(this.Segments[i], doc));
            }
            return doc;
        }
        private XmlNode GetXMLNodeFromSegment(IdocSegment seg, XmlDocument doc)
        {
            XmlNode node = doc.CreateNode(XmlNodeType.Element, Converts.OriginalNameToXmlName(seg.SegmentName), "");
            if (seg.Fields.Count > 0)
            {
                foreach (IdocSegmentField field in seg.Fields)
                {
                    if (!field.FieldValue.ToString().Trim().Equals(""))
                    {
                        XmlNode newChild = doc.CreateNode(XmlNodeType.Element, Converts.OriginalNameToXmlName(field.FieldName), "");
                        newChild.InnerText = field.FieldValue.ToString().TrimEnd(new char[0]);
                        node.AppendChild(newChild);
                    }
                }
            }
            else
            {
                XmlNode node3 = doc.CreateNode(XmlNodeType.Element, "BUFFER", "");
                node3.InnerText = seg.ReadDataBuffer(0, 0x3e8).TrimEnd(" ".ToCharArray());
                node.AppendChild(node3);
            }
            foreach (IdocSegment segment in seg.ChildSegments)
            {
                node.AppendChild(this.GetXMLNodeFromSegment(segment, doc));
            }
            return node;
        }
        private bool IsSegmentValid(string SegmentName)
        {
            SegmentName = SegmentName.Trim();
            if (SegmentName.Length < 3)
            {
                return false;
            }
            if (((IdocSegment)this.StoredSegments[SegmentName]) == null)
            {
                string str = SegmentName.Substring(0, SegmentName.Length - 3);
                if (((IdocSegment)this.StoredSegments[str]) == null)
                {
                    if (SegmentName.Substring(1, 1) == "2")
                    {
                        str = SegmentName.Substring(0, 1) + "1" + SegmentName.Substring(2);
                    }
                    else
                    {
                        str = SegmentName.Substring(0, 1) + "2" + SegmentName.Substring(2);
                    }
                    if (((IdocSegment)this.StoredSegments[str]) == null)
                    {
                        str = str.Substring(0, str.Length - 3);
                        if (((IdocSegment)this.StoredSegments[str]) == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private void LoadIdocSchema(DataSet ds)
        {
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable table = ds.Tables[i];
                int num2 = 1;
                if (((table.ExtendedProperties != null) && table.ExtendedProperties.ContainsKey("SEGMENTMAXOCCUR")) && ((table.ExtendedProperties["SEGMENTMAXOCCUR"] is string) && !string.IsNullOrEmpty((string)table.ExtendedProperties["SEGMENTMAXOCCUR"])))
                {
                    num2 = Convert.ToInt32(table.ExtendedProperties["SEGMENTMAXOCCUR"]);
                }
                string str = Converts.XmlNameToOriginalName(table.TableName);
                IdocSegment seg = new IdocSegment
                {
                    SegmentName = str,
                    MaxOccur = num2
                };
                int offset = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Columns[j].MaxLength > 0)
                    {
                        seg.Fields.Add(Converts.XmlNameToOriginalName(table.Columns[j].ColumnName), table.Columns[j].Caption, table.Columns[j].MaxLength, offset, "CHAR", "");
                        offset += table.Columns[j].MaxLength;
                    }
                }
                this.StoreSegmentForFurtherUse(seg);
            }
            this.RegenerateFields();
        }
        public void LoadIdocSchema(StreamReader IdocSchemaStreamReader)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXmlSchema(IdocSchemaStreamReader);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Thisisnotavalidschemafile, exception);
            }
            this.LoadIdocSchema(ds);
        }
        public void LoadIdocSchema(TextReader TextReader)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXmlSchema(TextReader);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Thisisnotavalidschemafile, exception);
            }
            this.LoadIdocSchema(ds);
        }
        public void LoadIdocSchema(string SchemaFileName)
        {
            if (!File.Exists(SchemaFileName))
            {
                throw new SAPException("File Not found");
            }
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXmlSchema(SchemaFileName);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Thisisnotavalidschemafile, exception);
            }
            this.LoadIdocSchema(ds);
        }
        public virtual void LoadPlainData(StreamReader strm)
        {
            this.Segments.Clear();
            this.PlainLoadSegmentHash = new Hashtable();
            bool flag = false;
            for (string str = strm.ReadLine(); str != null; str = strm.ReadLine())
            {
                str = str.PadRight(0x5dc);
                if (str.StartsWith("EDI_DC40"))
                {
                    flag = true;
                    this.TABNAM = str.Substring(0, 10).Trim();
                    this.MANDT = str.Substring(10, 3).Trim();
                    this.DOCNUM = str.Substring(13, 0x10).Trim();
                    this.DOCREL = str.Substring(0x1d, 4).Trim();
                    this.STATUS = str.Substring(0x21, 2).Trim();
                    this.DIRECT = str.Substring(0x23, 1).Trim();
                    this.OUTMOD = str.Substring(0x24, 1).Trim();
                    this.EXPRSS = str.Substring(0x25, 1).Trim();
                    this.TEST = str.Substring(0x26, 1).Trim();
                    this.IDOCTYP = str.Substring(0x27, 30).Trim();
                    this.CIMTYP = str.Substring(0x45, 30).Trim();
                    this.MESTYP = str.Substring(0x63, 30).Trim();
                    this.MESCOD = str.Substring(0x81, 3).Trim();
                    this.MESFCT = str.Substring(0x84, 3).Trim();
                    this.STD = str.Substring(0x87, 1).Trim();
                    this.STDVRS = str.Substring(0x88, 6).Trim();
                    this.STDMES = str.Substring(0x8e, 6).Trim();
                    this.SNDPOR = str.Substring(0x94, 10).Trim();
                    this.SNDPRT = str.Substring(0x9e, 2).Trim();
                    this.SNDPFC = str.Substring(160, 2).Trim();
                    this.SNDPRN = str.Substring(0xa2, 10).Trim();
                    this.SNDSAD = str.Substring(0xac, 0x15).Trim();
                    this.SNDLAD = str.Substring(0xc1, 70).Trim();
                    this.RCVPOR = str.Substring(0x107, 10).Trim();
                    this.RCVPRT = str.Substring(0x111, 2).Trim();
                    this.RCVPFC = str.Substring(0x113, 2).Trim();
                    this.RCVPRN = str.Substring(0x115, 10).Trim();
                    this.RCVSAD = str.Substring(0x11f, 0x15).Trim();
                    this.RCVLAD = str.Substring(0x134, 0x15).Trim();
                    this.CREDAT = str.Substring(0x149, 70).Trim();
                    this.CRETIM = str.Substring(0x18f, 10).Trim();
                    this.REFINT = str.Substring(0x199, 2).Trim();
                    this.REFGRP = str.Substring(0x19b, 2).Trim();
                    this.REFMES = str.Substring(0x19d, 10).Trim();
                    this.ARCKEY = str.Substring(0x1a7, 0x15).Trim();
                    this.SERIAL = str.Substring(0x1bc, 0x15).Trim();
                }
                else
                {
                    if (!flag)
                    {
                        throw new SAPException(Messages.Couldnotlocatecontrolrecord);
                    }
                    if (this.StoredSegments.Count == 0)
                    {
                        this.LoadSegmentFromPlainString(str, false);
                    }
                    else
                    {
                        this.LoadSegmentFromPlainString(str, true);
                    }
                }
            }
        }
        public virtual void LoadPlainData(string FileName)
        {
            StreamReader strm = File.OpenText(FileName);
            this.LoadPlainData(strm);
            strm.Close();
        }
        private void LoadSegmentFromPlainString(string SegmentString, bool UseStoredSegments)
        {
            IdocSegment segment;
            string segmentName = SegmentString.Substring(0, 30).Trim();
            SegmentString.Substring(30, 3).Trim();
            SegmentString.Substring(0x21, 0x10).Trim();
            string key = SegmentString.Substring(0x31, 6).Trim();
            string str3 = SegmentString.Substring(0x37, 6).Trim();
            SegmentString.Substring(0x3d, 2).Trim();
            string str4 = Converts.Unescape(SegmentString.Substring(0x3f), plainTextUnescapes, '\\');
            if (UseStoredSegments)
            {
                segment = this.CreateSegment(segmentName);
            }
            else
            {
                segment = new IdocSegment
                {
                    SegmentName = segmentName
                };
            }
            segment.WriteDataBuffer(str4.PadRight(0x3e8), 0, 0x3e8);
            segment.SegmentNumberForPlainLoad = key;
            if (str3.Equals("000000"))
            {
                this.Segments.Add(segment);
            }
            else if (this.PlainLoadSegmentHash[str3] == null)
            {
                this.Segments.Add(segment);
            }
            else
            {
                ((IdocSegment)this.PlainLoadSegmentHash[str3]).ChildSegments.Add(segment);
            }
            if (!key.Trim().Equals(""))
            {
                try
                {
                    this.PlainLoadSegmentHash.Add(key, segment);
                }
                catch
                {
                }
            }
            foreach (IdocSegmentField field in segment.Fields)
            {
                field.FieldValue = str4.Substring(field.OffsetInBuffer, field.ExternalLength).Trim();
            }
        }
        public virtual void LoadXMLData(TextReader IdocFileTextReader)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(IdocFileTextReader);
            this.LoadXMLData(xdoc);
        }
        public virtual void LoadXMLData(string IdocFile)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(IdocFile);
            this.LoadXMLData(xdoc);
        }
        private void LoadXMLData(XmlDocument xdoc)
        {
            XmlElement documentElement = xdoc.DocumentElement;
            if (!documentElement.HasChildNodes)
            {
                throw new SAPException("No nodes found");
            }
            if (documentElement.ChildNodes[0].Name.ToUpper() != "IDOC")
            {
                throw new SAPException("No IDoc node found");
            }
            XmlNode node = documentElement.ChildNodes[0];
            if (node.ChildNodes.Count < 2)
            {
                throw new SAPException("No segment data found");
            }
            this.Segments.Clear();
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode node2 = node.ChildNodes[i];
                if (node2.Name == "EDI_DC40")
                {
                    for (int j = 0; j < node2.ChildNodes.Count; j++)
                    {
                        string str = Converts.XmlNameToOriginalName(node2.ChildNodes[j].Name);
                        string innerText = node2.ChildNodes[j].InnerText;
                        if (str == "ARCKEY")
                        {
                            this._ARCKEY = innerText;
                        }
                        else if (str == "CIMTYP")
                        {
                            this._CIMTYP = innerText;
                        }
                        else if (str == "CREDAT")
                        {
                            this._CREDAT = innerText;
                        }
                        else if (str == "CRETIM")
                        {
                            this._CRETIM = innerText;
                        }
                        else if (str == "DIRECT")
                        {
                            this._DIRECT = innerText;
                        }
                        else if (str == "DOCNUM")
                        {
                            this._DOCNUM = innerText;
                        }
                        else if (str == "DOCREL")
                        {
                            this._DOCREL = innerText;
                        }
                        else if (str == "EXPRSS")
                        {
                            this._EXPRSS = innerText;
                        }
                        else if (str == "IDOCTYP")
                        {
                            this._IDOCTYP = innerText;
                        }
                        else if (str == "MANDT")
                        {
                            this._MANDT = innerText;
                        }
                        else if (str == "MESCOD")
                        {
                            this._MESCOD = innerText;
                        }
                        else if (str == "MESFCT")
                        {
                            this._MESFCT = innerText;
                        }
                        else if (str == "MESTYP")
                        {
                            this._MESTYP = innerText;
                        }
                        else if (str == "OUTMOD")
                        {
                            this._OUTMOD = innerText;
                        }
                        else if (str == "RCVLAD")
                        {
                            this._RCVLAD = innerText;
                        }
                        else if (str == "RCVPFC")
                        {
                            this._RCVPFC = innerText;
                        }
                        else if (str == "RCVPOR")
                        {
                            this._RCVPOR = innerText;
                        }
                        else if (str == "RCVPRN")
                        {
                            this._RCVPRN = innerText;
                        }
                        else if (str == "RCVPRT")
                        {
                            this._RCVPRT = innerText;
                        }
                        else if (str == "RCVSAD")
                        {
                            this._RCVSAD = innerText;
                        }
                        else if (str == "REFGRP")
                        {
                            this._REFGRP = innerText;
                        }
                        else if (str == "REFINT")
                        {
                            this._REFINT = innerText;
                        }
                        else if (str == "REFMES")
                        {
                            this._REFMES = innerText;
                        }
                        else if (str == "REFMES")
                        {
                            this._REFMES = innerText;
                        }
                        else if (str == "SERIAL")
                        {
                            this._SERIAL = innerText;
                        }
                        else if (str == "SNDLAD")
                        {
                            this._SNDLAD = innerText;
                        }
                        else if (str == "SNDPFC")
                        {
                            this._SNDPFC = innerText;
                        }
                        else if (str == "SNDPFC")
                        {
                            this._SNDPFC = innerText;
                        }
                        else if (str == "SNDPOR")
                        {
                            this._SNDPOR = innerText;
                        }
                        else if (str == "SNDPRN")
                        {
                            this._SNDPRN = innerText;
                        }
                        else if (str == "SNDPRT")
                        {
                            this._SNDPRT = innerText;
                        }
                        else if (str == "SNDSAD")
                        {
                            this._SNDSAD = innerText;
                        }
                        else if (str == "STATUS")
                        {
                            this._STATUS = innerText;
                        }
                        else if (str == "STD")
                        {
                            this._STD = innerText;
                        }
                        else if (str == "STDMES")
                        {
                            this._STDMES = innerText;
                        }
                        else if (str == "STDVRS")
                        {
                            this._STDVRS = innerText;
                        }
                        else if (str == "TABNAM")
                        {
                            this._TABNAM = innerText;
                        }
                        else if (str == "TEST")
                        {
                            this._TEST = innerText;
                        }
                    }
                }
                else
                {
                    IdocSegment segmentFromNode = this.GetSegmentFromNode(node2);
                    this.Segments.Add(segmentFromNode);
                }
            }
        }
        private void RegenerateFields()
        {
            for (int i = 0; i < this.Segments.Count; i++)
            {
                this.RegenerateSegment(this.Segments[i]);
            }
        }
        private void RegenerateSegment(IdocSegment seg)
        {
            try
            {
                if (seg.Fields.Count == 0)
                {
                    try
                    {
                        IdocSegment segment = this.CreateSegment(seg.SegmentName);
                        string str = seg.ReadDataBuffer(0, 0x3e8);
                        seg.Fields = segment.Fields;
                        foreach (IdocSegmentField field in seg.Fields)
                        {
                            field.FieldValue = str.Substring(field.OffsetInBuffer, field.ExternalLength);
                        }
                    }
                    catch
                    {
                    }
                }
                for (int i = 0; i < seg.ChildSegments.Count; i++)
                {
                    this.RegenerateSegment(seg.ChildSegments[i]);
                }
            }
            catch
            {
            }
        }
        public void SaveIdocSchema(string SchemaFileName)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(this.GetIdocSchema());
            XmlElement documentElement = document.DocumentElement;
            document.Save(SchemaFileName);
        }
        public void SaveIdocSchema(XmlWriter XmlWriter)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(this.GetIdocSchema());
            document.Save(XmlWriter);
        }
        public virtual void SavePlainData(StreamWriter writer)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.TABNAM.ToString().PadRight(10));
            builder.Append(this.MANDT.ToString().PadRight(3));
            builder.Append(this.DOCNUM.ToString().PadRight(0x10));
            builder.Append(this.DOCREL.ToString().PadRight(4));
            builder.Append(this.STATUS.ToString().PadRight(2));
            builder.Append(this.DIRECT.ToString().PadRight(1));
            builder.Append(this.OUTMOD.ToString().PadRight(1));
            builder.Append(this.EXPRSS.ToString().PadRight(1));
            builder.Append(this.TEST.ToString().PadRight(1));
            builder.Append(this.IDOCTYP.ToString().PadRight(30));
            builder.Append(this.CIMTYP.ToString().PadRight(30));
            builder.Append(this.MESTYP.ToString().PadRight(30));
            builder.Append(this.MESCOD.ToString().PadRight(3));
            builder.Append(this.MESFCT.ToString().PadRight(3));
            builder.Append(this.STD.ToString().PadRight(1));
            builder.Append(this.STDVRS.ToString().PadRight(6));
            builder.Append(this.STDMES.ToString().PadRight(6));
            builder.Append(this.SNDPOR.ToString().PadRight(10));
            builder.Append(this.SNDPRT.ToString().PadRight(2));
            builder.Append(this.SNDPFC.ToString().PadRight(2));
            builder.Append(this.SNDPRN.ToString().PadRight(10));
            builder.Append(this.SNDSAD.ToString().PadRight(0x15));
            builder.Append(this.SNDLAD.ToString().PadRight(70));
            builder.Append(this.RCVPOR.ToString().PadRight(10));
            builder.Append(this.RCVPRT.ToString().PadRight(2));
            builder.Append(this.RCVPFC.ToString().PadRight(2));
            builder.Append(this.RCVPRN.ToString().PadRight(10));
            builder.Append(this.RCVSAD.ToString().PadRight(0x15));
            builder.Append(this.RCVLAD.ToString().PadRight(70));
            builder.Append(this.CREDAT.ToString().PadRight(8));
            builder.Append(this.CRETIM.ToString().PadRight(6));
            builder.Append(this.REFINT.ToString().PadRight(14));
            builder.Append(this.REFGRP.ToString().PadRight(14));
            builder.Append(this.REFMES.ToString().PadRight(14));
            builder.Append(this.ARCKEY.ToString().PadRight(70));
            builder.Append(this.SERIAL.ToString().PadRight(20));
            writer.WriteLine(builder.ToString());
            this.SegNumForPlainFile = 1;
            for (int i = 0; i < this.Segments.Count; i++)
            {
                this.WriteSegmentToFile("0000", writer, this.Segments[i], 1);
            }
        }
        public virtual void SavePlainData(string FileName)
        {
            this.SavePlainData(FileName, null);
        }
        public void SavePlainData(string FileName, Encoding Encoding)
        {
            StreamWriter writer;
            FileStream stream = new FileStream(FileName, FileMode.Create);
            if (Encoding == null)
            {
                writer = new StreamWriter(stream);
            }
            else
            {
                writer = new StreamWriter(stream, Encoding);
            }
            this.SavePlainData(writer);
            writer.Flush();
            writer.Close();
            stream.Close();
        }
        public virtual void SaveXMLData(TextWriter IdocFileTextWriter)
        {
            this.GetXMLDocument("ISO-8859-1").Save(IdocFileTextWriter);
        }
        public virtual void SaveXMLData(string IdocFileName)
        {
            this.GetXMLDocument("ISO-8859-1").Save(IdocFileName);
        }
        public virtual void SaveXMLData(string IdocFileName, string XMLEncoding)
        {
            this.GetXMLDocument(XMLEncoding).Save(IdocFileName);
        }
        public virtual void Send()
        {
            //if (this.con == null)
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if ((this.con.RFCHandle <= 0) && (this.con.Protocol != ClientProtocol.HttpSoap))
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if (this._ChildSegments.Count == 0)
            //{
            //    throw new ERPException(Messages.Nosegmentsfound);
            //}
            //string tID = this.con.CreateTID();
            RfcUnitID tId = new RfcUnitID(RfcUnitType.TRANSACTIONAL);
            //  String tID = con.CreateTid();
            this.Send(tId);
            // this.con.ConfirmTID(tID);
        }
        public void Send(RfcUnitID tId)
        {
            //if (this.con == null)
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if ((this.con.RFCHandle <= 0) && (this.con.Protocol != ClientProtocol.HttpSoap))
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if (this._ChildSegments.Count == 0)
            //{
            //    throw new ERPException(Messages.Nosegmentsfound);
            //}
            // RFCFunction function = RFCFunctionFactory.GenerateFunctionObjectForIDOC_INBOUND_ASYNCHRONOUS(this.con.IsUnicode);
            IRfcFunction function = des.Repository.CreateFunction("IDOC_INBOUND_ASYNCHRONOUS");
            //function.Connection = this.con;
            IRfcTable table = function.GetTable("IDOC_CONTROL_REC_40");
            table.Append();
            IRfcStructure structure = table.CurrentRow;
            structure["TABNAM"].SetValue(this.TABNAM);
            structure["MANDT"].SetValue(this.MANDT);
            structure["DOCNUM"].SetValue(this.DOCNUM);
            structure["DOCREL"].SetValue(this.DOCREL);
            structure["STATUS"].SetValue(this.STATUS);
            structure["DIRECT"].SetValue(this.DIRECT);
            structure["OUTMOD"].SetValue(this.OUTMOD);
            structure["EXPRSS"].SetValue(this.EXPRSS);
            structure["IDOCTYP"].SetValue(this.IDOCTYP);
            structure["CIMTYP"].SetValue(this.CIMTYP);
            structure["MESTYP"].SetValue(this.MESTYP);
            structure["MESCOD"].SetValue(this.MESCOD);
            structure["MESFCT"].SetValue(this.MESFCT);
            structure["STD"].SetValue(this.STD);
            structure["STDVRS"].SetValue(this.STDVRS);
            structure["STDMES"].SetValue(this.STDMES);
            structure["SNDPOR"].SetValue(this.SNDPOR);
            structure["SNDPRT"].SetValue(this.SNDPRT);
            structure["SNDPFC"].SetValue(this.SNDPFC);
            structure["SNDPRN"].SetValue(this.SNDPRN);
            structure["SNDSAD"].SetValue(this.SNDSAD);
            structure["SNDLAD"].SetValue(this.SNDLAD);
            structure["RCVPOR"].SetValue(this.RCVPOR);
            structure["RCVPRT"].SetValue(this.RCVPRT);
            structure["RCVPFC"].SetValue(this.RCVPFC);
            structure["RCVPRN"].SetValue(this.RCVPRN);
            structure["RCVSAD"].SetValue(this.RCVSAD);
            structure["RCVLAD"].SetValue(this.RCVLAD);
            structure["CREDAT"].SetValue(this.CREDAT);
            structure["CRETIM"].SetValue(this.CRETIM);
            structure["REFINT"].SetValue(this.REFINT);
            structure["REFGRP"].SetValue(this.REFGRP);
            structure["REFMES"].SetValue(this.REFMES);
            structure["ARCKEY"].SetValue(this.ARCKEY);
            structure["SERIAL"].SetValue(this.SERIAL);
            IRfcTable tData = function.GetTable("IDOC_DATA_REC_40");
            for (int i = 0; i < this.Segments.Count; i++)
            {
                this.WriteSegmentToTable("0000", tData, this.Segments[i], 1);
            }
            des.ConfirmUnitID(tId);
            function.Invoke(des);
            // function.Execute(TID);

            //  this._LastTID = Encoding.Default.GetString(TID);
            this._LastTID = tId.Uuid.ToString();
        }
        //public void Send(string TID)
        //{
        //    if (this.con == null)
        //    {
        //        throw new ERPException(Messages.NoConnectionAssigned);
        //    }
        //    if ((this.con.RFCHandle <= 0) && (this.con.Protocol != ClientProtocol.HttpSoap))
        //    {
        //        throw new ERPException(Messages.NoConnectionAssigned);
        //    }
        //    if (this._ChildSegments.Count == 0)
        //    {
        //        throw new ERPException(Messages.Nosegmentsfound);
        //    }
        //    RFCFunction function = RFCFunctionFactory.GenerateFunctionObjectForIDOC_INBOUND_ASYNCHRONOUS(this.con.IsUnicode);
        //    function.Connection = this.con;
        //    RFCStructure structure = function.Tables["IDOC_CONTROL_REC_40"].AddRow();
        //    structure["TABNAM"] = this.TABNAM;
        //    structure["MANDT"] = this.MANDT;
        //    structure["DOCNUM"] = this.DOCNUM;
        //    structure["DOCREL"] = this.DOCREL;
        //    structure["STATUS"] = this.STATUS;
        //    structure["DIRECT"] = this.DIRECT;
        //    structure["OUTMOD"] = this.OUTMOD;
        //    structure["EXPRSS"] = this.EXPRSS;
        //    structure["IDOCTYP"] = this.IDOCTYP;
        //    structure["CIMTYP"] = this.CIMTYP;
        //    structure["MESTYP"] = this.MESTYP;
        //    structure["MESCOD"] = this.MESCOD;
        //    structure["MESFCT"] = this.MESFCT;
        //    structure["STD"] = this.STD;
        //    structure["STDVRS"] = this.STDVRS;
        //    structure["STDMES"] = this.STDMES;
        //    structure["SNDPOR"] = this.SNDPOR;
        //    structure["SNDPRT"] = this.SNDPRT;
        //    structure["SNDPFC"] = this.SNDPFC;
        //    structure["SNDPRN"] = this.SNDPRN;
        //    structure["SNDSAD"] = this.SNDSAD;
        //    structure["SNDLAD"] = this.SNDLAD;
        //    structure["RCVPOR"] = this.RCVPOR;
        //    structure["RCVPRT"] = this.RCVPRT;
        //    structure["RCVPFC"] = this.RCVPFC;
        //    structure["RCVPRN"] = this.RCVPRN;
        //    structure["RCVSAD"] = this.RCVSAD;
        //    structure["RCVLAD"] = this.RCVLAD;
        //    structure["CREDAT"] = this.CREDAT;
        //    structure["CRETIM"] = this.CRETIM;
        //    structure["REFINT"] = this.REFINT;
        //    structure["REFGRP"] = this.REFGRP;
        //    structure["REFMES"] = this.REFMES;
        //    structure["ARCKEY"] = this.ARCKEY;
        //    structure["SERIAL"] = this.SERIAL;
        //    RFCTable tData = function.Tables["IDOC_DATA_REC_40"];
        //    for (int i = 0; i < this.Segments.Count; i++)
        //    {
        //        this.WriteSegmentToTable("0000", tData, this.Segments[i], 1);
        //    }
        //    function.Execute(TID);
        //    this._LastTID = TID;
        //}
        public virtual bool SendAndWait()
        {
            //if (this.con == null)
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if ((this.con.RFCHandle <= 0) && (this.con.Protocol != ClientProtocol.HttpSoap))
            //{
            //    throw new ERPException(Messages.NoConnectionAssigned);
            //}
            //if (this._ChildSegments.Count == 0)
            //{
            //    throw new ERPException(Messages.Nosegmentsfound);
            //}
            IRfcFunction function = this.des.Repository.CreateFunction("IDOC_INBOUND_SINGLE");
            function["PI_DO_COMMIT"].SetValue("X");
            // function.Connection = this.con;
            IRfcStructure structure = function.GetStructure("PI_IDOC_CONTROL_REC_40");
            structure["TABNAM"].SetValue(this.TABNAM);
            structure["MANDT"].SetValue(this.MANDT);
            structure["DOCNUM"].SetValue(this.DOCNUM);
            structure["DOCREL"].SetValue(this.DOCREL);
            structure["STATUS"].SetValue(this.STATUS);
            structure["DIRECT"].SetValue(this.DIRECT.Trim().Equals("") ? "2" : this.DIRECT);
            structure["OUTMOD"].SetValue(this.OUTMOD);
            structure["EXPRSS"].SetValue(this.EXPRSS);
            structure["IDOCTYP"].SetValue(this.IDOCTYP);
            structure["CIMTYP"].SetValue(this.CIMTYP);
            structure["MESTYP"].SetValue(this.MESTYP);
            structure["MESCOD"].SetValue(this.MESCOD);
            structure["MESFCT"].SetValue(this.MESFCT);
            structure["STD"].SetValue(this.STD);
            structure["STDVRS"].SetValue(this.STDVRS);
            structure["STDMES"].SetValue(this.STDMES);
            structure["SNDPOR"].SetValue(this.SNDPOR);
            structure["SNDPRT"].SetValue(this.SNDPRT);
            structure["SNDPFC"].SetValue(this.SNDPFC);
            structure["SNDPRN"].SetValue(this.SNDPRN);
            structure["SNDSAD"].SetValue(this.SNDSAD);
            structure["SNDLAD"].SetValue(this.SNDLAD);
            structure["RCVPOR"].SetValue(this.RCVPOR);
            structure["RCVPRT"].SetValue(this.RCVPRT);
            structure["RCVPFC"].SetValue(this.RCVPFC);
            structure["RCVPRN"].SetValue(this.RCVPRN);
            structure["RCVSAD"].SetValue(this.RCVSAD);
            structure["RCVLAD"].SetValue(this.RCVLAD);
            structure["CREDAT"].SetValue(this.CREDAT);
            structure["CRETIM"].SetValue(this.CRETIM);
            structure["REFINT"].SetValue(this.REFINT);
            structure["REFGRP"].SetValue(this.REFGRP);
            structure["REFMES"].SetValue(this.REFMES);
            structure["ARCKEY"].SetValue(this.ARCKEY);
            structure["SERIAL"].SetValue(this.SERIAL);
            IRfcTable tData = function.GetTable("PT_IDOC_DATA_RECORDS_40");
            for (int i = 0; i < this.Segments.Count; i++)
            {
                this.WriteSegmentToTable("0000", tData, this.Segments[i], 1);
            }
            function.Invoke(des);
            this._DOCNUM = function["PE_IDOC_NUMBER"].GetValue().ToString();
            return function["PE_ERROR_PRIOR_TO_APPLICATION"].GetValue().ToString().Equals("X");
        }
        internal void StoreSegmentForFurtherUse(IdocSegment seg)
        {
            if (!this.StoredSegments.Contains(seg.SegmentName))
            {
                this.StoredSegments.Add(seg.SegmentName, seg);
            }
        }
        public override string ToString()
        {
            string ret = this.IDOCTYP + "\r\n";
            for (int i = 0; i < this.Segments.Count; i++)
            {
                this.WriteSegment(ref ret, this.Segments[i]);
            }
            return ret;
        }
        private void WriteSegment(ref string ret, IdocSegment seg)
        {
            string str = ret;
            ret = str + seg.SegmentName + " " + seg.Description + "\r\n";
            ret = ret + seg.ReadDataBuffer(0, 0x3e8) + "\r\n";
            for (int i = 0; i < seg.ChildSegments.Count; i++)
            {
                this.WriteSegment(ref ret, seg.ChildSegments[i]);
            }
        }
        private void WriteSegment(ref StringBuilder st, IdocSegment seg)
        {
            int maxOccur = seg.MaxOccur;
            if (maxOccur <= 0)
            {
                maxOccur = 1;
            }
            st.Append(string.Concat(new object[] { "<xsd:element name=\"", Converts.OriginalNameToXmlName(seg.SegmentName), "\" msprop:SEGMENTMAXOCCUR=\"", maxOccur, "\" maxOccurs=\"", maxOccur, "\">" }));
            st.Append("<xsd:annotation>\n");
            st.Append("<xsd:documentation>" + Converts.OriginalNameToXmlName(seg.Description.Replace("&", "")) + "</xsd:documentation>\n ");
            st.Append("</xsd:annotation>\n");
            st.Append("<xsd:complexType>\n");
            st.Append("<xsd:sequence>\n");
            foreach (IdocSegmentField field in seg.Fields)
            {
                st.Append("<xsd:element name=\"" + Converts.OriginalNameToXmlName(field.FieldName) + "\" minOccurs=\"0\">\n");
                st.Append("<xsd:annotation>\n");
                st.Append("<xsd:documentation>" + Converts.OriginalNameToXmlName(field.Description.Replace("&", "")) + "</xsd:documentation> \n");
                st.Append("</xsd:annotation>\n");
                st.Append("<xsd:simpleType>\n");
                st.Append("<xsd:restriction base=\"xsd:string\">\n");
                st.Append("<xsd:maxLength value=\"" + field.ExternalLength + "\" /> \n");
                st.Append("</xsd:restriction>\n");
                st.Append("</xsd:simpleType>\n");
                st.Append("</xsd:element>\n");
            }
            foreach (IdocSegment segment in seg.ChildSegments)
            {
                this.WriteSegment(ref st, segment);
            }
            st.Append("</xsd:sequence>\n");
            st.Append("<xsd:attribute name=\"SEGMENT\" use=\"required\">\n");
            st.Append("<xsd:simpleType>\n");
            st.Append("<xsd:restriction base=\"xsd:string\">\n");
            st.Append("<xsd:enumeration value=\"1\"/>\n");
            st.Append("</xsd:restriction>\n");
            st.Append("</xsd:simpleType>\n");
            st.Append("</xsd:attribute>\n");
            st.Append("</xsd:complexType>\n");
            st.Append("</xsd:element>\n");
        }
        private void WriteSegmentToFile(string ParentNr, StreamWriter writer, IdocSegment SegToWrite, int HLevel)
        {
            string str = "";
            str = SegToWrite.SegmentName.PadRight(30) + this.MANDT.PadRight(3) + this.DOCNUM.PadRight(0x10);
            string input = SegToWrite.ReadDataBuffer(0, 0x3e8).TrimEnd(new char[] { " ".ToCharArray()[0] });
            string parentNr = this.SegNumForPlainFile.ToString().PadLeft(6, "0".ToCharArray()[0]);
            string str4 = ParentNr.PadLeft(6, "0".ToCharArray()[0]);
            this.SegNumForPlainFile++;
            str = str + parentNr + str4;
            if ((HLevel == 1) && (SegToWrite.MaxOccur > 1))
            {
                HLevel++;
            }
            if (this._SkipHLevel)
            {
                str = str + "  ";
            }
            else
            {
                str = str + HLevel.ToString().PadLeft(2, "0".ToCharArray()[0]);
            }
            str = str + Converts.Escape(input, plainTextEscapes, '\\');
            writer.WriteLine(str);
            if (SegToWrite.HasChildren)
            {
                for (int i = 0; i < SegToWrite.ChildSegments.Count; i++)
                {
                    this.WriteSegmentToFile(parentNr, writer, SegToWrite.ChildSegments[i], HLevel + 1);
                }
            }
        }
        private void WriteSegmentToTable(string ParentNr, IRfcTable tData, IdocSegment SegToWrite, int HLevel)
        {
            tData.Append();
            IRfcStructure structure = tData.CurrentRow;
            //RFCStructure structure = tData.AddRow();
            string parentNr = tData.RowCount.ToString();
            string str2 = SegToWrite.ReadDataBuffer(0, 0x3e8);
            structure["SEGNAM"].SetValue(SegToWrite.SegmentName);
            structure["MANDT"].SetValue(this.MANDT);
            structure["DOCNUM"].SetValue(this.DOCNUM);
            structure["SEGNUM"].SetValue(parentNr.PadLeft(6, "0".ToCharArray()[0]));
            structure["PSGNUM"].SetValue(ParentNr.PadLeft(6, "0".ToCharArray()[0]));
            if ((HLevel == 1) && (SegToWrite.MaxOccur > 1))
            {
                HLevel++;
            }
            if (this._SkipHLevel)
            {
                structure["HLEVEL"].SetValue("  ");
            }
            else
            {
                structure["HLEVEL"].SetValue(Convert.ToString(HLevel).PadLeft(2, "0".ToCharArray()[0]));
            }
            structure["SDATA"].SetValue(str2);
            if (SegToWrite.HasChildren)
            {
                for (int i = 0; i < SegToWrite.ChildSegments.Count; i++)
                {
                    this.WriteSegmentToTable(parentNr, tData, SegToWrite.ChildSegments[i], HLevel + 1);
                }
            }
        }
        public string ARCKEY
        {
            get
            {
                return this._ARCKEY;
            }
            set
            {
                this._ARCKEY = value;
            }
        }
        public string CIMTYP
        {
            get
            {
                return this._CIMTYP;
            }
            set
            {
                this._CIMTYP = value;
            }
        }
        public SAPConnection Connection
        {
            get
            {
                return this.con;
            }
            set
            {
                this.con = value;
            }
        }
        public RfcDestination Destination
        {
            get
            {
                return this.des;
            }
            set
            {
                this.des = value;
            }
        }
        public string CREDAT
        {
            get
            {
                return this._CREDAT;
            }
            set
            {
                this._CREDAT = value;
            }
        }
        public string CRETIM
        {
            get
            {
                return this._CRETIM;
            }
            set
            {
                this._CRETIM = value;
            }
        }
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }
        public string DIRECT
        {
            get
            {
                return this._DIRECT;
            }
            set
            {
                this._DIRECT = value;
            }
        }
        public string DOCNUM
        {
            get
            {
                return this._DOCNUM;
            }
            set
            {
                this._DOCNUM = value;
            }
        }
        public string DOCREL
        {
            get
            {
                return this._DOCREL;
            }
            set
            {
                this._DOCREL = value;
            }
        }
        public string EXPRSS
        {
            get
            {
                return this._EXPRSS;
            }
            set
            {
                this._EXPRSS = value;
            }
        }
        public string IDOCTYP
        {
            get
            {
                return this._IDOCTYP;
            }
            set
            {
                this._IDOCTYP = value;
            }
        }
        public string LastTID
        {
            get
            {
                return this._LastTID;
            }
        }
        public string MANDT
        {
            get
            {
                return this._MANDT;
            }
            set
            {
                this._MANDT = value;
            }
        }
        public string MESCOD
        {
            get
            {
                return this._MESCOD;
            }
            set
            {
                this._MESCOD = value;
            }
        }
        public string MESFCT
        {
            get
            {
                return this._MESFCT;
            }
            set
            {
                this._MESFCT = value;
            }
        }
        public string MESTYP
        {
            get
            {
                return this._MESTYP;
            }
            set
            {
                this._MESTYP = value;
            }
        }
        public string OUTMOD
        {
            get
            {
                return this._OUTMOD;
            }
            set
            {
                this._OUTMOD = value;
            }
        }
        public string RCVLAD
        {
            get
            {
                return this._RCVLAD;
            }
            set
            {
                this._RCVLAD = value;
            }
        }
        public string RCVPFC
        {
            get
            {
                return this._RCVPFC;
            }
            set
            {
                this._RCVPFC = value;
            }
        }
        public string RCVPOR
        {
            get
            {
                return this._RCVPOR;
            }
            set
            {
                this._RCVPOR = value;
            }
        }
        public string RCVPRN
        {
            get
            {
                return this._RCVPRN;
            }
            set
            {
                this._RCVPRN = value;
            }
        }
        public string RCVPRT
        {
            get
            {
                return this._RCVPRT;
            }
            set
            {
                this._RCVPRT = value;
            }
        }
        public string RCVSAD
        {
            get
            {
                return this._RCVSAD;
            }
            set
            {
                this._RCVSAD = value;
            }
        }
        public string REFGRP
        {
            get
            {
                return this._REFGRP;
            }
            set
            {
                this._REFGRP = value;
            }
        }
        public string REFINT
        {
            get
            {
                return this._REFINT;
            }
            set
            {
                this._REFINT = value;
            }
        }
        public string REFMES
        {
            get
            {
                return this._REFMES;
            }
            set
            {
                this._REFMES = value;
            }
        }
        public IdocSegmentCollection Segments
        {
            get
            {
                return this._ChildSegments;
            }
            set
            {
                this._ChildSegments = value;
            }
        }
        public string SERIAL
        {
            get
            {
                return this._SERIAL;
            }
            set
            {
                this._SERIAL = value;
            }
        }
        public bool SkipHLevel
        {
            get
            {
                return this._SkipHLevel;
            }
            set
            {
                this._SkipHLevel = value;
            }
        }
        public string SNDLAD
        {
            get
            {
                return this._SNDLAD;
            }
            set
            {
                this._SNDLAD = value;
            }
        }
        public string SNDPFC
        {
            get
            {
                return this._SNDPFC;
            }
            set
            {
                this._SNDPFC = value;
            }
        }
        public string SNDPOR
        {
            get
            {
                return this._SNDPOR;
            }
            set
            {
                this._SNDPOR = value;
            }
        }
        public string SNDPRN
        {
            get
            {
                return this._SNDPRN;
            }
            set
            {
                this._SNDPRN = value;
            }
        }
        public string SNDPRT
        {
            get
            {
                return this._SNDPRT;
            }
            set
            {
                this._SNDPRT = value;
            }
        }
        public string SNDSAD
        {
            get
            {
                return this._SNDSAD;
            }
            set
            {
                this._SNDSAD = value;
            }
        }
        public string STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                this._STATUS = value;
            }
        }
        public string STD
        {
            get
            {
                return this._STD;
            }
            set
            {
                this._STD = value;
            }
        }
        public string STDMES
        {
            get
            {
                return this._STDMES;
            }
            set
            {
                this._STDMES = value;
            }
        }
        public string STDVRS
        {
            get
            {
                return this._STDVRS;
            }
            set
            {
                this._STDVRS = value;
            }
        }
        public string TABNAM
        {
            get
            {
                return this._TABNAM;
            }
            set
            {
                this._TABNAM = value;
            }
        }
        public string TEST
        {
            get
            {
                return this._TEST;
            }
            set
            {
                this._TEST = value;
            }
        }
    }
}
