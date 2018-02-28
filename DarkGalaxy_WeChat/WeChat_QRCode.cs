using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat_Model;
using System;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat二维码
    /// 提供一系列对于WeChat二维码的操作
    /// </summary>
    public class WeChat_QRCode
    {
        /// <summary>
        /// 发送Http请求创建带参数的二维码Ticket，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="qrCodeModel">二维码</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public QRCode_Ticket CreateArgumentsQRCodeTicket(QRCode qrCodeModel)
        {
            //处理错误参数
            if ((null == qrCodeModel) || (null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            QRCode_Ticket result = null;

            //获取创建二维码Ticke的请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/qrcode/create?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //创建二维码的Ticket
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(qrCodeModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<QRCode_Ticket>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 创建获取二维码的Url，返回二维码Url
        /// 创建失败则返回null
        /// </summary>
        /// <param name="ticket">二维码的Ticket</param>
        /// <returns>二维码Url</returns>
        public string CreateArgumentsQRCodeUrl(string ticket)
        {
            //处理错误参数
            if (String.IsNullOrEmpty(ticket))
            {
                return null;
            }
            else { }

            string result = null;

            //获取创建二维码Ticke的请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/showqrcode?ticket={0}";
            result = String.Format(strUrl, ticket);

            return result;
        }

        /// <summary>
        /// 创建获取二维码的Url，返回二维码Url
        /// 创建失败则返回null
        /// </summary>
        /// <param name="ticketModel">二维码的Ticket</param>
        /// <returns>二维码Url</returns>
        public string CreateArgumentsQRCodeUrl(QRCode_Ticket ticketModel)
        {
            //处理错误参数
            if ((null == ticketModel) || (String.IsNullOrEmpty(ticketModel.ticket)))
            {
                return null;
            }
            else { }

            string result = null;

            //获取创建二维码Ticke的请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/showqrcode?ticket={0}";
            result = String.Format(strUrl, ticketModel.ticket);

            return result;
        }
    }
}
