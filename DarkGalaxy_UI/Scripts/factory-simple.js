//订单状态文本简单工厂
function orderStatusTextSimple(status) {
    var result = '';
    switch (status) {
        case 0:
            result = '待付款';
            break;
        case 20:
            result = '已支付';
            break;
        case 50:
            result = '待评价'
            break;
        case 60:
            result = '待退款'
            break;
        case 61:
            result = '退款超时'
            break;
        case 62:
            result = '已退款'
            break;
        case 63:
            result = '退款关闭'
            break;
        case 64:
            result = '未退款'
            break;
        default:
            break;
    }
    return result;
}

//订单状态操作按钮简单工厂
function orderStatusBtuuonSimple(id, status) {
    var result = '';
    switch (status) {
        case 0://待付款
            result += ('<a href="javascript:void(0);" class="button button-round color-orange dgalaxy-btn order-payment" data-id="' + id + '">付款</a>');
            result += ('<a href="javascript:void(0);" class="button button-round color-gray dgalaxy-btn order-close" data-id="' + id + '">取消订单</a >');
            break;
        case 20://已支付
            result += ('<a href="javascript:void(0);" class="button button-round color-gray dgalaxy-btn order-refund" data-id="' + id + '">申请退款</a>');
            break;
        case 50://待评价
            result += ('<a href="javascript:void(0);" class="button button-round color-orange dgalaxy-btn order-evaluate" data-id="' + id + '">评价</a>');
            break;
        case 60:
        case 61:
        case 62:
        case 63:
        case 64:
            result += ('<a href="javascript:void(0);" class="button button-round color-orange dgalaxy-btn order-details" data-id="' + id + '">查看详情</a>');
            break;
        default:
            break;
    }
    return result;
}