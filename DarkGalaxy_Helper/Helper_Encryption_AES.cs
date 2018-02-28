﻿using DarkGalaxy_IHelper;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DarkGalaxy_Helper
{
    /// <summary>
    /// AES加密帮助类
    /// 提供一系列对于AES加密解密的操作
    /// </summary>
    public class Helper_Encryption_AES : IEncryptionSymmetric
    {
        /// <summary>
        /// 使用AES与密钥加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encoding">字符编码（默认使用UTF8编码）</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>加密后的字符串</returns>
        public string Encryption(string originalString, out byte[] encryptionKey, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(originalString))
            {
                encryptionKey = null;
                return null;
            }
            else { }

            string result = null;

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

            //进行AES加密
            RijndaelManaged crypAESCrypto = new RijndaelManaged()
            {
                Mode = cipherMode,
                Padding = paddingMode
            };
            crypAESCrypto.GenerateKey();
            encryptionKey = crypAESCrypto.Key;
            MemoryStream strmMemory = new MemoryStream();
            using (CryptoStream strmCrypto = new CryptoStream(strmMemory, crypAESCrypto.CreateEncryptor(), CryptoStreamMode.Write))
            {
                strmCrypto.Write(arrData, 0, arrData.Length);
                strmCrypto.FlushFinalBlock();
                result = Convert.ToBase64String(strmMemory.ToArray());
            }

            return result;
        }

        /// <summary>
        /// 使用AES与密钥解密原始字符串，返回解密后的字符串
        /// 解密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encoding">字符编码（默认使用UTF8编码）</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>解密后的字符串</returns>
        public string Decryption(string originalString, byte[] encryptionKey, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(originalString)) || (null == encryptionKey) || (0 > encryptionKey.Length))
            {
                return null;
            }
            else { }

            string result = null;

            //处理传入参数
            byte[] arrData = Convert.FromBase64String(originalString);

            //进行AES解密
            RijndaelManaged crypAESCrypto = new RijndaelManaged()
            {
                Key = encryptionKey,
                Mode = cipherMode,
                Padding = paddingMode
            };
            MemoryStream strmMemory = new MemoryStream();
            using (CryptoStream strmCrypto = new CryptoStream(strmMemory, crypAESCrypto.CreateDecryptor(), CryptoStreamMode.Write))
            {
                strmCrypto.Write(arrData, 0, arrData.Length);
                strmCrypto.FlushFinalBlock();

                //处理字符编码
                if (null == encoding)
                {
                    result = Encoding.UTF8.GetString(strmMemory.ToArray());
                }
                else
                {
                    result = encoding.GetString(strmMemory.ToArray());
                }
            }

            return result;
        }

        /// <summary>
        /// 使用AES与密钥和向量加密原始字符串，返回加密后的字符串
        /// 加密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encryptionIVector">向量</param>
        /// <param name="encoding">字符编码（默认使用UTF8编码）</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>加密后的字符串</returns>
        public string Encryption(string originalString, out byte[] encryptionKey, out byte[] encryptionIVector, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(originalString))
            {
                encryptionKey = null;
                encryptionIVector = null;
                return null;
            }
            else { }

            string result = null;

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

            //进行AES加密
            RijndaelManaged crypAESCrypto = new RijndaelManaged()
            {
                Mode = cipherMode,
                Padding = paddingMode
            };
            crypAESCrypto.GenerateKey();
            crypAESCrypto.GenerateIV();
            encryptionKey = crypAESCrypto.Key;
            encryptionIVector = crypAESCrypto.IV;
            MemoryStream strmMemory = new MemoryStream();
            using (CryptoStream strmCrypto = new CryptoStream(strmMemory, crypAESCrypto.CreateEncryptor(), CryptoStreamMode.Write))
            {
                strmCrypto.Write(arrData, 0, arrData.Length);
                strmCrypto.FlushFinalBlock();
                result = Convert.ToBase64String(strmMemory.ToArray());
            }

            return result;
        }

        /// <summary>
        /// 使用AES与密钥和向量解密原始字符串，返回解密后的字符串
        /// 解密失败则返回null
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        /// <param name="encryptionKey">密钥</param>
        /// <param name="encryptionIVector">向量</param>
        /// <param name="encoding">字符编码（默认使用UTF8编码）</param>
        /// <param name="cipherMode">运算模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns>解密后的字符串</returns>
        public string Decryption(string originalString, byte[] encryptionKey, byte[] encryptionIVector, Encoding encoding = null, CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.None)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(originalString)) || (null == encryptionKey) || (null == encryptionIVector) || (0 > encryptionKey.Length) || (0 > encryptionIVector.Length))
            {
                return null;
            }
            else { }

            string result = null;

            //处理传入参数
            byte[] arrData = Convert.FromBase64String(originalString);

            //进行AES解密
            RijndaelManaged crypAESCrypto = new RijndaelManaged()
            {
                Key = encryptionKey,
                IV = encryptionIVector,
                Mode = cipherMode,
                Padding = paddingMode
            };
            MemoryStream strmMemory = new MemoryStream();
            using (CryptoStream strmCrypto = new CryptoStream(strmMemory, crypAESCrypto.CreateDecryptor(), CryptoStreamMode.Write))
            {
                strmCrypto.Write(arrData, 0, arrData.Length);
                strmCrypto.FlushFinalBlock();

                //处理字符编码
                if (null == encoding)
                {
                    result = Encoding.UTF8.GetString(strmMemory.ToArray());
                }
                else
                {
                    result = encoding.GetString(strmMemory.ToArray());
                }
            }

            return result;
        }
    }
}
