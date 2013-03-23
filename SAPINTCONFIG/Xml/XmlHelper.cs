using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

// 此处代码来源于博客【在.net中读写config文件的各种方法】的示例代码
// http://www.cnblogs.com/fish-li/archive/2011/12/18/2292037.html


namespace ConfigFileTool
{
	public static class XmlHelper
	{
		private static byte[] XmlSerializeInternal(object o, Encoding encoding)
		{
			if( o == null )
				throw new ArgumentNullException("o");
			if( encoding == null )
				throw new ArgumentNullException("encoding");

			XmlSerializer ser = new XmlSerializer(o.GetType());
			using( MemoryStream ms = new MemoryStream() ) {
				using( XmlTextWriter writer = new XmlTextWriter(ms, encoding) ) {
					writer.Formatting = Formatting.Indented;
					ser.Serialize(writer, o);
					writer.Close();
				}
				return ms.ToArray();
			}
		}

		/// <summary>
		/// 将一个对象序列化为XML字符串
		/// </summary>
		/// <param name="o">要序列化的对象</param>
		/// <param name="encoding">编码方式</param>
		/// <returns>序列化产生的XML字符串</returns>
		public static string XmlSerialize(object o, Encoding encoding)
		{
			byte[] bytes = XmlSerializeInternal(o, encoding);
			return encoding.GetString(bytes);
		}
		
		/// <summary>
		/// 将一个对象按XML序列化的方式写入到一个文件
		/// </summary>
		/// <param name="o">要序列化的对象</param>
		/// <param name="path">保存文件路径</param>
		/// <param name="encoding">编码方式</param>
		public static void XmlSerializeToFile(object o, string path, Encoding encoding)
		{
			if( string.IsNullOrEmpty(path) )
				throw new ArgumentNullException("path");

			byte[] bytes = XmlSerializeInternal(o, encoding);
			File.WriteAllBytes(path, bytes);
		}

		/// <summary>
		/// 从XML字符串中反序列化对象
		/// </summary>
		/// <typeparam name="T">结果对象类型</typeparam>
		/// <param name="s">包含对象的XML字符串</param>
		/// <param name="encoding">编码方式</param>
		/// <returns>反序列化得到的对象</returns>
		public static T XmlDeserialize<T>(string s, Encoding encoding)
		{
			if( string.IsNullOrEmpty(s) )
				throw new ArgumentNullException("s");
			if( encoding == null )
				throw new ArgumentNullException("encoding");

			XmlSerializer mySerializer = new XmlSerializer(typeof(T));
			using( MemoryStream ms = new MemoryStream(encoding.GetBytes(s)) ) {
				using( StreamReader sr = new StreamReader(ms, encoding) ) {
					return (T)mySerializer.Deserialize(sr);
				}
			}
		}

		/// <summary>
		/// 读入一个文件，并按XML的方式反序列化对象。
		/// </summary>
		/// <typeparam name="T">结果对象类型</typeparam>
		/// <param name="path">文件路径</param>
		/// <param name="encoding">编码方式</param>
		/// <returns>反序列化得到的对象</returns>
		public static T XmlDeserializeFromFile<T>(string path, Encoding encoding)
		{
			if( string.IsNullOrEmpty(path) )
				throw new ArgumentNullException("path");
			if( encoding == null )
				throw new ArgumentNullException("encoding");

			string xml = File.ReadAllText(path, encoding);
			return XmlDeserialize<T>(xml, encoding);
		}


	}
}
