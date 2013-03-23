namespace MvcSapInterface.Controllers.SAP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using SAPINT;
    using SAPINT.DbHelper;
    using SAPINT.Function;

    public class Se37Controller : Controller
    {
        #region Methods
        string targetSystem = "RET";
        
        public ContentResult fun(string type ,string funame)
        {
            string output = "";
            funame = funame.ToUpper();
            if (funame == "")
            {
                

            }
            SAPFunctionJson.GetFuncMeta(targetSystem, funame, out output);

           // return Json(output, JsonRequestBehavior.AllowGet);
           return Content(output,"text/html");
        }

        //在table上分页显示保存的数据
        [HttpPost]
        public ContentResult GetData(int page, int rows)
        {
            var dbname = Request.QueryString["funame"];
            var tblname = Request.QueryString["tablename"];
            var output = SqliteReadTable.read(dbname, tblname, page, rows);

            //用Content的方式把Json 字符串返回，否则双引号会被转义
            return Content(output,"text/html");
        }

        //查询RFC函数列表
        public ContentResult getFuncList(string funcname)
        {
            var output = SqliteReadTable.getRFCList(targetSystem, funcname);
            //output = "{" + output + "}";
            return Content(output, "text/html");
        }


        // GET: /SAP/
        public ActionResult Index()
        {
            return View();
        }

        //查询函数
        [HttpPost]
        public JsonResult Post(string jsondata,string funame)
        {
            jsondata = Server.UrlDecode(jsondata);
            var output = SAPFunctionJson.PostJson(targetSystem, funame, jsondata);
            return Json(output);
        }

        //get the server status
        public ContentResult SeverInfo()
        {
            var output = SAPFunctionJson.GetSever(targetSystem).ToString();
            return Content(output,"text/html");
        }
        
        #endregion Methods
    }
}