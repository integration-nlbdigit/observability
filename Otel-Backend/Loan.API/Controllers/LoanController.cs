using System.Diagnostics;
using Loan.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using QueueFactory.Models;
using QueueFactory.Models.Interfaces;
using RabbitMQ.Client;
using commonModels = Models;

namespace Loan.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBus _bus;

        //Important: The name of the Activity should be the same as the name of the Source added in the Web API startup AddOpenTelemetryTracing Builder
        private static readonly ActivitySource Activity = new("APITracing");
        private static readonly TextMapPropagator Propagator = Propagators.DefaultTextMapPropagator;
        private static readonly List<LoanApplication> loans = new List<LoanApplication>();

        public LoanController(ICatalogService catalogService, IBus bus)
        {
            _catalogService = catalogService;
            _bus = bus;
        }

        /*
        [HttpPost]
        public async Task<IActionResult> AddLoanItem([FromBody] LoanItem item)
        {
            var concert = await _catalogService.GetConcert(item.ConcertId);
            return Ok(item);
        }
        */

        
        // Apply for a new loan
        [HttpPost]
        [Route("applyForLoan")]
        public IActionResult ApplyForLoan([FromBody] LoanApplication loan)
        {
            if ((loan.CustomerId != 0 ) || (loan.ProductId != 0) || loan.Amount <= 0 || loan.TermMonths <= 0)
            {
                return BadRequest("Invalid loan application data.");
            }
 
            loans.Add(loan);
            return Ok("Loan application submitted succesfully");
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout([FromBody] LoanApplication loan)
        {
            using (var activity = Activity.StartActivity("RabbitMq Publish", ActivityKind.Producer))
            {
                var basicProperties = _bus.GetBasicProperties();
                #pragma warning disable CS8604 // Possible null reference argument.

                AddActivityToHeader(activity, basicProperties);
                #pragma warning restore CS8604 // Possible null reference argument.

                await _bus.SendAsync(QueueType.Processing, new LoanRequest()
                {
                    Loan = loan
                }, basicProperties);
            }

            return Ok(loan.Id);
        }

       
        private void AddActivityToHeader(Activity activity, IBasicProperties props)
        {
            try
            {
                Propagator.Inject(new PropagationContext(activity.Context, Baggage.Current), props, InjectContextIntoHeader);
                activity?.SetTag("messaging.system", "rabbitmq");
                activity?.SetTag("messaging.destination_kind", "queue");
                activity?.SetTag("messaging.rabbitmq.queue", "sample"); //TODO
                activity?.SetTag("messaging.destination", string.Empty);
                activity?.SetTag("messaging.rabbitmq.routing_key", QueueType.Processing);
            }
            catch (Exception ex)
            {
                var t = ex.Message;
            }
        }

        private void InjectContextIntoHeader(IBasicProperties props, string key, string value)
        {
            try
            {
                props.Headers ??= new Dictionary<string, object>();
                props.Headers[key] = value;
            }
            catch (Exception ex)
            {
                _ = Serilog.ILogger.Equals(ex.Message, "Failed to inject trace context");
            }
        }
    }
}