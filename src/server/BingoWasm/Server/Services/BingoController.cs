using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BingoWasm.Server.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class BingoController : ControllerBase
    {
        // GET: api/<BingoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BingoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BingoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BingoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BingoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
