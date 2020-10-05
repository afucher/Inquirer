using Microsoft.Win32.SafeHandles;
using System;

namespace InquirerCore.Validators
{
    public class RangeValidator : IValidator
    {
    private int iMin { set; get; }
    private int iMax { set; get; }

        public RangeValidator(int _iMin, int _iMax)
        {
          iMin = _iMin;
          iMax = _iMax;
        }

        public bool Validate(string value)
        {
            try
            {
              int iVal = int.Parse(value);
              return iVal >= iMin && iVal <= iMax;
            }
            catch (Exception e)
            {
              return false;
            }
        }

        public string GetErrorMessage()
        {
        return String.Format("Answer accepts between {0} to {1}.", iMin, iMax);
        }
    }
}