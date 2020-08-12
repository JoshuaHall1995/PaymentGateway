using NSubstitute;
using PaymentGateway;
using PaymentGateway.DataAccess;
using PaymentGateway.Exceptions;
using PaymentGateway.Handlers;
using PaymentGateway.Models;
using Xunit;

namespace UnitTests
{
    public class ProcessPaymentHandlerTests
    {
        private IPaymentHistoryRepo _paymentHistoryRepo;
        private IBankAPI _bankApi;

        public ProcessPaymentHandlerTests()
        {
            _paymentHistoryRepo = Substitute.For<IPaymentHistoryRepo>();
            _bankApi = Substitute.For<IBankAPI>();
        }
        
        [Fact]
        public void GivenAPaymentRequest_IfAcceptedByTheBank_ShouldReturnSuccessful()
        {
            // arrange
            var paymentRequest = new PaymentRequest();

            _bankApi.MakePayment(paymentRequest).Returns(true);
            
            var handler = new ProcessPaymentHandler(_paymentHistoryRepo, _bankApi);

            // act
            var result = handler.Handle(paymentRequest);
            
            // assert
            Assert.True(result);
        }

        [Fact]
        public void GivenAPaymentRequest_IfRejectedByBank_ShouldReturnUnsuccessful()
        {
            // arrange
            var paymentRequest = new PaymentRequest();

            _bankApi.MakePayment(paymentRequest).Returns(false);
            
            var handler = new ProcessPaymentHandler(_paymentHistoryRepo, _bankApi);

            // act
            var result = handler.Handle(paymentRequest);
            
            // assert
            Assert.False(result);
        }
        
        [Fact]
        public void GivenADuplicatePaymentRequest_ShouldNotTalkToBank_AndShouldThrowBadRequestException()
        {
            // arrange
            _paymentHistoryRepo.IsDuplicate(Arg.Any<string>()).Returns(true);
            
            var handler = new ProcessPaymentHandler(_paymentHistoryRepo, _bankApi);
            var paymentRequest = new PaymentRequest();

            // act
            var ex = Assert.Throws<BadRequestException>(() => handler.Handle(paymentRequest));

            // assert 
            Assert.Equal("Duplicate request.", ex.Message);
        }
        
        [Fact]
        public void GivenAPaymentRequestThatSucceeds_ThenRequestLogged_AndLoggedDetailsShowSuccess()
        {
            // arrange
            var paymentRequest = new PaymentRequest();

            _bankApi.MakePayment(paymentRequest).Returns(true);
            
            var handler = new ProcessPaymentHandler(_paymentHistoryRepo, _bankApi);

            // act
            handler.Handle(paymentRequest);
            
            // assert
            _paymentHistoryRepo.Received(1).LogPayment(Arg.Is<LoggedPaymentRequest>(x => Equals(x.Success, true)));
        }
        
        [Fact]
        public void GivenAPaymentRequestThatSucceeds_ThenRequestLogged_AndLoggedDetailsShowFailure()
        {
            // arrange
            var paymentRequest = new PaymentRequest();

            _bankApi.MakePayment(paymentRequest).Returns(false);
            
            var handler = new ProcessPaymentHandler(_paymentHistoryRepo, _bankApi);

            // act
            handler.Handle(paymentRequest);
            
            // assert
            _paymentHistoryRepo.Received(1).LogPayment(Arg.Is<LoggedPaymentRequest>(x => Equals(x.Success, false)));
        }
    }
}