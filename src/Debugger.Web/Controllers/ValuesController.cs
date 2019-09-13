using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Debugger.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDbConnection _conn;

        public ValuesController(IDbConnection conn)
        {
            _conn = conn;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var date = DateTime.UtcNow;

            var text = new StringBuilder($"Starting Connection. at {JsonConvert.SerializeObject(date)}");

            try {
                text.AppendLine();

                _conn.Open();

                text.AppendLine("");
            }
            catch (Exception e)
            {
                text.AppendLine($"Error. {e.Message}");
            }

            text.AppendLine($"Operation Completed. Duration is {(DateTime.UtcNow - date).TotalSeconds} seconds");

            return text.ToString();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
