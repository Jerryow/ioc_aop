using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Attr;


namespace Ioc_Aop_Lib.Imp
{
    public class ShowProperty : IShowProperty
    {

        [Property]//属性注入标记特性且属性需要公开
        public IContructor Contructor { get; set; }

        [Property]//属性注入标记特性且属性需要公开
        public IShowMultipleOne one { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("搞点事情Property******");
            Console.WriteLine("*********************测试属性的分隔符*****************");
            this.Contructor.DoSomething();
            Console.WriteLine("*********************测试属性的分隔符*****************");
            this.one.DoSomething();
        }
    }
}
