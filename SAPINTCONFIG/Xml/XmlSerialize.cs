using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Reflection;
using System.IO;

namespace ConfigFileTool.Xml
{
    public class BaseClassXmlSerializable : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer se = new XmlSerializer(typeof(Object));
            Type myType = this.GetType();

            // Get the fields of the specified class.
            FieldInfo[] myField = myType.GetFields();

            //Console.WriteLine("\nDisplaying fields that have SpecialName attributes:\n");
            for (int i = 0; i < myField.Length; i++)
            {
                string key = myField[i].Name;
                Object objlocal = myField[i].GetValue(this);
                writer.WriteElementString(key, objlocal.ToString());
            }
        }


        public void ReadXml(XmlReader reader)
        {
            XmlSerializer se = new XmlSerializer(typeof(Object));
            Type myType = this.GetType();

            // Get the fields of the specified class.
            FieldInfo[] myField = myType.GetFields();

            //Console.WriteLine("\nDisplaying fields that have SpecialName attributes:\n");
            for (int i = 0; i < myField.Length; i++)
            {
                string key = myField[i].Name;
                string value = reader.ReadElementString(key);
                Object objlocal = System.Convert.ChangeType(value, myField[i].FieldType);
                myField[i].SetValue(this, objlocal);
            }
        }
    }

    /// <summary>
    /// 为了解决非标准的list的序列化问题，编写此继承类。其中的T必须继承于基类BaseClassXmlSerializable
    /// 例如
    /// class A
    /// {
    ///     public string Name1 = "Test1";
    ///     public string Name2 = "Test2";
    /// }
    /// List<A> TestList，添加两个对象，调用Net序列化类出来的结果是
    /// <TestList>
    ///     <A>
    ///         <Name1>Test1</Name1>
    ///         <Name2>Test1</Name2>
    ///     </A>
    ///     <A>
    ///         <Name1>Test1</Name1>
    ///         <Name2>Test1</Name2>
    ///     </A>
    /// </TestList>
    /// 但是在使用ListSerializable之后序列化出来的结果为
    /// <TestList>
    ///         <Name1>Test1</Name1>
    ///         <Name2>Test1</Name2>
    ///         <Name1>Test1</Name1>
    ///         <Name2>Test1</Name2>
    /// </TestList>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListSerializable<T> : List<T>, IXmlSerializable where T : BaseClassXmlSerializable, new()
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (T value in this)
            {
                value.WriteXml(writer);
            }
        }


        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement || !reader.Read())
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                T value = new T();
                value.ReadXml(reader);
                this.Add(value);
            }
            reader.ReadEndElement();
        }
    }

    /// <summary>
    /// 支持Xml序列化的泛型Dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {

        #region IXmlSerializable 成员

        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            if (reader.IsEmptyElement || !reader.Read())
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");

                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();

                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();

                reader.ReadEndElement();
                reader.MoveToContent();

                this.Add(key, value);
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");

                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();

                writer.WriteStartElement("value");
                valueSerializer.Serialize(writer, this[key]);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        #endregion
    }

    public class XmlSerialize
    {
        public void SerializeToFile(string filename, Object obj)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                // Create a FileStream to write with.
                using (Stream writer = new FileStream(filename, FileMode.Create))
                {
                    // Serialize the object, and close the TextWriter
                    serializer.Serialize(writer, obj);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SerializeFromFile(string filename, ref Object obj)
        {
            // Create an instance of the XmlSerializer specifying type.
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                // Create a TextReader to read the file. 
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    TextReader reader = new StreamReader(fs, Encoding.Default);
                    // Declare an object variable of the type to be deserialized.
                    // Use the Deserialize method to restore the object's state.
                    obj = serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    /// <summary>
    /// 从配置文件中读取或者写入配置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StructSerialize<T> where T : new()
    {
        public T Read(string FileName)
        {
            T _ds = new T();
            XmlSerialize se = new XmlSerialize();
            Object obj = (Object)_ds;
            se.SerializeFromFile(FileName, ref obj);
            _ds = (T)obj;
            return _ds;
        }

        public void Write(string FileName, T t)
        {
            XmlSerialize se = new XmlSerialize();
            se.SerializeToFile(FileName, t);
        }

    }
}
