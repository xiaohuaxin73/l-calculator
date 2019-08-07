using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Cpu
{
    public class OperandStack
    {
        private Stack stack;

        public OperandStack()
        {
            stack = new Stack();
        }

        //栈顶出站
        public Value.Value pop()
        {
            return (Value.Value)stack.Pop();

        }
        //入栈
        public void push(Value.Value value)
        {
            stack.Push(value);
        }

        //获取栈顶元素
        public Value.Value peek()
        {
            return (Value.Value)stack.Peek();
        }
        //判定栈是否为空
        public bool empty()
        {
            throw new NotImplementedException();
        }

        //清空栈
        public void clear()
        {
            stack = new Stack();
        }
    }
}
