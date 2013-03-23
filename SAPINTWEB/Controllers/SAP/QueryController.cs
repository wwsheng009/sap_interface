namespace MvcSapInterface.Controllers.SAP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SAPINT;
    using SAPINT.Function;

    public class QueryController : Controller
    {
        #region Methods

        //
        // GET: /Query/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ContentResult login()
        {
            
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var client = Request.Form["client"];
            var language = Request.Form["lang"];
            SAPFunction.login(username, password, client, language);
            return Content("{\"name\":\"" + username + "\",\"password\":\"" + password  + "\"}", "text/html");
        }

        public ActionResult Query()
        {

           // return View("index.html");
            return View("query1");
        }
        #endregion Methods
    }
}