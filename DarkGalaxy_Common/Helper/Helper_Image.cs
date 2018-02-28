using DarkGalaxy_Common.DarkGalaxy;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DarkGalaxy_Common.Helper
{
    /// <summary>
    /// 图片帮助类
    /// 提供一系列对于图片的操作
    /// </summary>
    public static class Helper_Image
    {
        /// <summary>
        /// 检验指定文件路径下的文件是否属于图片类型，返回是否属于图片类型
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns>是否属于图片类型</returns>
        public static bool VerifyImageType(string FilePath)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(FilePath)) || (false == File.Exists(Path.GetFullPath(FilePath))))
            {
                return false;
            }
            else { }

            bool result = false;

            //检验文件类型
            FileType FileTypes = Helper_File.GetFileRealType(FilePath);
            if (FileType.Unknown == FileTypes)
            {
                result = false;
            }
            else if ((FileType.JPG == FileTypes) || (FileType.PNG == FileTypes) || (FileType.BMP == FileTypes) || (FileType.GIF == FileTypes))
            {
                result = true;
            }
            else { }

            return result;
        }

        /// <summary>
        /// 在指定图片的目录下Small文件夹中创建相同文件名的对应缩略图，返回创建的缩略图文件路径
        /// 指定目录下图片不存在、缩略图文件已经存在或创建失败则返回null
        /// </summary>
        /// <param name="ImagePath">图片路径</param>
        /// <param name="Width">缩略图宽度（单位：像素）</param>
        /// <param name="Height">缩略图高度（单位：像素）</param>
        /// <returns>缩略图文件路径</returns>
        public static string CreateThumbnails(string ImagePath, int Width, int Height)
        {
            //处理错误参数
            if ((String.IsNullOrEmpty(ImagePath)) || (0 >= Width) || (0 >= Height))
            {
                return null;
            }
            else { }

            string result = null;

            //设置缩略图路径
            string ImageFullPath = Path.GetFullPath(ImagePath);
            if ((false == File.Exists(ImageFullPath)) || (false == VerifyImageType(ImageFullPath)))
            {
                return result;
            }
            else { }
            string ImageDirectory = Path.GetDirectoryName(ImageFullPath);
            string ImageName = Path.GetFileName(ImageFullPath);
            string SmallDirectory = Path.Combine(ImageDirectory, "Small");
            string SmallFullPath = Path.Combine(SmallDirectory, ImageName);
            if ((String.IsNullOrEmpty(ImageDirectory)) || (String.IsNullOrEmpty(ImageName)) || (String.IsNullOrEmpty(SmallDirectory)) || (String.IsNullOrEmpty(SmallFullPath)) || (File.Exists(SmallFullPath)))
            {
                return result;
            }
            else
            {
                if (!Directory.Exists(SmallDirectory))
                {
                    Directory.CreateDirectory(SmallDirectory);
                }
                else { }
            }

            //创建缩略图
            Image OriginalImage = Image.FromFile(ImageFullPath);
            Bitmap SmallBitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            Graphics SmallGraphics = Graphics.FromImage(SmallBitmap);
            SmallGraphics.DrawImage(OriginalImage, new Rectangle(0, 0, Width, Height));
            SmallBitmap.Save(SmallFullPath);
            result = SmallFullPath;

            //释放资源
            OriginalImage.Dispose();
            SmallBitmap.Dispose();
            SmallGraphics.Dispose();

            return result;
        }

        /// <summary>
        /// 获取指定图片路径的缩略图路径，返回获取的缩略图文件路径
        /// 图片不存在或创建失败则返回null
        /// </summary>
        /// <param name="ImagePath">图片路径</param>
        /// <returns>缩略图文件路径</returns>
        public static string GetThumbnailsPath(string ImagePath)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(ImagePath))
            {
                return null;
            }
            else { }

            string result = null;

            //获取缩略图目录
            string ImageDirectory = Path.GetDirectoryName(ImagePath);
            string ImageName = Path.GetFileName(ImagePath);
            string SmallDirectory = Path.Combine(ImageDirectory, "Small");
            string SmallFullPath = Path.Combine(SmallDirectory, ImageName);
            if ((String.IsNullOrEmpty(ImageDirectory)) || (String.IsNullOrEmpty(ImageName)) || (String.IsNullOrEmpty(SmallDirectory)) || (String.IsNullOrEmpty(SmallFullPath)))
            {
                result = SmallFullPath;
            }
            else { }

            return result;
        }
    }
}
