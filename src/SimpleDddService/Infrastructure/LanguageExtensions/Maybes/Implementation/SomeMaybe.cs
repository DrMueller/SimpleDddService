using System;
using System.Collections.Generic;

namespace SimpleDddService.Infrastructure.LanguageExtensions.Maybes.Implementation
{
    public class SomeMaybe<T> : Maybe<T>
    {
        private readonly T _content;

        public SomeMaybe(T content)
        {
            _content = content;
        }

        public override IEnumerable<T> AsEnumerable()
        {
            return new[] { _content };
        }

        public override bool Equals(Maybe<T> other)
        {
            return Equals(other as SomeMaybe<T>);
        }

        public override bool Equals(T other)
        {
            return ContentEquals(other);
        }

        public bool Equals(SomeMaybe<T> other)
        {
            return !ReferenceEquals(null, other) &&
                ContentEquals(other._content);
        }

        public override TResult Evaluate<TResult>(Func<T, TResult> whenSome, Func<TResult> whenNone)
        {
            return whenSome(_content);
        }

        public override void Evaluate(Action<T> whenSome = null, Action whenNone = null)
        {
            whenSome?.Invoke(_content);
        }

        public override int GetHashCode()
        {
            return _content?.GetHashCode() ?? 0;
        }

        public override Maybe<TNew> Map<TNew>(Func<T, TNew> mapping)
        {
            return new SomeMaybe<TNew>(mapping(_content));
        }

        public override T Reduce(Func<T> whenNone)
        {
            return _content;
        }

        public override T Reduce(T whenNone)
        {
            return _content;
        }

        private bool ContentEquals(T other)
        {
            return (ReferenceEquals(null, _content) && ReferenceEquals(null, other)) ||
                (!ReferenceEquals(null, _content) && _content.Equals(other));
        }
    }
}