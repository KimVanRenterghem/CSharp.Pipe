using System;
using FluentAssertions;
using Xunit;

namespace CSharp.Pipe.Test
{
    public class Pipe_Readable_Test
    {
        private int _val = 6;

        private int GetById(int id) => _val;
        private static Func<int, int> Add(int x) => y => x + y;

        private Action<int> Save(int id ) => val => _val = val;
        
        public  Pipe_Readable_Test()
        {
            _val = 6;
        }

        [Fact]
        public void NormalFlow()
        {
            const int id = 2;
            var v = GetById(id);
            v = Add(v)(2);
            Save(id)(v);

            _val.Should().Be(8);
        }

        [Fact]
        public void FunvtionalFlow()
        {
            const int id = 2;

            Save(id)(
                Add(
                    GetById(id)
                    )(2)
                );

            _val.Should().Be(8);
        }

        [Fact]
        public void Pipe_Flow()
        {
            const int id = 2;
            GetById(id)
                .Pipe(Add(2))
                .Pipe(Save(id));

            _val.Should().Be(8);
        }
    }
}
