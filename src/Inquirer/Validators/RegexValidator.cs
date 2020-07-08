using System;
using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class RegexValidator : IValidator
    {
        protected string pattern;
        public RegexValidator(string pattern)
        {
            this.pattern = pattern;
        }

        public bool Validate(string value)
        {
            return Regex.IsMatch(value, pattern);
        }

        public string GetErrorMessage()
        {
            return $"Answer should match pattern {pattern}";
        }
    }
}
