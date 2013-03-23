using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool
{
    /// <summary>
    /// 所有配置节点都要选择这个基类
    /// 它代表了一个节点
    /// <section name="GlobalSetting" type="ConfigFileTool.XmlKeyValueSection, ConfigFileTool"/>
    /// </summary>
	public class XmlKeyValueSection : ConfigurationSection	
	{
		private static readonly ConfigurationProperty s_property
			= new ConfigurationProperty(string.Empty, typeof(XmlKeyValueCollection), null, 
											ConfigurationPropertyOptions.IsDefaultCollection);
		
		[ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
		public XmlKeyValueCollection KeyValues
		{
			get
			{
				return (XmlKeyValueCollection)base[s_property];
			}
		}
	}

    /// <summary>
    /// 对应一个元素的集合。
    ///<GlobalSetting>
    ///<add key="aa" value="11111"></add>
    ///<add key="bb" value="22222"></add>
    ///<add key="cc" value="33333"></add>
    ///</GlobalSetting>
    ///
    /// </summary>
	[ConfigurationCollection(typeof(XmlKeyValueSetting))]
	public class XmlKeyValueCollection : ConfigurationElementCollection		// 自定义一个集合
	{
		// 基本上，所有的方法都只要简单地调用基类的实现就可以了。

		public XmlKeyValueCollection() : base(StringComparer.OrdinalIgnoreCase)	// 忽略大小写
		{
		}

		// 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
		new public XmlKeyValueSetting this[string name]
		{
			get
			{
				return (XmlKeyValueSetting)base.BaseGet(name);
			}
		}

		// 下面二个方法中抽象类中必须要实现的。
		protected override ConfigurationElement CreateNewElement()
		{
			return new XmlKeyValueSetting();
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((XmlKeyValueSetting)element).Key;
		}

		// 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
		public void Add(XmlKeyValueSetting setting)
		{
			this.BaseAdd(setting);
		}
		public void Clear()
		{
			base.BaseClear();
		}
		public void Remove(string name)
		{
			base.BaseRemove(name);
		}
	}

    /// <summary>
    /// 最小单元，一个元素。
    /// <add key="bb" value="22222"></add> 
    /// </summary>
	public class XmlKeyValueSetting : ConfigurationElement	// 集合中的每个元素
	{
		[ConfigurationProperty("key", IsRequired = true)]
		public string Key
		{
			get { return this["key"].ToString(); }
			set { this["key"] = value; }
		}

		[ConfigurationProperty("value", IsRequired = true)]
		public string Value
		{
			get { return this["value"].ToString(); }
			set { this["value"] = value; }
		}
	}
}
