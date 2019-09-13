using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Empowered.Reflection
{
    public static class AssemblyExtension
    {
        public static Method SearchMethod(this Assembly assembly, string className, string methodName)
        {
            var type = assembly.GetType(className);
            if (type == null)
            {
                return null;
            }

            var info = type.GetMethod(methodName);
            if (info == null)
            {
                return null;
            }

            return new Method(type, info);
        }
    }
}
