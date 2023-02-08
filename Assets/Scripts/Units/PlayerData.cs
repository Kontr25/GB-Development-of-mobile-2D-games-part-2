using System;
using System.Collections.Generic;

namespace Units
{
    public class PlayerData
    {
        public readonly DataType DataType;
        private int _value;
        
        private List<IEnemy> _enemies = new List<IEnemy>();

        public int Value
        {
            get => _value;
            set 
            {
                if (_value != value)
                {
                    _value = value;
                    Notify();
                }
            }
        }

        public PlayerData(DataType dataType) => DataType = dataType;
    
        public void Attach(IEnemy enemy) => _enemies.Add(enemy);
        
        public void Detach(IEnemy enemy) => _enemies.Remove(enemy);
        
        protected void Notify()
        {
            foreach (var investor in _enemies)
                investor.Update(this);
        }
        
    }
}