using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class UnaryOperation : Operation
    {
        public UnaryOperation()
        {
            throw new NotImplementedException();
        }


        public override void execute(Cpu cpu)
        {
            throw new NotImplementedException();
        }

        public abstract Value executeUnary(Value value);
    }
}
