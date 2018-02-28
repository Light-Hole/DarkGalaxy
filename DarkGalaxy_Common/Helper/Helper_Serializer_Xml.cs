using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// Xml序列化帮助类
    /// 提供一系列的关于Xml序列化/反序列化的操作
    /// 序列化或反序列化的类需要引用System.Runtime.Serialization程序集，需要声明特性[DataContract]，对应的属性需要声明特性[DataMember]
    /// </summary>
    public class Helper_Serializer_Xml
    {
        /// <summary>
        /// 原始泛型对象序列化为Xml字符串，返回序列化后的Xml字符串
        /// 序列化失败则返回null
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="genericsObject">原始泛型对象</param>
        /// <param name="prefix">Xml前缀</param>
        /// <param name="namespaces">Xml命名空间</param>
        /// <returns>序列化后的Xml字符串</returns>
        public static string XmlSerializer<T>(T genericsObject,string prefix,string namespaces)
            where T : class
        {
            //处理错误参数
            if (null == genericsObject)
            {
                return null;
            }
            else { }

            string result = null;

            //设置Xml前缀、命名空间
            XmlSerializerNamespaces srlXmlNamespaces = new XmlSerializerNamespaces();
            srlXmlNamespaces.Add(prefix, namespaces);

            //进行Xml序列化
            XmlSerializer srlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream strmMemory = new MemoryStream())
            {
                srlSerializer.Serialize(strmMemory, genericsObject, srlXmlNamespaces);
                result = Encoding.UTF8.GetString(strmMemory.ToArray());
            }

            return result;
        }

        /// <summary>
        /// 原始Xml字符串反序列化为泛型对象，返回反序列化后的泛型对象
        /// 序列化失败则返回null
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="originalString">原始Xml字符串</param>
        /// <returns>反序列化后的泛型对象</returns>
        public static T XmlDeserializer<T>(string originalString)
            where T : class
        {
            //处理错误参数
            if (String.IsNullOrEmpty(originalString))
            {
                return default(T);
            }
            else { }

            T result = null;

            //进行Xml反序列化
            XmlSerializer srlSerializer = new XmlSerializer(typeof(T));
            using (MemoryStream strmMemory = new MemoryStream(Encoding.UTF8.GetBytes(originalString)))
            {
                result = srlSerializer.Deserialize(strmMemory) as T;//获取反序列化后的泛型对象
            }

            return result;
        }
    }
}
