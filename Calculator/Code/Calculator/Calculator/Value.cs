using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface Value
    {
        Value create(string str);
        Value add(Value other);
        Value subtract(Value other);
        Value multiply(Value other);
        Value divide(Value other);
        Value negate();
        Value squareRoot();
        Value inverse();
        Value percent();
        String addDigit(string number, string digit);
    }
}
