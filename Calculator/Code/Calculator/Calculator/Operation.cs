using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class Operation
    {
        protected int precedence;
        protected bool lookahead;
        protected string symbol;
        protected Cpu cpu;
        protected OperandStack stack;

        public int getPrecedence()
        {
            return precedence;
        }

        public bool getLookahead()
        {
            return lookahead;
        }

        public String toString()
        {
            return symbol;
        }

        public void setString(String s)
        {
            symbol = s;
        }


        /**
         * The execute method signature which must be implemented for each operation.
         */
        public abstract void execute(Cpu cpu);

    }
}
