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
    public class SubjectController : ApiController
    {
        private ISubjectService sService;
        private IUserService uService;
        private IThesisService tService;
        private IStageService stService;

        public SubjectController(ISubjectService sservice, IUserService uservice, IThesisService tservice, IStageService stservice)
        {
            this.sService = sservice;
            this.uService = uservice;
            this.tService = tservice;
            this.stService = stservice;
        }

        // GET api/subject
        public IHttpActionResult Get()
        {
            return Ok(sService.GetAll());
        }

        // GET api/subject/5
        public IHttpActionResult Get(int id)
        {
            var subject = sService.Get(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // POST api/subject
        public void Post([FromBody]SubjectModel value)
        {
            value.Status = SubjectStatus.Submitted;
            value.OwnerId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(HttpContext.Current.User.Identity).ToString();
            value.CreationDate = DateTime.Now;
            value.isVisible = false;
            var scope = new List<string>();
            var scopepl = new List<string>();
            foreach(var i in value.Scope)
            {
                if (i != "")
                {
                    scope.Add(i);
                    scopepl.Add(i);
                }
            }
            value.Scope = scope;
            value.ScopePL = scopepl;
            sService.InsertSubject(value);
        }

        // PUT api/subject
        public void Put([FromBody]SubjectModel value)
        {
            value = sService.Get(value.SubjectId);
            string studentid = value.OwnerId;
            value.isVisible = true;
            value.Status = SubjectStatus.Approved;
            value.OwnerId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(HttpContext.Current.User.Identity).ToString();
            sService.UpdateSubject(value);
            var stage = stService.Get(2);
            ThesisModel tm = new ThesisModel { isVisible = true, Status = ThesisStatus.Assigned, Subject = value, Type = ThesisType.Bachelor, Supervisor = uService.Get(value.OwnerId), Student = uService.Get(studentid), Stage = stage };
            tService.InsertThesis(tm);
        }

        // DELETE api/subject/5
        public void Delete(int id)
        {
            sService.Delete(id);
        }
    }
}
