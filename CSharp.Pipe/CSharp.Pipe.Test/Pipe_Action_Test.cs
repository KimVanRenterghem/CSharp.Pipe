using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Pipe.Test
{
    [TestClass]
    public class Pipe_Action_Test
    {
        [TestMethod]
        public void Pipe_Number_To_Func()
        {
            var res = 0;
            Action<int> Add(int een) => twee => res = een + twee;

            2.Pipe(Add(2));

            Assert.AreEqual(4,res);
        }

        [TestMethod]
        public void Pipe_Number_To_FuncAsData()
        {
            var res = 0;
            Action<int> Add(int een) => twee => res = een + twee;

            var add2 = Add(2);
            2.Pipe(add2);

            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void Pipe_FunctionREsuld_To_FuncAsData()
        {
            var res = 0;
            Action<int> Add(int een) => twee => res = een + twee;

            var add2 = Add(2);

            int a(int i, int y) => i + y;

            a(2 , 2).Pipe(add2);

            Assert.AreEqual(6, res);
        }
    }
}
