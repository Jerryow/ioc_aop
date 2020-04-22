using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Ioc_Aop_Lib.Aop.Ex
{
    //Aop 动态代理--->还有静态代理(自己去搜)....
    //基于Castle ->去下载castle.core
    public class ClassProxy
    {
        //public object CreateClassProxy(Type classToProxy, params IInterceptor[] interceptors);
        public static object ProxyGenerate(Type obj)
        {
            ProxyGenerator generator = new ProxyGenerator();//代理类
            AopInterceptor interceptor = new AopInterceptor();//切面类
            return generator.CreateClassProxy(obj, interceptor);//代理进去;
        }
    }
}
