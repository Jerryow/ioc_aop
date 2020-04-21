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
            
            {
                IocContainer container = new IocContainer();
                container.Register<IShow, Show>();
                container.Register<IShowContructor, ShowContructor>();
                container.Register<IContructor, Contructor>();
                IShow show = container.Resolve<IShow>();
                IShowContructor showContructor = container.Resolve<IShowContructor>();
                show.DoSomething();
                showContructor.DoSomething();
                
            }



            Console.ReadKey();
        }
    }
}
