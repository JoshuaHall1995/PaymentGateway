using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using PaymentGateway.DataAccess;
using PaymentGateway.Exceptions;
using PaymentGateway.Handlers;

namespace PaymentGateway
{
    public static class GetPaymentDetailsFunction
    {
        [FunctionName("GetPaymentDetails")]
        public static IActionResult Status([HttpTrigger(
                AuthorizationLevel.Function,
                "GET",
                Route = "fakeBank/payment/{paymentRequestId}")]
            HttpRequestMessage request, string paymentRequestId)
        {
            var bankApi = new FakeBankApi();
            var handler = new GetPaymentHandler(bankApi);

            try
            {
                var paymentRequest = handler.Handle(paymentRequestId);
                return new OkObjectResult(paymentRequest);
            }
            catch (NotFoundException)
            {
                return new NotFoundResult();
            }
        }
    }
}