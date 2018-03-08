using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Pipe.Test
{
    [TestClass]
    public class Pipe_Func_Test
    {
        [TestMethod]
        public void Pipe_Number_To_Func()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var res = 2.Pipe(Add(3));

            Assert.AreEqual(2+3,res);
        }

        [TestMethod]
        public void Pipe_Number_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var Add2 = Add(2);
            var res = 2.Pipe(Add2);

            Assert.AreEqual(4, res);
        }

        [TestMethod]
        public void Pipe_FuncAsData_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            int Add2(Func<int, int> a) => a(2);

            var add3 = Add(3);

            var res = add3.Pipe(Add2);

            Assert.AreEqual(3+2, res);
        }


        [TestMethod]
        public void Fluend_Pipe()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            int Add2(Func<int, int> a) => a(2);

            var add3 = Add(3);

            var res = add3
                .Pipe(Add2)
                .Pipe(Add(4))
                .Pipe(Add(1));

            Assert.AreEqual(3+2+4+1, res);
        }
        [TestMethod]
        public void Pipe_FunctionREsuld_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var Add2 = Add(2);

            var res = Add2(2).Pipe(Add2);

            Assert.AreEqual((2+2) + 2, res);
        }
    }
}
