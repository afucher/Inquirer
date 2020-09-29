using System;
using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class EmailValidator : IValidator
    {
        private string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        
        public bool Validate(string value)
        {
            try
            {
                return Regex.IsMatch(value, emailPattern, RegexOptions.IgnoreCase,TimeSpan.FromMilliseconds(250));
            } catch(Exception e)
            {
                return false;
            }
        }

        public string GetErrorMessage()
        {
            return "Invalid email address";
        }
    }
}
