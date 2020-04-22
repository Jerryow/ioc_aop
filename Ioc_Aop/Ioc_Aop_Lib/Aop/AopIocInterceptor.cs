using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using Common.Attr;
using System.Linq;

namespace Ioc_Aop_Lib.Aop
{
    //切面类
    public class AopIocInterceptor : StandardInterceptor
    {
        /// <summary>
        /// 调用前拦截
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("调用前拦截到了***************");
            base.PreProceed(invocation);
        }

        /// <summary>
        /// 方法运行完成时拦截
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PerformProceed(IInvocation invocation)
        {
            //通过标记接口的特性去扩展aop  或者使用Ioc_Aop_Lib.Aop.Ex->InterfaceEx 扩展方法去结合ioc绑定接口
            var method = invocation.Method;
            Action action = () => base.PerformProceed(invocation);
            if (method.IsDefined(typeof(AopAttrAttribute), true))
            {
                var attrs = method.GetCustomAttributes<BaseAttribute>();
                //var attrs = method.GetCustomAttributes<BaseAttribute>().ToArray().Reverse(); ---> core 的管道模型会反转一下.
                foreach (var item in attrs)
                {
                    action = item.Do(action);
                }
            }
            action.Invoke();
            Console.WriteLine("返回结果时拦截到了***************");//这个要放在后面...
        }

        /// <summary>
        /// 调用后拦截
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("调用后时拦截到了***************");
            base.PostProceed(invocation);
        }
    }
}
