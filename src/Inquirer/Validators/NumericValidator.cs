using System;

namespace InquirerCore.Validators
{
    public class NumericValidator : BaseValidator
    {
        public NumericValidator() : base("Answer accepts only numbers.")
        {

        }

        public NumericValidator(string errorMessage) : base(errorMessage)
        {

        }

        public override bool Validate(string value)
        {
            try
            {
                float.Parse(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}