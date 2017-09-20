namespace SimpleDddService.Infrastructure.Application.Settings.Models
{
    public class AppSettings
    {
        public const string SectionName = "AppSettings";

        public MongoDbSettings MongoDbSettings { get; set; }
    }
}
