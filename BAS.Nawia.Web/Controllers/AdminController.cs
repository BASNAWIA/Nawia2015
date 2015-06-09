using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAS.Nawia.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Theses()
        {
            return PartialView();
        }

        public ActionResult Stages()
        {
            return PartialView();
        }

        public ActionResult Users()
        {
            return PartialView();
        }

    }
}