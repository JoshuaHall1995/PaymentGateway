using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using PaymentGateway.DataAccess;
using PaymentGateway.Exceptions;
using PaymentGateway.Handlers;
using PaymentGateway.Models;

namespace PaymentGateway
{
    public static class ProcessPaymentFunction
    {
        [FunctionName("ProcessPayment")]
        public static IActionResult Status([HttpTrigger(
                AuthorizationLevel.Function,
                "POST",
                Route = "fakeBank/payment/")]
            HttpRequestMessage request)
        {
            // Auth checks would be done here against or at Api Gateway level to ensure
            // person making request has access to do so for the merchant. 
            
            var bankApi = new FakeBankApi();
            var paymentHistoryRepo = new PaymentHistoryRepo();
            var handler = new ProcessPaymentHandler(paymentHistoryRepo, bankApi);

            try
            {
                var paymentRequest = new PaymentRequest();
                
                var isCompleted = handler.Handle(paymentRequest);
                
                if (isCompleted)
                    return new OkObjectResult(paymentRequest);
                
                return new BadRequestObjectResult("Payment Request Unsuccessful");
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}