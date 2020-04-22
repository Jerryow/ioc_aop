using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Ioc_Aop_Lib.Aop
{
    //切面类
    public class AopInterceptor : StandardInterceptor
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
            //可以校验参数
            var paras = invocation.Arguments;
            foreach (var item in paras)
            {
                Console.WriteLine($"参数:{item.GetType().FullName} : 值是:{item}");//目前参数的值和类型都获取到了,可以自行判断做校验
                if (item.GetType().FullName == "System.String")
                {
                    if ((string)item == "123")
                    {
                        base.PerformProceed(invocation);//校验通过 执行原方法
                    }
                    else
                    {
                        invocation.ReturnValue = "111";//校验失败  直接返回默认值
                    }
                }
            }

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
