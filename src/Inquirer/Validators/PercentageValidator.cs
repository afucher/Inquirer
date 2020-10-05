using System;

namespace InquirerCore.Validators 
{
    public class PercentageValidator : IValidator
    {
        public bool Validate(string value)
        {
            try
            {
                if (value.EndsWith("%"))
                {
                    value = value.Remove(value.Length - 1);
                }
                var number = float.Parse(value);
                return number >= 0 && number <= 100;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetErrorMessage()
        {
            return "A percentage must be a number between 0 and 100";
        }
    }
}