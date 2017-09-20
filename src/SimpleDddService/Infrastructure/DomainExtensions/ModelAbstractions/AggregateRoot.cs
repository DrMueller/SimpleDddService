using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions.Internals;

namespace SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions
{
    public abstract class AggregateRoot : ComparableIdentityProvider, IIdentityProvider
    {
        protected AggregateRoot()
        {
            AggregateTypeName = GetType().FullName;
        }

        public string AggregateTypeName { get; }
        public string Id { get; private set; }
        protected override string ComparedId => Id;
    }
}