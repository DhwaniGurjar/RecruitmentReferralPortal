using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentPortal.Zest.Services.Controllers
{
    public class ReferralController : ApiController
    {
        // GET: api/Referral
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Referral/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Referral
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Referral/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Referral/5
        public void Delete(int id)
        {
        }
    }
}
