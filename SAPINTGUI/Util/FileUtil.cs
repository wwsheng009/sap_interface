using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SAPINT.Gui.Util
{
    public class FileUtil
    {

        public static String FormatFileSize(Int64 fileSize)
        {
            if (fileSize < 0)
            {
                throw new ArgumentOutOfRangeException("fileSize");
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                return string.Format("{0:########0.00} GB", ((Double)fileSize) / (1024 * 1024 * 1024));
            }
            else if (fileSize >= 1024 * 1024)
            {
                return string.Format("{0:####0.00} MB", ((Double)fileSize) / (1024 * 1024));
            }
            else if (fileSize >= 1024)
            {
                return string.Format("{0:####0.00} KB", ((Double)fileSize) / 1024);
            }
            else
            {
                return string.Format("{0} bytes", fileSize);
            }
        }
        public static int GetFilesCount(string pmFilePath, string filter = null)
        {
            if (!Directory.Exists(pmFilePath))
            {
                throw new Exception("文件夹不存在");
            }
            int totalFile = 0;
            if (String.IsNullOrEmpty(filter))
            {
                totalFile = Directory.GetFiles(pmFilePath).Length;
            }
            else
            {
                totalFile = Directory.GetFiles(pmFilePath, filter).Length;
            }

            string[] fileList = Directory.GetDirectories(pmFilePath);
            foreach (string fileChild in fileList)
            {
                totalFile += GetFilesCount(fileChild);
            }
            return totalFile;
        }

        /// <summary>
        /// Checks the file is textfile or not.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static bool CheckIsTextFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            bool isTextFile = true;
            try
            {
                int i = 0;
                int length = (int)fs.Length;
                byte data;
                while (i < length && isTextFile)
                {
                    data = (byte)fs.ReadByte();
                    isTextFile = (data != 0);
                    i++;
                }
                return isTextFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public static bool IsTextFile(string fileName)
        {
            //要比对的字节,越大,正确度越高,但32个只够了.
            char[] buf = new char[32];
            //实际读到的字符数
            int readint = 0;

            try
            {
                StreamReader reader = new StreamReader(fileName, Encoding.Default);
                //最多读 buf.Length 个字符
                readint = reader.ReadBlock(buf, 0, buf.Length);
                reader.Close();
                //比对是否存在 '\0' 这个字符
                for (int i = 0; i < readint; i++)
                {
                    if (buf[i] == '\0')
                    {
                        //存在：这个就不是文本文件
                        return false;
                    }
                }
                //没找到，那么很大概率是文本文件
                return true;

            }
            catch (IOException)
            {
                throw;
            }
           
        }
    }
}
