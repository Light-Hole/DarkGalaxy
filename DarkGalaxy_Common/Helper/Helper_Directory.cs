using DarkGalaxy_Common.DarkGalaxy;
using System;
using System.Configuration;
using System.IO;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 目录帮助类
    /// 提供一系列对于文件夹、目录的操作
    /// 默认使用配置文件的AppSettings节[key="Helper_Directory_DefaultRootPath"]作为根目录
    /// </summary>
    public static class Helper_Directory
    {
        private static string _DefaultRootPath = ConfigurationManager.AppSettings["Helper_Directory_DefaultRootPath"];

        /// <summary>
        /// 默认根目录，默认值：配置文件AppSettings节[key="Helper_Directory_DefaultRootPath"]
        /// </summary>
        public static string DefaultRootPath
        {
            get
            {
                if (String.IsNullOrEmpty(_DefaultRootPath))
                {
                    return "/";
                }
                else
                {
                    return _DefaultRootPath;
                }
            }
            set
            {
                _DefaultRootPath = value;
            }
        }

        /// <summary>
        /// 在根目录下创建指定文件夹，返回创建的文件夹路径
        /// 创建失败则返回null
        /// </summary>
        /// <param name="FolderName">文件夹名</param>
        /// <param name="RootPath">根目录</param>
        /// <returns>创建的文件夹路径</returns>
        public static string CreateFolder(string FolderName, string RootPath = null)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(FolderName))
            {
                return null;
            }
            else { }

            string result = null;

            //设置文件根目录
            string FolderRootPath = null;
            if (String.IsNullOrEmpty(RootPath))
            {
                FolderRootPath = DefaultRootPath;
            }
            else
            {
                FolderRootPath = RootPath;
            }
            if (!String.IsNullOrEmpty(FolderRootPath))
            {
                if (!Directory.Exists(FolderRootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                else { }
            }
            else
            {
                return null;
            }

            //创建文件夹
            if (Path.IsPathRooted(FolderRootPath))
            {
                string FolderPath = Path.Combine(FolderRootPath, FolderName);
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                    result = FolderPath;
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 按照指定日期类型创建文件夹，返回创建的文件夹路径
        /// 创建失败则返回null
        /// 日期类型：yyyyMMddHHmmss（年月日小时分钟秒）
        /// </summary>
        /// <param name="DateTypes">日期类型（标志枚举）</param>
        /// <param name="RootPath">根目录</param>
        /// <returns>创建的文件夹路径</returns>
        public static string CreateDateFolder(DateType DateTypes, string RootPath = null)
        {
            string result = null;

            //设置文件根目录
            string FolderRootPath = null;
            if (String.IsNullOrEmpty(RootPath))
            {
                FolderRootPath = DefaultRootPath;
            }
            else
            {
                FolderRootPath = RootPath;
            }
            if (!String.IsNullOrEmpty(FolderRootPath))
            {
                if (!Directory.Exists(FolderRootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                else { }
            }
            else
            {
                return null;
            }

            //设置全目录路径，创建文件夹
            if (Path.IsPathRooted(FolderRootPath))
            {
                string FolderName = DGEnum.DateTypeToDateString(DateTypes);//根据标志枚举创建文件夹名
                string FolderPath = Path.Combine(FolderRootPath, FolderName);
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                    result = FolderPath;
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 按照指定日期类型创建目录，返回创建的目录路径
        /// 创建失败则返回null
        /// 日期类型：/yyyy/MM/dd/HH/mm/ss/（/年/月/日/小时/分钟/秒/）
        /// </summary>
        /// <param name="DateTypes">日期类型（标志枚举）</param>
        /// <param name="RootPath">根目录</param>
        /// <returns>创建的目录路径</returns>
        public static string CreateDateDirectory(DateType DateTypes, string RootPath = null)
        {
            string result = null;

            //设置文件根目录
            string FolderRootPath = null;
            if (String.IsNullOrEmpty(RootPath))
            {
                FolderRootPath = DefaultRootPath;
            }
            else
            {
                FolderRootPath = RootPath;
            }
            if (!String.IsNullOrEmpty(FolderRootPath))
            {
                if (!Directory.Exists(FolderRootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                else { }
            }
            else
            {
                return null;
            }

            //设置全目录路径，创建目录
            if (Path.IsPathRooted(FolderRootPath))
            {
                string DirectoryPath = DGEnum.DateTypeToDateTreeString(DateTypes);//根据标志枚举创建目录
                string FolderPath = Path.Combine(FolderRootPath, DirectoryPath);
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                    result = FolderPath;
                }
                else { }
            }
            else { }

            return result;
        }
    }
}
