using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付统一下单场景值的Model类
    /// </summary>
    [DataContract]
    public class UnifiedOrder_Scene
    {
        /// <summary>
        /// 门店唯一标识
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// 门店名称
        /// </summary>
        [DataMember]
        public string name;

        /// <summary>
        /// 门店所在地行政区划码
        /// </summary>
        [DataMember]
        public string area_code;

        /// <summary>
        /// 门店详细地址
        /// </summary>
        [DataMember]
        public string address;
    }
}
