using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Value;
namespace Cpu
{
    public class Cpu
    {
        private OperandStack operandStack;
        private OperationStack operationStack;
        private Memory memory;
        private Display display;
        private HashMap operationMap;

        bool displayUpdate;

        public Cpu()
        {
            
        }

        private void initializeStates()
        {
            WaitingForInputState = new WaitingForInputState(this);
            WaitingForNumberState = new WaitingForNumberState(this);
            WaitingForOperationState = new WaitingForOperationState(this);
            EnteringNumberState = new EnteringNumberState(this);
        }

        private void setState(State state)
        {
            boolean viewStateChange = false;

            this.state = state;

            if (viewStateChange)
            {
                String name = state.getClass().getName();
                System.out.println("State: " + name);
            }
        }

        /**
         * Enter operations into the CPU
         */
        public void enterOperation(String opcode)
        {

            // create a class for the operation
            Operation op = findOperation(opcode);

            // depending on the current state, do operation, set new state
            if (opcode.compareTo("MemoryRecall") == 0)
            {
                // memory recall is an operation but behaves like a number
                // so handle it as entering a value
                setState(state.enterValue(op));
            }
            else
                setState(state.enterOperation(op));
        }

        /**
         * Enter numbers into the CPU. The CPU uses its current state
         * to determine what to do with the number.
         */

        public void enterDigit(String digit)
        {

            // depending on the current state, handle new digit, set new state.
            setState(state.enterDigit(digit));
        }

        private Operation findOperation(String operation)
        {

            String model = "com.objectsbydesign.calc.model";
            Operation op = null;
            Constructor constructor = null;

            try
            {
                // check the operation cache first
                op = (Operation)operationMap.get(operation);
                if (op == null)
                {
                    // create an instance of the operation
                    Class klass = Class.forName(model + "." + operation);
                    constructor = klass.getDeclaredConstructor(null);
                    op = (Operation)constructor.newInstance(null);
                    operationMap.put(operation, op);
                }
            }
            catch (Exception ex)
            {
                System.out.println(ex.toString());
            }

            return op;
        }

        /**
         * Push the display input onto the operand stack, and broadcasts the
         * input to all observers
         */
        public void pushDisplayRegister()
        {
            Value value = display.createValue();
            operandStack.push(value);
            doNotify(new OperandCommand(value));
        }

        /**
         * Push the operand value onto the operand stack.
         */
        public void loadOperand(Value value)
        {
            operandStack.push(value);
        }

        /**
         * Push the operation onto the operation stack or execute immediately, and broadcast the
         * input to all observers
         */
        public void pushOperation(Operation op)
        {

            // compare precedence of new operation to the top of the stack (if not empty)
            // if the new operation has equal or higher precedence,
            // execute the operation from the stack
            if (!operationStack.empty() &&
                    operationStack.peek().getPrecedence() >= op.getPrecedence())
                operationStack.pop().execute(this);

            // if the operation has no lookahead
            if (!op.getLookahead())
            {
                // execute immediately
                op.execute(this);
            }
            // if the operation has a lookahead
            else
            {
                // push operation for later execution
                operationStack.push(op);
            }

            doNotify(new OperationCommand(op));
            updateDisplay();
        }

        /**
         *  Execute the operation and broadcast the input to all observers
         */
        public void executeOperation(Operation op)
        {
            op.execute(this);
            doNotify(new OperationCommand(op));
        }

        /**
         *  Replace the top operation on the operation stack.
         */
        public void replaceOperation(Operation op)
        {
            if (!operationStack.empty())
            {
                operationStack.pop();
                pushOperation(op);
            }
        }

        /**
         * Execute the equals function.
         */
        public void equals()
        {
            while (!operationStack.empty())
            {
                operationStack.pop().execute(this);
            }
        }


        /**
         * Set the display register with any calculated results
         */
        public void updateDisplay()
        {
            if (displayUpdate && !operandStack.empty())
            {
                Value.Value value = operandStack.peek();
                display.setValue(value);
                doNotify(new OperandCommand(value));
                displayUpdate = false;
            }
        }

        /**
         * Executes the clear function. Empties the stacks and clears the display register.
         */
        public void clear()
        {
            operandStack.clear();
            operationStack.clear();
            display.clear();
        }

        /**
         * Resets the CPU. Empties the stacks and resets the display register.
         */
        public void reset()
        {
            operandStack.clear();
            operationStack.clear();
            display.reset();
        }


        public void addDisplayObserver(Observer observer)
        {
            display.addObserver(observer);

        }

        public void addMemoryObserver(Observer observer)
        {
            memory.addObserver(observer);
        }

        /**
         * Notify all observers of an input to the CPU
         */
        private void doNotify(Object object)
        {
            setChanged();
            notifyObservers(object);
        }

        public void setUpdateDisplay()
        {
            displayUpdate = true;
        }

        public OperandStack getOperandStack()
        {
            return operandStack;
        }

        public OperationStack getOperationStack()
        {
            return operationStack;
        }

        public Memory getMemoryRegister()
        {
            return memory;
        }

        public Display getDisplayRegister()
        {
            return display;
        }
    }
}
