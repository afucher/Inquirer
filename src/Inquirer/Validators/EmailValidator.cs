using System.Net.Mail;

namespace InquirerCore.Validators
{
    public class EmailValidator : BaseValidator
    {
        public EmailValidator() : base("Answer accepts only valid Email adresses.")
        {

        }

        public EmailValidator(string errorMessage) : base(errorMessage)
        {

        }

        public override bool Validate(string value)
        {
            try
            {
                var emailAddress = new MailAddress(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
