using SimpleDddService.Infrastructure.LanguageExtensions.Maybes.Implementation;

namespace SimpleDddService.Infrastructure.LanguageExtensions.Maybes
{
    public static class MaybeFactory
    {
        public static Maybe<T> CreateFromNullable<T>(T possiblyNull)
        {
            return possiblyNull == null ? CreateNone<T>() : CreateSome(possiblyNull);
        }

        public static Maybe<T> CreateNone<T>()
        {
            return new NoneMaybe<T>();
        }

        public static Maybe<T> CreateSome<T>(T value)
        {
            return new SomeMaybe<T>(value);
        }
    }
}