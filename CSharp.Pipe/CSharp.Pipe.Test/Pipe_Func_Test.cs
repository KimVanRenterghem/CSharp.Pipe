using System;
using FluentAssertions;
using Xunit;

namespace CSharp.Pipe.Test
{
    public class Pipe_Func_Test
    {
        [Fact]
        public void Pipe_Number_To_Func()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var res = 2.Pipe(Add(3));

            res.Should().Be(5);
        }

        [Fact]
        public void Pipe_Number_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var Add2 = Add(2);
            var res = 2.Pipe(Add2);

            res.Should().Be(4);
        }

        [Fact]
        public void Pipe_FuncAsData_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            int Add2(Func<int, int> a) => a(2);

            var add3 = Add(3);

            var res = add3.Pipe(Add2);

            res.Should().Be(5);
        }

        [Fact]
        public void Fluend_Pipe()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            int Add2(Func<int, int> a) => a(2);

            var add3 = Add(3);

            var res = add3
                .Pipe(Add2)
                .Pipe(Add(4))
                .Pipe(Add(1));

            res.Should().Be(10);
        }

        [Fact]
        public void Pipe_FunctionREsuld_To_FuncAsData()
        {
            Func<int, int> Add(int een) => twee => een + twee;

            var Add2 = Add(2);

            var res = Add2(2).Pipe(Add2);

            res.Should().Be(6);
        }
    }
}
