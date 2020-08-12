using System;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PaymentGateway;
using PaymentGateway.Exceptions;
using PaymentGateway.Handlers;
using PaymentGateway.Models;
using Xunit;

namespace UnitTests
{
    public class GetPaymentHandlerTests
    {
        private IBankAPI _bankApi;

        public GetPaymentHandlerTests()
        {
            _bankApi = Substitute.For<IBankAPI>();
        }

        [Fact]
        public void GivenASuccessfulPaymentRequestToRetrieve_IfItExistsWithBank_ShouldReturnPayment()
        {
            // arrange
            var expectedPaymentRequestId = Guid.NewGuid().ToString();
            var paymentRequest = BuildTestPaymentRequestResponse(expectedPaymentRequestId, true);
            _bankApi.FetchPaymentDetails(expectedPaymentRequestId).Returns(paymentRequest);
            
            var handler = new GetPaymentHandler(_bankApi);

            
            // act
            var result = handler.Handle(expectedPaymentRequestId);
            
            // assert
            Assert.Equal(expectedPaymentRequestId, result.RequestId);
            Assert.True(result.Success);
        }

        [Fact]
        public void GivenAFailedPaymentRequestToRetrieve_IfItExistsWithBank_ShouldReturnPayment()
        {
            // arrange
            var expectedPaymentRequestId = Guid.NewGuid().ToString();
            var paymentRequest = BuildTestPaymentRequestResponse(expectedPaymentRequestId, false);
            _bankApi.FetchPaymentDetails(expectedPaymentRequestId).Returns(paymentRequest);
            
            var handler = new GetPaymentHandler(_bankApi);

            
            // act
            var result = handler.Handle(expectedPaymentRequestId);
            
            // assert
            Assert.Equal(expectedPaymentRequestId, result.RequestId);
            Assert.False(result.Success);
        }

        [Fact]
        public void GivenAPaymentId_IfItDoesNotExistWithTheBank_ShouldReturnNotFoundException()
        {
            // arrange
            _bankApi.FetchPaymentDetails(Arg.Any<string>()).ReturnsNull();

            var handler = new GetPaymentHandler(_bankApi);

            // act
            var ex = Assert.Throws<NotFoundException>(() => handler.Handle("id"));

            // assert 
            Assert.NotNull(ex);
        }

        [Fact]
        public void GivenPaymentRequestToRetrieve_IfItExistsWithBank_ShouldReturnHashedCardNumber()
        {
            // arrange
            var expectedPaymentRequestId = Guid.NewGuid().ToString();
            var paymentRequest = BuildTestPaymentRequestResponse(expectedPaymentRequestId, true, "hashTest");
            var expectedHashedCardNumber = Utils.HashCardNumber(paymentRequest.CardNumber);
            _bankApi.FetchPaymentDetails(expectedPaymentRequestId).Returns(paymentRequest);
            
            var handler = new GetPaymentHandler(_bankApi);
            // act
            var result = handler.Handle(expectedPaymentRequestId);
            
            // assert
            Assert.Equal(expectedHashedCardNumber, result.HashedCardNumber);
        }
        
        private static FakeBankHistoricalPaymentRequest BuildTestPaymentRequestResponse(string expectedPaymentRequestId, 
            bool isSuccess, string cardNumber = "fakeCardNumber")
        {
            return new FakeBankHistoricalPaymentRequest
            {
                RequestId = expectedPaymentRequestId,
                CardNumber = cardNumber,
                Success = isSuccess
            };
        }
        
    }
}