using DarkGalaxy_Common.DarkGalaxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_IHelper
{
    /// <summary>
    /// 非对称加密接口
    /// </summary>
    public interface IEncryptionAsymmetric
    {
        /// <summary>
        /// 加密原始byte数组，返回加密后的byte数组
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalBytes">原始byte数组</param>
        /// <param name="count">加密的次数</param>
        /// <returns>加密后的byte数组</returns>
        byte[] Encryption(byte[] originalBytes, int count = 1);

        /// <summary>
        /// 加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="matchCaseTypes">字符串字母大小写</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="count">加密的次数</param>
        /// <returns>加密后的字符串</returns>
        string Encryption(string originalString, MatchCaseType matchCaseTypes, Encoding encoding = null, int count = 1);
    }
}
