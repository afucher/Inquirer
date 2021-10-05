using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class CpfValidator : IValidator
    {
        public bool Validate(string value)
        {
			if (string.IsNullOrEmpty(value))
				return false;

            // Remove spaces, dashes and dots
            var cleanCpfNumber = new Regex(@"[\s-.]+")
                .Replace(value, "");

            // Is all digits with length equals 11?
            var isValidNumberFormat = new Regex(@"^[0-9]{11}$")
                .Match(cleanCpfNumber).Success;

            if (isValidNumberFormat)
                return isValidCpfNumber(cleanCpfNumber);

			return false;
        }

        private bool isValidCpfNumber(string value)
        {
			int[] multplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digit;
			int sum;
			int rest;
			tempCpf = value.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multplier1[i];
			
			rest = sum % 11;
			
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;
			
			digit = rest.ToString();
			tempCpf = tempCpf + digit;
			sum = 0;
			
			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
			
			rest = sum % 11;
			
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;
			
			digit = digit + rest.ToString();
			
			return value.EndsWith(digit);
		}

        public string GetErrorMessage()
        {
			return "Answer accepts only CPF's numbers.";
		}


    }
}
