using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDddService.Infrastructure.LanguageExtensions.Maybes.Implementation
{
    public class NoneMaybe<T> : Maybe<T>
    {
        public override IEnumerable<T> AsEnumerable()
        {
            return Enumerable.Empty<T>();
        }

        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as NoneMaybe<T>);
        }

        public override bool Equals(T other)
        {
            return false;
        }

        public bool Equals(NoneMaybe<T> other)
        {
            return !ReferenceEquals(null, other);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping)
        {
            return new NoneMaybe<TNew>();
        }

        public override T Reduce(Func<T> whenNone)
        {
            return whenNone();
        }

        public override T Reduce(T whenNone)
        {
            return whenNone;
        }

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone)
        {
            return whenNone();
        }
    }
}