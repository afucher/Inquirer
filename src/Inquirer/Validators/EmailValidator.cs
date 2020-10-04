using System.Net.Mail;

namespace InquirerCore.Validators
{
    public class EmailValidator : IValidator
    {
        public bool Validate(string value)
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

        public string GetErrorMessage()
        {
            return "Answer accepts only valid Email adresses.";
        }
    }
}
