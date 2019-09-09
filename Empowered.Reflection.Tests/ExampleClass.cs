using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empowered.Reflection.Tests
{
    public class ExampleClass
    {
        public string MethodReturningString()
        {
            return "test";
        }

        public void VoidMethod()
        {

        }

        public async Task AsyncMethodWithoutReturnValue()
        {
        }

        public async Task AsyncMethodJustChangingInput(List<string> list)
        {
            list.Add("added in method");
        }

        public async Task<string> AsyncMethodReturningString()
        {
            return "from async method";
        }
    }
}
