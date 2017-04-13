using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SimpleApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ReadAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string _connStr = "Server=simpledata; User Id=sa; Password=Test@123; Database=AwesomeData; Trusted_Connection=False;";

        private IEnumerable<string> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(_connStr))
            {
                var readValues = "select word from AwesomeWords";
                return db.Query<string>(readValues, CommandType.Text);
            }
        }
    }
}
