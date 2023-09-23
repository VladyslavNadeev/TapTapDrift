﻿using System;

namespace Infrastructure.Services.PersistenceProgress
{
    [Serializable]
    public class AnalyticsData
    {
        public User User;
        public Application Application = new Application();
        public Session CurrentSession = new Session();
        public int SessionAmount = 0;
        public long FirstLoadTimestamp;

        public AnalyticsData(string id)
        {
            User = new User(id);
        }

        public bool IsFirstSession => SessionAmount <= 1;
    }

    public class Session
    {
        public long Id;
        public float FPS;
    }
}