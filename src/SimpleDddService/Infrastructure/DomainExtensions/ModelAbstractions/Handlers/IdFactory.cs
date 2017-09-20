using MongoDB.Bson;

namespace SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions.Handlers
{
    internal static class IdFactory
    {
        internal static string CreateId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}