using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// Json序列化帮助类
    /// 提供一系列的关于Json序列化/反序列化的操作
    /// 序列化或反序列化的类需要引用System.Runtime.Serialization程序集，需要声明特性[DataContract]，对应的属性需要声明特性[DataMember]
    /// </summary>
    public static class Helper_Serializer_Json
    {
        /// <summary>
        /// 原始泛型对象序列化为Json字符串，返回序列化后的Json字符串
        /// 序列化失败则返回null
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="genericsObject">原始泛型对象</param>
        /// <returns>序列化后的Json字符串</returns>
        public static string JsonSerializer<T>(T genericsObject)
            where T : class
        {
            //处理错误参数
            if (null == genericsObject)
            {
                return null;
            }
            else { }

            string result = null;

            //进行Json序列化
            DataContractJsonSerializer srlJsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream strmMemory = new MemoryStream())
            {
                srlJsonSerializer.WriteObject(strmMemory, genericsObject);
                result = Encoding.UTF8.GetString(strmMemory.ToArray());
            }

            return result;
        }

        /// <summary>
        /// 原始Json字符串反序列化为泛型对象，返回反序列化后的泛型对象
        /// 序列化失败则返回泛型默认值
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="originalString">原始Json字符串</param>
        /// <returns>反序列化后的泛型对象</returns>
        public static T JsonDeserializer<T>(string originalString)
            where T : class
        {
            //处理错误参数
            if (String.IsNullOrEmpty(originalString))
            {
                return default(T);
            }
            else { }

            T result = default(T);

            //进行Json反序列化
            DataContractJsonSerializer srlJsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream strmMemory = new MemoryStream(Encoding.UTF8.GetBytes(originalString)))
            {
                result = srlJsonSerializer.ReadObject(strmMemory) as T;//获取反序列化后的泛型对象
            }

            return result;
        }
    }
}
