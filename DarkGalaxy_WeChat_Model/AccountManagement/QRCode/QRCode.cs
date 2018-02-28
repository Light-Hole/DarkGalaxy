using System;
using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 二维码的Model类
    /// </summary>
    [DataContract]
    public class QRCode
    {
        private int _expire_seconds = 30;

        /// <summary>
        /// 二维码有效时间（单位：秒）
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int expire_seconds
        {
            get
            {
                return _expire_seconds;
            }
            set
            {
                if (2592000 < value)
                {
                    _expire_seconds = 2592000;
                }
                else if(0 >= value)
                {
                    _expire_seconds = 1;
                }
                else
                {
                    _expire_seconds = value;
                }
            }
        }

        /// <summary>
        /// 二维码类型
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string action_name;

        /// <summary>
        /// 二维码详细信息
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public QRCode_Info action_info;

        /// <summary>
        /// 构造函数，初始化二维码类型
        /// </summary>
        /// <param name="qrCodeTypes">二维码类型</param>
        public QRCode(QRCodeType qrCodeTypes)
        {
            action_name = Enum.GetName(typeof(QRCodeType), qrCodeTypes);
        }
    }

    /// <summary>
    /// 二维码详细信息的Model类
    /// </summary>
    [DataContract]
    public class QRCode_Info
    {
        /// <summary>
        /// 二维码场景值
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public QRCode_Scene scene;
    }

    /// <summary>
    /// 二维码场景值的Model类
    /// </summary>
    [DataContract]
    public class QRCode_Scene
    {
        private int _scene_id = 1;

        /// <summary>
        /// 场景值ID
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int scene_id
        {
            get
            {
                return _scene_id;
            }
            set
            {
                if (100000 < value)
                {
                    _scene_id = 100000;
                }
                else if (0 >= value)
                {
                    _scene_id = 1;
                }
                else
                {
                    _scene_id = value;
                }
            }
        }

        /// <summary>
        /// 场景值ID字符串
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string scene_str;
    }
}
