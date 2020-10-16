using System;

namespace InquirerCore.Validators 
{
    public class PercentageValidator : BaseValidator
    {
        public PercentageValidator() : base("A percentage must be a number between 0 and 100")
        {

        }

        public PercentageValidator(string errorMessage) : base(errorMessage)
        {

        }

        public override bool Validate(string value)
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
    }
}