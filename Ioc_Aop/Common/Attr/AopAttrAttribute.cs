using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attr
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class BaseAttribute : Attribute
    {
        //public abstract void Do();

        //组装管道
        public abstract Action Do(Action action);
    }


    [AttributeUsage(AttributeTargets.Method)]
    public class AopAttrAttribute : BaseAttribute
    {
        //public override void Do()
        //{
        //    Console.WriteLine("这个是Aop特性1");
        //}

        //组装管道
        public override Action Do(Action action)
        {
            return () =>
            {
                Console.WriteLine("这个是Aop特性1----->前");
                action.Invoke();
                Console.WriteLine("这个是Aop特性1----->后");
            };
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class AopAttr2Attribute : BaseAttribute
    {

        //public override void Do()
        //{
        //    Console.WriteLine("这个是Aop特性2");
        //}

        //组装管道
        public override Action Do(Action action)
        {
            return () =>
            {
                Console.WriteLine("这个是Aop特性2----->前");
                action.Invoke();
                Console.WriteLine("这个是Aop特性2----->后");
            };
        }

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class AopAttr3Attribute : BaseAttribute
    {

        //public override void Do()
        //{
        //    Console.WriteLine("这个是Aop特性3");
        //}

        //组装管道
        public override Action Do(Action action)
        {
            return () =>
            {
                Console.WriteLine("这个是Aop特性3----->前");
                action.Invoke();
                Console.WriteLine("这个是Aop特性3----->后");
            };
        }
    }
}
