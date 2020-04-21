using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;


namespace Ioc_Aop_Lib.Imp
{
    public class ShowContructor : IShowContructor
    {
        private IContructor _contructor;
        public ShowContructor(IContructor contructor)
        {
            this._contructor = contructor;
        }
        public void DoSomething()
        {
            Console.WriteLine("搞点事情One******");
            Console.WriteLine("*********************测试构造注入的分隔符*****************");
            this._contructor.DoSomething();
        }
    }
}
