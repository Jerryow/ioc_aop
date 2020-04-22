using System;
using Common.Container;
using Ioc_Aop_Lib.Imp;
using Ioc_Aop_Lib.Inter;
using Ioc_Aop_Lib;

namespace Ioc_Aop_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 准备容器
            IocContainer container = new IocContainer();
            container.Register<IShow, Show>();
            container.Register<IShowContructor, ShowContructor>();
            container.Register<IContructor, Contructor>();
            container.Register<IShowProperty, ShowProperty>();
            container.Register<IShowMultiple, ShowMultiple>();
            container.Register<IShowMultipleOne, ShowMultipleOne>();
            container.Register<IShowMultipleTwo, ShowMultipleTwo>();
            #endregion

            #region 无参数构造/有参数构造注入
            {
                //单层级注入
                IShow show = container.Resolve<IShow>();
                IShowContructor showContructor = container.Resolve<IShowContructor>();
                show.DoSomething();
                showContructor.DoSomething();

                //多层级注入
                IShowMultiple showMultiple = container.Resolve<IShowMultiple>();
                showMultiple.DoSomething();
            }
            #endregion

            #region 属性注入
            IShowProperty showProperty = container.Resolve<IShowProperty>();
            showProperty.DoSomething();
            
            #endregion


            Console.ReadKey();
        }
    }
}
