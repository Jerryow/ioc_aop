using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attr
{
    [AttributeUsage(AttributeTargets.Property)]//标记属性特性
    public class PropertyAttribute : Attribute
    {
    }
}
