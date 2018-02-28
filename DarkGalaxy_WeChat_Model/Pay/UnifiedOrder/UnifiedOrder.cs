using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat支付统一下单的Model类
    /// </summary>
    [DataContract]
    [XmlRoot(ElementName = "xml")]
    public class UnifiedOrder
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [DataMember]
        public string appid;

        /// <summary>
        /// 商户号
        /// </summary>
        [DataMember]
        public string mch_id;

        /// <summary>
        /// 设备号
        /// </summary>
        [DataMember]
        public string device_info = "WEB";

        /// <summary>
        /// 随机字符串
        /// </summary>
        [DataMember]
        public string nonce_str;

        /// <summary>
        /// 签名
        /// </summary>
        [DataMember]
        public string sign;

        /// <summary>
        /// 签名类型
        /// </summary>
        [DataMember]
        public string sign_type;

        /// <summary>
        /// 商品描述
        /// </summary>
        [DataMember]
        public string body;

        /// <summary>
        /// 商品详情
        /// </summary>
        [DataMember]
        public string detail;

        /// <summary>
        /// 附加数据
        /// </summary>
        [DataMember]
        public string attach;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [DataMember]
        public string out_trade_no;

        /// <summary>
        /// 标价币种
        /// </summary>
        [DataMember]
        public string fee_type = "CNY";

        /// <summary>
        /// 标价金额（单位：分）
        /// </summary>
        [DataMember]
        public int total_fee;

        /// <summary>
        /// 终端IP
        /// </summary>
        [DataMember]
        public string spbill_create_ip;

        /// <summary>
        /// 交易起始时间（格式：yyyyMMddHHmmss）
        /// </summary>
        [DataMember]
        public string time_start;

        /// <summary>
        /// 交易结束时间（格式：yyyyMMddHHmmss）
        /// </summary>
        [DataMember]
        public string time_expire;

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        [DataMember]
        public string goods_tag;

        /// <summary>
        /// 通知地址
        /// </summary>
        [DataMember]
        public string notify_url;

        /// <summary>
        /// 交易类型
        /// </summary>
        [DataMember]
        public string trade_type;

        /// <summary>
        /// 商品ID
        /// </summary>
        [DataMember]
        public string product_id;

        /// <summary>
        /// 指定支付方式
        /// </summary>
        [DataMember]
        public string limit_pay;

        /// <summary>
        /// 用户标识
        /// </summary>
        [DataMember]
        public string openid;

        /// <summary>
        /// 场景信息（UnifiedOrder_Scene类对象的Json字符串）
        /// </summary>
        [DataMember]
        public string scene_info;

        /// <summary>
        /// 无参构造方法
        /// </summary>
        protected UnifiedOrder()
        {

        }

        /// <summary>
        /// 构造方法，初始化必填参数
        /// </summary>
        /// <param name="appID">公众账号ID</param>
        /// <param name="mchID">商户号</param>
        /// <param name="nonceStr">随机字符串</param>
        /// <param name="body">商品描述</param>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="money">标价金额</param>
        /// <param name="ip">终端IP</param>
        /// <param name="url">通知地址</param>
        /// <param name="payTypes">交易类型</param>
        /// <param name="parameter">交易类型对应必填参数（公众号支付为OpenID，扫码支付为商品ID）</param>
        /// <param name="signatureTypes">签名类型</param>
        public UnifiedOrder(string appID, string mchID, string nonceStr, string body, string outTradeNo, int money, string ip, string url, PayType payTypes, string parameter = null, PaySignatureType signatureTypes = PaySignatureType.MD5)
        {
            appid = appID;
            mch_id = mchID;
            if (32 < nonceStr.Length)
            {
                nonce_str = nonceStr.Substring(0, 32);
            }
            else
            {
                nonce_str = nonceStr;
            }
            this.body = body;
            if (32 < outTradeNo.Length)
            {
                out_trade_no = outTradeNo.Substring(0, 32);
            }
            else
            {
                out_trade_no = outTradeNo;
            }
            total_fee = money;
            spbill_create_ip = ip;
            notify_url = url;
            trade_type = Enum.GetName(typeof(PayType), payTypes);
            if(PayType.JSAPI == payTypes)
            {
                openid = parameter;
            }
            else if(PayType.NATIVE == payTypes)
            {
                product_id = parameter;
            }
            else { }
            sign_type = Enum.GetName(typeof(PaySignatureType), signatureTypes);
        }
    }
}
