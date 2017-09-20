using SimpleDddService.Infrastructure.DataAccess.DataMapping;
using SimpleDddService.Infrastructure.DataAccess.DataMapping.Implementation;
using SimpleDddService.Infrastructure.DataAccess.Repositories;
using SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers;
using SimpleDddService.Infrastructure.DataAccess.Repositories.Handlers.Implemention;
using SimpleDddService.Infrastructure.DataAccess.Repositories.Implementatrion;
using StructureMap;

namespace SimpleDddService.Infrastructure.Application.Initialization.Handlers
{
    public static class ContainerInitialization
    {
        public static Container CreateInitializedContainer()
        {
            var result = new Container();

            result.Configure(
                config =>
                {
                    config.Scan(
                        scan =>
                        {
                            // Fun fact: TheCallingAssembly doesn't work in AspNet Core
                            scan.AssemblyContainingType(typeof(ContainerInitialization));

                            scan.AddAllTypesOf(typeof(IRepository<>));
                            scan.AddAllTypesOf(typeof(IMongoDbFilterDefinitionFactory<>));
                            scan.AddAllTypesOf<IDataMapper>();
                            scan.WithDefaultConventions();
                        });

                    config.For<IRepositoryFactory>().Use<RepositoryFactory>().Singleton();
                    config.For<IDataMappingInitializationService>().Use<DataMappingInitializationService>().Singleton();
                    config.For<IMongoClientFactory>().Use<MongoClientFactory>().Singleton();
                });

            return result;
        }
    }
}