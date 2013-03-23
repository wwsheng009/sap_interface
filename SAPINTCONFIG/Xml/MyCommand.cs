using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

// 此处代码来源于博客【在.net中读写config文件的各种方法】的示例代码
// http://www.cnblogs.com/fish-li/archive/2011/12/18/2292037.html


namespace ConfigFileTool
{
    public class MyCommand
    {
		[XmlAttribute("Name")]
		public string CommandName;

		[XmlAttribute]
		public string Database;

		[XmlArrayItem("Parameter")]
		public List<MyCommandParameter> Parameters = new List<MyCommandParameter>();

		[XmlElement]
		public MyCDATA CommandText;
		//public string CommandText;
    }
	
	public class MyCommandParameter
	{
		[XmlAttribute("Name")]
		public string ParamName;

		[XmlAttribute("Type")]
		public string ParamType;
	}
}
