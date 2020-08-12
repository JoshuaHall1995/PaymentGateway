using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using PaymentGateway.DataAccess;
using PaymentGateway.Exceptions;
using PaymentGateway.Handlers;
using PaymentGateway.Models;
using PaymentGateway.Validators;

namespace PaymentGateway
{
    public static class ProcessPaymentFunction
    {
        [FunctionName("ProcessPayment")]
        public static async Task<IActionResult> Status([HttpTrigger(
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
                var paymentRequest = DeserializeRequestFromBody(await request.Content.ReadAsStringAsync());
                
                var validation = new ProcessPaymentValidator().Validate(paymentRequest);
                if (!validation.IsValid)
                {
                    return new BadRequestObjectResult(JsonConvert.SerializeObject(validation.Errors));
                }
                
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
        
        private static PaymentRequest DeserializeRequestFromBody(string json)
        {
            PaymentRequest request;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                request = JsonConvert.DeserializeObject<PaymentRequest>(json, settings);
            }
            catch (JsonSerializationException)
            {
                throw new BadRequestException("Invalid body");
            }

            return request;
        }
    }
}