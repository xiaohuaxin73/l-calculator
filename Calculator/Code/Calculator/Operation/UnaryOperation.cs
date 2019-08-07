using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    abstract class UnaryOperation : Operation
    {
        public UnaryOperation()
        {
            throw new NotImplementedException();
        }


        public override void execute(Object cpu)
        {
            throw new NotImplementedException();
        }

        public abstract Value.Value executeUnary(Value.Value value);
    }
}
