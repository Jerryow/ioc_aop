using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc_Aop_Lib.Imp
{
    public class ShowMultipleOne : IShowMultipleOne
    {
        private IShowMultipleTwo _showMultipleTwo;
        public ShowMultipleOne(IShowMultipleTwo showMultipleTwo)
        {
            this._showMultipleTwo = showMultipleTwo;
        }
        public void DoSomething()
        {
            Console.WriteLine("搞点事情MultipleOne******");
            Console.WriteLine("************************多层2分隔符**************************");
            this._showMultipleTwo.DoSomething();
        }
    }
}
