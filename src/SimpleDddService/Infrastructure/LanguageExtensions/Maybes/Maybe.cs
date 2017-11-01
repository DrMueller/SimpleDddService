using System;
using System.Collections.Generic;

namespace SimpleDddService.Infrastructure.LanguageExtensions.Maybes
{
    public abstract class Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public abstract IEnumerable<T> AsEnumerable();

        public abstract bool Equals(Maybe<T> other);

        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Maybe<T>)obj);
        }

        public abstract override int GetHashCode();

        public abstract Maybe<TNew> Map<TNew>(Func<T, TNew> mapping);

        public static bool operator ==(Maybe<T> a, Maybe<T> b)
        {
            return (ReferenceEquals(null, a) && ReferenceEquals(null, b)) ||
                (!ReferenceEquals(null, a) && a.Equals(b));
        }

        public static bool operator ==(Maybe<T> a, T b)
        {
            return !ReferenceEquals(null, a) && a.Equals(b);
        }

        public static bool operator !=(Maybe<T> a, Maybe<T> b)
        {
            return !(a == b);
        }

        public static bool operator !=(Maybe<T> a, T b)
        {
            return !(a == b);
        }

        public abstract T Reduce(Func<T> whenNone);

        public abstract T Reduce(T whenNone);

        public abstract TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone);
    }
}