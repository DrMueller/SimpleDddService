using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;
using SimpleDddService.Infrastructure.DomainExtensions.Specifications;
using SimpleDddService.Infrastructure.LanguageExtensions.Maybes;

namespace SimpleDddService.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> spec);

        Task<T> LoadSingleAsync(ISpecification<T> spec);

        Task<T> LoadByIdAsync(string id);

        Task<T> SaveAsync(T aggregateRoot);
    }
}