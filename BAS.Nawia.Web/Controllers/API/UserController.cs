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
    public class UserController : ApiController
    {
        private IUserService uService;

        public UserController(IUserService uservice)
        {
            this.uService = uservice;
        }

        // GET api/user
        public IHttpActionResult Get()
        {
            return Ok(uService.GetAll());
        }

        // GET api/user/5
        public IHttpActionResult Get(string id)
        {
            var user = uService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public void Put([FromBody]UserModel value)
        {
            uService.UpdateUser(value);
        }
    }
}
