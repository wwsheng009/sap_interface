namespace MvcSapInterface.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using MvcSapInterface;

    public class HomeController : Controller
    {
        #region Methods

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        #endregion Methods
    }
}