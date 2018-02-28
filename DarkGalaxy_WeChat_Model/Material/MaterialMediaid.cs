using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat素材ID的Model类
    /// </summary>
    [DataContract]
    public class MaterialMediaID : ResultCode
    {
        /// <summary>
        /// 素材ID
        /// </summary>
        [DataMember]
        public string media_id;
    }
}
