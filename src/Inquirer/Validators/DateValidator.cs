using System;

namespace InquirerCore.Validators
{
    public class DateValidator : IValidator
    {
        public bool Validate(string value)
        {
            return DateTime.TryParse(value, out _);
        }

        public string GetErrorMessage()
        {
            return "Answer accepts only dates.";
        }
    }
}