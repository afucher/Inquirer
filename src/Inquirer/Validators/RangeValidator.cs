using System;

namespace InquirerCore.Validators
{
  public class RangeValidator : BaseValidator
  {
    private int Min { set; get; }
    private int Max { set; get; }

    public RangeValidator(int minValue, int maxValue)
    : base($"Answer accepts between {minValue} to {maxValue}.")
    {
            Min = minValue;
            Max = maxValue;
    }

    public RangeValidator(int minValue, int maxValue, string errorMessage)
    : base(errorMessage)
        {
            Min = minValue;
            Max = maxValue;
        }

        public override bool Validate(string value)
    {
      try
      {
        int val = int.Parse(value);
        return val >= Min && val <= Max;
      }
      catch (Exception)
        {
            return false;
            }
    }
  }
}