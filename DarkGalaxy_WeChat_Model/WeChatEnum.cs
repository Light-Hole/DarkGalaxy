namespace DarkGalaxy_WeChat_Model
{
    /// <summary>
    /// WeChat自定义菜单事件类型
    /// </summary>
    public enum CustomizeMenusEventType
    {
        /// <summary>
        /// 点击推事件
        /// </summary>
        click,
        /// <summary>
        /// 跳转URL
        /// </summary>
        view,
        /// <summary>
        /// 扫描二维码
        /// </summary>
        scancode_push,
        /// <summary>
        /// 扫描二维码弹出提示消息
        /// </summary>
        scancode_waitmsg,
        /// <summary>
        /// 弹出系统拍照发图
        /// </summary>
        pic_sysphoto,
        /// <summary>
        /// 弹出拍照或者相册发图
        /// </summary>
        pic_photo_or_album,
        /// <summary>
        /// 弹出微信相册发图器
        /// </summary>
        pic_weixin,
        /// <summary>
        /// 弹出地理位置选择器
        /// </summary>
        location_select,
        /// <summary>
        /// 下发消息
        /// </summary>
        media_id,
        /// <summary>
        /// 跳转图文消息URL
        /// </summary>
        view_limited
    }

    /// <summary>
    /// WeChat的JSApi接口类型
    /// </summary>
    public enum JSApiType
    {
        /// <summary>
        /// 分享到朋友圈
        /// </summary>
        onMenuShareTimeline,
        /// <summary>
        /// 分享给朋友
        /// </summary>
        onMenuShareAppMessage,
        /// <summary>
        /// 分享到QQ
        /// </summary>
        onMenuShareQQ,
        /// <summary>
        /// 分享到微博
        /// </summary>
        onMenuShareWeibo,
        /// <summary>
        /// 分享到QQ空间
        /// </summary>
        onMenuShareQZone,
        /// <summary>
        /// 开始录音
        /// </summary>
        startRecord,
        /// <summary>
        /// 结束录音
        /// </summary>
        stopRecord,
        /// <summary>
        /// 监听录音自动停止
        /// </summary>
        onVoiceRecordEnd,
        /// <summary>
        /// 播放语音
        /// </summary>
        playVoice,
        /// <summary>
        /// 暂停播放语音
        /// </summary>
        pauseVoice,
        /// <summary>
        /// 停止播放语音
        /// </summary>
        stopVoice,
        /// <summary>
        /// 监听语音播放完毕
        /// </summary>
        onVoicePlayEnd,
        /// <summary>
        /// 上传语音
        /// </summary>
        uploadVoice,
        /// <summary>
        /// 下载语音
        /// </summary>
        downloadVoice,
        /// <summary>
        /// 选择图片
        /// </summary>
        chooseImage,
        /// <summary>
        /// 预览图片
        /// </summary>
        previewImage,
        /// <summary>
        /// 上传图片
        /// </summary>
        uploadImage,
        /// <summary>
        /// 下载图片
        /// </summary>
        downloadImage,
        /// <summary>
        /// 翻译语音
        /// </summary>
        translateVoice,
        /// <summary>
        /// 获取网络类型
        /// </summary>
        getNetworkType,
        /// <summary>
        /// 打开地理位置
        /// </summary>
        openLocation,
        /// <summary>
        /// 获取地理位置
        /// </summary>
        getLocation,
        /// <summary>
        /// 隐藏按钮
        /// </summary>
        hideOptionMenu,
        /// <summary>
        /// 显示按钮
        /// </summary>
        showOptionMenu,
        /// <summary>
        /// 批量隐藏按钮
        /// </summary>
        hideMenuItems,
        /// <summary>
        /// 批量显示按钮
        /// </summary>
        showMenuItems,
        /// <summary>
        /// 隐藏所有非基础接口按钮
        /// </summary>
        hideAllNonBaseMenuItem,
        /// <summary>
        /// 显示所有功能按钮
        /// </summary>
        showAllNonBaseMenuItem,
        /// <summary>
        /// 关闭窗口
        /// </summary>
        closeWindow,
        /// <summary>
        /// 微信扫一扫
        /// </summary>
        scanQRCode,
        /// <summary>
        /// 微信支付
        /// </summary>
        chooseWXPay,
        /// <summary>
        /// 跳转微信商品页
        /// </summary>
        openProductSpecificView,
        /// <summary>
        /// 添加卡劵
        /// </summary>
        addCard,
        /// <summary>
        /// 选择卡劵
        /// </summary>
        chooseCard,
        /// <summary>
        /// 查看卡劵
        /// </summary>
        openCard,
    }

    /// <summary>
    /// WeChat的素材类型
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// 图片
        /// </summary>
        image,
        /// <summary>
        /// 视频
        /// </summary>
        video,
        /// <summary>
        /// 语音
        /// </summary>
        voice,
        /// <summary>
        /// 图文
        /// </summary>
        news
    }

    /// <summary>
    /// WeChat支付类型
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 公众号支付
        /// </summary>
        JSAPI,
        /// <summary>
        /// 原生扫码支付
        /// </summary>
        NATIVE,
        /// <summary>
        /// APP支付
        /// </summary>
        APP,
        /// <summary>
        /// 刷卡支付
        /// </summary>
        MICROPAY
    }

    /// <summary>
    /// WeChat支付订单号类型
    /// </summary>
    public enum PayOrderNumberType
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        WeChat,
        /// <summary>
        /// 商户订单号
        /// </summary>
        Merchant
    }

    /// <summary>
    /// 红包场景类型
    /// </summary>
    public enum RedPacketSceneType
    {
        /// <summary>
        /// 商品促销
        /// </summary>
        PRODUCT_1,
        /// <summary>
        /// 抽奖
        /// </summary>
        PRODUCT_2,
        /// <summary>
        /// 虚拟物品兑奖
        /// </summary>
        PRODUCT_3,
        /// <summary>
        /// 企业内部福利
        /// </summary>
        PRODUCT_4,
        /// <summary>
        /// 渠道分润
        /// </summary>
        PRODUCT_5,
        /// <summary>
        /// 保险回馈
        /// </summary>
        PRODUCT_6,
        /// <summary>
        /// 彩票派奖
        /// </summary>
        PRODUCT_7,
        /// <summary>
        /// 税务刮奖
        /// </summary>
        PRODUCT_8
    }

    /// <summary>
    /// WeChat退款订单号类型
    /// </summary>
    public enum RefundOrderNumberType
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        WeChat,
        /// <summary>
        /// 商户订单号
        /// </summary>
        Merchant,
        /// <summary>
        /// 微信退款订单号
        /// </summary>
        WeChatRefund,
        /// <summary>
        /// 商户退款订单号
        /// </summary>
        MerchantRefund
    }

    /// <summary>
    /// WeChat支付签名类型
    /// </summary>
    public enum PaySignatureType
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        MD5,
        /// <summary>
        /// SHA1加密
        /// </summary>
        SHA1
    }

    /// <summary>
    /// WeChat二维码类型
    /// </summary>
    public enum QRCodeType
    {
        /// <summary>
        /// 临时的整型参数值
        /// </summary>
        QR_SCENE,
        /// <summary>
        /// 临时的字符串参数值
        /// </summary>
        QR_STR_SCENE,
        /// <summary>
        /// 永久的整型参数值
        /// </summary>
        QR_LIMIT_SCENE,
        /// <summary>
        /// 永久的字符串参数值
        /// </summary>
        QR_LIMIT_STR_SCENE
    }

    /// <summary>
    /// WeChat网页授权类型
    /// </summary>
    public enum WebAuthorizationType
    {
        /// <summary>
        /// 不弹出授权页面，直接跳转，只能获取用户openid
        /// </summary>
        snsapi_base,
        /// <summary>
        /// 弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息
        /// </summary>
        snsapi_userinfo
    }
}
