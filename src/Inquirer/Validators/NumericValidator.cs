using System;

namespace InquirerCore.Validators
{
    public class NumericValidator : IValidator
    {
        public bool Validate(string value)
        {
            try
            {
                float.Parse(value);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}