using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace PayRunService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayRunController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PayRunController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        // GET: api/PayRun
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PayRun/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PayRun
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PayRunClosedEvent payRunClosedEvent)
        {
            await _publishEndpoint.Publish<PayRunClosedEvent>(payRunClosedEvent);
            
            return Ok();
        }

        // PUT: api/PayRun/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/PayRun/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}