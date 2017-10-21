using InquirerCore;
using InquirerCore.Prompts;
using InquirerCore.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Basic
{
    public static class Sample2
    {
        public static void Run()
        {
            var options = new string[] { "Option 1", "Option 2" };
            var listInput = new ListInput("option", "Which option?", options);

            var inquirer = new Inquirer(listInput);

            inquirer.Ask();

            var answer = listInput.Answer();
            System.Console.WriteLine($@"You have selected option: {answer} - {options[Int32.Parse(answer)-1]}");
            System.Console.ReadKey();
        }
    }
}
