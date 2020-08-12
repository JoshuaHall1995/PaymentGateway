using System.Text.RegularExpressions;
using FluentValidation;
using PaymentGateway.Models;

namespace PaymentGateway.Validators
{
    public class ProcessPaymentValidator : AbstractValidator<PaymentRequest>
    {
        public ProcessPaymentValidator()
        {
            RuleFor(x => x.CardNumber != null && Regex.IsMatch(x.CardNumber, @"^\d+$")).NotEqual(false);
            RuleFor(x => x.CVV != null && Regex.IsMatch(x.CVV, @"^\d+$")).NotEqual(false);
            RuleFor(x => x.Amount != null && IsDouble(x.Amount)).NotEqual(false);
            RuleFor(x => x.RequestId).NotNull();
            RuleFor(x => x.RequestType).NotNull();
            RuleFor(x => x.ExpiryDate).NotNull();
        }

        private bool IsDouble(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}