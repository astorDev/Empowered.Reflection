using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Empowered.Reflection.Tests
{
    [TestClass]
    public class Assembly_SearchMethod_Should
    {
        public Assembly Assembly => this.GetType().Assembly;

        [TestMethod]
        public void ReturnMethodInfo_WhenClassAndMethodExists()
        {
            var m = this.Assembly.SearchMethod("Empowered.Reflection.Tests.ExampleClass", "MethodReturningString");

            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void ReturnNull_WhenMethodDoesNotExists()
        {
            var m = this.Assembly.SearchMethod("Empowered.Reflection.Tests.ExampleClass", "NotExistingMethod");

            Assert.IsNull(m);
        }

        [TestMethod]
        public void ReturnNull_WhenClassDoesNotExists()
        {
            var m = this.Assembly.SearchMethod("NotExisting", "Method");

            Assert.IsNull(m);
        }
    }
}
