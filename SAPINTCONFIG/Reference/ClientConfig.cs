using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;
using System.Xml;

//http://www.cnblogs.com/LifelongLearning/archive/2011/09/16/2179265.html
//
namespace ConfigFileTool.Config
{
    public class ClientConfig : ConfigBase<NameValueCollection>
    {
        public ClientConfig(WeiboType weiboType)
            : this(weiboType, null) { }


        public ClientConfig(WeiboType weiboType, string configFile)
            : base(string.Format("WeiboClientSectionGroup/{0}Section", weiboType), configFile)
        {
        }
        public string AccessToken
        {

            get { return Section["AccessToken"]; }
        }
        public string AccessTokenSecret
        {
            get { return Section["AccessTokenSecret"]; }
        }
        public ResultFormat ResultFormat
        {
            get { return (ResultFormat)Enum.Parse(typeof(ResultFormat), Section["ResultFormat"]); }
        }
    }

    public abstract class ConfigBase<T> where T : class
    {
        public ConfigBase(string sectionName, string configFile)
        {
            if (string.IsNullOrEmpty(configFile))
            {
                Section = (T)System.Configuration.ConfigurationManager.GetSection(sectionName);
            }
            else
            {
                var configMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
                var config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                var configurationSection = config.GetSection(sectionName);
                if (configurationSection != null)
                {
                    Section = LoadSection(configurationSection.SectionInformation);
                }
            }
        }

        private static TReturn LoadSection<TReturn>(SectionInformation information) where TReturn : class
        {
            string[] strs = information.Type.Split(",".ToCharArray(), 2);
            var handler = (IConfigurationSectionHandler)Assembly.Load(strs[1]).CreateInstance(strs[0]);
            var doc = new XmlDocument();
            doc.LoadXml(information.GetRawXml());
            if (handler != null)
                return (TReturn)handler.Create(null, null, doc.ChildNodes[0]);
            return null;
        }

        protected T LoadSection(SectionInformation information)
        {
            return LoadSection<T>(information);
        }

        protected T Section { get; private set; }
    }

}
