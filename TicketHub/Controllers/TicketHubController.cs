using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketHubController : ControllerBase
    {
        private readonly ILogger<TicketHubController> _logger;
        private readonly IConfiguration _configuration;

        public TicketHubController(ILogger<TicketHubController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Tiacket Hub Controller-Get()");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer, IConfiguration configuration) 
        {
            if (ModelState.IsValid == false) 
            {
                BadRequest(ModelState);
            }

            string queueName = "";
            return Ok();
        }
    }
}
