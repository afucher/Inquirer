using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class FullNameValidator : IValidator
    {
        public bool Validate(string value)
        {
            var match = Regex.Match(value, @"^[a-zA-Z\u00C0-\u00FF]{3,}(?: [a-zA-Z\u00C0-\u00FF]+){0,}$");
         
            return match.Success;
        }

        public string GetErrorMessage()
        {
            return "Name must be valid.";
        }
    }
}
