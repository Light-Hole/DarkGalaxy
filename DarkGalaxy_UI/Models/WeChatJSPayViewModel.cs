using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkGalaxy_UI.Models
{
    /// <summary>
    /// WeChatJSPay的ViewModel类
    /// </summary>
    public class WeChatJSPayViewModel
    {
        /// <summary>
        /// JSApi配置信息
        /// </summary>
        public JSApiConfig JSConfigModel
        {
            get;
            set;
        }

        /// <summary>
        /// JSApi支付信息
        /// </summary>
        public JSPay JSPayModel
        {
            get;
            set;
        }

        /// <summary>
        /// 订单总价（单位：分）
        /// </summary>
        public int OrderTotal
        {
            get;
            set;
        }
    }
}