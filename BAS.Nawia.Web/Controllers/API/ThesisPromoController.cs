using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BAS.Nawia.Web.Controllers.API
{
    public class ThesisPromoController : ApiController
    {
        private IThesisService tService;
        private ISubjectService sService;

        public ThesisPromoController(IThesisService tservice, ISubjectService sservice)
        {
            this.tService = tservice;
            this.sService = sservice;
        }


        public IHttpActionResult Get(string id)
        {
            var thesis = tService.GetThesisBySupervisor(id);
            if (thesis == null)
            {
                return NotFound();
            }
            return Ok(thesis);
        }

        public IHttpActionResult Post([FromBody]SubjectModel value)
        {
            value.Status = SubjectStatus.Approved;
            value.OwnerId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(HttpContext.Current.User.Identity).ToString();
            value.CreationDate = DateTime.Now;
            value.isVisible = true;
            var scope = new List<string>();
            var scopepl = new List<string>();
            foreach (var i in value.Scope)
            {
                if (i != "")
                {
                    scope.Add(i);
                    scopepl.Add(i);
                }
            }
            value.Scope = scope;
            value.ScopePL = scopepl;
            var subjectid = sService.InsertSubject(value);
            return Ok(subjectid);
        }
    }
}
