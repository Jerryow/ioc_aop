using System;
using System.Collections.Generic;
using System.Text;
using Common.Attr;

namespace Ioc_Aop_Lib.Inter
{
    public interface IShow
    {
        [AopAttr]
        [AopAttr2]
        [AopAttr3]
        void DoSomething();
    }
}
