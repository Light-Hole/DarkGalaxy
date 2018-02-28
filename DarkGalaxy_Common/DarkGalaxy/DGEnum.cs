using DarkGalaxy_Common.Helper;
using System;
using System.IO;

namespace DarkGalaxy_Common.DarkGalaxy
{
    /// <summary>
    /// 日期类型（标志枚举）
    /// 从低位到高位分别代表:年、月、日、小时、分钟、秒、毫秒
    /// </summary>
    [Flags]
    public enum DateType
    {
        /// <summary>
        /// 年
        /// </summary>
        Year = 1,
        /// <summary>
        /// 月
        /// </summary>
        Month = 2,
        /// <summary>
        /// 日
        /// </summary>
        Day = 4,
        /// <summary>
        /// 小时
        /// </summary>
        Hour = 8,
        /// <summary>
        /// 分钟
        /// </summary>
        Minute = 16,
        /// <summary>
        /// 秒
        /// </summary>
        Second = 32,
        /// <summary>
        /// 毫秒
        /// </summary>
        Millisecond = 64,
        /// <summary>
        /// 年月日
        /// </summary>
        YearMonthDay = (DateType.Year | DateType.Month | DateType.Day),
        /// <summary>
        /// 时分秒
        /// </summary>
        HourMinuteSecond = (DateType.Hour | DateType.Minute | DateType.Second),
        /// <summary>
        /// 全部时间
        /// </summary>
        AllTime = (DateType.YearMonthDay | DateType.HourMinuteSecond | DateType.Millisecond)
    }

    /// <summary>
    /// 文件类型
    /// 文件扩展名类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,
        /// <summary>
        /// JPG图片文件
        /// </summary>
        JPG = 255216,
        /// <summary>
        /// GIF图片文件
        /// </summary>
        GIF = 7173,
        /// <summary>
        /// BMP图片文件
        /// </summary>
        BMP = 6677,
        /// <summary>
        /// PNG图片文件
        /// </summary>
        PNG = 13780,
        /// <summary>
        /// EXE可执行文件
        /// </summary>
        EXE = 7790,
        /// <summary>
        /// RAR压缩文件
        /// </summary>
        RAR = 8297,
        /// <summary>
        /// ZIP压缩文件
        /// </summary>
        ZIP = 8075,
        /// <summary>
        /// XML文本文件
        /// </summary>
        XML = 6063,
        /// <summary>
        /// HTML超文本文件
        /// </summary>
        HTML = 6033,
        /// <summary>
        /// ASPX模版引擎文件
        /// </summary>
        ASPX = 239187,
        /// <summary>
        /// C#类文件
        /// </summary>
        CS = 117115,
        /// <summary>
        /// JS脚本文件
        /// </summary>
        JS = 119105,
        /// <summary>
        /// TXT文本文件
        /// </summary>
        TXT = 210187,
        /// <summary>
        /// SQL数据库脚本文件
        /// </summary>
        SQL = 255254
    }

    /// <summary>
    /// Http请求方式类型
    /// </summary>
    public enum HttpMethodType
    {
        /// <summary>
        /// GET请求方式
        /// </summary>
        GET = 0,
        /// <summary>
        /// POST请求方式
        /// </summary>
        POST
    }

    /// <summary>
    /// Http请求数据类型
    /// </summary>
    public enum HttpContentType
    {
        /// <summary>
        /// 标准的编码格式，窗体数据编码为名称/值对
        /// application/x-www-form-urlencoded
        /// </summary>
        UrlEncoded,
    }

    /// <summary>
    /// Http传值方式类型
    /// </summary>
    public enum HttpTransitType
    {
        /// <summary>
        /// 全部传值方式
        /// </summary>
        Params,
        /// <summary>
        /// 地址传值方式
        /// </summary>
        QueryString,
        /// <summary>
        /// 表单传值方式
        /// </summary>
        Form,
        /// <summary>
        /// 服务器变量传值方式
        /// </summary>
        ServerVariables
    }

    /// <summary>
    /// DarkGalaxy特性类型（标志枚举）
    /// DarkGalaxy项目的自定义特性
    /// </summary>
    [Flags]
    public enum AttributeType
    {
        /// <summary>
        /// 无DG特性
        /// </summary>
        None = 1,
        /// <summary>
        /// 具有[DGInsertNeglect]特性
        /// </summary>
        InsertNeglect = 2,
        /// <summary>
        /// 具有[DGDeleteNeglect]特性
        /// </summary>
        DeleteNeglect = 4,
        /// <summary>
        /// 具有[DGUpdateNeglect]特性
        /// </summary>
        UpdateNeglect = 8,
        /// <summary>
        /// 具有[DGSelectNeglect]特性
        /// </summary>
        SelectNeglect = 16,
        /// <summary>
        /// 具有[DGPrimaryKey]特性
        /// </summary>
        PrimaryKey = 32,
        /// <summary>
        /// 具有[DGInsertNeglect]与[DGUpdateNeglect]特性
        /// </summary>
        InsertAndUpdateNeglect = (InsertNeglect | UpdateNeglect)
    }

    /// <summary>
    /// DarkGalaxy自定义返回状态码类型
    /// </summary>
    public enum ResultCodeType
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        UnknownError = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 200,
        /// <summary>
        /// 操作完成
        /// </summary>
        Finish = 201,
        /// <summary>
        /// 错误的请求
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// 未找到数据
        /// </summary>
        NoFound = 404,
    }

    /// <summary>
    /// 区分英文字母大小写类型
    /// </summary>
    public enum MatchCaseType
    {
        /// <summary>
        /// 大写字母
        /// </summary>
        Uppercase,
        /// <summary>
        /// 小写字母
        /// </summary>
        Lowercase
    }

    /// <summary>
    /// DarkGalaxy项目自定义枚举类
    /// 提供一系列对于DarkGalaxy项目自定义枚举的操作
    /// </summary>
    public static class DGEnum
    {
        /// <summary>
        /// 按照文件类型枚举FileType转换成文件后缀字符串，返回转换后的字符串
        /// 转换失败则返回null
        /// </summary>
        /// <param name="FileTypes">文件类型</param>
        /// <returns>转换后的字符串</returns>
        public static string FileTypeToExtension(FileType FileTypes)
        {
            string result = null;

            //FileType枚举转换为指定的字符串
            string FileExtension = Enum.GetName(typeof(FileType), FileTypes);
            if (!String.IsNullOrEmpty(FileExtension))
            {
                result = "." + FileExtension.ToLower();
            }
            else { }

            return result;
        }

        /// <summary>
        /// 按照指定日期格式顺序将标志枚举DataType转换为字符串，返回转换后的字符串
        /// 转换失败则返回null
        /// 格式顺序：yyyyMMddHHmmss（年月日小时分钟秒）
        /// </summary>
        /// <param name="DateTypes">日期类型（标志枚举）</param>
        /// <returns>转换后的字符串</returns>
        public static string DateTypeToDateString(DateType DateTypes)
        {
            string result = null;

            //按照yyyyMMddHHmmss（年月日小时分钟秒）顺序生成字符串
            DateTime Date = DateTime.Now;
            if (0 != (DateTypes & DateType.Year))
            {
                result += Date.ToString("yyyy");
            }
            else { }
            if (0 != (DateTypes & DateType.Month))
            {
                result += Date.ToString("MM");
            }
            else { }
            if (0 != (DateTypes & DateType.Day))
            {
                result += Date.ToString("dd");
            }
            else { }
            if (0 != (DateTypes & DateType.Hour))
            {
                result += Date.ToString("HH");
            }
            else { }
            if (0 != (DateTypes & DateType.Minute))
            {
                result += Date.ToString("mm");
            }
            else { }
            if (0 != (DateTypes & DateType.Second))
            {
                result += Date.ToString("ss");
            }
            else { }

            return result;
        }

        /// <summary>
        /// 按照指定日期格式顺序将标志枚举DataType转换为字符串，返回转换后的字符串
        /// 转换失败则返回null
        /// 格式顺序：yyyy/MM/dd/HH/mm/ss/（年月日小时分钟秒）
        /// </summary>
        /// <param name="DateTypes">日期类型（标志枚举）</param>
        /// <returns>转换后的字符串</returns>
        public static string DateTypeToDateTreeString(DateType DateTypes)
        {
            string result = null;

            //按照yyyy/MM/dd/HH/mm/ss/（年月日小时分钟秒）顺序生成字符串
            DateTime Date = DateTime.Now;
            if (0 != (DateTypes & DateType.Year))
            {
                result += (Date.ToString("yyyy") + "/");
            }
            else { }
            if (0 != (DateTypes & DateType.Month))
            {
                result += (Date.ToString("MM") + "/");
            }
            else { }
            if (0 != (DateTypes & DateType.Day))
            {
                result += (Date.ToString("dd") + "/");
            }
            else { }
            if (0 != (DateTypes & DateType.Hour))
            {
                result += (Date.ToString("HH") + "/");
            }
            else { }
            if (0 != (DateTypes & DateType.Minute))
            {
                result += (Date.ToString("mm") + "/");
            }
            else { }
            if (0 != (DateTypes & DateType.Second))
            {
                result += (Date.ToString("ss") + "/");
            }
            else { }

            return result;
        }

        /// <summary>
        /// 按照Http请求数据类型枚举HttpContentType转换为ContentType字符串
        /// </summary>
        /// <param name="HttpContentTypes">Http请求数据类型</param>
        /// <returns>ContentType字符串</returns>
        public static string HttpContentTypeToContentTypeString(HttpContentType HttpContentTypes)
        {
            string result = null;

            switch(HttpContentTypes)
            {
                case HttpContentType.UrlEncoded:
                    result = "application/x-www-form-urlencoded";
                    break;
            }

            return result;
        }
    }
}
