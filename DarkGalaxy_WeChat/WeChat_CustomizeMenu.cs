using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat自定义菜单
    /// 提供一系列对于WeChat自定义菜单的操作
    /// </summary>
    public class WeChat_CustomizeMenu
    {
        /// <summary>
        /// 发送Http请求创建自定义菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="jsonString">自定义菜单Json数据</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode CreateCustomizeMenu(string jsonString)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(jsonString)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取创建自定义菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/create?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //创建自定义菜单
            string strRequestContent = jsonString;
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求创建自定义菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="customizeMenuModel">自定义菜单</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode CreateCustomizeMenu(CustomizeMenu customizeMenuModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (null == customizeMenuModel) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取创建自定义菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/create?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //创建自定义菜单
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(customizeMenuModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求删除自定义菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode DeleteCustomizeMenu()
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取删除自定义菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/delete?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //删除自定义菜单
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求查询自定义菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        public CustomizeMenuSelect_Result SelectCustomizeMenu()
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            CustomizeMenuSelect_Result result = null;

            //获取查询自定义菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/get?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //查询自定义菜单
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<CustomizeMenuSelect_Result>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求查询自定义菜单Json数据，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        public string SelectCustomizeMenuJson()
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            string result = null;

            //获取查询自定义菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/get?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //查询自定义菜单Json数据
            result = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);

            return result;
        }

        /// <summary>
        /// 发送Http请求创建个性化菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="jsonString">个性化菜单Json数据</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public IndividuationMenu_MenuID CreateIndividuationMenu(string jsonString)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(jsonString)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            IndividuationMenu_MenuID result = null;

            //获取创建个性化菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/addconditional?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //创建个性化菜单
            string strRequestContent = jsonString;
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<IndividuationMenu_MenuID>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求创建个性化菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="individuationMenuModel">个性化菜单</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public IndividuationMenu_MenuID CreateIndividuationMenu(IndividuationMenu individuationMenuModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (null == individuationMenuModel) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            IndividuationMenu_MenuID result = null;

            //获取创建个性化菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/addconditional?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //创建个性化菜单
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(individuationMenuModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<IndividuationMenu_MenuID>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求删除个性化菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="jsonString">个性化菜单ID的Json数据</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode DeleteIndividuationMenu(string jsonString)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(jsonString)) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取删除个性化菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/delconditional?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //删除个性化菜单
            string strRequestContent = jsonString;
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求删除个性化菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="individuationMenuIDModel">个性化菜单ID</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode DeleteIndividuationMenu(IndividuationMenu_MenuID individuationMenuIDModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (null == individuationMenuIDModel) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取删除个性化菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/delconditional?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //删除个性化菜单
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(individuationMenuIDModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求测试个性化菜单，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="individuationMenuTestModel">个性化菜单测试</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public CustomizeMenu TestIndividuationMenu(IndividuationMenu_Test individuationMenuTestModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (null == individuationMenuTestModel) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            CustomizeMenu result = null;

            //获取测试个性化菜单请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/menu/trymatch?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //测试个性化菜单
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(individuationMenuTestModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<CustomizeMenu>(strResponseContent);

            return result;
        }
    }
}
