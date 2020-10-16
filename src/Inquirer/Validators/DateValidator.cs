using System;

namespace InquirerCore.Validators
{
    public class DateValidator : BaseValidator
    {
        public DateValidator() : base("Answer accepts only dates.")
        {

        }

        public DateValidator(string errorMessage) : base(errorMessage)
        {

        }

        public override bool Validate(string value) => DateTime.TryParse(value, out _);
    }
}