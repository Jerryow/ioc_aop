using System;
using Ioc_Aop_Lib.Imp;
using Ioc_Aop_Lib.Inter;
using Ioc_Aop_Lib;
using Ioc_Aop_Lib.Aop.Ex;
using Ioc_Aop_Lib.Aop;
using Ioc_Aop_Lib.Container;

namespace Ioc_Aop_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 准备容器
            IocContainer container = new IocContainer();
            container.Register<IShow, Show>();
            //container.Register<IShowContructor, ShowContructor>();
            //container.Register<IContructor, Contructor>();
            //container.Register<IShowProperty, ShowProperty>();
            //container.Register<IShowMultiple, ShowMultiple>();
            //container.Register<IShowMultipleOne, ShowMultipleOne>();
            //container.Register<IShowMultipleTwo, ShowMultipleTwo>();
            #endregion

            #region 无参数构造/有参数构造注入
            {
                //单层级注入
                //IShow show = container.Resolve<IShow>();
                //IShowContructor showContructor = container.Resolve<IShowContructor>();
                //show.DoSomething();
                //showContructor.DoSomething();

                //多层级注入
                //IShowMultiple showMultiple = container.Resolve<IShowMultiple>();
                //showMultiple.DoSomething();
            }
            #endregion

            #region 属性注入
            {
                //IShowProperty showProperty = container.Resolve<IShowProperty>();
                //showProperty.DoSomething();
            }
            #endregion

            #region 一个接口多个实现的注入
            //这个也暂时不处理--->多个参数给别名就好. 不要再register的时候传--->要构造的时候给定特性判断来传!!!!!
            //不过这个也一般用不到...  - -.
            #endregion

            #region 生命周期
            //1.暂时不弄 --->目前就是每次都构造一个全新的/
            //2.单例  ----> 根据key缓存一下type实例就好
            //3.scope  ----> 需要创建以及copy子容器. 每个容器单例就好
            #endregion

            #region Aop
            //类型代理  --->class
            //校验参数 不通过返回自定义的值
            //方法前, 方法运行完成时候, 方法后
            {
                //var proxy = (AopClassOne)ClassProxy.ProxyGenerate(typeof(AopClassOne));
                //var a = proxy.ActionOne("1323", 22);
                //Console.WriteLine("*********************************************");
                //Console.WriteLine($"返回值:{a}");
                //proxy.ActionTwo();
            }

            //接口代理  --->interface 需要结合ioc
            {
                //IShow show = container.Resolve<IShow>();
                //show.DoSomething();
                //show = (IShow)show.AopExtend(typeof(IShow));
                //show.DoSomething();

            }

            //上两种是类型注入
            //下面是使用特性代理
            {
                IShow show = container.Resolve<IShow>();
                show.DoSomething();
            }
            #endregion


            Console.ReadKey();
        }
    }
}
