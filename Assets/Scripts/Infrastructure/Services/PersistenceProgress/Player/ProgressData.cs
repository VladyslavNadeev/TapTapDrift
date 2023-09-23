using System;
using UnityEngine.Serialization;

namespace Infrastructure.Services.PersistenceProgress
{
    [Serializable]
    public class ProgressData
    {
        public Action DiamondsChanged;
        
        public int Diamonds;

        public void AddMoney(int value)
        {
            Diamonds += value;
            DiamondsChanged?.Invoke();
        }
        
        public void WithdrawMoney(int value)
        {
            Diamonds -= value;
            DiamondsChanged?.Invoke();
        }
    }
}