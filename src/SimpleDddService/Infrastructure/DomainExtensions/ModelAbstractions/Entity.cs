using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions.Handlers;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions.Internals;

namespace SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions
{
    // http://enterprisecraftsmanship.com/2014/11/08/domain-object-base-class/
    public abstract class Entity : ComparableIdentityProvider, IIdentityProvider
    {
        protected Entity()
        {
            Id = IdFactory.CreateId();
        }

        public string Id { get; private set; }
        protected override string ComparedId => Id;
    }
}