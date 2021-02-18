namespace PortalWebServer.Models.Interfaces
{
    public interface IDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}