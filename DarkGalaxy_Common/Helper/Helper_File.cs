using DarkGalaxy_Common.DarkGalaxy;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 文件帮助类
    /// 提供一系列对于文件的操作
    /// 默认使用配置文件的AppSettings节[key="Helper_File_DefaultFilePath"]作为根目录
    /// </summary>
    public static class Helper_File
    {
        private static string _DefaultRootPath = ConfigurationManager.AppSettings["Helper_File_DefaultFilePath"];

        /// <summary>
        /// 默认根目录，默认值：配置文件AppSettings节[key="Helper_File_DefaultFilePath"]
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
        /// 创建指定文件名的文件，返回创建的文件路径
        /// 文件已经存在或创建失败则返回null
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="RootPath">根目录</param>
        /// <returns>创建的文件路径</returns>
        public static string CreateFile(string FileName, string RootPath = null)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(FileName))
            {
                return null;
            }
            else { }

            string result = null;

            //设置文件根目录
            string FileRootPath = null;
            if (String.IsNullOrEmpty(RootPath))
            {
                FileRootPath = DefaultRootPath;
            }
            else
            {
                FileRootPath = RootPath;
            }
            if (!String.IsNullOrEmpty(FileRootPath))
            {
                if (!Directory.Exists(FileRootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                else { }
            }
            else
            {
                return null;
            }

            //判断文件是否存在，创建文件
            if (Path.IsPathRooted(FileRootPath))
            {
                string FilePath = Path.Combine(FileRootPath, FileName);
                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath);
                    result = FilePath;
                }
                else { }
            }

            return result;
        }

        /// <summary>
        /// 按照指定日期格式顺序、根目录、文件类型创建文件，返回创建的文件路径
        /// 文件已经存在或创建失败则返回null
        /// 格式顺序：yyyyMMddHHmmss（年月日小时分钟秒）
        /// </summary>
        /// <param name="DateTypes">日期文件名类型（标志枚举）</param>
        /// <param name="FileTypes">枚举类型，文件类型</param>
        /// <param name="RootPath">根目录</param>
        /// <returns>创建的文件路径</returns>
        public static string CreateDateFile(DateType DateTypes, FileType FileTypes, string RootPath = null)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(RootPath)) || (!Path.IsPathRooted(RootPath)))
            {
                return null;
            }
            else { }

            string result = null;

            //设置文件根目录
            string FileRootPath = null;
            if (String.IsNullOrEmpty(RootPath))
            {
                FileRootPath = DefaultRootPath;
            }
            else
            {
                FileRootPath = RootPath;
            }
            if (!String.IsNullOrEmpty(FileRootPath))
            {
                if (!Directory.Exists(FileRootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                else { }
            }
            else
            {
                return null;
            }

            //创建文件
            if (Path.IsPathRooted(FileRootPath))
            {
                //设置文件全路径
                string FileName = DGEnum.DateTypeToDateString(DateTypes);
                FileName += DGEnum.FileTypeToExtension(FileTypes);
                string FilePath = Path.Combine(FileRootPath, FileName);

                //判断文件是否存在，创建文件
                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath);
                    result = FilePath;
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 获取指定文件路径的文件真实类型，返回获取的文件真实类型
        /// 未获取到数据则返回FileType.Unknown（未知类型）
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>文件真实类型</returns>
        public static FileType GetFileRealType(string FilePath)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(FilePath))
            {
                return FileType.Unknown;
            }
            else { }

            FileType result = FileType.Unknown;

            //获取文件真实类型的标识码
            string CodeString = null;
            string FileFullPath = Path.GetFullPath(FilePath);
            if (File.Exists(FileFullPath))
            {
                FileStream FileStrems = new FileStream(FileFullPath, FileMode.Open, FileAccess.Read);
                using (BinaryReader BinaryReaders = new BinaryReader(FileStrems))
                {
                    byte FileBuffer = BinaryReaders.ReadByte();
                    CodeString += FileBuffer.ToString();
                    FileBuffer = BinaryReaders.ReadByte();
                    CodeString += FileBuffer.ToString();
                }

                //获取文件真实类型
                int Code = Convert.ToInt32(CodeString);
                FileType FileRealType = (FileType)Enum.ToObject(typeof(FileType), Code);
                if (Enum.IsDefined(typeof(FileType), FileRealType))
                {
                    result = FileRealType;
                }
                else { }
            }
            else { }

            return result;
        }

        /// <summary>
        /// 保存Http上传文件，返回保存的文件路径
        /// </summary>
        /// <param name="SavePath">保存路径</param>
        /// <param name="FileName">保存文件名称</param>
        /// <param name="UploadCollectionName">上传文件集合名称</param>
        /// <returns></returns>
        public static string SaveHttpUploadFile(string SavePath, string FileName, string UploadCollectionName)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(SavePath)) || (String.IsNullOrEmpty(UploadCollectionName)) || (String.IsNullOrEmpty(FileName)) || (false == Path.IsPathRooted(SavePath)) || (null == HttpContext.Current.Request.Files[UploadCollectionName]))
            {
                return null;
            }
            else { }

            string result = null;

            //上传文件
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            else { }
            HttpPostedFile UploadFile = HttpContext.Current.Request.Files[UploadCollectionName];
            string FileExtension = Path.GetExtension(UploadFile.FileName);
            if(!String.IsNullOrEmpty(FileExtension))//判断文件名是否含有后缀
            {
                FileName += FileExtension;
            }
            else { }
            string UploadPath = Path.Combine(SavePath, FileName);
            if (!String.IsNullOrEmpty(UploadPath))
            {
                UploadFile.SaveAs(UploadPath);
                result = UploadPath;
            }
            else { }

            return result;
        }
    }
}
