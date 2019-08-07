using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Calculator
{
    public class Cpu
    {
        private OperandStack operandStack;
        private OperationStack operationStack;
        private Memory memory;
        private Display display;
        private Hashtable operationMap;

        bool displayUpdate;

        public Cpu()
        {

            throw new NotImplementedException();
        }

        private void initializeStates()
        {

            throw new NotImplementedException();
        }

        /**
         * Enter operations into the CPU
         */
        public void enterOperation(string opcode)
        {
            throw new NotImplementedException();
        }

        /**
         * Enter numbers into the CPU. The CPU uses its current state
         * to determine what to do with the number.
         */

        public void enterDigit(String digit)
        {
            throw new NotImplementedException();
        }

        private Operation findOperation(String operation)
        {

            throw new NotImplementedException();
        }

        
        public void pushDisplayRegister()
        {
            throw new NotImplementedException();
        }

        
        public void loadOperand(Value value)
        {
            operandStack.push(value);
        }

        
      

        /**
         * Execute the equals function.
         */
        public void equals()
        {
            throw new NotImplementedException();
        }


        /**
         * Set the display register with any calculated results
         */
        public void updateDisplay()
        {
            throw new NotImplementedException();
        }

        
        public void clear()
        {
            throw new NotImplementedException();
        }

       
        public void reset()
        {
            throw new NotImplementedException();
        }

        

    }
}
