using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAS.Nawia.Web.Controllers
{
    public class PromoController : Controller
    {
        public ActionResult MySubjects()
        {
            return PartialView();
        }

        public ActionResult StudentsSubjects()
        {
            return PartialView();
        }

        public ActionResult ThesisDetails()
        {
            return PartialView();
        }

        public ActionResult AddSubject()
        {
            return PartialView();
        }

    }
}