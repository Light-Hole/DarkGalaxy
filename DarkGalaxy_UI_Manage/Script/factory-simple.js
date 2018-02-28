//微信菜单类型简单工厂
function wechatMenuGenreSimple(genre) {
    var result = '未知类型';
    switch (genre) {
        case 'click':
            result = '点击';
            break;
        case 'view':
            result = '网页链接';
            break;
        case 'scancode_push':
            result = '扫描二维码';
            break;
        case 'scancode_waitmsg':
            result = '扫描二维码（弹出消息框）';
            break;
        case 'pic_sysphoto':
            result = '拍摄照片';
            break;
        case 'pic_photo_or_album':
            result = '拍摄照片/相册图片';
            break;
        case 'pic_weixin':
            result = '相册图片';
            break;
        case 'ocation_select':
            result = '地理位置';
            break;
        case 'media_id':
            result = '媒体消息';
            break;
        case 'view_limited':
            result = '图文消息';
            break;
        case 'miniprogram':
            result = '小程序';
            break;
        default:
            break;
    }
    return result;
}

//微信菜单启用状态简单工厂
function wechatMenuEmploySimple(employ) {
    var result = '未知状态';
    switch (employ) {
        case true:
            result = '已启用';
            break;
        case false:
            result = '未启用';
            break;
        default:
            break;
    }
    return result;
}

//订单状态简单工厂
function orderStatusSimple(status) {
    var result = '未知状态';
    switch (status) {
        case 0:
            result = '待付款';
            break;
        case 10:
            result = '订单关闭';
            break;
        case 11:
            result = '订单关闭（超时）';
            break;
        case 20:
            result = '已支付';
            break;
        case 30:
            result = '待发货';
            break;
        case 32:
            result = '已发货';
            break;
        case 40:
            result = '已收货';
            break;
        case 41:
            result = '已收货（超时）';
            break;
        case 50:
            result = '待评价';
            break;
        case 51:
            result = '已评价（超时）';
            break;
        case 52:
            result = '已评价';
            break;
        case 60:
            result = '待退款';
            break;
        case 61:
            result = '退款超时';
            break;
        case 62:
            result = '已退款';
            break;
        case 63:
            result = '退款关闭';
            break;
        case 64:
            result = '未退款';
            break;
        case 80:
            resize = "完成";
            break;
        default:
            break;
    }
    return result;
}

//订单状态工具栏按钮简单工厂
function orderStatusButtonSimple(status) {
    var result = '<button class="layui-btn layui-btn-xs" lay-event="details"><i class="layui-icon">&#xe63c;</i>详细信息</button>';
    var button = null;
    switch (status) {
        case 52:
            button = '<button class="layui-btn layui-btn-xs layui-btn-normal" lay-event="evaluateAudit"><i class="layui-icon">&#xe63c;</i>评价审核</button>'
            result = (button + result);
            break;
        case 60:
            button = '<button class="layui-btn layui-btn-xs layui-btn-normal" lay-event="refundAudit"><i class="layui-icon">&#xe63c;</i>退款审核</button>'
            result = (button + result);
            break;
        case 62:
        case 64:
            button = '<button class="layui-btn layui-btn-xs" lay-event="detailsRefund"><i class="layui-icon">&#xe63c;</i>退款详情</button>'
            result = (button + result);
            break;
        default:
            break;
    }
    return result;
}
