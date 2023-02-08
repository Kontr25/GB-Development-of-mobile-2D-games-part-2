using UnityEngine;

namespace Units
{
    public interface IEnemy
    {
        void Update(PlayerData playerData);
    }
    internal class Enemy: IEnemy
    {
        private const int KMoneys = 5;
        private const float KPower = 1.5f;
        private const int MaxHealthPlayer = 20;
        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;
        private int _crimePlayer;
        public Enemy(string name)
        {
            name = name;
        }
        public void Update(PlayerData playerData)
        {
            switch (playerData.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = playerData.Value;
                    break;
                case DataType.Health:
                    _healthPlayer = playerData.Value;
                    break;
                case DataType.Power:
                    _powerPlayer = playerData.Value;
                    break;
                case DataType.Crime:
                    _crimePlayer = playerData.Value;
                    break;
            }
            Debug.Log($"Notified {_name} change to {playerData.DataType}");
        }

        public float CalcPower()
        {
            var kHealth = _healthPlayer > MaxHealthPlayer ? 100 : 5;
            var power = (int) (_moneyPlayer / KMoneys + kHealth + _powerPlayer / KPower + _crimePlayer * 2);
            return power;
        }
    }
}