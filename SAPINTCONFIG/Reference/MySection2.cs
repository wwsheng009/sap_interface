using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigFileTool
{
    /// <summary>
    /// 自定义一个配置节
    /// </summary>
	public class MySection2 : ConfigurationSection
	{
		[ConfigurationProperty("users", IsRequired = true)]
		public MySectionElement Users
		{
			get { return (MySectionElement)this["users"]; }
		}
	}
	
    /// <summary>
    /// 自定义元素
    /// </summary>
	public class MySectionElement : ConfigurationElement
	{
		[ConfigurationProperty("username", IsRequired = true)]
		public string UserName
		{
			get { return this["username"].ToString(); }
			set { this["username"] = value; }
		}

		[ConfigurationProperty("password", IsRequired = true)]
		public string Password
		{
			get { return this["password"].ToString(); }
			set { this["password"] = value; }
		}
	}

}
