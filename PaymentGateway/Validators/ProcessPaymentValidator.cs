using System.Text.RegularExpressions;
using FluentValidation;
using PaymentGateway.Models;

namespace PaymentGateway.Validators
{
    public class ProcessPaymentValidator : AbstractValidator<PaymentRequest>
    {
        public ProcessPaymentValidator()
        {
            RuleFor(x => x.CardNumber).NotNull();
            RuleFor(x => Regex.IsMatch(x.CardNumber, @"^\d+$")).Equal(true);
            RuleFor(x => x.CVV).NotNull();
            RuleFor(x => Regex.IsMatch(x.CVV, @"^\d+$"));
            RuleFor(x => x.RequestId).NotNull();
            RuleFor(x => x.RequestType).NotNull();
            RuleFor(x => x.ExpiryDate).NotNull();
            RuleFor(x => x.Amount).NotNull();
            // Amount not a valid number
        }
    }
}