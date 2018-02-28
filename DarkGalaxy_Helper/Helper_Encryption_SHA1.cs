using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_IHelper;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DarkGalaxy_Helper
{
    /// <summary>
    /// SHA1加密帮助类
    /// 提供一系列对于SHA1加密的操作
    /// </summary>
    public class Helper_Encryption_SHA1 : IEncryptionAsymmetric
    {
        /// <summary>
        /// 使用SHA1加密原始byte数组，返回加密后的byte数组
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalBytes">原始byte数组</param>
        /// <param name="count">加密的次数</param>
        /// <returns>加密后的byte数组</returns>
        public byte[] Encryption(byte[] originalBytes, int count = 1)
        {
            //处理错误参数
            if ((null == originalBytes) || (0 == originalBytes.Length) || (0 >= count))
            {
                return null;
            }
            else { }

            byte[] result = null;

            //进行SHA1加密
            using (SHA1 crypSHA1 = SHA1.Create())
            {
                //根据加密次数进行多次SHA1加密
                for (int i = 0; i < count; i++)
                {
                    originalBytes = crypSHA1.ComputeHash(originalBytes);
                }
                result = originalBytes;
            }

            return result;
        }

        /// <summary>
        /// 使用SHA1加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="matchCaseTypes">加密字符串字母大小写</param>
        /// <param name="encoding">字符编码（默认使用UTF8编码）</param>
        /// <param name="count">加密的次数</param>
        /// <returns>加密后的字符串</returns>
        public string Encryption(string originalString, MatchCaseType matchCaseTypes, Encoding encoding = null, int count = 1)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(originalString)) || (0 >= count))
            {
                return null;
            }
            else { }

            string result = null;

            //设置加密大小写
            string strFormatString = null;
            if (MatchCaseType.Lowercase == matchCaseTypes)
            {
                strFormatString = "x2";
            }
            else if (MatchCaseType.Uppercase == matchCaseTypes)
            {
                strFormatString = "X2";
            }
            else
            {
                return result;
            }

            //处理传入参数
            byte[] arrData = null;
            if (null == encoding)
            {
                arrData = Encoding.UTF8.GetBytes(originalString);
            }
            else
            {
                arrData = encoding.GetBytes(originalString);
            }

            //进行SHA1加密
            StringBuilder strbResults = new StringBuilder();
            using (SHA1 crypSHA1 = SHA1.Create())
            {
                //根据加密次数进行多次SHA1加密
                for (int i = 0; i < count; i++)
                {
                    arrData = crypSHA1.ComputeHash(arrData);
                }

                //使加密后的byte数组按照十六进制转化为字符串
                for (int i = 0; i < arrData.Length; i++)
                {
                    strbResults.Append(arrData[i].ToString(strFormatString));
                }
                result = strbResults.ToString();
            }

            return result;
        }
    }
}
