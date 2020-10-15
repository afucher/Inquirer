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
        int iVal = int.Parse(value);
        return iVal >= Min && iVal <= Max;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public string GetErrorMessage()
    {
      return $"Answer accepts between {Min} to {Max}.";
        //String.Format("Answer accepts between {0} to {1}.", Min, Max);
    }
  }
}