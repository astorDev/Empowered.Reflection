using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Empowered.Reflection.Tests
{
    [TestClass]
    public class MethodInfo_InvokeAsync_Should
    {
        private Type type = typeof(ExampleClass);

        [TestMethod]
        public async Task ReturnMethodReturnValue_WhenMethodHasReturnValue()
        {
            var method = type.GetMethod("MethodReturningString");
            var result = await method.InvokeAsync(new ExampleClass());
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public async Task ReturnNull_WhenRunMethodIsVoid()
        {
            var method = type.GetMethod("VoidMethod");
            var result = await method.InvokeAsync(new ExampleClass());
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task ReturnNull_WhenRunMethodIsAsyncAndReturnsJustTask()
        {
            var method = type.GetMethod("AsyncMethodWithoutReturnValue");
            var result = await method.InvokeAsync(new ExampleClass());
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task ChangesInput_WhenRunMethodIsAsync()
        {
            var method = type.GetMethod("AsyncMethodJustChangingInput");
            var list = new List<string>();
            await method.InvokeAsync(new ExampleClass(), list);
            Assert.AreEqual("added in method", list[0]);
        }

        [TestMethod]
        public async Task ReturnsAsyncReturnValue_WhenMethodIsAsyncWithReturnValue()
        {
            var method = type.GetMethod("AsyncMethodReturningString");
            var result = await method.InvokeAsync(new ExampleClass());
            Assert.AreEqual("from async method", result);
        }
    }


}
