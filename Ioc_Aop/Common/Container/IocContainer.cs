using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Attr;

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
            return (TSource)CreateInstance(typeof(TSource));
        }

        //用于创建对象
        private object CreateInstance(Type source)
        {
            var sourceType = this.container[source.FullName];


            #region 判断构造函数注入
            //var constructor = sourceType.GetConstructors()[0];//选择构造函数

            //方式1:默认选择参数最多的构造函数
            //var constructor = sourceType.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();

            //方式2:使用构造特性来选择构造
            var constructor = sourceType.GetConstructors().FirstOrDefault(x => x.IsDefined(typeof(ConstructorAttribute), true));
            if (constructor == null)
            {
                //可以自由选择-->参数最多-->参数最少-->随机  *******按需定制自己的就好
                constructor = sourceType.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();//没有特性的话选择参数最多的
            }


            var paras = constructor.GetParameters();//获取所有参数
            List<object> parasList = new List<object>();  //用于保存参数生成的构造实例
            foreach (var item in paras)
            {
                Type paraType = item.ParameterType;//获取参数的type
                object ins = this.CreateInstance(paraType);//递归实现多层级的构造
                parasList.Add(ins);//添加到实例列表
            }
            #endregion

            //var instance = Activator.CreateInstance(sourceType); //此方式只能创建默认无参数构造实例
            var instance = Activator.CreateInstance(sourceType, parasList.ToArray()); //此方式创建有参数的构造实例

            #region 属性注入
            var properties = sourceType.GetProperties().Where(x => x.IsDefined(typeof(PropertyAttribute), true));//获取所有标记了属性注入的特性属性
            foreach (var item in properties)
            {
                var propertyType = item.PropertyType;//获取属性的type
                object propIns = this.CreateInstance(propertyType);//递归实现多属性的构造
                item.SetValue(instance, propIns);//给属性set赋值
            }
            #endregion

            return instance;
        }
    }
}
