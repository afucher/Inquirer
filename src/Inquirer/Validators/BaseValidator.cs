using System;
namespace InquirerCore.Validators
{
    public abstract class BaseValidator : IValidator
    {
        public string ErrorMessage { get; }

        protected BaseValidator(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(string value);
    }
}
