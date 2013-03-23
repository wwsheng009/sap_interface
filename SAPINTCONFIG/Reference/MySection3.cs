using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool
{
	public class MySection3 : ConfigurationSection
	{
		[ConfigurationProperty("Command1", IsRequired = true)]
		public MyTextElement Command1
		{
			get { return (MyTextElement)this["Command1"]; }
		}

		[ConfigurationProperty("Command2", IsRequired = true)]
		public MyTextElement Command2
		{
			get { return (MyTextElement)this["Command2"]; }
		}
	}

	public class MyTextElement : ConfigurationElement
	{
		protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey)
		{
			CommandText = reader.ReadElementContentAs(typeof(string), null) as string;
		}
		protected override bool SerializeElement(System.Xml.XmlWriter writer, bool serializeCollectionKey)
		{
			if( writer != null )
				writer.WriteCData(CommandText);
			return true;
		}

		[ConfigurationProperty("data", IsRequired = false)]
		public string CommandText
		{
			get { return this["data"].ToString(); }
			set { this["data"] = value; }
		}
	}


}
