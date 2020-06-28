using InquirerCore;
using InquirerCore.Prompts;
using InquirerCore.Validators;

namespace Samples.Basic
{
    public static class Sample1
    {
        public static void Run()
        {
            var numbersOnly = new RegexValidator("^[0-9]*$");
            var nameInput = new Input("name", "What is your name?");
            var ageInput = new Input("age", "What is your age?");
            ageInput.SetValid(numbersOnly);

            var passwordInput = new PasswordInput("password", "What is the password?");
            
            var inquirer = new Inquirer(nameInput, ageInput, passwordInput);

            inquirer.Ask();

            System.Console.WriteLine($@"Hello {nameInput.Answer()}! Your age is {ageInput.Answer()}");
            System.Console.WriteLine($@"Secret password: {passwordInput.Answer()}!");
            System.Console.ReadKey();
        }
    }
}
