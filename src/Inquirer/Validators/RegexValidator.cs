using System;
using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class RegexValidator : BaseValidator
    {
        protected string pattern;

        public RegexValidator(string pattern) : base($"Answer should match pattern {pattern}")
        {
            this.pattern = pattern;
        }

        public RegexValidator(string pattern, string errorMessage) : base(errorMessage)
        {
            this.pattern = pattern;
        }

        public override bool Validate(string value) => Regex.IsMatch(value, pattern);
    }
}
