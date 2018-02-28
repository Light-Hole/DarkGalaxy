using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat素材列表的Model类
    /// </summary>
    [DataContract]
    public class MaterialList
    {
        /// <summary>
        /// 素材类型
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// 素材偏移位置
        /// </summary>
        [DataMember]
        public int offset;

        /// <summary>
        /// 素材数量（1-20）
        /// </summary>
        [DataMember]
        public int count;

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="materialTypes">素材类型</param>
        /// <param name="offSet">素材偏移位置</param>
        /// <param name="count">素材数量</param>
        public MaterialList(MaterialType materialTypes, int offSet, int count)
        {
            type = Enum.GetName(typeof(MaterialType), materialTypes);
            offset = offSet;
            if(1 > count)
            {
                this.count = 1;
            }
            else if(20 < count)
            {
                this.count = 20;
            }
            else
            {
                this.count = count;
            }
        }
    }
}
