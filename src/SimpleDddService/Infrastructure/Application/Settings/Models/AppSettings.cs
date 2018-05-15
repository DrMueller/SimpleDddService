namespace SimpleDddService.Infrastructure.Application.Settings.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        // TODO THE DIRTY AZURE MONEY IS GONE, FIND A FIX
        ////public MongoDbSettings MongoDbSettings { get; set; }
        public SecuritySettings SecuritySettings { get; set; }
    }
}