using ElectricMeterApp.Models;
using FluentValidation;

namespace ElectricMeterApp.Validators
{
    public class MeterQueryRequestValidator : AbstractValidator<MeterQueryRequest>
    {
        public MeterQueryRequestValidator()
        {
            RuleFor(x => x.MeterNo)
                .NotEmpty().WithMessage("Meter number is required")
                .Must(BeValidMeterNumber).WithMessage("Meter number must be exactly 11 or 13 digits (numbers only)")
                .Length(11, 13).WithMessage("Meter number must be 11 or 13 digits");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(20).WithMessage("Amount must be at least 20")
                .LessThanOrEqualTo(500).WithMessage("Amount must not exceed 500");
        }

        private bool BeValidMeterNumber(string meterNo)
        {
            if (string.IsNullOrWhiteSpace(meterNo))
                return false;

            // Check if it's exactly 11 or 13 digits and all are numbers
            return (meterNo.Length == 11 || meterNo.Length == 13) &&
                   meterNo.All(char.IsDigit);
        }
    }
}