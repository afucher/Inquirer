using System;

namespace InquirerCore.Validators
{
  public class RangeValidator : IValidator
  {
    private int Min { set; get; }
    private int Max { set; get; }

    public RangeValidator(int minValue, int maxValue)
    {
      Min = minValue;
      Max = maxValue;
    }

    public bool Validate(string value)
    {
      try
      {
        int val = int.Parse(value);
        return val >= Min && val <= Max;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public string GetErrorMessage()
    {
      return $"Answer accepts between {Min} to {Max}.";
    }
  }
}