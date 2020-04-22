using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bot.Controllers
{

    [ApiController]
    [Route("api/github/webhook")]
    public class GitHubWebhookController : ControllerBase
    {
        private readonly ILogger<GitHubWebhookController> _logger;

        public GitHubWebhookController(ILogger<GitHubWebhookController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> ReceiveEventsAsync([FromBody] string payload)
        {
            return new OkResult();
        }

        // GET: /
        [Route("/")]
        [HttpGet]
        public IActionResult Home()
        {

            return Content("{ message = \"Your webhook is up and running. You can try it by sending [POST] requests to: 'api/github/webhook'.\" }");
        }
    }


}