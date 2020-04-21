using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Container
{
    public class IocContainer
    {
        //用于存储对象
        public Dictionary<string, Type> container = new Dictionary<string, Type>();

        //用于注册对象
        public void Register<TSource, TDestination>()
            where TDestination : TSource //约束一下
        {
            
            this.container.Add(typeof(TSource).FullName, typeof(TDestination));
        }

        //用于生成对象实例
        public TSource Resolve<TSource>()
        {
            return CreateInstance<TSource>();
        }

        //用于创建对象
        private TSource CreateInstance<TSource>()
        {
            var sourceType = this.container[typeof(TSource).FullName];

            #region 判断构造函数注入
            var constructors = sourceType.GetConstructors()[0];
            var paras = constructors.GetParameters();
            List<object> parasList = new List<object>();  //用于保存参数生成的构造实例
            foreach (var item in paras)
            {
                var paraTypeName = item.ParameterType.FullName;//获取参数的type名称
                parasList.Add(Activator.CreateInstance(this.container[paraTypeName]));//添加到实例列表
            }
            #endregion


            //var instance = Activator.CreateInstance(sourceType); //此方式只能创建默认无参数构造实例
            var instance = Activator.CreateInstance(sourceType, parasList.ToArray()); //此方式创建有参数的构造实例
            return (TSource)instance;
        }
    }
}
