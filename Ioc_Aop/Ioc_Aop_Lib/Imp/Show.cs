﻿using Ioc_Aop_Lib.Inter;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Attr;

namespace Ioc_Aop_Lib.Imp
{
    public class Show : IShow
    {
        public void DoSomething()
        {
            Console.WriteLine("搞点事情******");
        }
    }
}
