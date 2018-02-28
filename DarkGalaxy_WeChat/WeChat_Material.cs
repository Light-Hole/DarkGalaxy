using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using DarkGalaxy_WeChat_Model;
using System;
using System.Collections.Generic;

namespace DarkGalaxy_WeChat
{
    /// <summary>
    /// WeChat素材
    /// 提供一系列对于WeChat素材的操作
    /// </summary>
    public class WeChat_Material
    {
        /// <summary>
        /// 发送Http请求删除永久素材，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="materialMediaIDModel">永久素材ID</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public ResultCode DeletePermanentMaterial(MaterialMediaID materialMediaIDModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            ResultCode result = null;

            //获取删除永久素材地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/del_material?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //删除永久素材
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(materialMediaIDModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<ResultCode>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取永久图文素材，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="materialMediaIDModel">永久素材ID</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public MaterialSelect_News SelectPermanentMaterial_News(MaterialMediaID materialMediaIDModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            MaterialSelect_News result = null;

            //获取永久素材地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/get_material?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //获取素材列表
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(materialMediaIDModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<MaterialSelect_News>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取永久视频素材，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="materialMediaIDModel">永久素材ID</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public MaterialSelect_Video SelectPermanentMaterial_Video(MaterialMediaID materialMediaIDModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            MaterialSelect_Video result = null;

            //获取永久素材地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/get_material?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //获取素材列表
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(materialMediaIDModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<MaterialSelect_Video>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取素材数量，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <returns>WeChat服务端返回的数据</returns>
        public MaterialCount SelectMaterialCount()
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            MaterialCount result = null;

            //获取素材数量请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/get_materialcount?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //发送Http请求，获取服务端回发数据
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.GET, HttpContentType.UrlEncoded);
            result = Helper_Serializer_Json.JsonDeserializer<MaterialCount>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取图文素材列表，返回WeChat服务端返回的数据
        /// 请求失败则返回null
        /// </summary>
        /// <param name="offSet">素材偏移位置</param>
        /// <param name="count">素材数量</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public MaterialList_ResultNews SelectMaterialList_News(int offSet, int count)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (0 > offSet) || (0 > count) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)))
            {
                return null;
            }
            else { }

            MaterialList_ResultNews result = null;

            //获取图文素材列表请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/batchget_material?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //获取图文素材列表
            MaterialList wmodMaterialList = new MaterialList(MaterialType.news, offSet, count);
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(wmodMaterialList);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<MaterialList_ResultNews>(strResponseContent);

            return result;
        }

        /// <summary>
        /// 发送Http请求获取非图文素材列表，返回WeChat服务端返回的数据
        /// 该方法无法获取图文素材列表，如需获取图文素材列表请使用GetNewsMaterialList方法
        /// 请求失败则返回null
        /// </summary>
        /// <param name="materialListModel">素材列表</param>
        /// <returns>WeChat服务端返回的数据</returns>
        public MaterialList_Result SelectMaterialList_NotNews(MaterialList materialListModel)
        {
            //处理错误参数
            if ((null == WeChat_Basicinfo.AccessToken) || (String.IsNullOrEmpty(WeChat_Basicinfo.AccessToken.access_token)) || (0 == String.Compare("news", materialListModel.type, true)))
            {
                return null;
            }
            else { }

            MaterialList_Result result = null;

            //获取素材列表请求地址
            string strUrl = WeChat_Basicinfo.APIUrl + "/cgi-bin/material/batchget_material?access_token={0}";
            strUrl = String.Format(strUrl, WeChat_Basicinfo.AccessToken.access_token);

            //获取素材列表
            string strRequestContent = Helper_Serializer_Json.JsonSerializer(materialListModel);
            string strResponseContent = Helper_Http.SendHttpRequest(strUrl, HttpMethodType.POST, HttpContentType.UrlEncoded, strRequestContent);
            result = Helper_Serializer_Json.JsonDeserializer<MaterialList_Result>(strResponseContent);

            return result;
        }
    }
}
