using SimpleDddService.Infrastructure.LanguageExtensions.Maybes.Implementation;

namespace SimpleDddService.Infrastructure.LanguageExtensions.Maybes
{
    public static class MaybeFactory
    {
        public static Maybe<T> CreateSome<T>(T value) => new SomeMaybe<T>(value);
        public static Maybe<T> CreateNone<T>() => new NoneMaybe<T>();
    }
}
