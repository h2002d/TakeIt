using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TakeIt.Controllers
{
    public class TakeItController : ApiController
    {
        // GET api/takeit
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/takeit/5
        public string Login([FromBody]string username, [FromBody]string password)
        {
            int userId = TakeIt.Models.User.Login(username, password);
            return userId.ToString();
        }

        // POST api/takeit
        public void Post([FromBody]string value)
        {
        }

        // PUT api/takeit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/takeit/5
        public void Delete(int id)
        {
        }
    }
}
