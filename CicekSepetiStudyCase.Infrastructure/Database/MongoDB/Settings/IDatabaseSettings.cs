namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB.Settings
{
    public interface IDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
