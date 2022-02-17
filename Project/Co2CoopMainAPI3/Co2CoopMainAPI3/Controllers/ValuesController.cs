using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Co2CoopMainAPI3.Controllers
{
    public class ValuesController : ApiController
    {
        // http://172.16.21.44/api/values
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // http://172.16.21.44/api/values/[int]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
