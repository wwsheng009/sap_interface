using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SAPINT.Gui.Http
{
    public partial class FormMd5Caculator : DockWindow
    {
        public FormMd5Caculator()
        {
            InitializeComponent();
        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {
          //  var md5 = MD5Value(this.txtSource.Text, true);
            var md5 = GetMD5(this.txtSource.Text);
            this.txtMd5Result.Text = md5;
        }

        // <summary>
        /// 计算字符串或者文件MD5值
        /// </summary>
        /// <param name="str">需要计算的字符串或文件路径</param>
        /// <param name="isStr">true为字符串，false为文件</param>
        /// <returns>MD5值</returns>
        public string MD5Value(String str, Boolean isStr)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5ch;
            if (isStr)
            {
                byte[] ch = System.Text.Encoding.Default.GetBytes(str);
                md5ch = md5.ComputeHash(ch);
            }
            else
            {
                if (!File.Exists(str))
                    return string.Empty;
                FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read);
                md5ch = md5.ComputeHash(fs);
                fs.Close();
            }
            md5.Clear();
            string strMd5 = "";
            for (int i = 0; i < md5ch.Length - 1; i++)
            {
                strMd5 += md5ch[i].ToString("x").PadLeft(2, '0');
            }
            return strMd5;
        }

        string GetMD5(string str)
        {
            var restr = "";
            byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(data);
            for (int i = 0; i < bytes.Length; i++)
            {
                restr += bytes[i].ToString("x2");
            }
            return restr;
        }
        string GetMD5ByFile(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash_byte = md5.ComputeHash(file);
            string str = System.BitConverter.ToString(hash_byte);
            str = str.Replace("-", "");
            return str;
        }

    }
}
