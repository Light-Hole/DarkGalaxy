using System;
using System.Collections.Generic;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 随机数帮助类
    /// 提供一系列对于随机数的操作
    /// </summary>
    public static class Helper_Random
    {
        /// <summary>
        /// 重复的从集合中随机取指定个数的元素，返回随机取出的元素集合
        /// 随机失败则返回null
        /// </summary>
        /// <typeparam name="T">泛型，List集合的类型</typeparam>
        /// <param name="genericsList">原始List集合</param>
        /// <param name="count">取出元素的个数</param>
        /// <returns>随机取出的元素集合</returns>
        public static List<T> RandomRepeat<T>(List<T> genericsList, int count)
        {
            //处理错误参数
            if ((null == genericsList) || (0 == genericsList.Count) || (0 >= count))
            {
                return null;
            }
            else { }

            List<T> result = new List<T>();

            //重复的从集合中随机取元素
            int intRandomIndex = 0;
            int intListCount = genericsList.Count;
            Random radRandoms = new Random();
            for (int i = 0; i < count; i++)
            {
                intRandomIndex = radRandoms.Next(0, intListCount);
                result.Add(genericsList[intRandomIndex]);
            }

            return result;
        }

        /// <summary>
        /// 重复的从集合中随机取指定个数的元素，返回随机取出的元素集合
        /// 随机失败则返回null
        /// </summary>
        /// <typeparam name="TKey">泛型，Dictionary集合的Key类型</typeparam>
        /// <typeparam name="TValue">泛型，Dictionary集合的Value类型</typeparam>
        /// <param name="genericsDictionary">原始Dictionary集合</param>
        /// <param name="count">取出元素的个数</param>
        /// <returns>随机取出的元素集合</returns>
        public static Dictionary<TKey, TValue> RandomRepeat<TKey, TValue>(Dictionary<TKey, TValue> genericsDictionary, int count)
        {
            //处理错误参数
            if ((null == genericsDictionary) || (0 == genericsDictionary.Count) || (0 >= count))
            {
                return null;
            }
            else { }

            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();

            //重复的从集合中随机取元素
            int intRandomIndex = 0;
            List<TKey> lisGenericsKey = new List<TKey>(genericsDictionary.Keys);//获取Dictionarry的Key集合
            int intListCount = lisGenericsKey.Count;
            Random radRandoms = new Random();
            for (int i = 0; i < count; i++)
            {
                intRandomIndex = radRandoms.Next(0, intListCount);
                result.Add(lisGenericsKey[intRandomIndex], genericsDictionary[lisGenericsKey[intRandomIndex]]);
            }

            return result;
        }

        /// <summary>
        /// 不重复的从集合中随机取指定个数的元素，返回随机取出的元素集合
        /// 随机失败则返回null
        /// </summary>
        /// <typeparam name="T">泛型,List集合的类型</typeparam>
        /// <param name="genericsList">原始List集合</param>
        /// <param name="count">取出元素的个数</param>
        /// <returns>随机取出的元素集合</returns>
        public static List<T> RandomNoRepeat<T>(List<T> genericsList, int count)
        {
            //处理错误参数
            if ((null == genericsList) || (0 == genericsList.Count) || (0 >= count) || (genericsList.Count < count))
            {
                return null;
            }
            else { }

            List<T> result = new List<T>();

            //不重复的从集合中随机取元素
            int intRandomIndex = 0;
            Random radRandoms = new Random();
            for (int i = 0; i < count; i++)
            {
                intRandomIndex = radRandoms.Next(0, genericsList.Count);
                result.Add(genericsList[intRandomIndex]);
                genericsList.Remove(genericsList[intRandomIndex]);
            }

            return result;
        }

        /// <summary>
        /// 不重复的从集合中随机取指定个数的元素，返回随机取出的元素集合
        /// 随机失败则返回null
        /// </summary>
        /// <typeparam name="TKey">泛型，Dictionary集合的Key类型</typeparam>
        /// <typeparam name="TValue">泛型，Dictionary集合的Value类型</typeparam>
        /// <param name="genericsDictionary">原始Dictionary集合</param>
        /// <param name="count">取出元素的个数</param>
        /// <returns>随机取出的元素集合</returns>
        public static Dictionary<TKey, TValue> RandomNoRepeat<TKey, TValue>(Dictionary<TKey, TValue> genericsDictionary, int count)
        {
            //处理错误参数
            if ((null == genericsDictionary) || (0 == genericsDictionary.Count) || (0 >= count) || (genericsDictionary.Count < count))
            {
                return null;
            }
            else { }

            Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();

            //重复的从集合中随机取元素
            int intRandomIndex = 0;
            List<TKey> lisGenericsKey = new List<TKey>(genericsDictionary.Keys);//获取Dictionarry的Key集合
            Random radRandoms = new Random();
            for (int i = 0; i < count; i++)
            {
                intRandomIndex = radRandoms.Next(0, genericsDictionary.Count);
                result.Add(lisGenericsKey[intRandomIndex], genericsDictionary[lisGenericsKey[intRandomIndex]]);
                genericsDictionary.Remove(lisGenericsKey[intRandomIndex]);
            }

            return result;
        }
    }
}
