namespace Infrastructure.Services.PersistenceProgress
{
    public class PersistenceProgressService : IPersistenceProgressService
    {
        public PlayerData PlayerData { get; set; }
        public AnalyticsData AnalyticsData { get; set; }
    }
}