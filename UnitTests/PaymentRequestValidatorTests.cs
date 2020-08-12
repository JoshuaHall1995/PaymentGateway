using System;
using System.Text.RegularExpressions;
using PaymentGateway.Models;
using PaymentGateway.Validators;
using Xunit;

namespace UnitTests
{
    public class PaymentRequestValidatorTests : ShouldBase
    {
        [Fact]
        public void GivenValidPaymentRequest_ShouldReturnIsValid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            
            // act
            var result = validator.Validate(paymentRequest);
            

            // assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void GivenAPaymentRequest_WithMissingCardNumber_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.CardNumber = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_WithACardNumberContainingLetters_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.CardNumber = "12344hello";

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_WithCVVMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.CVV = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_WithCVVContainingLetters_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.CVV = "12345hello";
            
            var test = Regex.IsMatch(paymentRequest.CVV, @"^\d+$");

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_ExpiryDateMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.ExpiryDate = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        // Would check for type in a further iteration, but was unsure if it would be "08/2020" or a actual date.

        [Fact]
        public void GivenAPaymentRequest_AmountMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.Amount = null;
            
            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_AmountNotValid_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.Amount = "hello";
            
            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GivenAPaymentRequest_RequestIdMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.RequestId = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        [Fact]
        public void GivenAPaymentRequest_RequestTypeMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.RequestType = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
        
        // Would be expanded for unexpected type
        
        [Fact]
        public void GivenAPaymentRequest_CurrencyMissing_ShouldBeInvalid()
        {
            // arrange
            var validator = new ProcessPaymentValidator();
            var paymentRequest = BuildValidTestPaymentRequest();
            paymentRequest.Currency = null;

            // act
            var result = validator.Validate(paymentRequest);

            // assert
            Assert.False(result.IsValid);
        }
    }
}