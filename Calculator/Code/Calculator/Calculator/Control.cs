using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Control
    {
        private string input;
        private string process;
        private string history;
        public string Input { get { return input; } set { input = value; } }
            
        public string Process { get{ return process; } set{ process = value; } }
        public string History {  get { return history; } set { history = value; } }

        public object CoreControl(string input)
        {
            object obj1=null;
            /*根据输入input判断是什么类型的输入并作出相应的操作
             * 实例化某一个类型对象，并返回对象
             */

            return obj1;
        }
        public string ConnectProcess(string input) { return null; }
    }
}
