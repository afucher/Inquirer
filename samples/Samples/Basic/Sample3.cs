using InquirerCore;
using InquirerCore.Prompts;

namespace Samples.Basic
{
    public static class Sample3
    {
        public static void Run()
        {
            var emailInput = new Input("name", "What is your email?");

            var passwordInput = new PasswordInput("password", "What is the password?");

            var inquirer = new Inquirer(emailInput, passwordInput);

            inquirer.Ask();

            System.Console.WriteLine($@"Your email is {emailInput.Answer()}!");
            System.Console.WriteLine($@"Secret password: {passwordInput.Answer()}!");
            System.Console.ReadKey();
        }
    }
}
