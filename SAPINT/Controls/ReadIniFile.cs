using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
namespace SAPINT.Controls
{
    public class ReadIniSection
{
    /// <summary>
    /// 读取INI文件专用类
    /// </summary>
    private Hashtable iniFile = new Hashtable();
    public int Count { get { return iniFile.Count; } }
    public string this[string IndexKey] { 
        get {
            if (iniFile.ContainsKey(IndexKey))
            {
                return iniFile[IndexKey].ToString();
            }
            else
            {
                return string.Empty;
            }
        } 
    }
    /// <summary>
    /// 读取指定INI文件中的配置信息
    /// </summary>
    /// <param name="file">配置文件的完整路径名</param>
    /// <param name="section">配置文件中的节名</param>
    public ReadIniSection(string file, string section)
    {
        string Section = "[" + section + "]";
        LoadIniFile(file, Section);
        //如果SpecialIniFilePath不为空，则从SpecialIniFilePath指定的文件中读取配置信息
        if (iniFile.Count>0 && iniFile.Contains("SpecialIniFilePath"))
        {
            string path = this["SpecialIniFilePath"].Trim();
            if (path != "") LoadIniFile(path, Section);
        }
    }
    private void LoadIniFile(string filePath, string Section)
    {
        try
        {
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
            string readLine = null;
            bool readEnd = false;
            string[] keyWord;
            while ((readLine = sr.ReadLine()) != null)
            {
                if (readLine == Section)   //是指定的节，则开始读取配置信息
                {
                    while ((readLine = sr.ReadLine()) != null)
                    {
                        if (readLine != "")   //跳过空行
                        {
                            if (readLine.Substring(0, 1) == "[")   //是另一新节，则结束本次的读取
                            {
                                readEnd = true;
                                break;
                            }
                            keyWord = readLine.Split('=');
                            iniFile[keyWord[0].Trim()] = keyWord[1];
                        }
                    }
                }
                if (readEnd == true) break;
            }
            sr.Close();
        }
        catch
        {
            iniFile.Clear();
        }
    }
}
}
