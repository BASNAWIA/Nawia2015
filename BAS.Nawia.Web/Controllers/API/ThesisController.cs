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
    public class ThesisController : ApiController
    {
        private IThesisService tService;
        private IUserService uService;
        private ISubjectService sService;
        private IStageService stService;

        public ThesisController(IThesisService tservice, IUserService uservice, ISubjectService sservice, IStageService stservice)
        {
            this.tService = tservice;
            this.uService = uservice;
            this.sService = sservice;
            this.stService = stservice;
        }

        // GET api/thesis
        public IHttpActionResult Get()
        {
            return Ok(tService.GetAll());
        }

        public IHttpActionResult Get(string id)
        {
            int parsed;
            int.TryParse(id, out parsed);
            if (parsed == 0)
            {
                var thesis = tService.GetThesisByStudent(id);
                if (thesis == null)
                {
                    return NotFound();
                }
                return Ok(thesis);
            }
            else
            {
                var thesis = tService.Get(parsed);
                if (thesis == null)
                {
                    return NotFound();
                }
                return Ok(thesis);
            }
        }

        public IHttpActionResult Get(ThesisStatus status)
        {
            var thesis = tService.GetThesisByStatus(status);
            return Ok(thesis);
        }

        public IHttpActionResult Get(ThesisType type)
        {
            var thesis = tService.GetThesisByType(type);
            return Ok(thesis);
        }

        // POST api/thesis
        public void Post([FromBody]ThesisModel value)
        {
            value.Student = null;
            var supervisor = uService.Get(Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(HttpContext.Current.User.Identity).ToString());
            value.Supervisor = supervisor;
            var subject = sService.Get(value.SubjectID);
            value.Subject = subject;
            var stage = stService.Get(value.StageID);
            value.Stage = stage;
            value.isVisible = true;
            tService.InsertThesis(value);
        }

        // PUT api/thesis
        public void Put([FromBody]ThesisModel value)
        {
            value.Stage = stService.Get(value.StageID);
            value.Student = uService.Get(value.StudentID);
            value.Supervisor = uService.Get(value.SupervisorID);
            value.Subject = sService.Get(value.SubjectID);
            tService.UpdateThesis(value);
        }

        // DELETE api/thesis/5
        public void Delete(int id)
        {
            tService.Delete(id);
        }
    }
}