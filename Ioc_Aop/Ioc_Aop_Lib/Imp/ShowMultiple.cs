using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc_Aop_Lib.Imp
{
    public class ShowMultiple : IShowMultiple
    {
        private IShowMultipleOne _showMultipleOne;
        public ShowMultiple(IShowMultipleOne showMultipleOne)
        {
            this._showMultipleOne = showMultipleOne;
        }
        public void DoSomething()
        {
            Console.WriteLine("搞点事情Multiple******");
            Console.WriteLine("************************多层1分隔符**************************");
            this._showMultipleOne.DoSomething();
        }
    }
}
