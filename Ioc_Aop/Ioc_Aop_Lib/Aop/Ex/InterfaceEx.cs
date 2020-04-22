using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Ioc_Aop_Lib.Aop.Ex
{
    //未接口做扩展
    public static class InterfaceEx
    {

        public static object AopExtend(this object t, Type interfaceType)
        {
            ProxyGenerator generator = new ProxyGenerator();//代理类
            AopIocInterceptor interceptor = new AopIocInterceptor();//切面类
            return generator.CreateInterfaceProxyWithTarget(interfaceType, t, interceptor);//代理进去;
        }
    }
}
