using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Empowered.Reflection
{
    public static class MethodInfoExtension
    {
        public async static Task<object> InvokeAsync(this MethodInfo method, object instance, params object[] args)
        {
            if (method.IsAsync())
            {
                if (method.ReturnType.IsGenericType)
                {
                    return (object)await (dynamic)method.Invoke(instance, args);
                }

                await (Task)method.Invoke(instance, args);
                return null;
            }

            return method.Invoke(instance, args);
        }

        public static bool IsAsync(this MethodInfo method)
        {
            return method.ReturnType.GetMethod(nameof(Task.GetAwaiter)) != null;
        }
    }
}
