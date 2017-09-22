using System;

namespace CSharp.Pipe
{
    public static class Piping
    {
        public static TOut Pipe<TIn, TOut>(this TIn i, Func<TIn, TOut> f)
            => f(i);
        public static void Pipe<TIn>(this TIn i, Action<TIn> a)
            => a(i);
    }
}
