﻿using System.Collections.Generic;

namespace Infrastructure.Services.Analytics
{
    public interface IAnalyticEvent
    {
        string Name { get; }
        IReadOnlyDictionary<string, object> Data { get; }
    }
}