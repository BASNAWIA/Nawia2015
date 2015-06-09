using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BAS.Nawia.Web.Controllers.Api
{
    public class StudentSubjectController : ApiController
    {
        private ISubjectService sService;
        private IThesisService tService;
        private IUserService uService;

        public StudentSubjectController(ISubjectService sservice, IThesisService tservice, IUserService uservice)
        {
            this.sService = sservice;
            this.tService = tservice;
            this.uService = uservice;
        }

        public IHttpActionResult Get()
        {
            SubjectStatus status = SubjectStatus.Submitted;
            var subjects = sService.GetSubjectByStatus(status);
            return Ok(subjects);
        }

        public void Put([FromBody]ThesisModel value)
        {
            var thmodel = tService.Get(value.ThesisId);
            thmodel.Student = uService.Get(Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(HttpContext.Current.User.Identity).ToString());
            tService.UpdateThesis(thmodel);
        }
    }
}
