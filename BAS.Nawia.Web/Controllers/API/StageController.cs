using BAS.Nawia.Common.Interfaces;
using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAS.Nawia.Web.Controllers.API
{
    public class StageController : ApiController
    {
        private IStageService sService;

        public StageController(IStageService sservice)
        {
            this.sService = sservice;
        }

        // GET api/stage
        public IHttpActionResult Get()
        {
            return Ok(sService.GetAll());
        }

        // GET api/stage/5
        public IHttpActionResult Get(int id)
        {
            var stage = sService.Get(id);
            if (stage == null)
            {
                return NotFound();
            }
            return Ok(stage);
        }

        public IHttpActionResult Get(StageStatus status)
        {
            var stage = sService.GetStageByStatus(status);
            return Ok(stage);
        }

        // POST api/stage
        public void Post([FromBody]StageModel value)
        {
            sService.InsertStage(value);
        }

        // PUT api/stage
        public void Put([FromBody]StageModel value)
        {
            sService.UpdateStage(value);
        }

        public void Put(int id, StageStatus status)
        {
            sService.ChangeStageStatus(id, status);
        }

        // DELETE api/stage/5
        public void Delete(int id)
        {
            sService.Delete(id);
        }
    }
}
