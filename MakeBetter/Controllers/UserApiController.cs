using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakeBetter.Controllers
{
    public class UserApiController : ApiController
    {
        // GET api/userapi
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/userapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/userapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/userapi/5
        public void Delete(int id)
        {
        }
    }
}
