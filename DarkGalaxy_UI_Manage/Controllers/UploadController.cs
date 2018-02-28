using DarkGalaxy_Common;
using DarkGalaxy_Common.DarkGalaxy;
using DarkGalaxy_Common.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkGalaxy_UI_Manage.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult UploadTempImage()
        {
            string result = null;

            //保存上传图片
            DGResultData<string> ResultJson = new DGResultData<string>();
            string strUrl = "http://admin.jiangshanjiaqi.com";
            string FileName = Guid.NewGuid().ToString().Replace("-", "");//文件名
            string FilePath = ConfigurationManager.AppSettings["UploadTempImagePath"];//上传路径
            string SavePath = Server.MapPath(FilePath);
            string UploadImagePath = Helper_File.SaveHttpUploadFile(SavePath, FileName, "file");
            if (!String.IsNullOrEmpty(UploadImagePath))
            {
                //图片安全校验
                switch (Helper_File.GetFileRealType(UploadImagePath))
                {
                    case FileType.BMP:
                    case FileType.GIF:
                    case FileType.JPG:
                    case FileType.PNG:
                        ResultJson.Data = (strUrl + FilePath + FileName + Path.GetExtension(UploadImagePath));
                        ResultJson.Code = ResultCodeType.Succeed;
                        ResultJson.Message = "上传成功！";
                        break;
                    default:
                        System.IO.File.Delete(UploadImagePath);
                        ResultJson.Code = ResultCodeType.UnknownError;
                        ResultJson.Message = "文件安全性未知，禁止上传！";
                        break;
                }
            }
            else { }

            result = Helper_Serializer_Json.JsonSerializer(ResultJson);

            return Content(result);
        }

        public ActionResult RichEditor()
        {
            LayuiEdit result = new LayuiEdit();

            //保存上传图片
            string strUrl = "http://admin.jiangshanjiaqi.com";
            if (null != Request.Files["file"])
            {
                var File = Request.Files["file"];
                string FilePath = Path.Combine("/Upload/LayuiEdit/", Guid.NewGuid().ToString() + File.FileName);
                string SavePath = Request.MapPath(FilePath);
                File.SaveAs(SavePath);

                //设置图片信息
                LayuiEditData data = new LayuiEditData()
                {
                    src = strUrl + FilePath,
                    title = File.FileName
                };
                result.data = data;
                result.code = 0;
                result.msg = "上传成功";
            }
            else { }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}