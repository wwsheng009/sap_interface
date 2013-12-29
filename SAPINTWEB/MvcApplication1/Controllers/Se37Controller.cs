using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SAPINT.Function;
using SAPINT.Function.Json;
using SAPINTDB.DbHelper;

namespace MvcApplication1.Controllers
{
    public class Se37Controller : Controller
    {
        string targetSystem = ConfigFileTool.SAPGlobalSettings.GetDefaultSapCient();
        //string targetSystem = "AIP";
        public ContentResult fun(string type, string funame)
        {
            string output = "";
            funame = funame.ToUpper();
            if (funame == "")
            {


            }
            SAPFunctionJson.GetFuncMeta(targetSystem, funame, out output);

            // return Json(output, JsonRequestBehavior.AllowGet);
            return Content(output, "text/html");
        }

        //在table上分页显示保存的数据
        [HttpPost]
        public ContentResult GetData(int page, int rows)
        {
            var funame = Request.QueryString["funame"];
            var tblname = Request.QueryString["tablename"];
            var output = SqliteReadTable.read(funame, tblname, page, rows);

            //用Content的方式把Json 字符串返回，否则双引号会被转义
            return Content(output, "text/html");
        }

        //查询RFC函数列表
        public ContentResult getFuncList(string funcname)
        {
            try
            {
                var output = SqliteReadTable.GetRFCList(targetSystem, funcname);
                if (string.IsNullOrEmpty(output))
                {
                    if (funcname.Length>=3)
                    {
                        SAPFunction.GetRFCfunctionListAndSaveToDb(targetSystem, funcname);
                        output = SqliteReadTable.GetRFCList(targetSystem, funcname);
                    }
                   
                }
                // output = "{" + output + "}";
                return Content(output, "text/html");
            }
            catch (Exception ex)
            {
                var message = JsonConvert.SerializeObject(ex.Message);
                message = "{error:" + message + "}";
                return Content(message, "text/html");
            }

        }


        // GET: /SAP/
        public ActionResult Index()
        {
            return View();
        }

        //查询函数
        [HttpPost]
        public JsonResult Post(string jsondata, string funame)
        {
            jsondata = Server.UrlDecode(jsondata);
            var output = SAPFunctionJson.PostJson(targetSystem, funame, jsondata);
            return Json(output);
        }

        //get the server status
        public ContentResult SeverInfo()
        {
            var output = SAPFunctionJson.GetSever(targetSystem).ToString();
            return Content(output, "text/html");
        }

    }
}
