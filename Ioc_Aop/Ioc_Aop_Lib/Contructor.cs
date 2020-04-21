using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc_Aop_Lib
{
    public class Contructor : IContructor
    {
        public void DoSomething()
        {
            Console.WriteLine("搞点事情Constructor******");
        }
    }
}
