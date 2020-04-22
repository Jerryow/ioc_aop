using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attr
{
    [AttributeUsage(AttributeTargets.Constructor)]//标记构造函数特性
    public class ConstructorAttribute : Attribute
    {
    }
}
