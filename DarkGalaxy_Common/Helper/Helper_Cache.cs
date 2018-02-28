using System;
using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 缓存帮助类
    /// 提供一系列对于缓存的操作
    /// </summary>
    public static class Helper_Cache
    {
        /// <summary>
        /// 启用配置文件中全部数据库依赖，返回启用是否成功
        /// 默认使用配置文件的connectionStrings节[name="DefaultConnectionString"]作为数据库连接字符串
        /// 默认使用配置文件的AppSettings节[key="SqlCacheDependencyTable"]作为数据库依赖表名
        /// 数据库表名格式：表名1/表名2/表名3/.../表名n
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="dependencyTables">数据库依赖表名</param>
        /// <returns>启用是否成功</returns>
        public static bool EnableSqlCacheDependency(string connectionString = null, string dependencyTables = null)
        {
            //设置数据库连接字符串、数据库依赖表名
            string strConnectionString = null;
            string strDependencyTables = null;
            if (String.IsNullOrEmpty(connectionString))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;//默认数据库连接字符串
            }
            else
            {
                strConnectionString = connectionString;
            }
            if (String.IsNullOrEmpty(dependencyTables))
            {
                strDependencyTables = ConfigurationManager.AppSettings["SqlCacheDependencyTable"];//默认数据库依赖表名
            }
            else
            {
                strDependencyTables = dependencyTables;
            }

            //处理错误参数
            if ((String.IsNullOrEmpty(strConnectionString)) || (String.IsNullOrEmpty(strDependencyTables)))
            {
                return false;
            }
            else { }

            bool result = false;

            //启用配置文件中全部数据库依赖
            string[] arrDependencyTables = strDependencyTables.Split('/');
            if ((null != arrDependencyTables) && (0 < arrDependencyTables.Length))
            {
                SqlCacheDependencyAdmin.EnableTableForNotifications(strConnectionString, arrDependencyTables);
                result = true;
            }
            else { }

            return result;
        }

        /// <summary>
        /// 禁用配置文件中全部数据库依赖，返回禁用是否成功
        /// 默认使用配置文件的connectionStrings节[name="DefaultConnectionString"]作为数据库连接字符串
        /// 默认使用配置文件的AppSettings节[key="SqlCacheDependencyTable"]作为数据库依赖表名
        /// 数据库表名格式：表名1/表名2/表名3/.../表名n
        /// </summary>
        /// <returns>禁用是否成功</returns>
        public static bool DisableSqlCacheDependency(string connectionString = null, string dependencyTables = null)
        {
            //设置数据库连接字符串、数据库依赖表名
            string strConnectionString = null;
            string strDependencyTables = null;
            if (String.IsNullOrEmpty(connectionString))
            {
                strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;//默认数据库连接字符串
            }
            else
            {
                strConnectionString = connectionString;
            }
            if (String.IsNullOrEmpty(dependencyTables))
            {
                strDependencyTables = ConfigurationManager.AppSettings["SqlCacheDependencyTable"];//默认数据库依赖表名
            }
            else
            {
                strDependencyTables = dependencyTables;
            }

            //处理错误参数
            if ((String.IsNullOrEmpty(strConnectionString)) || (String.IsNullOrEmpty(strDependencyTables)))
            {
                return false;
            }
            else { }

            bool result = false;

            //禁用配置文件中全部数据库依赖
            string[] arrDependencyTables = strDependencyTables.Split('/');
            if ((null != arrDependencyTables) && (0 < arrDependencyTables.Length))
            {
                SqlCacheDependencyAdmin.DisableTableForNotifications(strConnectionString, arrDependencyTables);
                result = true;
            }
            else { }

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="RemoveTime">移除缓存时间</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, DateTime RemoveTime)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, null, RemoveTime, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="IntervalTime">缓存可调到期的间隔时间</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, TimeSpan IntervalTime)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)) || (TimeSpan.Zero == IntervalTime) || (TimeSpan.FromDays(365) < IntervalTime))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, null, Cache.NoAbsoluteExpiration, IntervalTime, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="RemoveTime">移除缓存时间</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, DateTime RemoveTime)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, RemoveTime, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="IntervalTime">缓存可调到期的间隔时间</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, TimeSpan IntervalTime)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)) || (TimeSpan.Zero == IntervalTime) || (TimeSpan.FromDays(365) < IntervalTime))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, Cache.NoAbsoluteExpiration, IntervalTime, CacheItemPriority.Default, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="RemoveTime">移除缓存时间</param>
        /// <param name="Priority">缓存优先级</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, DateTime RemoveTime, CacheItemPriority Priority)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, RemoveTime, Cache.NoSlidingExpiration, Priority, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="IntervalTime">缓存可调到期的间隔时间</param>
        /// <param name="Priority">缓存优先级</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, TimeSpan IntervalTime, CacheItemPriority Priority)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)) || (TimeSpan.Zero == IntervalTime) || (TimeSpan.FromDays(365) < IntervalTime))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, Cache.NoAbsoluteExpiration, IntervalTime, Priority, null);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="RemoveTime">移除缓存时间</param>
        /// <param name="CacheCallback">缓存移除回调委托</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, DateTime RemoveTime, CacheItemRemovedCallback CacheCallback)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, RemoveTime, Cache.NoSlidingExpiration, CacheItemPriority.Default, CacheCallback);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="IntervalTime">缓存可调到期的间隔时间</param>
        /// <param name="CacheCallback">缓存移除回调委托</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, TimeSpan IntervalTime, CacheItemRemovedCallback CacheCallback)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)) || (TimeSpan.Zero == IntervalTime) || (TimeSpan.FromDays(365) < IntervalTime))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, Cache.NoAbsoluteExpiration, IntervalTime, CacheItemPriority.Default, CacheCallback);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="RemoveTime">移除缓存时间</param>
        /// <param name="Priority">缓存优先级</param>
        /// <param name="CacheCallback">缓存移除回调委托</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, DateTime RemoveTime, CacheItemPriority Priority, CacheItemRemovedCallback CacheCallback)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, RemoveTime, Cache.NoSlidingExpiration, Priority, CacheCallback);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 添加新的缓存项，返回添加是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <param name="Value">缓存项</param>
        /// <param name="Dependency">缓存依赖</param>
        /// <param name="IntervalTime">缓存可调到期的间隔时间</param>
        /// <param name="Priority">缓存优先级</param>
        /// <param name="CacheCallback">缓存移除回调委托</param>
        /// <returns>添加是否成功</returns>
        public static bool AddCache(string Key, object Value, CacheDependency Dependency, TimeSpan IntervalTime, CacheItemPriority Priority, CacheItemRemovedCallback CacheCallback)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key) || (null == Value) || (null != GetCache(Key)) || (TimeSpan.Zero == IntervalTime) || (TimeSpan.FromDays(365) < IntervalTime))
            {
                return false;
            }
            else { }

            bool result = false;

            //添加新的缓存项
            object Caches = HttpRuntime.Cache.Add(Key, Value, Dependency, Cache.NoAbsoluteExpiration, IntervalTime, Priority, CacheCallback);
            result = (Caches == null ? true : false);

            return result;
        }

        /// <summary>
        /// 删除指定缓存键的缓存项，返回删除是否成功
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <returns>删除是否成功</returns>
        public static bool RemoveCache(string Key)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key))
            {
                return false;
            }
            else { }

            bool result = false;

            //删除指定缓存键的缓存项
            object Caches = HttpRuntime.Cache.Remove(Key);
            result = (Caches == null ? false : true);

            return result;
        }

        /// <summary>
        /// 获取指定缓存键的缓存项，返回获取到的缓存项
        /// 未找到缓存项则返回null
        /// </summary>
        /// <param name="Key">缓存键</param>
        /// <returns>对应缓存键的缓存项</returns>
        public static object GetCache(string Key)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(Key))
            {
                return null;
            }
            else { }

            object result = null;

            //获取指定缓存键的缓存项
            result = HttpRuntime.Cache.Get(Key);

            return result;
        }
    }
}
