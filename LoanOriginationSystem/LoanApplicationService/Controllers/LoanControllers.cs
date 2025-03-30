using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenTelemetry.Trace;

namespace LoanApplicationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LoanController> _logger;
 
        public LoanController(IHttpClientFactory httpClientFactory, ILogger<LoanController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }
 
        [HttpPost]
        public async Task<IActionResult> Apply([FromBody] LoanApplication application)
        {
            //if (!Status.Error)
            //{
            //    return BadRequest(ModelState);
           // }
 
            // Simulate processing the application
            _logger.LogInformation("Processing application for: {Name}", application.Name);
 
            // Send notification
            //var response = await _httpClient.PostAsJsonAsync("http://notificationservice/send", new Notification
            //{
            //    Message = $"Application received for {application.Name}"
            //});
 
            //if (response.StatusCode != HttpStatusCode.OK)
            //{
            //    return StatusCode((int)response.StatusCode, "Failed to send notification.");
            //}
       
            return Ok("Loan application submitted successfully.");
        }
    }
 
    public class LoanApplication
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
 
    public class Notification
    {
        public string Message { get; set; }
    }
}
