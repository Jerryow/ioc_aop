using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Attr;

namespace Ioc_Aop_Lib.Imp
{
    public class ShowContructor : IShowContructor
    {
        private IContructor _contructor;
        private IShowMultipleTwo _showMultipleTwo;

        public ShowContructor(IContructor contructor)
        {
            this._contructor = contructor;
        }

        [Constructor]
        public ShowContructor(IContructor contructor, IShowMultipleTwo showMultipleTwo)
        {
            this._contructor = contructor;
            this._showMultipleTwo = showMultipleTwo;
        }


        public void DoSomething()
        {
            Console.WriteLine("搞点事情Contructor******");
            Console.WriteLine("*********************测试构造注入的分隔符*****************");
            this._contructor.DoSomething();
            Console.WriteLine("*********************测试构造注入的多参数分隔符*****************");
            this._showMultipleTwo.DoSomething();
        }

        public void DoSomethingTwo()
        {
            Console.WriteLine("搞点事情Contructor******");
            Console.WriteLine("*********************测试构造注入的分隔符*****************");
            this._contructor.DoSomething();
        }
    }
}
