using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Unit
    {
        //第一个数 第二的数 运算符 结果
        private string number1;
        private string number2;
        private string my_operator;
        private string result;
        public string Number1{  set { number1 = value; }  get { return number1; } }
        public string Number2 { set { number2 = value; } get { return number2; } }
        public string My_Operator { set { my_operator = value; } get { return my_operator; } }
        public string Result { set { result = value; } get { return result; } }



    }
}
