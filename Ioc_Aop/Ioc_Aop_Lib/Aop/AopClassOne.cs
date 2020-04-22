using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc_Aop_Lib.Aop
{
    public class AopClassOne
    {
        //方法一定要指定虚方法  不然代理无法override
        //不明白的去搜  静态代理-----
        public virtual string ActionOne(string a, int b)
        {
            Console.WriteLine("这里是Aop的基础方法1********************");
            return "计算之后的值";
        }

        public virtual void ActionTwo()
        {
            Console.WriteLine("这里是Aop的基础方法2********************");
        }
    }
}
