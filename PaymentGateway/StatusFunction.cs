using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace PaymentGateway
{
    public static class StatusFunction
    {
        [FunctionName("Status")]
        public static IActionResult Status([HttpTrigger(
                AuthorizationLevel.Function,
                "GET", // Could be HEAD
                Route = "status")]
            HttpRequestMessage request)
        {
            return new OkObjectResult("Function App is awake");
        }
    }
}