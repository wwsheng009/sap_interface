using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Globalization;
using System.Data;
using System.Collections;

namespace SAPINT
{
    static class RfcTypeConvertor
    {
        private static readonly Dictionary<string, RfcDataType> exidToRfcTypeDict = new Dictionary<string, RfcDataType>(0x11);
        private static readonly NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

        static RfcTypeConvertor()
        {
            exidToRfcTypeDict.Add("B", RfcDataType.INT1);
            exidToRfcTypeDict.Add("C", RfcDataType.CHAR);
            exidToRfcTypeDict.Add("D", RfcDataType.DATE);
            exidToRfcTypeDict.Add("F", RfcDataType.FLOAT);
            exidToRfcTypeDict.Add("G", RfcDataType.STRING);
            exidToRfcTypeDict.Add("H", RfcDataType.TABLE);
            exidToRfcTypeDict.Add("I", RfcDataType.INT4);
            exidToRfcTypeDict.Add("N", RfcDataType.NUM);
            exidToRfcTypeDict.Add("P", RfcDataType.BCD);
            exidToRfcTypeDict.Add("S", RfcDataType.INT2);
            exidToRfcTypeDict.Add("T", RfcDataType.TIME);
            exidToRfcTypeDict.Add("U", RfcDataType.STRUCTURE);
            exidToRfcTypeDict.Add("V", RfcDataType.STRUCTURE);
            exidToRfcTypeDict.Add("X", RfcDataType.BYTE);
            exidToRfcTypeDict.Add("Y", RfcDataType.XSTRING);
            exidToRfcTypeDict.Add(string.Empty, RfcDataType.STRUCTURE);
            exidToRfcTypeDict.Add(" ", RfcDataType.STRUCTURE);
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = string.Empty;


        }

        internal static System.Type RfcTypeToSystemType(RfcDataType Type)
        {
            if (Type == RfcDataType.CHAR)
            {
                return System.Type.GetType("System.String");
            }
            if (Type == RfcDataType.BYTE)
            {
                return System.Type.GetType("System.String");
            }
            if (Type == RfcDataType.DATE)
            {
                return System.Type.GetType("System.String");
            }
            if (Type == RfcDataType.TIME)
            {
                return System.Type.GetType("System.String");
            }
            if (Type == RfcDataType.BCD)
            {
                return System.Type.GetType("System.Decimal");
            }
            if (((Type == RfcDataType.INT4) || (Type == RfcDataType.INT1)) || (Type == RfcDataType.INT2))
            {
                return System.Type.GetType("System.Int32");
            }
            if (Type == RfcDataType.NUM)
            {
                return System.Type.GetType("System.Int32");
            }
            if (Type != RfcDataType.FLOAT)
            {
                // throw new ERPException(string.Format(Messages.CannotconvertRFCtype_0_toascalarsystemtype, Type.ToString()));
                throw new Exception(string.Format("Cannot convert RFCtype {0} to a scalar system type", Type.ToString()));
            }
            return System.Type.GetType("System.Double");
        }

        internal static System.Type AbapInnerTypeToSystemType(string innerType)
        {
            return RfcTypeToSystemType(AbapInnerTypeToRfcDataType(innerType));
        }
        /// <summary>
        /// 单字节的类型
        /// </summary>
        /// <param name="innerType"></param>
        /// <returns></returns>
        internal static RfcDataType AbapInnerTypeToRfcDataType(string innerType)
        {
            innerType = innerType.ToUpper().Trim();
            return exidToRfcTypeDict[innerType];
        }

        internal static RfcDataType StringTypeToRFCType(string st)
        {
            if (st == "CLNT")
            {
                return RfcDataType.CHAR;
            }
            if (st == "CHAR")
            {
                return RfcDataType.CHAR;
            }
            if (st == "DEC")
            {
                return RfcDataType.FLOAT;
            }
            if (st == "DATS")
            {
                return RfcDataType.DATE;
            }
            if (st == "DATE")
            {
                return RfcDataType.DATE;
            }
            if (st == "TIME")
            {
                return RfcDataType.TIME;
            }
            if (st == "BCD")
            {
                return RfcDataType.BCD;
            }
            if (st == "INT")
            {
                return RfcDataType.INT4;
            }
            if (st == "INT1")
            {
                return RfcDataType.INT1;
            }
            if (st == "INT2")
            {
                return RfcDataType.INT2;
            }
            if (st == "NUM")
            {
                return RfcDataType.NUM;
            }
            if (st == "NUMC")
            {
                return RfcDataType.NUM;
            }
            if (st == "UNIT")
            {
                return RfcDataType.CHAR;
            }
            if (st == "QUAN")
            {
                return RfcDataType.FLOAT;
            }
            if (st == "FLOAT")
            {
                return RfcDataType.FLOAT;
            }
            if (st == "STRUCTURE")
            {
                return RfcDataType.STRUCTURE;
            }
            if (st == "BYTE")
            {
                return RfcDataType.BYTE;
            }
            if (st == "ITAB")
            {
                return RfcDataType.TABLE;
            }
            if (st == "STRING")
            {
                return RfcDataType.STRING;
            }
            if (st != "XSTRING")
            {
                // throw new ERPException(string.Format(Messages.Cannotconvert_0_toaninternalRFCtype, st));
                throw new Exception(string.Format("Cannotconvert_{0}_to an internal RFCtype", st));
            }
            return RfcDataType.XSTRING;
        }


    }



}
