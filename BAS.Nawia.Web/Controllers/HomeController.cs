using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAS.Nawia.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult UserDissertations()
        {
            return PartialView();
        }

        public ActionResult UserSuggestTopic()
        {
            return PartialView();
        }

    }
}