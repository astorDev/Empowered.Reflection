using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Empowered.Reflection
{
    public class Method
    {
        public Type Type { get; }
        public MethodInfo Info { get; }

        public Method(Type type, MethodInfo info)
        {
            this.Type = type;
            this.Info = info;
        }

    }
}
