using System;

namespace Infrastructure.Services.PersistenceProgress
{
    [Serializable]
    public class Application
    {
        public string Version;
        public string UnityVersion;
        public string BundleID;
    }
}