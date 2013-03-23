using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

// 此处代码来源于博客【在.net中读写config文件的各种方法】的示例代码
// http://www.cnblogs.com/fish-li/archive/2011/12/18/2292037.html


namespace ConfigFileTool
{
	public class MyCDATA : IXmlSerializable
	{
		private string _value;

		public MyCDATA() { }

		public MyCDATA(string value)
		{
			this._value = value;
		}

		public string Value
		{
			get { return _value; }
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			this._value = reader.ReadElementContentAsString();
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			writer.WriteCData(this._value);
		}

		public override string ToString()
		{
			return this._value;
		}

		public static implicit operator MyCDATA(string text)
		{
			return new MyCDATA(text);
		}
	}
}
