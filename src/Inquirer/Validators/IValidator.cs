
namespace InquirerCore.Validators
{
    public interface IValidator
    {
        bool Validate(string value);
        string ErrorMessage { get; }
    }
}
