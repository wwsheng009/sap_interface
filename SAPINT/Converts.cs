using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
namespace SAPINT
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    // using System.Windows.Forms;
    using System.Xml;
    internal class Converts
    {
        //[ThreadStatic]
        internal static Encoding enc;
        private static readonly NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        //[ThreadStatic]
        private static int integerType;
        //[ThreadStatic]
        public static bool IsUnicode;
        internal const int MissingBytesWorkaroundCount = 0x40;
        static Converts()
        {

        }
        private Converts()
        {
        }
        //public static void CopyBytes(byte[] source, byte[] destination, int sourceOffset, int destinationOffset, int count)
        //{
        //    Buffer.BlockCopy(source, sourceOffset, destination, destinationOffset, count);
        //}
        //public static byte[] DecimalToRawBCDBytes(decimal val, int Length, int Decimals)
        //{
        //    decimal num = 0M;
        //    num = val * ((decimal)Math.Pow(10.0, (double)Decimals));
        //    string str = Math.Abs(num).ToString();
        //    if (str.IndexOf(".") > -1)
        //    {
        //        str = str.Split(".".ToCharArray())[0];
        //    }
        //    if (str.IndexOf(",") > -1)
        //    {
        //        str = str.Split(",".ToCharArray())[0];
        //    }
        //    string decInText = "";
        //    if (Decimals > 0)
        //    {
        //        try
        //        {
        //            if (str.Length <= Decimals)
        //            {
        //                str = str.PadLeft(Length * 2, "0".ToCharArray()[0]);
        //                decInText = "0." + str.Substring(str.Length - Decimals, Decimals);
        //            }
        //            else
        //            {
        //                decInText = str.Substring(0, str.Length - Decimals);
        //                decInText = decInText + "." + str.Substring(str.Length - Decimals, Decimals);
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            //MessageBox.Show(exception.ToString());
        //            throw exception;
        //        }
        //    }
        //    else
        //    {
        //        decInText = str;
        //    }
        //    if (num < 0M)
        //    {
        //        decInText = decInText + "-";
        //    }
        //    else
        //    {
        //        decInText = decInText + " ";
        //    }
        //    decInText = decInText.PadLeft(Length * 2, " ".ToCharArray()[0]);
        //    IntPtr newPointer = GetNewPointer(Length);
        //    int num2 = RFCAPI.RfcConvertCharToBcd(decInText, decInText.Length, ref Decimals, newPointer, Length);
        //    if (num2 != 0)
        //    {
        //        throw new ERPException("RfcConvertCharToBcd returned " + num2.ToString() + " Source: " + decInText);
        //    }
        //    byte[] destination = new byte[Length];
        //    Marshal.Copy(newPointer, destination, 0, Length);
        //    DestroyPointer(ref newPointer);
        //    return destination;
        //}
        //public static void DestroyPointer(ref IntPtr dest)
        //{
        //    if (dest != IntPtr.Zero)
        //    {
        //        Marshal.FreeHGlobal(dest);
        //        dest = IntPtr.Zero;
        //    }
        //}
        //internal static void DestroyStringPointer(ref IntPtr ptr)
        //{
        //    if (ptr != IntPtr.Zero)
        //    {
        //        RFCAPI.RfcFreeString(Marshal.ReadIntPtr(ptr));
        //        DestroyPointer(ref ptr);
        //    }
        //}
        //internal static void DestroyXstringPointer(ref IntPtr ptr)
        //{
        //    if (ptr != IntPtr.Zero)
        //    {
        //        RFCAPI.RfcResizeXString(ptr, 0);
        //        DestroyPointer(ref ptr);
        //    }
        //}
        //public static byte[] DoubleToRawBytes(double src, int Length)
        //{
        //    byte[] array = new byte[Length];
        //    BitConverter.GetBytes(src).CopyTo(array, 0);
        //    return array;
        //}
        internal static string Escape(string input, Dictionary<char, char> replacements, char escapeCharacter)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (replacements == null)
            {
                throw new ArgumentNullException("replacements");
            }
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == escapeCharacter)
                {
                    builder.Append(escapeCharacter);
                    builder.Append(escapeCharacter);
                }
                else
                {
                    char ch;
                    if (replacements.TryGetValue(input[i], out ch))
                    {
                        builder.Append(escapeCharacter);
                        builder.Append(ch);
                    }
                    else
                    {
                        builder.Append(input[i]);
                    }
                }
            }
            return builder.ToString();
        }
        //internal static RfcDataType ExidToRfcType(string exid)
        //{
        //    RfcDataType rfctype;
        //    try
        //    {
        //        rfctype = exidToRfcTypeDict[exid.ToLowerInvariant().Trim()];
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        throw new ERPException("Cannot convert EXID '" + exid + "' to RfcDataType");
        //    }
        //    return rfctype;
        //}
        public static string FormatMessage(string message, string var1, string var2, string var3, string var4)
        {
            var1 = var1.Trim();
            var2 = var2.Trim();
            var3 = var3.Trim();
            var4 = var4.Trim();
            string str = message.ToString().Replace("&1", var1).Replace("&2", var2).Replace("&3", var3).Replace("&4", var4);
            int num = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1).Equals("&"))
                {
                    switch (num)
                    {
                        case 1:
                            str = str.Substring(0, i) + var1 + str.Substring(i + 1);
                            num++;
                            break;
                        case 2:
                            str = str.Substring(0, i) + var2 + str.Substring(i + 1);
                            num++;
                            break;
                        case 3:
                            str = str.Substring(0, i) + var3 + str.Substring(i + 1);
                            num++;
                            break;
                        case 4:
                            str = str.Substring(0, i) + var4 + str.Substring(i + 1);
                            num++;
                            break;
                    }
                }
            }
            return str;
        }
        public static IntPtr GetNewPointer(int Length)
        {
            IntPtr ptr;
            try
            {
                ptr = Marshal.AllocHGlobal(Length);
            }
            catch
            {
                try
                {
                    ptr = Marshal.AllocHGlobal(Length);
                }
                catch
                {
                    try
                    {
                        ptr = Marshal.AllocHGlobal(Length);
                    }
                    catch
                    {
                        return new IntPtr(10);
                    }
                    return ptr;
                }
            }
            return ptr;
        }
        internal static IntPtr GetNewZeroFilledPointer(int length)
        {
            IntPtr newPointer = GetNewPointer(length);
            Marshal.Copy(new byte[length], 0, newPointer, length);
            return newPointer;
        }
        internal static string GetXmldataName(string name)
        {
            string input = name.Replace("/", "_-");
            if (Regex.IsMatch(input, "^[0-9].*", RegexOptions.Compiled))
            {
                input = "_--3" + input;
            }
            return input;
        }
        public static string HexEncodingBytesToString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str = str + bytes[i].ToString("X2");
            }
            return str;
        }
        public static int HexEncodingGetByteCount(string hexString)
        {
            int num = 0;
            for (int i = 0; i < hexString.Length; i++)
            {
                char c = hexString[i];
                if (HexEncodingIsHexDigit(c))
                {
                    num++;
                }
            }
            if ((num % 2) != 0)
            {
                num--;
            }
            return (num / 2);
        }
        public static byte[] HexEncodingGetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string str = "";
            for (int i = 0; i < hexString.Length; i++)
            {
                char c = hexString[i];
                if (HexEncodingIsHexDigit(c))
                {
                    str = str + c;
                }
                else
                {
                    discarded++;
                }
            }
            if ((str.Length % 2) != 0)
            {
                discarded++;
                str = str.Substring(0, str.Length - 1);
            }
            int num2 = str.Length / 2;
            byte[] buffer = new byte[num2];
            int num3 = 0;
            for (int j = 0; j < buffer.Length; j++)
            {
                string hex = new string(new char[] { str[num3], str[num3 + 1] });
                buffer[j] = HexEncodingHexToByte(hex);
                num3 += 2;
            }
            return buffer;
        }
        private static byte HexEncodingHexToByte(string hex)
        {
            if ((hex.Length > 2) || (hex.Length <= 0))
            {
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            }
            return byte.Parse(hex, NumberStyles.HexNumber);
        }
        public static bool HexEncodingIsHexDigit(char c)
        {
            int num2 = Convert.ToInt32('A');
            int num3 = Convert.ToInt32('0');
            c = char.ToUpper(c);
            int num = Convert.ToInt32(c);
            return (((num >= num2) && (num < (num2 + 6))) || ((num >= num3) && (num < (num3 + 10))));
        }
        public static bool HexEncodingIsInHexFormat(string hexString)
        {
            foreach (char ch in hexString)
            {
                if (!HexEncodingIsHexDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        internal static string IBMCodepageToSAPCodepage(string IBMCodepage)
        {
            string str = IBMCodepage;
            if (str != null)
            {
                str = string.IsInterned(str);
                if (!(str != "0120"))
                {
                    return "1100";
                }
                if (str == "0410")
                {
                    return "1404";
                }
                if (str == "0500")
                {
                    return "1504";
                }
                if (str == "0610")
                {
                    return "1614";
                }
                if (str == "0700")
                {
                    return "1704";
                }
                if (str == "0800")
                {
                    return "1804";
                }
            }
            return "1100";
        }
        //public static byte[] Int32ToRawBytes(int src, int Length)
        //{
        //    byte[] destination = new byte[Length];
        //    CopyBytes(BitConverter.GetBytes(src), destination, 0, 0, Length);
        //    return destination;
        //}
        //public static byte[] Int64ToRawBytes(long src, int Length)
        //{
        //    byte[] destination = new byte[Length];
        //    CopyBytes(BitConverter.GetBytes(src), destination, 0, 0, Length);
        //    return destination;
        //}
        internal static string NETToSoap(object NetValue, RfcDataType Type)
        {
            string str;
            if (Type == RfcDataType.CHAR)
            {
                str = NetValue.ToString();
            }
            else if (Type == RfcDataType.DATE)
            {
                if (NetValue.ToString().Length == 8)
                {
                    str = NetValue.ToString().Substring(0, 4) + "-" + NetValue.ToString().Substring(4, 2) + "-" + NetValue.ToString().Substring(6, 2);
                }
                else
                {
                    str = NetValue.ToString();
                }
            }
            else if (Type == RfcDataType.BCD)
            {
                NumberFormatInfo provider = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ""
                };
                str = Convert.ToString((decimal)NetValue, provider);
            }
            else if (Type == RfcDataType.FLOAT)
            {
                NumberFormatInfo info2 = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ""
                };
                str = Convert.ToString((double)NetValue, info2);
            }
            else if (((Type == RfcDataType.INT4) || (Type == RfcDataType.INT2)) || (Type == RfcDataType.INT1))
            {
                NumberFormatInfo info3 = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ""
                };
                str = Convert.ToString((int)NetValue, info3);
            }
            else if (Type == RfcDataType.NUM)
            {
                str = NetValue.ToString();
            }
            else if (Type == RfcDataType.STRING)
            {
                str = NetValue.ToString();
            }
            else if (Type == RfcDataType.TIME)
            {
                string str2 = NetValue.ToString();
                if (str2.Length == 4)
                {
                    str = str2.Substring(0, 2) + ":" + str2.Substring(2, 2) + ":00";
                }
                else if (str2.Length == 6)
                {
                    str = str2.Substring(0, 2) + ":" + str2.Substring(2, 2) + ":" + str2.Substring(4, 2);
                }
                else
                {
                    str = str2;
                }
            }
            else
            {
                if ((Type == RfcDataType.XSTRING) || (Type == RfcDataType.BYTE))
                {
                    return Convert.ToBase64String((byte[])NetValue);
                }
                if (Type == RfcDataType.TABLE)
                {
                    IRfcTable table = NetValue as IRfcTable;
                    if (table == null)
                    {
                        return "";
                    }
                    StringBuilder builder = new StringBuilder();
                    foreach (IRfcStructure structure in table.ToList())
                    {
                        builder.Append("<item>");
                        if (table.Metadata.LineType.FieldCount == 1)
                        {
                            builder.Append(NETToSoap(structure[table.Metadata.LineType[0].Name].GetValue(), table.Metadata.LineType[0].DataType));
                        }
                        else
                        {
                            for (var i = 1; i < table.Metadata.LineType.FieldCount; i++)
                            {
                                string str3 = table.Metadata.LineType[i].Name.Replace("/", "_-");
                                builder.Append("<" + str3 + ">");
                                builder.Append(NETToSoap(structure[i].GetValue(), structure[i].Metadata.DataType));
                                builder.Append("</" + str3 + ">");
                            }
                        }
                        builder.Append("</item>");
                    }
                    return builder.ToString();
                }
                if (Type != RfcDataType.STRUCTURE)
                {
                    //throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, Type.ToString()));
                    throw new Exception(string.Format("Type{0} not supported in this context", Type.ToString()));
                }
                IRfcStructure structure2 = NetValue as IRfcStructure;
                if (structure2 == null)
                {
                    return "";
                }
                StringBuilder builder2 = new StringBuilder();
                foreach (IRfcField column2 in structure2.ToList())
                {
                    string str4 = column2.Metadata.Name.Replace("/", "_-");
                    builder2.Append("<" + str4 + ">");
                    builder2.Append(NETToSoap(structure2[column2.Metadata.Name], column2.Metadata.DataType));
                    builder2.Append("</" + str4 + ">");
                }
                return builder2.ToString();
            }
            return StringToXMLString(str);
        }
        internal static string OriginalNameToXmlName(string origninalName)
        {
            string input = origninalName;
            if (input.StartsWith("___"))
            {
                input = "_US-" + input;
            }
            else if (Regex.IsMatch(input, "^[0-9].*", RegexOptions.Compiled))
            {
                input = "_NU-" + input;
            }
            return input.Replace("_FZ_", "_UFZU-").Replace("_ST_", "_USTU-").Replace("_x002F_", "_Ux002FU-").Replace("?", "_FZ-").Replace("/", "_-");
        }
        internal static byte[] PointerToRawBytes(IntPtr ptr, int length)
        {
            byte[] destination = new byte[length];
            Marshal.Copy(ptr, destination, 0, length);
            return destination;
        }
        //public static unsafe decimal RawBCDBytesToDecimal(byte[] RawBytes, int Offset, int Length, int Decimals)
        //{
        //    decimal num5;
        //    StringBuilder decInText = new StringBuilder("");
        //    string str = "";
        //    string toBeStripped = "";
        //    string str3 = "";
        //    try
        //    {
        //        int num;
        //        decimal num4;
        //        try
        //        {
        //            int capacity = (Length * 2) + 2;
        //            decInText = new StringBuilder(capacity);
        //            fixed (byte* numRef = &(RawBytes[Offset]))
        //            {
        //                num = RFCAPI.RfcConvertBcdToChar(new IntPtr((void*)numRef), Length, Decimals, decInText, capacity);
        //            }
        //            if (decInText.Length > capacity)
        //            {
        //                decInText.Length = capacity;
        //            }
        //        }
        //        catch
        //        {
        //            return 0M;
        //        }
        //        if (num != 0)
        //        {
        //            throw new ERPException("RfcConvertBcdToChar returned " + num.ToString());
        //        }
        //        str = decInText.ToString();
        //        for (int i = 0; i < decInText.Length; i++)
        //        {
        //            if ("0123456789., -".IndexOf(decInText.ToString().Substring(i, 1)) == -1)
        //            {
        //                decInText[i] = 'X';
        //            }
        //        }
        //        decInText = decInText.Replace("X", "");
        //        if (decInText.ToString().Trim().Equals("0.00"))
        //        {
        //            return 0M;
        //        }
        //        if (Decimals > 0)
        //        {
        //            string[] strArray = decInText.ToString().Split(new char[] { ".".ToCharArray()[0] });
        //            if (strArray.GetLength(0) < 2)
        //            {
        //                throw new ERPException(string.Concat(new object[] { decInText, " -> not expected format. Length = ", Length, " Decimals = ", Decimals.ToString() }));
        //            }
        //            toBeStripped = strArray[0];
        //            toBeStripped = StripGarbageOnLeftSideOfNumericString(toBeStripped);
        //            str3 = strArray[1].Substring(0, strArray[1].Length - 1);
        //            if (str3.Length > Decimals)
        //            {
        //                str3 = str3.Substring(0, Decimals);
        //            }
        //        }
        //        else
        //        {
        //            if (decInText.ToString().IndexOf(".") > -1)
        //            {
        //                toBeStripped = decInText.ToString().Split(new char[] { ".".ToCharArray()[0] })[0];
        //            }
        //            else
        //            {
        //                toBeStripped = decInText.ToString().Substring(0, decInText.ToString().Length - 1);
        //            }
        //            toBeStripped = StripGarbageOnLeftSideOfNumericString(toBeStripped);
        //            str3 = "0";
        //            str3 = "0";
        //        }
        //        string str4 = " ";
        //        if (decInText.ToString().IndexOf("-") > -1)
        //        {
        //            str4 = "-";
        //        }
        //        if (toBeStripped.Trim().Equals(""))
        //        {
        //            toBeStripped = "0";
        //        }
        //        if (str4 == "-")
        //        {
        //            num4 = (Convert.ToDecimal(toBeStripped) + (Math.Abs(Convert.ToDecimal(str3)) / Convert.ToDecimal(Math.Pow(10.0, (double)Decimals)))) * -1M;
        //        }
        //        else
        //        {
        //            num4 = Convert.ToDecimal(toBeStripped) + (Convert.ToDecimal(str3) / Convert.ToDecimal(Math.Pow(10.0, (double)Decimals)));
        //        }
        //        num5 = num4;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new ERPException(string.Concat(new object[] { "Error during conversion. DecInText='", decInText, "',DecInTextOriginal='", str, "',LeftPart='", toBeStripped, "',RightPart='", str3, "',Length=", Length.ToString(), ",Decimals=", Decimals.ToString(), " -> ", exception.Message }), exception);
        //    }
        //    return num5;
        //}
        //public static byte[] RawBytesToBytes(byte[] RawBytes, int Offset, int Length)
        //{
        //    byte[] buffer = new byte[Length];
        //    for (int i = Offset; i < (Offset + Length); i++)
        //    {
        //        buffer[i - Offset] = RawBytes[i];
        //    }
        //    return buffer;
        //}
        //public static double RawBytesToDouble(byte[] RawBytes, int Offset, int Length)
        //{
        //    if (IntegerType == 1)
        //    {
        //        return BitConverter.ToDouble(RawBytes, Offset);
        //    }
        //    byte[] buffer = new byte[Length];
        //    for (int i = 0; i < Length; i++)
        //    {
        //        buffer[(Length - i) - 1] = RawBytes[Offset + i];
        //    }
        //    return BitConverter.ToDouble(buffer, 0);
        //}
        //public static void RawBytesToExistingPointer(byte[] src, int Length, IntPtr dest)
        //{
        //    Marshal.Copy(src, 0, dest, Length);
        //}
        //internal static short RawBytesToInt16BigEndian(byte[] rawBytes)
        //{
        //    return (short)RawBytesToInt64BigEndian(rawBytes, 2);
        //}
        //public static int RawBytesToInt32(byte[] RawBytes, int Offset, int Length)
        //{
        //    int num = 0;
        //    if (IntegerType == 1)
        //    {
        //        if (Length == 2)
        //        {
        //            num = BitConverter.ToInt16(RawBytes, Offset);
        //        }
        //        else if (Length == 1)
        //        {
        //            num = RawBytes[Offset];
        //        }
        //        else
        //        {
        //            num = BitConverter.ToInt32(RawBytes, Offset);
        //        }
        //    }
        //    else
        //    {
        //        if (IntegerType != 2)
        //        {
        //            throw new ERPException("Unknown IntegerType " + IntegerType.ToString());
        //        }
        //        if (Length == 4)
        //        {
        //            for (int i = 0; i < Length; i++)
        //            {
        //                switch (i)
        //                {
        //                    case 3:
        //                        num += RawBytes[Offset + i];
        //                        break;
        //                    case 2:
        //                        num += RawBytes[Offset + i] * 0x100;
        //                        break;
        //                    case 1:
        //                        num += RawBytes[Offset + i] * 0x10000;
        //                        break;
        //                    case 0:
        //                        num += RawBytes[Offset + i] * 0x1000000;
        //                        break;
        //                }
        //            }
        //        }
        //        else if (Length == 2)
        //        {
        //            for (int j = 0; j < Length; j++)
        //            {
        //                switch (j)
        //                {
        //                    case 1:
        //                        num += RawBytes[Offset + j];
        //                        break;
        //                    case 0:
        //                        num += RawBytes[Offset + j] * 0x100;
        //                        break;
        //                }
        //            }
        //        }
        //        else if (Length == 1)
        //        {
        //            num = RawBytes[Offset];
        //        }
        //    }
        //    if ((num <= 0x5f5e100) && (num >= -100000000))
        //    {
        //        return num;
        //    }
        //    if (Length == 2)
        //    {
        //        return BitConverter.ToInt16(RawBytes, Offset);
        //    }
        //    if (Length == 1)
        //    {
        //        return RawBytes[Offset];
        //    }
        //    return BitConverter.ToInt32(RawBytes, Offset);
        //}
        //internal static int RawBytesToInt32BigEndian(byte[] rawBytes)
        //{
        //    return (int)RawBytesToInt64BigEndian(rawBytes, 4);
        //}
        //internal static long RawBytesToInt64BigEndian(byte[] rawBytes)
        //{
        //    return RawBytesToInt64BigEndian(rawBytes, 8);
        //}
        //internal static long RawBytesToInt64BigEndian(byte[] rawBytes, int length)
        //{
        //    if ((length > 8) || (length < 0))
        //    {
        //        throw new FormatException("Invalid length: " + length.ToString());
        //    }
        //    if (length > rawBytes.Length)
        //    {
        //        length = rawBytes.Length;
        //    }
        //    int num = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        num += rawBytes[(rawBytes.Length - i) - 1] << (i * 8);
        //    }
        //    return (long)num;
        //}
        //public static IntPtr RawBytesToPointer(byte[] src, int Length)
        //{
        //    IntPtr newPointer = GetNewPointer(Length + 2);
        //    Marshal.Copy(src, 0, newPointer, Length);
        //    return newPointer;
        //}
        //public static string RawBytesToString(byte[] RawBytes, int Offset, int Length, RfcDataType Type)
        //{
        //    string str;
        //    try
        //    {
        //        str = enc.GetString(RawBytes, Offset, Length).Replace('\0', ' ');
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return str;
        //}
        //public static string RawCharArrayToString(char[] RawBytes)
        //{
        //    string str = "";
        //    for (int i = 0; i < RawBytes.Length; i++)
        //    {
        //        if (RawBytes[i] == '\0')
        //        {
        //            return str;
        //        }
        //        str = str + RawBytes[i];
        //    }
        //    return str;
        //}

        internal static int SAPCodepageToMSCodepage(string SAPCodePage)
        {
            switch (SAPCodePage)
            {
                case "1100":
                    return 0x4e4;
                case "1160":
                    return 0x4e4;
                case "4102":
                    return 0x4b1;
                case "4103":
                    return 0x4b0;
                case "1500":
                    return 0x6fb3;
                case "1401":
                    return 0x6fb0;
                case "1700":
                    return 0x4e5;
                case "4110":
                    return 0xfde9;
                case "8604":
                    return 0x36a;
                case "8000":
                    return 0x3a4;
                case "8004":
                    return 0x3a4;
                case "8400":
                    return 0x3a8;
                case "8404":
                    return 0x3a8;
                case "8500":
                    return 0x3b5;
                case "8504":
                    return 0x3b5;
                case "8300":
                    return 950;
                case "8304":
                    return 950;
                case "1404":
                    return 0x4e2;
                case "1405":
                    return 0x4e2;
                case "1504":
                    return 0x4e3;
                case "1704":
                    return 0x4e5;
                case "1614":
                    return 0x4e6;
                case "1804":
                    return 0x4e7;
                case "8704":
                    return 0x4e8;
                case "1904":
                    return 0x4e9;
                case "0120":
                    return 0x4e4;
                case "0410":
                    return 0x4e2;
                case "0500":
                    return 0x4e3;
                case "0610":
                    return 0x4e6;
                case "0700":
                    return 0x4e5;
                case "0800":
                    return 0x4e7;
                case "1800":
                    return 0x4e7;
                case "1810":
                    return 0x4e7;
                case "8600":
                    return 0x36a;
            }
            return 0x4e4;
        }
        //internal static string ScalarToXmlPersist(object value, RfcDataType rfcType)
        //{
        //    switch (rfcType)
        //    {
        //        case RfcDataType.CHAR:
        //        case RfcDataType.NUM:
        //        case RfcDataType.STRING:
        //            return value.ToString();
        //        case RfcDataType.DATE:
        //            {
        //                string str = value.ToString();
        //                if (str.Length == 8)
        //                {
        //                    return str.Insert(6, "-").Insert(4, "-");
        //                }
        //                return str;
        //            }
        //        case RfcDataType.BCD:
        //        case RfcDataType.INT4:
        //        case RfcDataType.INT2:
        //        case RfcDataType.INT1:
        //            return Convert.ToString(value, numberFormatInfo);
        //        case RfcDataType.TIME:
        //            {
        //                string str2 = value.ToString();
        //                switch (str2.Length)
        //                {
        //                    case 4:
        //                        return (str2.Insert(2, ":") + ":00");
        //                    case 5:
        //                        return str2;
        //                    case 6:
        //                        return str2.Insert(4, ":").Insert(2, ":");
        //                }
        //                return str2;
        //            }
        //        case RfcDataType.BYTE:
        //        case RfcDataType.XSTRING:
        //            return Convert.ToBase64String((byte[])value);
        //        case RfcDataType.FLOAT:
        //            {
        //                double num = (double)value;
        //                return num.ToString("R", numberFormatInfo);
        //            }
        //    }
        //    throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, rfcType.ToString()));
        //}
        //internal static string ScalarToXmlValue(object value, RfcDataType rfcType)
        //{
        //    switch (rfcType)
        //    {
        //        case RfcDataType.CHAR:
        //        case RfcDataType.NUM:
        //        case RfcDataType.STRING:
        //            return value.ToString();
        //        case RfcDataType.DATE:
        //            {
        //                string str = value.ToString();
        //                if (str.Length == 8)
        //                {
        //                    return str.Insert(6, "-").Insert(4, "-");
        //                }
        //                return str;
        //            }
        //        case RfcDataType.BCD:
        //        case RfcDataType.INT4:
        //        case RfcDataType.INT2:
        //        case RfcDataType.INT1:
        //            return Convert.ToString(value, numberFormatInfo);
        //        case RfcDataType.TIME:
        //            {
        //                string str2 = value.ToString();
        //                switch (str2.Length)
        //                {
        //                    case 4:
        //                        return (str2.Insert(2, ":") + ":00");
        //                    case 5:
        //                        return str2;
        //                    case 6:
        //                        return str2.Insert(4, ":").Insert(2, ":");
        //                }
        //                return str2;
        //            }
        //        case RfcDataType.BYTE:
        //        case RfcDataType.XSTRING:
        //            return Convert.ToBase64String((byte[])value);
        //        case RfcDataType.FLOAT:
        //            {
        //                double num = (double)value;
        //                return num.ToString("R", numberFormatInfo);
        //            }
        //    }
        //    throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, rfcType.ToString()));
        //}
        internal static object SOAPToNET(string SOAPValue, RfcDataType Type, bool SOAPValueIsAlreadyDecoded)
        {
            if (!SOAPValueIsAlreadyDecoded)
            {
                SOAPValue = XMLStringToString(SOAPValue);
            }
            if (Type == RfcDataType.CHAR)
            {
                return SOAPValue;
            }
            if (Type == RfcDataType.DATE)
            {
                SOAPValue = SOAPValue.Trim();
                if (SOAPValue.Length == 10)
                {
                    return (SOAPValue.Substring(0, 4) + SOAPValue.Substring(5, 2) + SOAPValue.Substring(8, 2));
                }
                return SOAPValue;
            }
            if (Type == RfcDataType.BCD)
            {
                NumberFormatInfo provider = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                };
                return Convert.ToDecimal(SOAPValue, provider);
            }
            if (Type == RfcDataType.FLOAT)
            {
                NumberFormatInfo info2 = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                };
                return Convert.ToDouble(SOAPValue, info2);
            }
            if (((Type == RfcDataType.INT4) || (Type == RfcDataType.INT1)) || (Type == RfcDataType.INT2))
            {
                return Convert.ToInt32(SOAPValue);
            }
            if (Type == RfcDataType.NUM)
            {
                return SOAPValue;
            }
            if (Type == RfcDataType.TIME)
            {
                SOAPValue = SOAPValue.Trim();
                if (SOAPValue.Length == 8)
                {
                    return (SOAPValue.Substring(0, 2) + SOAPValue.Substring(3, 2) + SOAPValue.Substring(6, 2));
                }
                return SOAPValue;
            }
            if (Type == RfcDataType.STRING)
            {
                return SOAPValue;
            }
            if ((Type == RfcDataType.XSTRING) || (Type == RfcDataType.BYTE))
            {
                try
                {
                    return Convert.FromBase64String(SOAPValue);
                }
                catch
                {
                    return new byte[0];
                }
            }
            if (Type != RfcDataType.TABLE)
            {
                //throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, Type.ToString()));
                throw new Exception(string.Format("Type_{0}_not supported in this context", Type.ToString()));
            }
            return "";
        }
        //internal static IntPtr StringBytesToPtr(byte[] stringBytes)
        //{
        //    IntPtr destination = RFCAPI.RfcAllocString(stringBytes.Length);
        //    Marshal.Copy(stringBytes, 0, destination, stringBytes.Length);
        //    IntPtr newPointer = GetNewPointer(IntPtr.Size);
        //    Marshal.WriteIntPtr(newPointer, destination);
        //    return newPointer;
        //}
        public static byte[] StringToRawBytes(string src, int Length, RfcDataType type)
        {
            string s = new string(" ".ToCharArray()[0], Length);
            s = src;
            if (((type == RfcDataType.CHAR) || (type == RfcDataType.BYTE)) || (type == RfcDataType.STRING))
            {
                s = s.PadRight(Length);
            }
            else
            {
                if (((type != RfcDataType.DATE) && (type != RfcDataType.TIME)) && (type != RfcDataType.NUM))
                {
                    throw new Exception(string.Format("Type:{0}isnotallowedinConvertsStringToRawBytes", type.ToString()));
                }
                if (IsUnicode)
                {
                    s = s.PadLeft(Length / 2, "0".ToCharArray()[0]);
                }
                else
                {
                    s = s.PadLeft(Length, "0".ToCharArray()[0]);
                }
            }
            if (type == RfcDataType.STRING)
            {
                return enc.GetBytes(s + "\0");
            }
            return enc.GetBytes(s);
        }
        public static string StringToXMLString(string In)
        {
            StringBuilder builder = new StringBuilder(In.Length);
            foreach (char ch in In)
            {
                int num = ch;
                switch (ch)
                {
                    case '&':
                        builder.Append("&amp;");
                        break;
                    case '<':
                        builder.Append("&lt;");
                        break;
                    case '>':
                        builder.Append("&gt;");
                        break;
                    case '"':
                        builder.Append("&quot;");
                        break;
                    default:
                        if (num > 0x7f)
                        {
                            builder.Append("&#");
                            builder.Append(num);
                            builder.Append(";");
                        }
                        else
                        {
                            builder.Append(ch);
                        }
                        break;
                }
            }
            return builder.ToString();
        }

        private static string StripGarbageOnLeftSideOfNumericString(string ToBeStripped)
        {
            ToBeStripped = ToBeStripped.Trim();
            ToBeStripped = ToBeStripped.Replace("-", "");
            string str = "";
            for (int i = ToBeStripped.Length - 1; i >= 0; i--)
            {
                if ("0123456789".IndexOf(ToBeStripped.Substring(i, 1)) > -1)
                {
                    str = ToBeStripped.Substring(i, 1) + str;
                }
                else
                {
                    return str;
                }
            }
            return str;
        }
        internal static string Unescape(string input, Dictionary<char, char> replacements, char escapeCharacter)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (replacements == null)
            {
                throw new ArgumentNullException("replacements");
            }
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == escapeCharacter)
                {
                    i++;
                    if (i == input.Length)
                    {
                        throw new ArgumentException("input ends with escape character", "input");
                    }
                    if (input[i] != escapeCharacter)
                    {
                        char ch;
                        if (!replacements.TryGetValue(input[i], out ch))
                        {
                            throw new ArgumentException("no replacement found for '" + input[i] + "'", "input");
                        }
                        builder.Append(ch);
                    }
                    else
                    {
                        builder.Append(escapeCharacter);
                    }
                }
                else
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }
        internal static string XmlNameToOriginalName(string xmlName)
        {
            string str = xmlName;
            if (xmlName.Contains("-"))
            {
                if (str.StartsWith("_US-"))
                {
                    str = str.Substring(4);
                }
                else if (str.StartsWith("_NU-"))
                {
                    str = str.Substring(4);
                }
                return str.Replace("_UFZU-", "_FZ_").Replace("_USTU-", "_ST_").Replace("_Ux002FU-", "_x002F_").Replace("_FZ-", "?").Replace("_-", "/");
            }
            if (str.StartsWith("___"))
            {
                str = str.Substring(3);
            }
            return str.Replace("_FZ_", "?").Replace("_ST_", "/").Replace("_x002F_", "/");
        }
        internal static object XmlPersistToScalar(string value, RfcDataType rfcType)
        {
            switch (rfcType)
            {
                case RfcDataType.CHAR:
                case RfcDataType.NUM:
                    return value;
                case RfcDataType.DATE:
                    if (value.Length == 10)
                    {
                        return value.Remove(4, 1).Remove(6, 1);
                    }
                    return value;
                case RfcDataType.BCD:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToDecimal(value, numberFormatInfo);
                    }
                    return 0M;
                case RfcDataType.TIME:
                    if (value.Length != 8)
                    {
                        return value;
                    }
                    return value.Remove(2, 1).Remove(4, 1);
                case RfcDataType.BYTE:
                case RfcDataType.XSTRING:
                    if (string.IsNullOrEmpty(value))
                    {
                        return new byte[0];
                    }
                    return Convert.FromBase64String(value);
                case RfcDataType.FLOAT:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToDouble(value, numberFormatInfo);
                    }
                    return 0.0;
                case RfcDataType.INT4:
                case RfcDataType.INT2:
                case RfcDataType.INT1:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToInt32(value, numberFormatInfo);
                    }
                    return 0;
                case RfcDataType.STRING:
                    return value;
            }
            //throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, rfcType.ToString()));
            throw new Exception(string.Format("Cannotconvert_{0}_to an internal RFCtype", rfcType.ToString()));
        }
        public static string XMLStringToString(string In)
        {
            try
            {
                XmlNode node = new XmlDocument().CreateElement("foo");
                node.InnerXml = In;
                return node.InnerText;
            }
            catch
            {
                return In;
            }
        }
        public static object ObjectToRfcValue(Object input, RfcDataType type)
        {
            Object o = input;
            switch (type)
            {
                case RfcDataType.BCD:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.BYTE:
                    break;
                case RfcDataType.CDAY:
                    break;
                case RfcDataType.CHAR:
                    break;
                case RfcDataType.CLASS:
                    break;
                case RfcDataType.DATE:
                    input = input.ToString().Replace("-", "");
                    input = input.ToString().Replace("/", "");
                    if (input.ToString() != "" && input.ToString().Length != 8)
                    {
                        throw new SAPException(input.ToString() + " ���ڸ�ʽ����ȷ");
                    }
                    break;
                case RfcDataType.DECF16:
                    break;
                case RfcDataType.DECF34:
                    break;
                case RfcDataType.DTDAY:
                    break;
                case RfcDataType.DTMONTH:
                    break;
                case RfcDataType.DTWEEK:
                    break;
                case RfcDataType.FLOAT:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.INT1:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.INT2:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.INT4:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.INT8:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.NUM:
                    if (input.ToString().Trim() == "")
                    {
                        o = 0;
                    }
                    break;
                case RfcDataType.STRING:
                    break;
                case RfcDataType.STRUCTURE:
                    break;
                case RfcDataType.TABLE:
                    break;
                case RfcDataType.TIME:
                    input = input.ToString().Replace(":", "");
                    if (input.ToString() != "" && input.ToString().Length != 6)
                    {
                        throw new SAPException("ʱ����ʽ����ȷ��");
                    }
                    break;
                case RfcDataType.TMINUTE:
                    break;
                case RfcDataType.TSECOND:
                    break;
                case RfcDataType.UNKNOWN:
                    break;
                case RfcDataType.UTCLONG:
                    break;
                case RfcDataType.UTCMINUTE:
                    break;
                case RfcDataType.UTCSECOND:
                    break;
                case RfcDataType.XSTRING:
                    break;
                default:
                    break;
            }
            return o;
        }
        public static object RfcValueToObject(String rfcValue, String rfcValueType)
        {
            if (rfcValue == null)
            {
                return null;
            }
            String value = rfcValue;
            //��Ҫ����������֧���հף���Ϊ�еĵ�ֵ��ȷΪ�ա�
            // value = value.TrimStart(' ').TrimEnd(' ');
            // value.Trim();
            Object o = value;
            int iout = 0;
            switch (rfcValueType)
            {
                case "N":
                    if (int.TryParse(value, out iout))
                    {
                        o = iout;
                        if (o.ToString() == "0")
                        {
                            o = "";
                        }
                    }
                    break;
                case "I":
                    if (int.TryParse(value, out iout))
                    {
                        o = iout;
                        if (o.ToString() == "0")
                        {
                            o = "";
                        }
                    }
                    break;
                case "b":
                    if (int.TryParse(value, out iout))
                    {
                        o = iout;
                        if (o.ToString() == "0")
                        {
                            o = "";
                        }
                    }
                    break;
                case "s":
                    if (int.TryParse(value, out iout))
                    {
                        o = iout;
                        if (o.ToString() == "0")
                        {
                            o = "";
                        }
                    }
                    break;
                case "F":
                    o = float.Parse(value);
                    break;
                case "D":
                    if (value == "00000000")
                    {
                        o = "";
                    }
                    else
                        o = value.Substring(0, 4) + "-" + value.Substring(4, 2) + "-" + value.Substring(6, 2);
                    Console.WriteLine(o.ToString());
                    //o = new DateTime(int.Parse(value.Substring(0, 4)), int.Parse(value.Substring(4, 2)), int.Parse(value.Substring(6, 2)));
                    //o = String.Format("{0:yyyy-MM-dd}", o);
                    break;
                case "T":
                    o = value.Substring(0, 2) + ":" + value.Substring(2, 2) + ":" + value.Substring(4, 2);
                    //o = String.Format("{0:HH:mm:ss}", value);
                    break;
                default:
                    o = value;
                    break;
            }
            return o;
        }
        public static object RfcToDoNetValue(Object output, RfcDataType type)
        {
            try
            {


                Object o = output;
                if (o == null)
                {
                    o = "";
                    output = "";
                }
                int iout = 0;
                switch (type)
                {
                    case RfcDataType.BCD:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = double.Parse(output.ToString());
                        break;
                    case RfcDataType.BYTE:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        else
                        {
                            o = o.ToString();
                        }
                        //o = byte.Parse(o.ToString());

                        break;
                    case RfcDataType.CDAY:
                        break;
                    case RfcDataType.CHAR:
                        break;
                    case RfcDataType.CLASS:
                        break;
                    case RfcDataType.DATE:
                        if (o.ToString() == "00000000")
                        {
                            o = "";
                        }
                        else
                        {
                            //  o = o.ToString().Replace("-","");
                            //  o = o.ToString().Substring(0, 4) + "-" + o.ToString().Substring(4, 2) + "-" + o.ToString().Substring(6, 2);
                        }
                        break;
                    case RfcDataType.DECF16:
                        break;
                    case RfcDataType.DECF34:
                        break;
                    case RfcDataType.DTDAY:
                        break;
                    case RfcDataType.DTMONTH:
                        break;
                    case RfcDataType.DTWEEK:
                        break;
                    case RfcDataType.FLOAT:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = float.Parse(output.ToString());
                        break;
                    case RfcDataType.INT1:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = int.Parse(output.ToString());
                        break;
                    case RfcDataType.INT2:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = int.Parse(output.ToString());
                        break;
                    case RfcDataType.INT4:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = int.Parse(output.ToString());
                        break;
                    case RfcDataType.INT8:
                        if (o.ToString() == "")
                        {
                            o = 0;
                            break;
                        }
                        o = int.Parse(output.ToString());
                        break;
                    case RfcDataType.NUM:

                        if (output == null)
                        {
                            o = 0;
                        }
                        if (o.ToString().Trim() == "0")
                        {
                            o = 0;
                        }
                        else
                        {
                            int.TryParse(output.ToString(), out iout);
                            o = iout;

                        }

                        break;
                    case RfcDataType.STRING:
                        break;
                    case RfcDataType.STRUCTURE:
                        break;
                    case RfcDataType.TABLE:
                        break;
                    case RfcDataType.TIME:
                        //o = o.ToString().Substring(0, 2) + ":" + o.ToString().Substring(2, 2) + ":" + o.ToString().Substring(4, 2);
                        break;
                    case RfcDataType.TMINUTE:
                        break;
                    case RfcDataType.TSECOND:
                        break;
                    case RfcDataType.UNKNOWN:
                        break;
                    case RfcDataType.UTCLONG:
                        break;
                    case RfcDataType.UTCMINUTE:
                        break;
                    case RfcDataType.UTCSECOND:
                        break;
                    case RfcDataType.XSTRING:
                        break;
                    default:
                        break;
                }
                return o;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal static object XmlToScalarValue(string value, RfcDataType rfcType)
        {
            switch (rfcType)
            {
                case RfcDataType.CHAR:
                case RfcDataType.NUM:
                    return value;
                case RfcDataType.DATE:
                    if (value.Length == 10)
                    {
                        return value.Remove(4, 1).Remove(6, 1);
                    }
                    return value;
                case RfcDataType.BCD:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToDecimal(value, numberFormatInfo);
                    }
                    return 0M;
                case RfcDataType.TIME:
                    if (value.Length != 8)
                    {
                        return value;
                    }
                    return value.Remove(2, 1).Remove(4, 1);
                case RfcDataType.BYTE:
                case RfcDataType.XSTRING:
                    if (string.IsNullOrEmpty(value))
                    {
                        return new byte[0];
                    }
                    return Convert.FromBase64String(value);
                case RfcDataType.FLOAT:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToDouble(value, numberFormatInfo);
                    }
                    return 0.0;
                case RfcDataType.INT4:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToInt32(value, numberFormatInfo);
                    }
                    return 0;
                case RfcDataType.INT2:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToInt16(value, numberFormatInfo);
                    }
                    return 0;
                case RfcDataType.INT1:
                    if (!string.IsNullOrEmpty(value))
                    {
                        return Convert.ToByte(value, numberFormatInfo);
                    }
                    return 0;
                case RfcDataType.STRING:
                    return value;
            }
            //throw new ERPException(string.Format(Messages.Type_0_notsupportedinthiscontext, rfcType.ToString()));
            throw new Exception(string.Format("Cannotconvert_{0}_to an internal RFCtype", rfcType.ToString()));
        }
        public static string LanguageSapToIso(string language)
        {
            string ISO = "EN";
            switch (language)
            {
                case "e":
                    ISO = "EN";
                    break;
                case "1":
                    ISO = "ZH";
                    break;
                default:
                    ISO = "EN";
                    break;
            }
            return ISO;
        }
        public static string languageIsotoSap(string language)
        {
            string sap = "e";
            switch (language)
            {
                case "EN":
                    sap = "e";
                    break;
                case "ZH":
                    sap = "1";
                    break;
                default:
                    sap = "e";
                    break;
            }
            return sap;
        }
        public static int IntegerType
        {
            get
            {
                return integerType;
            }
            set
            {
                if ((value != 1) && (value != 2))
                {
                    throw new FormatException("Invalid IntegerType: " + value.ToString());
                }
                integerType = value;
            }
        }
    }
}
