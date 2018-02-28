using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat数据统计
    /// 提供一系列对于WeChat数据统计的操作
    /// </summary>
    public class WeChat_DataStatistics
    {
        /// <summary>
        /// 发送Http请求分析用户数据总数量，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="userAnalyzeModel"></param>
        /// <returns>WeChat服务端返回的数据</returns>
        public UserAnalyze_ResultCumulate UserAnalyzeCumulate(UserAnalyze userAnalyzeModel)
        {
            //处理错误参数
            if (null == userAnalyzeModel)
            {
                return null;
            }
            else { }

            UserAnalyze_ResultCumulate result = null;

            //获取分析用户数据总数量的请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/datacube/getusercumulate?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //分析用户数据总数量
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(userAnalyzeModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<UserAnalyze_ResultCumulate>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求分析用户数据增减数量，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="userAnalyzeModel"></param>
        /// <returns>WeChat服务端返回的数据</returns>
        public UserAnalyze_ResultSummary UserAnalyzeSummary(UserAnalyze userAnalyzeModel)
        {
            //处理错误参数
            if(null == userAnalyzeModel)
            {
                return null;
            }
            else { }

            UserAnalyze_ResultSummary result = null;

            //获取分析用户数据增减数量的请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/datacube/getusersummary?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //分析用户数据增减数量
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(userAnalyzeModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<UserAnalyze_ResultSummary>(strResponseContent);

            return result;
        }
    }
}
