using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_Model
{
    /// <summary>
    /// 性别类型
    /// </summary>
    public enum GenderType
    {
        /// <summary>
        /// 女性
        /// </summary>
        Female = 0,
        /// <summary>
        /// 男性
        /// </summary>
        Male = 1,
        /// <summary>
        /// 保密
        /// </summary>
        Secrecy = 2
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatusType
    {
        /// <summary>
        /// 待付款
        /// </summary>
        WaitPay = 0,
        /// <summary>
        /// 订单关闭
        /// </summary>
        Close = 10,
        /// <summary>
        /// 订单关闭（超时）
        /// </summary>
        CloseTimeout = 11,
        /// <summary>
        /// 已支付
        /// </summary>
        Pay = 20,
        /// <summary>
        /// 待发货
        /// </summary>
        Ship = 30,
        /// <summary>
        /// 已发货
        /// </summary>
        ShipFinish = 32,
        /// <summary>
        /// 已收货
        /// </summary>
        Receiv = 40,
        /// <summary>
        /// 已收货（超时）
        /// </summary>
        ReceivTimeout = 41,
        /// <summary>
        /// 待评价
        /// </summary>
        Evaluate = 50,
        /// <summary>
        /// 已评价（超时）
        /// </summary>
        EvaluateTimeout = 51,
        /// <summary>
        /// 已评价
        /// </summary>
        EvaluateFinish = 52,
        /// <summary>
        /// 待退款
        /// </summary>
        Refund = 60,
        /// <summary>
        /// 退款超时
        /// </summary>
        RefundTimeout = 61,
        /// <summary>
        /// 已退款
        /// </summary>
        RefundFinish = 62,
        /// <summary>
        /// 退款关闭
        /// </summary>
        RefundClose = 63,
        /// <summary>
        /// 未退款
        /// </summary>
        RefundReject = 64,
        /// <summary>
        /// 完成
        /// </summary>
        Finish = 80
    }

    /// <summary>
    /// 商品排序类型
    /// </summary>
    public enum CommoditySortType
    {
        /// <summary>
        /// 默认排序
        /// </summary>
        Default,
        /// <summary>
        /// 价格升序排序
        /// </summary>
        PriceAsc,
        /// <summary>
        /// 价格降序排序
        /// </summary>
        PriceDesc
    }
}
