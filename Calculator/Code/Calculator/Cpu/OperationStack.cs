using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Cpu
{
    public class OperationStack
    {
        private Stack stack;

        //初始化
        public OperationStack()
        {
            stack = new Stack();
        }

        //入栈运算符
        public void push(Object operation)
        {
            stack.Push(operation);
        }

        //栈顶出站运算符
        public Object pop()
        {
            throw new NotImplementedException();
        }

        //获取栈顶元素
        public Object peek()
        {
            throw new NotImplementedException();
        }

        //判断是否为空
        public bool empty()
        {
            throw new NotImplementedException();
        }

        //清空
        public void clear()
        {
            stack = new Stack();
        }

    }
}
