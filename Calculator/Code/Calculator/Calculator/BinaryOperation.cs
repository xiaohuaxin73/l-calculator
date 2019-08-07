using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class BinaryOperation : Operation
    {
        public BinaryOperation()
        {
            lookahead = true;
        }

        public override void execute(Cpu cpu)
        {
            throw new NotImplementedException();
        }

        public abstract Value executeBinary(Value value1, Value value2);
        
    }
}
