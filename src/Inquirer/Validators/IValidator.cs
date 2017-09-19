using System;
using System.Collections.Generic;
using System.Text;

namespace InquirerCore.Validators
{
    public interface IValidator
    {
        bool Validate(string value);
    }
}
