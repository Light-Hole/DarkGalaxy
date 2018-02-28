using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_IHelper
{
    /// <summary>
    /// 序列化接口
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 原始泛型对象序列化为字符串，返回序列化后的字符串
        /// 序列化失败则返回null
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="genericsObject">原始泛型对象</param>
        /// <returns>序列化后的Json字符串</returns>
        string Serializer<T>(T genericsObject) where T : class;

        /// <summary>
        /// 原始字符串反序列化为泛型对象，返回反序列化后的泛型对象
        /// 序列化失败则返回泛型默认值
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="originalString">原始Json字符串</param>
        /// <returns>反序列化后的泛型对象</returns>
        T Deserializer<T>(string originalString) where T : class;
    }
}
