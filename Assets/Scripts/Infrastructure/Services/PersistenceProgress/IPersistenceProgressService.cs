namespace Infrastructure.Services.PersistenceProgress
{
    public interface IPersistenceProgressService
    {
        PlayerData PlayerData { get; set; }
        AnalyticsData AnalyticsData { get; set; }
    }
}