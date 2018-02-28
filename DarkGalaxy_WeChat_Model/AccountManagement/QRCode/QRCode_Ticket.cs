using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 二维码Ticket的Model类
    /// </summary>
    [DataContract]
    public class QRCode_Ticket
    {
        /// <summary>
        /// 获取二维码的ticket
        /// </summary>
        [DataMember]
        public string ticket;

        /// <summary>
        /// 二维码有效时间（单位：秒）
        /// </summary>
        [DataMember]
        public int expire_seconds;

        /// <summary>
        /// 二维码图片解析后的地址
        /// </summary>
        [DataMember]
        public string url;
    }
}
