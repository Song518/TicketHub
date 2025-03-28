using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
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

            string queueName = "tickethub";
            string? connectionString = _configuration["AzureStorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = "";

            // send string message to queue
            await queueClient.SendMessageAsync(message);
            return Ok();
        }
    }
}
