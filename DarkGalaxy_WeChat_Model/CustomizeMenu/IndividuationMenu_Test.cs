using System.Runtime.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// 个性菜单测试的Model类
    /// </summary>
    [DataContract]
    public class IndividuationMenu_Test
    {
        /// <summary>
        /// 用户OpenID或者WeChat帐号
        /// </summary>
        [DataMember]
        public string user_id;

        /// <summary>
        /// 构造函数，初始化必填参数
        /// </summary>
        /// <param name="userID">用户ID</param>
        public IndividuationMenu_Test(string userID)
        {
            user_id = userID;
        }
    }
}
