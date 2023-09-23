using System;
using UnityEngine.Serialization;

namespace Infrastructure.Services.PersistenceProgress
{
    [Serializable]
    public class PlayerData
    {
        public ProgressData Progress = new ProgressData();
    }
}