using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_IHelper
{
    /// <summary>
    /// 对称加密接口
    /// </summary>
    public interface IEncryptionSymmetric
    {
        /// <summary>
        /// 使用密钥加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>加密后的字符串</returns>
        string Encryption(string originalString, out byte[] encryptionKey, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None);

        /// <summary>
        /// 使用密钥解密原始字符串，返回解密后的字符串
        /// 解密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>解密后的字符串</returns>
        string Decryption(string originalString, byte[] encryptionKey, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None);

        /// <summary>
        /// 使用密钥和向量加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encryptionIVector">向量</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>加密后的字符串</returns>
        string Encryption(string originalString, out byte[] encryptionKey, out byte[] encryptionIVector, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None);

        /// <summary>
        /// 使用密钥和向量解密原始字符串，返回解密后的字符串
        /// 解密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encryptionIVector">向量</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>解密后的字符串</returns>
        string Decryption(string originalString, byte[] encryptionKey, byte[] encryptionIVector, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None);
    }
}
