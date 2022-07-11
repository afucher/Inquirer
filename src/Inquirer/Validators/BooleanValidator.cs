using System;

namespace InquirerCore.Validators
{
    public class BooleanValidator : IValidator
    {
        public bool Validate(string value)
        {
            return bool.TryParse(value, out _);
        }

        public string GetErrorMessage()
        {
            return "Answer accepts only valid boolean values.";
        }
    }
}