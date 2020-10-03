using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class CreditCardNumberValidator : IValidator
    {
        public bool Validate(string value)
        {
            //Remove spaces and dashes
            string cleanValue = new Regex(@"[\s-]+")
                .Replace(value, "");

            // It matches a 16 digits number?
            return new Regex(@"^\d{16}$")
                .Match(cleanValue).Success;
        }

        public string GetErrorMessage()
        {
            return "Answer accepts only valid 16 digits credit cards.";
        }
    }
}