using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InquirerCore.Validators
{
    public class CreditCardNumberValidator : BaseValidator
    {
        public CreditCardNumberValidator(string errorMessage)
            : base(errorMessage)
        {

        }

        public CreditCardNumberValidator()
            : base("Answer accepts only valid credit cards numbers.")
        {

        }

        public override bool Validate(string value)
        {
            // Remove spaces and dashes
            var cleanCreditCardNumber = new Regex(@"[\s-]+")
                .Replace(value, "");

            // Is all digits with length between 8 and 19?
            var isValidNumberFormat = new Regex(@"^[0-9]{8,19}$")
                .Match(cleanCreditCardNumber).Success;

            if (isValidNumberFormat) return IsValidLuhnAlgorithm(cleanCreditCardNumber);
           
            return false;
        }

        private bool IsValidLuhnAlgorithm(string cleanCreditCardNumber)
        {
            // Store the last digit (check digit)
            var checkDigit = cleanCreditCardNumber[cleanCreditCardNumber.Length - 1];

            // Remove the last digit (check digit)
            cleanCreditCardNumber = cleanCreditCardNumber.Remove(cleanCreditCardNumber.Length - 1);

            // Reverse all digits
            cleanCreditCardNumber = new string(cleanCreditCardNumber.Reverse().ToArray());

            // Convert the clean credit card number into a int list
            var creditCardNumArr = cleanCreditCardNumber.ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToList();

            // Multiply odd position digits by 2
            var creditCardNumArrTemp = new List<int>();
            for (int i = 0; i < creditCardNumArr.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    creditCardNumArrTemp.Add(creditCardNumArr[i] * 2);
                }
                else
                {
                    creditCardNumArrTemp.Add(creditCardNumArr[i]);
                }
            }
            creditCardNumArr = creditCardNumArrTemp;

            // Subtract 9 to all numbers above 9
            creditCardNumArr = creditCardNumArr.Select(x =>
            {
                if (x > 9)
                {
                    return x - 9;
                }
                return x;
            }).ToList();

            // Get numbers total
            var ccNumbersTotal = creditCardNumArr.Sum();

            // Get modulo of total
            var moduloOfNumbersTotal = (10 - (ccNumbersTotal % 10)) % 10;

            // If modulo of total is equal to the check digit
            return moduloOfNumbersTotal == (int)char.GetNumericValue(checkDigit);
        }
    }
}
