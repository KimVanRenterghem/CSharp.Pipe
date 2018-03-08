using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Pipe.Test
{
    [TestClass]
    public class Pipe_Readable_Test
    {
        private int _val = 6;

        private int GetById(int id) => _val;
        private static Func<int, int> Add(int x) => y => x + y;

        private Action<int> Save(int id ) => val => _val = val;

        [TestInitialize]
        public void Setup()
        {
            _val = 6;
        }

        [TestMethod]
        public void NormalFlow()
        {
            const int id = 2;
            var v = GetById(id);
            v = Add(v)(2);
            Save(id)(v);

            Assert.AreEqual(6 + 2,_val);
        }

        [TestMethod]
        public void FunvtionalFlow()
        {
            const int id = 2;

            Save(id)(
                Add(
                    GetById(id)
                    )(2)
                );

            Assert.AreEqual(6 + 2, _val);
        }

        [TestMethod]
        public void Pipe_Flow()
        {
            const int id = 2;
            GetById(id)
                .Pipe(Add(2))
                .Pipe(Save(id));

            Assert.AreEqual(6 + 2, _val);
        }
    }
}
